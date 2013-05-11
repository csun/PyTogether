using System.Net;
using System.Net.Sockets;
using System.Threading;

using PyTogether.Network;

namespace PyTogether.Client
{
    class ClientConnection
    {
        public delegate void ConnectDelegate();
        public delegate void ReceiveDelegate(Message m);

        private string clientName;
        private Socket handler;

        private StreamData incomingData;

        /// <summary>
        /// Callback called after a successful connection.
        /// </summary>
        public ConnectDelegate OnConnect { get; set; }
        /// <summary>
        /// Callbcack called after a Message is received.
        /// </summary>
        public ReceiveDelegate OnReceive { get; set; }

        public ClientConnection(string clientName, ConnectDelegate OnConnect, ReceiveDelegate OnReceive)
        {
            this.clientName = clientName;
            this.OnConnect = OnConnect;
            this.OnReceive = OnReceive;
            incomingData = new StreamData();
        }

        public void BeginConnect(IPAddress address, int port)
        {
            handler = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            handler.BeginConnect(new IPEndPoint(address, port), endConnect, null);
        }
        public void BeginSend(byte[] data, StreamData.DataType type)
        {
            //Format data to be sent
            data = StreamData.FormatDataToSend(data, type);

            handler.BeginSend(data, 0, data.Length, SocketFlags.None, endSend, null);
        }

        private void endConnect(System.IAsyncResult result)
        {
            handler.Send(System.Text.Encoding.ASCII.GetBytes(clientName));
            handler.EndConnect(result);

            OnConnect();
            beginReceive();
        }

        private void beginReceive()
        {
            handler.BeginReceive(incomingData.ReceiveBuffer, 0, incomingData.ReceiveBuffer.Length,
                        SocketFlags.None, new System.AsyncCallback(endReceive), null);
        }
        private void endReceive(System.IAsyncResult result)
        {
            int bytesRead = handler.EndReceive(result);

            if (bytesRead > 0)
            {
                incomingData.AddBufferedData(bytesRead);

                if (incomingData.IsComplete())
                {
                    //Tell the owner of this connection to handle the received Message.
                    Message m = new Message(incomingData.GetFormattedData().ToArray());
                    OnReceive(m);

                    //Reset current data and get ready to receive more data
                    incomingData.Clear();
                    beginReceive();
                }
                else
                {
                    beginReceive();
                }
            }

        }

        private void endSend(System.IAsyncResult result)
        {
            handler.EndSend(result);
        }
    }
}
