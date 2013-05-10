using System.Collections.Generic;

using PyTogether.Network;

namespace PyTogether.Server
{
    abstract class ClientInfo
    {
        public List<string> SubscribedChannels { get; set; }
        public string Name { get; set; }

        public ClientInfo(string Name)
        {
            this.Name = Name;
        }
        public ClientInfo()
        {
        }

        public abstract void SendMessageToClient(Message m);
    }
}
