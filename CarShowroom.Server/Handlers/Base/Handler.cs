using System;
using System.Threading.Tasks;
using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Server.HandlerServices.Interfaces;
using Newtonsoft.Json;
using Ninject;

namespace CarShowroom.Server.Handlers.Base
{
    public class Handler<T1, T2> : IHandler
    {
        [Inject]
        public IHandlerService<T1, T2> HandlerService { get; set; }

        public async Task<DataReciever> ExecuteAction(DataTransfer transferModel)
        {
            T1 model = JsonConvert.DeserializeObject<T1>(transferModel.Object);

            DataReciever reciever = new DataReciever();

            try
            {
                var answer = await HandlerService.ExecuteAsync(model);

                reciever.RequestResult = RequestResult.Success;
                reciever.Object = JsonConvert.SerializeObject(answer);
            }
            catch (Exception e)
            {
                throw e;
            }

            return reciever;
        }
    }
}