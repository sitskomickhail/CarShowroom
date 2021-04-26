using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using CarShowroom.Entities.DatabaseModels.Context;
using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Server.Handlers.Interfaces;
using CarShowroom.Server.Helpers;
using Ninject;

namespace CarShowroom.Server.Factories
{
    public class TcpHandlerFactory
    {
        [Inject]
        public IKernel Kernel { get; set; }

        public async Task RunClientHandler(TcpClient client)
        {
            var stream = client.GetStream();
            Console.WriteLine("New client start working");
            
            while (client.Connected)
            {
                try
                {
                    DataTransfer transfer = TransferHelper.ReadStream(stream, client);

                    IHandlerExecutor handlerExecutor = Kernel.Get<IHandlerExecutor>();
                    DataReciever answer = await handlerExecutor.ExecuteAction(transfer);
                    
                    TransferHelper.WriteStream(stream, answer);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                    DataReciever resData = new DataReciever
                    {
                        Message = e.Message,
                        RequestResult = RequestResult.Error
                    };

                    TransferHelper.WriteStream(stream, resData);
                }
            }
        }
    }
}