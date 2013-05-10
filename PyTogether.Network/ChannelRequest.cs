using System.Collections.Generic;

namespace PyTogether.Network
{
    public class ChannelRequest
    {
        public const StreamData.DataType DATATYPE = StreamData.DataType.ChannelRequest;

        public enum RequestType : byte { Join, Leave, Create }
        
        public RequestType CurrentRequest { get; set; }
        public string ChannelName { get; set; }
        public string Password { get; set; }

        public ChannelRequest(string ChannelName, string Password, RequestType CurrentRequest)
        {
            this.ChannelName = ChannelName;
            this.Password = Password;
            this.CurrentRequest = CurrentRequest;
        }
        public ChannelRequest(byte[] bytes)
        {
            ConvertFromBytes(bytes);
        }

        /// <summary>
        /// Returns a list of bytes representing the ChannelRequest. Bytes are in the following order:
        /// 1 byte: CurrentRequest
        /// 4 bytes: ChannelName length, as an int.
        /// N bytes: ChannelName
        /// 4 bytes: Password lenght, as an int.
        /// N bytes: Password
        /// </summary>
        /// <returns>Returns byte[]</returns>
        public byte[] ConvertToBytes()
        {
            List<byte> byteList = new List<byte>();
            byteList.Add((byte)CurrentRequest);

            byteList.AddRange(System.BitConverter.GetBytes(ChannelName.Length));
            byteList.AddRange(System.Text.Encoding.ASCII.GetBytes(ChannelName));

            byteList.AddRange(System.BitConverter.GetBytes(Password.Length));
            byteList.AddRange(System.Text.Encoding.ASCII.GetBytes(Password));

            return byteList.ToArray();
        }
        /// <summary>
        /// Convert ChannelRequest from an array of bytes. (See format used in ConvertToBytes())
        /// </summary>
        /// <param name="bytes">Bytes to convert ChannelRequest from</param>
        public bool ConvertFromBytes(byte[] bytes)
        {
            if (!IsCorrectFormat(bytes))
                return false;
            try
            {
                CurrentRequest=(RequestType)bytes[0];

                int chanLength = System.BitConverter.ToInt32(bytes, 1);
                ChannelName = System.Text.Encoding.ASCII.GetString(bytes, 5, chanLength);

                int passLength = System.BitConverter.ToInt32(bytes, 5 + chanLength);
                Password = System.Text.Encoding.ASCII.GetString(bytes, 9 + chanLength, passLength);

                return true;
            }
            catch (System.Exception e)
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

            int passLength = System.BitConverter.ToInt32(bytes, 5 + chanLength);

            return (9 + chanLength + passLength == bytes.Length);
        }
    }
}
