using FileSerialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace FileTransfer
{
    class Client : IDisposable
    {
        private String address;
        private int port;
        private TcpClient tcpClient;
        private NetworkStream networkStream;
        private ISerialization serialization;

        public Client()
        {
            address = "127.0.0.1";
            port = 13000;
            tcpClient = new TcpClient();
            serialization = new Serialization();
        }

        public void connect()
        {
            try
            {
                tcpClient.Connect(address, port);
                networkStream = tcpClient.GetStream();
            }
            catch (SocketException e)
            {
               
            }
        }


        public void sendFile(FileSender data)
        {
            try
            {
                serialization.writeToStream(networkStream, data);
            }
            catch (SocketException ex)
            {
            }
        }


        public void Dispose()
        {
            networkStream.Close();
            tcpClient.Close();
        }
    }
}
