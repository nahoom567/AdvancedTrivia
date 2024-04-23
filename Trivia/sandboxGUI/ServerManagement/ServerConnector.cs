using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace sandboxGUI
{
    internal class ServerConnector
    {
        public ServerConnector(string serverIp = "127.0.0.1")
        {
            try
            {
                // making a connection with the server:
                m_serverIp = serverIp;
                m_client = new TcpClient();
                m_client.Connect(serverIp, m_serverPort);

                // getting the network stream so it will be easy to receive and send data:
                m_stream = m_client.GetStream();
            }
            catch
            {

            }
        }

        public void SendData(byte[] data)
        {
            m_stream.Write(data, 0, data.Length);
        }

        public Tuple<int, byte[]> reciveData()
        {
            int msgCode = m_stream.ReadByte();

            byte[] buffer = new byte[m_msgSizeBuffer];
            int bytesRead = m_stream.Read(buffer, 0, m_msgSizeBuffer);

            Array.Reverse(buffer);
            int msgLength = BitConverter.ToInt32(buffer, 0);

            byte[] msgBuffer = new byte[msgLength];
            bytesRead = m_stream.Read(msgBuffer, 0, msgLength);

            return Tuple.Create(msgCode, msgBuffer);
        }


        private TcpClient m_client; 
        private NetworkStream m_stream;
        private string m_serverIp;
        private const int m_serverPort = 7348;
        private const int m_msgSizeBuffer = 4;
    }
}
