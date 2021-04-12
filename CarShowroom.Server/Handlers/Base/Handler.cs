using System.Threading.Tasks;
using CarShowroom.Server.HandlerServices.Interfaces;
using Newtonsoft.Json;
using Ninject;

namespace CarShowroom.Server.Handlers.Base
{
    public class Handler<T1, T2> : IHandler
    {
        [Inject]
        public IHandlerService<T1, T2> HandlerService { get; set; }

        public async Task<string> ExecuteAction(string jsonModel)
        {
            T1 model = JsonConvert.DeserializeObject<T1>(jsonModel);

            var answer = await HandlerService.ExecuteAsync(model);

            return JsonConvert.SerializeObject(answer);
        }
    }
}