using System.Collections.Generic;

namespace PyTogether.Network
{
    /// <summary>
    /// Used to contain data being sent over the network. For all streamed data, the first byte of the data 
    /// details the type of data that the stream describes, which also describes the format that will be 
    /// used to process it.
    /// The next int descibes the total length of the rest of the data to be sent.
    /// </summary>
    public class StreamData
    {
        public enum DataType : byte { Unknown, Message, ChannelRequest }

        public const int DEFAULT_BUFFER_SIZE = 8192;
        public byte[] ReceiveBuffer { get; set; }

        public List<byte> CurrentData { get; set; }


        public StreamData(int bufferSize = DEFAULT_BUFFER_SIZE)
        {
            ReceiveBuffer = new byte[bufferSize];
            CurrentData = new List<byte>();
        }

        /// <summary>
        /// Adds current data in ReceiveBuffer to CurrentReceivedData
        /// </summary>
        /// <param name="bytesRead">Bytes to read from buffer</param>
        public void AddBufferedData(int bytesRead)
        {
            //Last index of currentReceivedData after buffered data is added in
            int newEnd = CurrentData.Count + bytesRead - 1;
            CurrentData.AddRange(ReceiveBuffer);
            //Trim the excess empty bytes from buffer
            CurrentData.RemoveRange(newEnd, CurrentData.Count - newEnd);
        }
        /// <summary>
        /// Returns the actual "meat" of the data: The received bytes sans length/type info
        /// </summary>
        /// <returns></returns>
        public List<byte> GetFormattedData()
        {
            return CurrentData.GetRange(5, CurrentData.Count - 5);
        }
        /// <summary>
        /// Clears current data.
        /// </summary>
        public void Clear()
        {
            CurrentData = new List<byte>();
        }

        /// <summary>
        /// Formats the given bytes to be sent over the network.
        /// </summary>
        /// <param name="data">Data to be formatted.</param>
        /// <param name="type">Type that the data represents.</param>
        /// <returns></returns>
        public static byte[] FormatDataToSend(byte[] data, DataType type)
        {
            List<byte> listBytes = new List<byte>(data);

            listBytes.InsertRange(0, System.BitConverter.GetBytes(data.Length));
            listBytes.Insert(0, (byte)type);

            return listBytes.ToArray();
        }

        /// <summary>
        /// Checks if the received data contains all the data that it was supposed to receive.
        /// </summary>
        /// <returns>Returns true if all data is accounted for.</returns>
        public bool IsComplete()
        {
            if (CurrentData.Count >= 5)
            {
                return CurrentData.Count ==
                    (5 + System.BitConverter.ToInt32(CurrentData.ToArray(), 1));
            }
            return false;
        }

        /// <summary>
        /// Checks first byte to determine what type of Data the Stream represents.
        /// </summary>
        /// <returns>Returns a DataType</returns>
        public DataType GetDataType()
        {
            if (CurrentData.Count > 0)
                return (DataType)CurrentData[0];
            return DataType.Unknown;
        }
    }
}
