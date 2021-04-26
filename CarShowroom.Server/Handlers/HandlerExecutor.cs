using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarShowroom.Entities.Models.AnswerModels.Users;
using CarShowroom.Entities.Models.AnswerModels.Vehicles;
using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels;
using CarShowroom.Entities.Models.TransferModels.Vehicles;
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

        [Inject]
        public Handler<CreateVehicleModel, VehicleAnswerModel> CreateVehicleHandler { get; set; }

        [Inject]
        public Handler<SearchVehicleModel, List<VehicleAnswerModel>> SearchVehiclesHandler { get; set; }

        [Inject]
        public Handler<GetVehicleListModel, List<VehicleAnswerModel>> GetVehiclesHandler { get; set; }

        [Inject]
        public Handler<EditVehicleModel, VehicleAnswerModel> EditVehicleHandler { get; set; }

        public async Task<DataReciever> ExecuteAction(DataTransfer dataTransfer)
        {
            DataReciever answer = new DataReciever();

            try
            {
                switch (dataTransfer.Action)
                {
                    case RequestAction.Login: answer = await LoginHandler.ExecuteAction(dataTransfer); break;
                    case RequestAction.Register: answer = await RegisterHandler.ExecuteAction(dataTransfer); break;
                    case RequestAction.CreateVehicle: answer = await CreateVehicleHandler.ExecuteAction(dataTransfer); break;
                    case RequestAction.EditVehicle: answer = await EditVehicleHandler.ExecuteAction(dataTransfer); break;
                    case RequestAction.GetVehicles: answer = await GetVehiclesHandler.ExecuteAction(dataTransfer); break;
                    case RequestAction.SearchVehicles: answer = await SearchVehiclesHandler.ExecuteAction(dataTransfer); break;
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