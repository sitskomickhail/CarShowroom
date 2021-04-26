using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using CarShowroom.TransferHandlers.Interfaces;

namespace CarShowroom.TransferHandlers
{
    public class TcpTransferHandler : ITcpTransferHandler
    {
        private TcpClient TcpClient { get; set; }

        private NetworkStream Stream { get; set; }

        public TcpTransferHandler()
        {
            TcpClient = new TcpClient();
        }

        public void CreateConnection(string ip, int port)
        {
            TcpClient.Connect(ip, port);
            Stream = TcpClient.GetStream();
        }

        public void WriteStream(string json)
        {
            byte[] data = Encoding.UTF8.GetBytes(json);
            Stream.Write(data, 0, data.Length);
        }

        public string ReadStream()
        {
            byte[] data = new byte[100000];
            int bytes = Stream.Read(data, 0, data.Length); // получаем количество считанных байтов
            string message = Encoding.UTF8.GetString(data, 0, bytes);

            return message;
        }

        public void DisposeConnection()
        {
            Stream.Close();
            TcpClient.Close();
        }
    }
}