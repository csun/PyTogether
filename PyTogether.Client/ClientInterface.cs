using PyTogether.Network;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
namespace PyTogether.Client
{
    public partial class ClientInterface : Form
    {
        private const int PORT = 1357;
        private ClientConnection connection;

        public ClientInterface()
        {
            InitializeComponent();
        }


        private void onConnect()
        {

        }
        private void onReceive(Network.Message m)
        {
            if (!messageTabs.TabPages.ContainsKey(m.ChannelName))
                addNewChannelTab(m.ChannelName);

            string displayText = messageTabs.TabPages[m.ChannelName].Controls["messagesText"].Text;
            displayText += m.Text + @"
";
            messageTabs.TabPages[m.ChannelName].Controls["messagesText"].Text = displayText;
        }

        /// <summary>
        /// Add new tab to display channel messages
        /// </summary>
        /// <param name="name">Name of the channel for the tab to represent</param>
        private void addNewChannelTab(string name)
        {
            TabPage tab = new TabPage(name);
            tab.Name = name;

            TextBox messagesText = new TextBox();
            messagesText.Multiline = true;
            messagesText.ReadOnly = true;
            messagesText.BackColor = SystemColors.ControlLightLight;
            messagesText.Dock = DockStyle.Fill;
            messagesText.Name = "messagesText";

            tab.Controls.Add(messagesText);

            messageTabs.TabPages.Add(tab);
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            IPAddress address = IPAddress.Parse(ipTextBox.Text);
            connection = new ClientConnection(usernameTextBox.Text, onConnect, onReceive);

            connection.BeginConnect(address, PORT);
        }
        private void sendButton_Click(object sender, EventArgs e)
        {
            string text = sendMessageText.Text;
            sendMessageText.Text = "";

            Network.Message m = new Network.Message(text, messageTabs.SelectedTab.Name);
            m.IsInject = injectCheckBox.CheckState.Equals(CheckState.Checked);
            connection.BeginSend(m.ConvertToBytes(), StreamData.DataType.Message);
        }

        private void joinButton_Click(object sender, EventArgs e)
        {
            string channelName = channelNameTextBox.Text;
            string pass = passwordTextBox.Text;

            ChannelRequest r = new ChannelRequest(channelName, pass, ChannelRequest.RequestType.Join);
            connection.BeginSend(r.ConvertToBytes(), StreamData.DataType.ChannelRequest);

            addNewChannelTab(channelName);

            channelNameTextBox.Text = "";
            passwordTextBox.Text = "";
        }
        private void createButton_Click(object sender, EventArgs e)
        {
            string channelName = channelNameTextBox.Text;
            string pass = passwordTextBox.Text;

            ChannelRequest r = new ChannelRequest(channelName, pass, ChannelRequest.RequestType.Create);
            connection.BeginSend(r.ConvertToBytes(), StreamData.DataType.ChannelRequest);
        }
    }
}
