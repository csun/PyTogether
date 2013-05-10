using System.Net.Sockets;
using System.Collections.Generic;

using PyTogether.Network;

namespace PyTogether.Server
{
    class RemoteClientInfo : ClientInfo
    {
        public delegate void HandleDelegate(StreamData data, ClientInfo info);


        public Socket Handler { get; set; }
        /// <summary>
        /// The method that will do something with all the data streamed in after it is complete.
        /// </summary>
        public HandleDelegate HandlingMethod { get; set; }
        /// <summary>
        /// StreamData representing currently received data
        /// </summary>
        public StreamData IncomingData { get; set; }

        public RemoteClientInfo(string Name, HandleDelegate HandlingMethod, Socket sock)
            : base(Name)
        {
            this.HandlingMethod = HandlingMethod;
            Handler = sock;
            IncomingData = new StreamData();
        }

        /// <summary>
        /// Calls Handler.BeginReceive with the proper arguments. Makes code look cleaner.
        /// </summary>
        public void BeginReceive()
        {
            Handler.BeginReceive(IncomingData.ReceiveBuffer, 0, IncomingData.ReceiveBuffer.Length,
                        SocketFlags.None, new System.AsyncCallback(endReceive), null);
        }
        public override void SendMessageToClient(Message m)
        {
            beginSend(StreamData.FormatDataToSend(m.ConvertToBytes(), Message.DATATYPE));
        }

        private void endReceive(System.IAsyncResult result)
        {
            int bytesRead = Handler.EndReceive(result);

            if (bytesRead > 0)
            {
                IncomingData.AddBufferedData(bytesRead);

                if (IncomingData.IsComplete())
                {
                    //Route the now complete Message data
                    HandlingMethod(IncomingData, this);
                    //Reset current data and get ready to receive more data
                    IncomingData.Clear();
                    BeginReceive();
                }
                else
                {
                    BeginReceive();
                }
            }
        }

        private void beginSend(byte[] data)
        {
            Handler.BeginSend(data, 0, data.Length, SocketFlags.None, endSend, null);
        }
        private void endSend(System.IAsyncResult result)
        {
            Handler.EndSend(result);
        }
    }
}
