using System.Net.Sockets;
using System.Text;
using CarShowroom.Entities.Models.DataTransfers;
using Newtonsoft.Json;

namespace CarShowroom.Server.Helpers
{
    public static class TransferHelper
    {
        public static DataTransfer ReadStream(NetworkStream stream, TcpClient client)
        {
            byte[] bytes = new byte[client.ReceiveBufferSize];
            stream.Read(bytes, 0, (int)client.ReceiveBufferSize);
            string json = Encoding.UTF8.GetString(bytes);

            var transferedData = JsonConvert.DeserializeObject<DataTransfer>(json);

            return transferedData;
        }

        public static void WriteStream(NetworkStream stream, DataReciever reciever)
        {
            byte[] sendBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(reciever));
            stream.Write(sendBytes, 0, sendBytes.Length);
        }
    }
}