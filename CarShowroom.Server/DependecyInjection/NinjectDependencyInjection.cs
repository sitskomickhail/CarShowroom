using System.Collections.Generic;
using AutoMapper;
using CarShowroom.Entities.DatabaseModels.Context;
using CarShowroom.Entities.Models.AnswerModels.Clients;
using CarShowroom.Entities.Models.AnswerModels.Maintenances;
using CarShowroom.Entities.Models.AnswerModels.Resolutions;
using CarShowroom.Entities.Models.AnswerModels.Sales;
using CarShowroom.Entities.Models.AnswerModels.Users;
using CarShowroom.Entities.Models.AnswerModels.Vehicles;
using CarShowroom.Entities.Models.TransferModels;
using CarShowroom.Entities.Models.TransferModels.Clients;
using CarShowroom.Entities.Models.TransferModels.Maintenances;
using CarShowroom.Entities.Models.TransferModels.Resolutions;
using CarShowroom.Entities.Models.TransferModels.Sales;
using CarShowroom.Entities.Models.TransferModels.Users;
using CarShowroom.Entities.Models.TransferModels.Vehicles;
using CarShowroom.Server.Factories;
using CarShowroom.Server.Handlers;
using CarShowroom.Server.Handlers.Base;
using CarShowroom.Server.Handlers.Interfaces;
using CarShowroom.Server.HandlerServices.Clients;
using CarShowroom.Server.HandlerServices.Interfaces;
using CarShowroom.Server.HandlerServices.Maintenances;
using CarShowroom.Server.HandlerServices.Resolutions;
using CarShowroom.Server.HandlerServices.Sales;
using CarShowroom.Server.HandlerServices.Users;
using CarShowroom.Server.HandlerServices.Vehicles;
using CarShowroom.Server.Profiles;
using CarShowroom.Server.Services;
using CarShowroom.Server.Services.Interfaces;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;

namespace CarShowroom.Server.DependecyInjection
{
    public class NinjectDependencyInjection : NinjectModule
    {
        public IKernel Kernel { get; set; }

        public NinjectDependencyInjection()
        {
            Kernel = new StandardKernel(new NinjectSettings() { InjectNonPublic = true });
        }

        public override void Load()
        {
            InjectMsSqlServer();
            InjectListenerService();
            InjectFactory();
            InjectHandlers();
            InjectHandlerServices();
            InjectMapper();
            InjectServices();
        }

        private void InjectMsSqlServer()
        {
            Kernel.Bind<SqlServerContext>().ToSelf().InRequestScope();
        }

        private void InjectFactory()
        {
            Kernel.Bind<TcpHandlerFactory>().ToSelf().InRequestScope();
        }

        public void InjectListenerService()
        {
            Kernel.Bind<IClientListenerService>().To<ClientListenerService>().InRequestScope();
        }

        public void InjectHandlers()
        {
            Kernel.Bind<IHandlerExecutor>().To<HandlerExecutor>().InRequestScope();

            Kernel.Bind<IHandler>().To<Handler<LoginModel, UserAnswerModel>>().InRequestScope();
            Kernel.Bind<IHandler>().To<Handler<RegisterModel, UserAnswerModel>>().InRequestScope();
            Kernel.Bind<IHandler>().To<Handler<CreateVehicleModel, VehicleAnswerModel>>().InRequestScope();
            Kernel.Bind<IHandler>().To<Handler<SearchVehicleModel, List<VehicleAnswerModel>>>().InRequestScope();
            Kernel.Bind<IHandler>().To<Handler<GetVehicleListModel, List<VehicleAnswerModel>>>().InRequestScope();
            Kernel.Bind<IHandler>().To<Handler<EditVehicleModel, VehicleAnswerModel>>().InRequestScope();
            Kernel.Bind<IHandler>().To<Handler<DeleteVehicleModel, VehicleAnswerModel>>().InRequestScope();
            Kernel.Bind<IHandler>().To<Handler<CreateUserModel, UserAnswerModel>>().InRequestScope();
            Kernel.Bind<IHandler>().To<Handler<EditUserModel, UserAnswerModel>>().InRequestScope();
            Kernel.Bind<IHandler>().To<Handler<DeleteUserModel, UserAnswerModel>>().InRequestScope();
            Kernel.Bind<IHandler>().To<Handler<GetUsersListModel, List<UserAnswerModel>>>().InRequestScope();
            Kernel.Bind<IHandler>().To<Handler<GetClientListModel, List<ClientAnswerModel>>>().InRequestScope();
            Kernel.Bind<IHandler>().To<Handler<GetClientInfoModel, ClientDealsAnswerModel>>().InRequestScope();
            Kernel.Bind<IHandler>().To<Handler<EditClientModel, ClientAnswerModel>>().InRequestScope();
            Kernel.Bind<IHandler>().To<Handler<DeleteClientModel, ClientAnswerModel>>().InRequestScope();
            Kernel.Bind<IHandler>().To<Handler<GetSalesListModel, List<SaleAnswerModel>>>().InRequestScope();
            Kernel.Bind<IHandler>().To<Handler<AcceptSaleModel, SaleAnswerModel>>().InRequestScope();
            Kernel.Bind<IHandler>().To<Handler<EditMaintenanceModel, MaintenanceAnswerModel>>().InRequestScope();
            Kernel.Bind<IHandler>().To<Handler<GetMaintenanceListModel, List<MaintenanceAnswerModel>>>().InRequestScope();
            Kernel.Bind<IHandler>().To<Handler<GetClientByUserIdModel, ClientAnswerModel>>().InRequestScope();
            Kernel.Bind<IHandler>().To<Handler<CreateSaleModel, List<SaleAnswerModel>>>().InRequestScope();
            Kernel.Bind<IHandler>().To<Handler<GetSailingVehiclesModel, List<VehicleAnswerModel>>>().InRequestScope();
            Kernel.Bind<IHandler>().To<Handler<GetClientMaintenancesModel, List<MaintenanceAnswerModel>>>().InRequestScope();
            Kernel.Bind<IHandler>().To<Handler<GetClientVehiclesModel, List<VehicleAnswerModel>>>().InRequestScope();
            Kernel.Bind<IHandler>().To<Handler<CreateMaintenanceModel, MaintenanceAnswerModel>>().InRequestScope();
            Kernel.Bind<IHandler>().To<Handler<GetMaintenanceStatisticModel, List<MaintenanceStatisticAnswerModel>>>().InRequestScope();
            Kernel.Bind<IHandler>().To<Handler<InitResolutionModel, ResolutionValuesAnswerModel>>().InRequestScope();
            Kernel.Bind<IHandler>().To<Handler<GetResolutionValuesModel, ResolutionValuesAnswerModel>>().InRequestScope();
            Kernel.Bind<IHandler>().To<Handler<GetResolutionResultModel, List<ResolutionAnswerModel>>>().InRequestScope();
        }

        public void InjectHandlerServices()
        {
            Kernel.Bind<IHandlerService<LoginModel, UserAnswerModel>>().To<LoginHandlerService>().InRequestScope();
            Kernel.Bind<IHandlerService<RegisterModel, UserAnswerModel>>().To<RegistrateHandlerService>().InRequestScope();
            Kernel.Bind<IHandlerService<CreateVehicleModel, VehicleAnswerModel>>().To<CreateVehicleHandlerService>().InRequestScope();
            Kernel.Bind<IHandlerService<SearchVehicleModel, List<VehicleAnswerModel>>>().To<SearchVehiclesHandlerService>().InRequestScope();
            Kernel.Bind<IHandlerService<GetVehicleListModel, List<VehicleAnswerModel>>>().To<GetVehiclesHandlerService>().InRequestScope();
            Kernel.Bind<IHandlerService<EditVehicleModel, VehicleAnswerModel>>().To<EditVehicleHandlerService>().InRequestScope();
            Kernel.Bind<IHandlerService<DeleteVehicleModel, VehicleAnswerModel>>().To<DeleteVehicleHandlerService>().InRequestScope();
            Kernel.Bind<IHandlerService<CreateUserModel, UserAnswerModel>>().To<CreateUserHandlerService>().InRequestScope();
            Kernel.Bind<IHandlerService<EditUserModel, UserAnswerModel>>().To<EditUserHandlerService>().InRequestScope();
            Kernel.Bind<IHandlerService<DeleteUserModel, UserAnswerModel>>().To<DeleteUserHandlerService>().InRequestScope();
            Kernel.Bind<IHandlerService<GetUsersListModel, List<UserAnswerModel>>>().To<GetUserListHandlerService>().InRequestScope();
            Kernel.Bind<IHandlerService<GetClientListModel, List<ClientAnswerModel>>>().To<GetClientListHandlerService>().InRequestScope();
            Kernel.Bind<IHandlerService<GetClientInfoModel, ClientDealsAnswerModel>>().To<GetClientDealHandlerService>().InRequestScope();
            Kernel.Bind<IHandlerService<EditClientModel, ClientAnswerModel>>().To<EditClientHandlerService>().InRequestScope();
            Kernel.Bind<IHandlerService<DeleteClientModel, ClientAnswerModel>>().To<DeleteClientHandlerService>().InRequestScope();
            Kernel.Bind<IHandlerService<AcceptSaleModel, SaleAnswerModel>>().To<AcceptSaleHandlerService>().InRequestScope();
            Kernel.Bind<IHandlerService<GetSalesListModel, List<SaleAnswerModel>>>().To<GetSaleListHandlerService>().InRequestScope();
            Kernel.Bind<IHandlerService<GetMaintenanceListModel, List<MaintenanceAnswerModel>>>().To<GetMaintenanceListHandlerService>().InRequestScope();
            Kernel.Bind<IHandlerService<EditMaintenanceModel, MaintenanceAnswerModel>>().To<EditMaintenanceHandlerService>().InRequestScope();
            Kernel.Bind<IHandlerService<GetClientByUserIdModel, ClientAnswerModel>>().To<GetClientByUserIdHandlerService>().InRequestScope();
            Kernel.Bind<IHandlerService<CreateSaleModel, List<SaleAnswerModel>>>().To<CreateSaleHandlerService>().InRequestScope();
            Kernel.Bind<IHandlerService<GetSailingVehiclesModel, List<VehicleAnswerModel>>>().To<GetSailingVehiclesHandlerService>().InRequestScope();
            Kernel.Bind<IHandlerService<GetClientVehiclesModel, List<VehicleAnswerModel>>>().To<GetClientVehiclesHandlerService>().InRequestScope();
            Kernel.Bind<IHandlerService<GetClientMaintenancesModel, List<MaintenanceAnswerModel>>>().To<GetClientMaintenancesHandlerService>().InRequestScope();
            Kernel.Bind<IHandlerService<CreateMaintenanceModel, MaintenanceAnswerModel>>().To<CreateMaintenanceHandlerService>().InRequestScope();
            Kernel.Bind<IHandlerService<GetMaintenanceStatisticModel, List<MaintenanceStatisticAnswerModel>>>().To<GetMaintenanceStatisticsHandlerService>().InRequestScope();
            Kernel.Bind<IHandlerService<InitResolutionModel, ResolutionValuesAnswerModel>>().To<SetResolutionValuesHandlerService>().InRequestScope();
            Kernel.Bind<IHandlerService<GetResolutionValuesModel, ResolutionValuesAnswerModel>>().To<GetResolutionValuesHandlerService>().InRequestScope();
        }

        private void InjectMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<VehicleProfile>();
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<SaleProfile>();
                cfg.AddProfile<MaintenanceProfile>();
                cfg.AddProfile<ClientProfile>();
                cfg.AddProfile<ResolutionProfile>();
            });

            Kernel.Bind<IMapper>().ToConstructor(c => new Mapper(mapperConfiguration)).InSingletonScope();
        }

        public void InjectServices()
        {
        }
    }
}