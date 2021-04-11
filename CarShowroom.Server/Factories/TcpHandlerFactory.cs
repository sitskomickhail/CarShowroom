using System.Net.Sockets;
using System.Threading.Tasks;
using CarShowroom.Entities.DatabaseModels.Context;
using Ninject;

namespace CarShowroom.Server.Factories
{
    public class TcpHandlerFactory
    {
        [Inject]
        public SqlServerContext Context { get; set; }

        public async Task RunClientHandler(TcpClient client)
        {
            
        }
    }
}