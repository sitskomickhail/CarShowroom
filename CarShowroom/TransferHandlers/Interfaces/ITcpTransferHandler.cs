using System.Threading.Tasks;

namespace CarShowroom.TransferHandlers.Interfaces
{
    public interface ITcpTransferHandler
    {
        void CreateConnection(string ip, int port);

        void WriteStream(string json);

        string ReadStream();

        void DisposeConnection();
    }
}