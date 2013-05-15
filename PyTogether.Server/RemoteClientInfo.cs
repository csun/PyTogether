using System.Net.Sockets;
using System.Collections.Generic;

using PyTogether.Network;

namespace PyTogether.Server
{
    class RemoteClientInfo : ClientInfo
    {
        public delegate void HandleDelegate(StreamData data, ClientInfo info);
        public delegate void KickDelegate(string name);

        public Socket Handler { get; set; }
        /// <summary>
        /// The method that will do something with all the data streamed in after it is complete.
        /// </summary>
        public HandleDelegate HandlingMethod { get; set; }
        /// <summary>
        /// Delegate of the method to be called when RemoteClientInfo wants to kick itself
        /// </summary>
        public KickDelegate KickMethod { get; set; }
        /// <summary>
        /// StreamData representing currently received data
        /// </summary>
        private StreamData incomingData;

        /// <summary>
        /// Create a new RemoteClientInfo and begin receiving data.
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="HandlingMethod"></param>
        /// <param name="sock"></param>
        public RemoteClientInfo(string Name, HandleDelegate HandlingMethod, KickDelegate KickMethod, Socket sock)
            : base(Name)
        {
            this.HandlingMethod = HandlingMethod;
            this.KickMethod = KickMethod;
            Handler = sock;
            incomingData = new StreamData();

            beginReceive();
        }

        /// <summary>
        /// Calls Handler.BeginReceive with the proper arguments. Makes code look cleaner.
        /// </summary>
        private void beginReceive()
        {
            try
            {
                Handler.BeginReceive(incomingData.ReceiveBuffer, 0, incomingData.ReceiveBuffer.Length,
                            SocketFlags.None, new System.AsyncCallback(endReceive), null);
            }
            catch
            {
                if (!checkConnectionExists())
                {
                    disconnect();
                     KickMethod(Name);
                }
            }
        }
        public override void SendMessageToClient(Message m)
        {
            try
            {
                beginSend(StreamData.FormatDataToSend(m.ConvertToBytes(), Message.DATATYPE));
            }
            catch
            {
                if (!checkConnectionExists())
                {
                    disconnect();
                     KickMethod(Name);
                }
            }
        }

        private void endReceive(System.IAsyncResult result)
        {
            try
            {
                int bytesRead = Handler.EndReceive(result);

                if (bytesRead > 0)
                {
                    incomingData.AddBufferedData(bytesRead);

                    if (incomingData.IsComplete())
                    {
                        //Route the now complete Message data
                        HandlingMethod(incomingData, this);
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
            catch
            {
                if (!checkConnectionExists())
                {
                    disconnect();
                     KickMethod(Name);
                }
            }
        }

        private void beginSend(byte[] data)
        {
            try
            {
                Handler.BeginSend(data, 0, data.Length, SocketFlags.None, endSend, null);
            }
            catch
            {
                if (!checkConnectionExists())
                {
                    disconnect();
                     KickMethod(Name);
                }
            }
        }
        private void endSend(System.IAsyncResult result)
        {
            try
            {
                Handler.EndSend(result);
            }
            catch
            {
                if (!checkConnectionExists())
                {
                    disconnect();
                    KickMethod(Name);
                }
            }
        }

        /// <summary>
        /// Checks if Socket is still connected to the client.
        /// </summary>
        /// <returns>Returns true if still connected.</returns>
        private bool checkConnectionExists()
        {
            return !(Handler.Poll(1, SelectMode.SelectRead) && Handler.Available == 0);
        }
        private void disconnect()
        {
            Handler.Shutdown(SocketShutdown.Both);
            Handler.Close();
            Handler = null;
        }
    }
}
