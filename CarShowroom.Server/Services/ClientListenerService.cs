using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using CarShowroom.Entities.DatabaseModels.Context;
using CarShowroom.Server.Factories;
using CarShowroom.Server.Services.Interfaces;
using Ninject;

namespace CarShowroom.Server.Services
{
    public class ClientListenerService : IClientListenerService
    {
        [Inject]
        public SqlServerContext Context { get; set; }

        [Inject]
        public TcpHandlerFactory TcpHandlerFactory { get; set; }

        public async Task ListenClientConnections()
        {
            try
            {
                TcpListener listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 5545);
                listener.Start();
                Console.WriteLine("Server ready for accepting new clients...");

                while (true)
                {
                    TcpClient mainClient = new TcpClient();
                    TcpHandlerFactory.RunClientHandler(mainClient).Start();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
