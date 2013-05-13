using System;
using System.Collections.Generic;
using System.IO;

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
        private const int TYPELEN = 1;
        private const int DATA_LENGTH_LEN = 4;

        public enum DataType : byte { Unknown, Message, ChannelRequest }

        public const int DEFAULT_BUFFER_SIZE = 8192;
        public byte[] ReceiveBuffer { get; set; }

        private MemoryStream currentData = new MemoryStream();


        public StreamData(int bufferSize = DEFAULT_BUFFER_SIZE)
        {
            ReceiveBuffer = new byte[bufferSize];
        }

        /// <summary>
        /// Adds current data in ReceiveBuffer to CurrentReceivedData
        /// </summary>
        /// <param name="bytesRead">Bytes to read from buffer</param>
        public void AddBufferedData(int bytesRead)
        {
            currentData.Write(ReceiveBuffer, 0, bytesRead);
        }

        /// <summary>
        /// Returns the actual "meat" of the data: The received bytes sans length/type info
        /// </summary>
        /// <returns></returns>
        public byte[] GetPayload()
        {
            const int OFF = TYPELEN + DATA_LENGTH_LEN;
            byte[] data = currentData.GetBuffer();
            byte[] ret = new byte[data.Length - OFF - 5]; // Is -5 a bug?
            Array.Copy(data, OFF, ret, 0, ret.Length);
            return ret;
        }
        
        /// <summary>
        /// Clears current data.
        /// </summary>
        public void Clear()
        {
            currentData = new MemoryStream(); // TODO: Can we replace this with currentData.SetLength(0)?
        }

        /// <summary>
        /// Formats the given bytes to be sent over the network.
        /// </summary>
        /// <param name="data">Data to be formatted.</param>
        /// <param name="type">Type that the data represents.</param>
        /// <returns></returns>
        public static byte[] FormatDataToSend(byte[] data, DataType type)
        {
            byte[] listBytes = new byte[TYPELEN + DATA_LENGTH_LEN + data.Length];

            listBytes[0] = (byte)type;
            Array.Copy(BitConverter.GetBytes(data.Length), 0, listBytes, TYPELEN, DATA_LENGTH_LEN);
            Array.Copy(data, 0, listBytes, TYPELEN + DATA_LENGTH_LEN, data.Length);

            return listBytes;
        }

        /// <summary>
        /// Checks if the received data contains all the data that it was supposed to receive.
        /// </summary>
        /// <returns>Returns true if all data is accounted for.</returns>
        public bool IsComplete()
        {
            if (currentData.Length >= TYPELEN + DATA_LENGTH_LEN)
            {
                return currentData.Length ==
                    (TYPELEN + DATA_LENGTH_LEN + BitConverter.ToInt32(currentData.GetBuffer(), 1));
            }
            return false;
        }

        /// <summary>
        /// Checks first byte to determine what type of Data the Stream represents.
        /// </summary>
        /// <returns>Returns a DataType</returns>
        public DataType GetDataType()
        {
            if (currentData.Length > 0)
            {
                foreach (DataType dataType in Enum.GetValues(typeof(DataType)))
                {
                    if (currentData.GetBuffer()[0] == (byte)dataType)
                    {
                        return dataType;
                    }
                }
            }
            return DataType.Unknown;
        }
    }
}
