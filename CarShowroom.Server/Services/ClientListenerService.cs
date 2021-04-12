using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using CarShowroom.Server.Factories;
using CarShowroom.Server.Services.Interfaces;
using Ninject;

namespace CarShowroom.Server.Services
{
    public class ClientListenerService : IClientListenerService
    {
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
                    TcpClient mainClient = listener.AcceptTcpClient();
                    TcpHandlerFactory.RunClientHandler(mainClient);
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