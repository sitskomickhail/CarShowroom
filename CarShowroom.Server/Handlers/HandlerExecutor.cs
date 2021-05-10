using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarShowroom.Entities.Models.AnswerModels.Clients;
using CarShowroom.Entities.Models.AnswerModels.Maintenances;
using CarShowroom.Entities.Models.AnswerModels.Resolutions;
using CarShowroom.Entities.Models.AnswerModels.Sales;
using CarShowroom.Entities.Models.AnswerModels.Users;
using CarShowroom.Entities.Models.AnswerModels.Vehicles;
using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels;
using CarShowroom.Entities.Models.TransferModels.Clients;
using CarShowroom.Entities.Models.TransferModels.Maintenances;
using CarShowroom.Entities.Models.TransferModels.Resolutions;
using CarShowroom.Entities.Models.TransferModels.Sales;
using CarShowroom.Entities.Models.TransferModels.Users;
using CarShowroom.Entities.Models.TransferModels.Vehicles;
using CarShowroom.Server.Handlers.Base;
using CarShowroom.Server.Handlers.Interfaces;
using Ninject;

namespace CarShowroom.Server.Handlers
{
    public class HandlerExecutor : IHandlerExecutor
    {
        [Inject] public Handler<LoginModel, UserAnswerModel> LoginHandler { get; set; }

        [Inject] public Handler<RegisterModel, UserAnswerModel> RegisterHandler { get; set; }

        [Inject] public Handler<CreateVehicleModel, VehicleAnswerModel> CreateVehicleHandler { get; set; }

        [Inject] public Handler<SearchVehicleModel, List<VehicleAnswerModel>> SearchVehiclesHandler { get; set; }

        [Inject] public Handler<GetVehicleListModel, List<VehicleAnswerModel>> GetVehiclesHandler { get; set; }

        [Inject] public Handler<EditVehicleModel, VehicleAnswerModel> EditVehicleHandler { get; set; }

        [Inject] public Handler<DeleteVehicleModel, VehicleAnswerModel> DeleteVehicleHandler { get; set; }

        [Inject] public Handler<CreateUserModel, UserAnswerModel> CreateUserHandler { get; set; }

        [Inject] public Handler<EditUserModel, UserAnswerModel> EditUserHandler { get; set; }

        [Inject] public Handler<DeleteUserModel, UserAnswerModel> DeleteUserHandler { get; set; }

        [Inject] public Handler<GetUsersListModel, List<UserAnswerModel>> GetUserListHandler { get; set; }

        [Inject] public Handler<GetClientListModel, List<ClientAnswerModel>> GetClientListHandler { get; set; }

        [Inject] public Handler<GetClientInfoModel, ClientDealsAnswerModel> GetClientDealHandler { get; set; }

        [Inject] public Handler<EditClientModel, ClientAnswerModel> EditClientHandler { get; set; }

        [Inject] public Handler<DeleteClientModel, ClientAnswerModel> DeleteClientHandler { get; set; }

        [Inject] public Handler<GetSalesListModel, List<SaleAnswerModel>> GetSaleListHandler { get; set; }

        [Inject] public Handler<AcceptSaleModel, SaleAnswerModel> AcceptSaleHandler { get; set; }
        
        [Inject] public Handler<EditMaintenanceModel, MaintenanceAnswerModel> EditMaintenanceHandler { get; set; }
        
        [Inject] public Handler<GetMaintenanceListModel, List<MaintenanceAnswerModel>> GetMaintenanceListHandler { get; set; }
        
        [Inject] public Handler<GetClientByUserIdModel, ClientAnswerModel> GetClientByUserIdHandler { get; set; }
        
        [Inject] public Handler<CreateSaleModel, List<SaleAnswerModel>> CreateSaleHandler { get; set; }
        
        [Inject] public Handler<GetSailingVehiclesModel, List<VehicleAnswerModel>> GetSailingVehiclesHandler { get; set; }
        
        [Inject] public Handler<GetClientMaintenancesModel, List<MaintenanceAnswerModel>> GetClientMaintenancesHandler { get; set; }
        
        [Inject] public Handler<GetClientVehiclesModel, List<VehicleAnswerModel>> GetClientVehiclesHandler { get; set; }
        
        [Inject] public Handler<CreateMaintenanceModel, MaintenanceAnswerModel> CreateMaintenanceHandler { get; set; }
        
        [Inject] public Handler<GetMaintenanceStatisticModel, List<MaintenanceStatisticAnswerModel>> GetMaintenanceStatisticsHandler { get; set; }
        
        [Inject] public Handler<InitResolutionModel, ResolutionValuesAnswerModel> SetResolutionValuesHandler { get; set; }

        [Inject] public Handler<GetResolutionValuesModel, ResolutionValuesAnswerModel> GetResolutionValuesHandler { get; set; }
       
        [Inject] public Handler<GetResolutionResultModel, List<ResolutionAnswerModel>> GetResolutionResultHandler { get; set; }

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
                    case RequestAction.DeleteVehicle: answer = await DeleteVehicleHandler.ExecuteAction(dataTransfer); break;
                    case RequestAction.GetUsers: answer = await GetUserListHandler.ExecuteAction(dataTransfer); break;
                    case RequestAction.CreateUser: answer = await CreateUserHandler.ExecuteAction(dataTransfer); break;
                    case RequestAction.DeleteUser: answer = await DeleteUserHandler.ExecuteAction(dataTransfer); break;
                    case RequestAction.EditUser: answer = await EditUserHandler.ExecuteAction(dataTransfer); break;
                    case RequestAction.GetClients: answer = await GetClientListHandler.ExecuteAction(dataTransfer); break;
                    case RequestAction.GetClientDeals: answer = await GetClientDealHandler.ExecuteAction(dataTransfer); break;
                    case RequestAction.EditClient: answer = await EditClientHandler.ExecuteAction(dataTransfer); break;
                    case RequestAction.DeleteClient: answer = await DeleteClientHandler.ExecuteAction(dataTransfer); break;
                    case RequestAction.AcceptSale: answer = await AcceptSaleHandler.ExecuteAction(dataTransfer); break;
                    case RequestAction.GetSales: answer = await GetSaleListHandler.ExecuteAction(dataTransfer); break;
                    case RequestAction.EditMaintenace: answer = await EditMaintenanceHandler.ExecuteAction(dataTransfer); break;
                    case RequestAction.GetMaintenances: answer = await GetMaintenanceListHandler.ExecuteAction(dataTransfer); break;
                    case RequestAction.GetClientByUserId: answer = await GetClientByUserIdHandler.ExecuteAction(dataTransfer); break;
                    case RequestAction.CreateSale: answer = await CreateSaleHandler.ExecuteAction(dataTransfer); break;
                    case RequestAction.GetSailingVehicles: answer = await GetSailingVehiclesHandler.ExecuteAction(dataTransfer); break;
                    case RequestAction.GetClientMaintenances: answer = await GetClientMaintenancesHandler.ExecuteAction(dataTransfer); break;
                    case RequestAction.GetMaintenanceStatistic: answer = await GetMaintenanceStatisticsHandler.ExecuteAction(dataTransfer); break;
                    case RequestAction.GetClientVehicles: answer = await GetClientVehiclesHandler.ExecuteAction(dataTransfer); break;
                    case RequestAction.CreateMaintenance: answer = await CreateMaintenanceHandler.ExecuteAction(dataTransfer); break;
                    case RequestAction.SetResolutionValues: answer = await SetResolutionValuesHandler.ExecuteAction(dataTransfer); break;
                    case RequestAction.GetResolutionValues: answer = await GetResolutionValuesHandler.ExecuteAction(dataTransfer); break;
                    case RequestAction.GetResolutionResult: answer = await GetResolutionResultHandler.ExecuteAction(dataTransfer); break;
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