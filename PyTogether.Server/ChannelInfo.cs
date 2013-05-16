using System.Collections.ObjectModel;
using IronPython.Hosting;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

using System.Collections.Generic;

using PyTogether.Network;

namespace PyTogether.Server
{
    class ChannelInfo
    {

        //--------Fields--------//
        public string Name { get; set; }
        public string Password { get; set; }

        private ScriptEngine engine;
        /// <summary>
        /// Each channel has a scope within which "utility" functions can be called
        /// </summary>
        private ScriptScope scope;

        private Dictionary<string, ClientInfo> clients;

        //--------Methods--------//
        public ChannelInfo(string Name, ScriptEngine engine, ScriptScope utilitiesScope, string Password = "")
        {
            this.Name = Name;
            this.Password = Password;
            this.engine = engine;
            this.scope = utilitiesScope;

            clients = new Dictionary<string, ClientInfo>();
        }

        /// <summary>
        /// Directly injects a line of code in channel's scope
        /// </summary>
        /// <param name="code">Code to inject</param>
        public void Inject(string code)
        {
            try
            {
                engine.Execute(code, scope);
            }
            catch
            {
            }
        }
        public void SendToAll(Message m)
        {
            findAndEvaluate(ref m);
            foreach (ClientInfo c in clients.Values)
                c.SendMessageToClient(m);
        }

        public void AddClient(ClientInfo cl, string pass)
        {
            if (pass == Password)
                clients.Add(cl.Name, cl);
        }
        public bool KickClient(string name)
        {
            return clients.Remove(name);
        }

        /// <summary>
        /// Finds and evaluates any code escape sequences in the given Message.
        /// </summary>
        /// <param name="m">Message to check</param>
        private void findAndEvaluate(ref Message m)
        {
            string text = m.Text;

            int startIndex = text.IndexOf(Message.CODE_ESCAPE);
            while (startIndex != -1)
            {
                int endIndex = text.IndexOf(Message.CODE_UNESCAPE);

                string code = text.Substring
                    ((startIndex + Message.CODE_ESCAPE.Length), (endIndex - (startIndex + Message.CODE_ESCAPE.Length)));

                //Try to resolve the code within the escape sequence
                bool resolved = true;
                string result = "";
                try
                {
                    result = engine.Execute<string>(code, scope);
                }
                catch
                {
                    resolved = false;
                }

                text = text.Remove(startIndex, (endIndex - startIndex) + Message.CODE_UNESCAPE.Length);
                if (resolved)
                {
                    text = text.Insert(startIndex, result);
                }
                else
                {
                    text = text.Insert(startIndex, "ERROR");
                }
                m.Text = text;
                startIndex = text.IndexOf(Message.CODE_ESCAPE);
            }
        }

    }
}
