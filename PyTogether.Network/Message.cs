using System.Collections.Generic;

namespace PyTogether.Network
{
    /// <summary>
    /// A simple transmission that contains text and Channel info. Sender info is added by server. If
    /// the message is specified as an "Inject," the text is instead interpreted as code that is directly
    /// injected within the given channel's scope.
    /// </summary>
    public class Message
    {
        public const StreamData.DataType DATATYPE = StreamData.DataType.Message;

        /// <summary>
        /// Escape sequence used to denote that the user wants code evaluatedfor a string result
        /// </summary>
        public const string CODE_ESCAPE = @"/*";
        public const string CODE_UNESCAPE = @"*/";

        public bool IsInject { get; set; }
        public string Text { get; set; }
        public string ChannelName { get; set; }

        public Message(string Text, string ChannelName)
        {
            this.Text = Text;
            this.ChannelName = ChannelName;
        }
        public Message(byte[] bytes)
        {
            ConvertFromBytes(bytes);
        }

        /// <summary>
        /// Adds "sender: " to the message text
        /// </summary>
        /// <param name="sender">Sender's name</param>
        public void AddSenderPrefix(string sender)
        {
            Text = sender + ": " + Text;
        }

        /// <summary>
        /// Returns a list of bytes representing the message. Bytes are in the following order:
        /// 1 byte: IsInject
        /// 4 bytes: ChannelName length, as an int.
        /// N bytes: ChannelName
        /// 4 bytes: Text lenght, as an int.
        /// N bytes: Text
        /// </summary>
        /// <returns>Returns byte[]</returns>
        public byte[] ConvertToBytes()
        {
            List<byte> byteList = new List<byte>();
            byteList.AddRange(System.BitConverter.GetBytes(IsInject));

            byteList.AddRange(System.BitConverter.GetBytes(ChannelName.Length));
            byteList.AddRange(System.Text.Encoding.ASCII.GetBytes(ChannelName));

            byteList.AddRange(System.BitConverter.GetBytes(Text.Length));
            byteList.AddRange(System.Text.Encoding.ASCII.GetBytes(Text));

            return byteList.ToArray();
        }
        /// <summary>
        /// Convert Message from an array of bytes. (See format used in ConvertToBytes())
        /// </summary>
        /// <param name="bytes">Bytes to convert Message from</param>
        public bool ConvertFromBytes(byte[] bytes)
        {
            if (!IsCorrectFormat(bytes))
                return false;
            try
            {
                IsInject = System.BitConverter.ToBoolean(bytes, 0);

                int chanLength = System.BitConverter.ToInt32(bytes, 1);
                ChannelName = System.Text.Encoding.ASCII.GetString(bytes, 5, chanLength);

                int textLength = System.BitConverter.ToInt32(bytes, 5 + chanLength);
                Text = System.Text.Encoding.ASCII.GetString(bytes, 9 + chanLength, textLength);

                return true;
            }
            catch
            {
                throw new System.ArgumentOutOfRangeException("Improper format of bytes");
            }
        }

        /// <summary>
        /// Checks if given array of bytes is correct length for Message serialization (See Serialize() for
        /// format)
        /// </summary>
        /// <param name="bytes">Byte array to check</param>
        /// <returns>Returns true if correct format</returns>
        public static bool IsCorrectFormat(byte[] bytes)
        {
            if (bytes.Length < 9)
                return false;

            int chanLength = System.BitConverter.ToInt32(bytes, 1);
            if (9 + chanLength > bytes.Length)
                return false;

            int textLength = System.BitConverter.ToInt32(bytes, 5 + chanLength);

            return (9 + chanLength + textLength == bytes.Length);
        }

    }
}
