using System;
using System.Threading.Tasks;
using CarShowroom.Server.DependecyInjection;
using CarShowroom.Server.Services.Interfaces;
using Ninject;

namespace CarShowroom.Server
{
    class Program
    {
        static async Task Main(string[] args)
        {
            NinjectDependencyInjection ninjectDI = new NinjectDependencyInjection();
            ninjectDI.Load();

            var clientListener = ninjectDI.Kernel.Get<IClientListenerService>();

            try
            {
                await clientListener.ListenClientConnections();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception was thrown");
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("End of program");
            }
        }
    }
}