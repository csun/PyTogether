namespace PyTogether.Client
{
    partial class ClientInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.messageTabs = new System.Windows.Forms.TabControl();
            this.Lobby = new System.Windows.Forms.TabPage();
            this.messagesText = new System.Windows.Forms.TextBox();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.ipLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.sendMessageText = new System.Windows.Forms.TextBox();
            this.injectCheckBox = new System.Windows.Forms.CheckBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.channelNameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.joinButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.channelNameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.messageTabs.SuspendLayout();
            this.Lobby.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(10, 10);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(352, 191);
            this.splitContainer1.SplitterDistance = 129;
            this.splitContainer1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(10, 10);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(332, 109);
            this.textBox1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.button2);
            this.splitContainer2.Size = new System.Drawing.Size(352, 58);
            this.splitContainer2.SplitterDistance = 166;
            this.splitContainer2.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 58);
            this.button1.TabIndex = 0;
            this.button1.Text = "Send Message";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(182, 58);
            this.button2.TabIndex = 0;
            this.button2.Text = "Inject Code";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // messageTabs
            // 
            this.messageTabs.Controls.Add(this.Lobby);
            this.messageTabs.Location = new System.Drawing.Point(12, 16);
            this.messageTabs.Name = "messageTabs";
            this.messageTabs.SelectedIndex = 0;
            this.messageTabs.Size = new System.Drawing.Size(503, 380);
            this.messageTabs.TabIndex = 0;
            // 
            // Lobby
            // 
            this.Lobby.Controls.Add(this.messagesText);
            this.Lobby.Location = new System.Drawing.Point(4, 22);
            this.Lobby.Name = "Lobby";
            this.Lobby.Size = new System.Drawing.Size(495, 354);
            this.Lobby.TabIndex = 0;
            this.Lobby.Text = "Lobby";
            this.Lobby.UseVisualStyleBackColor = true;
            // 
            // messagesText
            // 
            this.messagesText.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.messagesText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messagesText.Location = new System.Drawing.Point(0, 0);
            this.messagesText.Multiline = true;
            this.messagesText.Name = "messagesText";
            this.messagesText.ReadOnly = true;
            this.messagesText.Size = new System.Drawing.Size(495, 354);
            this.messagesText.TabIndex = 0;
            // 
            // ipTextBox
            // 
            this.ipTextBox.Location = new System.Drawing.Point(55, 591);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(133, 20);
            this.ipTextBox.TabIndex = 2;
            this.ipTextBox.Text = "127.0.0.1";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(264, 591);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(133, 20);
            this.usernameTextBox.TabIndex = 3;
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Location = new System.Drawing.Point(32, 594);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(17, 13);
            this.ipLabel.TabIndex = 4;
            this.ipLabel.Text = "IP";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(203, 594);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(55, 13);
            this.usernameLabel.TabIndex = 5;
            this.usernameLabel.Text = "Username";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(420, 588);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 6;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // sendMessageText
            // 
            this.sendMessageText.AcceptsTab = true;
            this.sendMessageText.Location = new System.Drawing.Point(26, 419);
            this.sendMessageText.Multiline = true;
            this.sendMessageText.Name = "sendMessageText";
            this.sendMessageText.Size = new System.Drawing.Size(308, 126);
            this.sendMessageText.TabIndex = 7;
            // 
            // injectCheckBox
            // 
            this.injectCheckBox.AutoSize = true;
            this.injectCheckBox.Location = new System.Drawing.Point(35, 551);
            this.injectCheckBox.Name = "injectCheckBox";
            this.injectCheckBox.Size = new System.Drawing.Size(80, 17);
            this.injectCheckBox.TabIndex = 8;
            this.injectCheckBox.Text = "Inject Code";
            this.injectCheckBox.UseVisualStyleBackColor = true;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(121, 551);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 9;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // channelNameTextBox
            // 
            this.channelNameTextBox.Location = new System.Drawing.Point(382, 445);
            this.channelNameTextBox.Name = "channelNameTextBox";
            this.channelNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.channelNameTextBox.TabIndex = 10;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(382, 486);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(100, 20);
            this.passwordTextBox.TabIndex = 11;
            // 
            // joinButton
            // 
            this.joinButton.Location = new System.Drawing.Point(359, 512);
            this.joinButton.Name = "joinButton";
            this.joinButton.Size = new System.Drawing.Size(75, 23);
            this.joinButton.TabIndex = 12;
            this.joinButton.Text = "Join";
            this.joinButton.UseVisualStyleBackColor = true;
            this.joinButton.Click += new System.EventHandler(this.joinButton_Click);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(440, 512);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 13;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // channelNameLabel
            // 
            this.channelNameLabel.AutoSize = true;
            this.channelNameLabel.Location = new System.Drawing.Point(379, 429);
            this.channelNameLabel.Name = "channelNameLabel";
            this.channelNameLabel.Size = new System.Drawing.Size(77, 13);
            this.channelNameLabel.TabIndex = 14;
            this.channelNameLabel.Text = "Channel Name";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(379, 470);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 15;
            this.passwordLabel.Text = "Password";
            // 
            // ClientInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 623);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.channelNameLabel);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.joinButton);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.channelNameTextBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.injectCheckBox);
            this.Controls.Add(this.sendMessageText);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.ipLabel);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.ipTextBox);
            this.Controls.Add(this.messageTabs);
            this.Name = "ClientInterface";
            this.Text = "PyTogether";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.messageTabs.ResumeLayout(false);
            this.Lobby.ResumeLayout(false);
            this.Lobby.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl messageTabs;
        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.TextBox sendMessageText;
        private System.Windows.Forms.CheckBox injectCheckBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox channelNameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button joinButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Label channelNameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TabPage Lobby;
        private System.Windows.Forms.TextBox messagesText;

    }
}