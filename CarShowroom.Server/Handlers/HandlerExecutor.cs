using System;
using System.Threading.Tasks;
using CarShowroom.Entities.Models.AnswerModels.Users;
using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels;
using CarShowroom.Server.Handlers.Base;
using CarShowroom.Server.Handlers.Interfaces;
using Ninject;

namespace CarShowroom.Server.Handlers
{
    public class HandlerExecutor : IHandlerExecutor
    {
        [Inject]
        public Handler<LoginModel, UserAnswerModel> LoginHandler { get; set; }

        [Inject]
        public Handler<RegisterModel, UserAnswerModel> RegisterHandler { get; set; }

        public async Task<DataReciever> ExecuteAction(DataTransfer dataTransfer)
        {
            DataReciever answer = new DataReciever();

            try
            {
                switch (dataTransfer.Action)
                {
                    case RequestAction.Login: answer = await LoginHandler.ExecuteAction(dataTransfer); break;
                    case RequestAction.Logout: break;
                    case RequestAction.Register: answer = await RegisterHandler.ExecuteAction(dataTransfer); break;
                    default: throw new Exception("Action type was not found");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in HandlerExecutor was thrown");
                Console.WriteLine($"Operation {dataTransfer.Action} was called");
                Console.WriteLine($"Exception message: {e.Message}");

                answer.RequestResult = RequestResult.Error;
                answer.Message = e.Message;
            }

            return answer;
        }
    }
}