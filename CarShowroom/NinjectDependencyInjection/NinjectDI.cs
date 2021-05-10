using CarShowroom.Controls.Administration;
using CarShowroom.Controls.Administration.Vehicles;
using CarShowroom.Handlers.Interfaces.Login;
using CarShowroom.Handlers.Interfaces.Vehicles;
using CarShowroom.Handlers.Login;
using CarShowroom.Handlers.Vehicles;
using CarShowroom.TransferHandlers;
using CarShowroom.TransferHandlers.Interfaces;
using CarShowroom.View;
using CarShowroom.ViewModel;
using CarShowroom.ViewModel.Administration.Vehicles;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using AutoMapper;
using CarShowroom.Controls.Administration.Clients;
using CarShowroom.Controls.Administration.Maintenances;
using CarShowroom.Controls.Administration.Sales;
using CarShowroom.Controls.Administration.Users;
using CarShowroom.Controls.Client;
using CarShowroom.Controls.Employee;
using CarShowroom.Controls.Employee.Clients;
using CarShowroom.Controls.Employee.Maintenances;
using CarShowroom.Controls.Employee.Resolutions;
using CarShowroom.Controls.Employee.Sales;
using CarShowroom.Controls.Employee.Vehicles;
using CarShowroom.Handlers;
using CarShowroom.Handlers.Clients;
using CarShowroom.Handlers.Interfaces.Clients;
using CarShowroom.Handlers.Interfaces.Maintenances;
using CarShowroom.Handlers.Interfaces.Resolutions;
using CarShowroom.Handlers.Interfaces.Sales;
using CarShowroom.Handlers.Interfaces.Users;
using CarShowroom.Handlers.Maintenances;
using CarShowroom.Handlers.Resolutions;
using CarShowroom.Handlers.Sales;
using CarShowroom.Handlers.Users;
using CarShowroom.Profiles;
using CarShowroom.Services;
using CarShowroom.Services.Interfaces;
using CarShowroom.ViewModel.Administration.Clients;
using CarShowroom.ViewModel.Administration.Maintenances;
using CarShowroom.ViewModel.Administration.Sales;
using CarShowroom.ViewModel.Administration.Users;
using CarShowroom.ViewModel.Client;
using CarShowroom.ViewModel.Employee.Resolutions;

namespace CarShowroom.NinjectDependencyInjection
{
    public class NinjectDI : NinjectModule
    {
        public IKernel Kernel { get; set; }

        public NinjectDI()
        {
            Kernel = new StandardKernel(new NinjectSettings { InjectNonPublic = false });
        }

        public override void Load()
        {
            InjectMapper();
            InjectViewModels();
            InjectControls();
            InjectWindows();
            InjectTcpHandler();
            InjectHandlers();
            InjectServices();
        }

        private void InjectServices()
        {
            Kernel.Bind<IPdfService>().To<PdfService>().InRequestScope();
        }

        private void InjectMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<VehicleProfile>();
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<ClientProfile>();
                cfg.AddProfile<SaleProfile>();
                cfg.AddProfile<MaintenanceProfile>();
            });

            Kernel.Bind<IMapper>().ToConstructor(c => new Mapper(mapperConfiguration)).InSingletonScope();
        }

        private void InjectWindows()
        {
            Kernel.Bind<LoginWindow>().ToSelf().InSingletonScope();
            Kernel.Bind<AdministrationWindow>().ToSelf().InSingletonScope();
            Kernel.Bind<EmployeeWindow>().ToSelf().InSingletonScope();
            Kernel.Bind<RegisterWindow>().ToSelf().InSingletonScope();
            Kernel.Bind<ClientWindow>().ToSelf().InSingletonScope();
        }

        private void InjectControls()
        {
            Kernel.Bind<AdministrationBaseControl>().ToSelf().InSingletonScope();

            Kernel.Bind<VehicleListControl>().ToSelf().InSingletonScope();
            Kernel.Bind<VehicleCreateControl>().ToSelf().InSingletonScope();
            Kernel.Bind<VehicleListEditControl>().ToSelf().InSingletonScope();

            Kernel.Bind<UserCreateControl>().ToSelf().InSingletonScope();
            Kernel.Bind<UserEditControl>().ToSelf().InSingletonScope();
            Kernel.Bind<UserListControl>().ToSelf().InSingletonScope();

            Kernel.Bind<ClientEditControl>().ToSelf().InSingletonScope();
            Kernel.Bind<ClientListControl>().ToSelf().InSingletonScope();

            Kernel.Bind<SaleListControl>().ToSelf().InSingletonScope();
            Kernel.Bind<AcceptSalesControl>().ToSelf().InSingletonScope();

            Kernel.Bind<MaintenanceEditControl>().ToSelf().InSingletonScope();
            Kernel.Bind<MaintenanceListControl>().ToSelf().InSingletonScope();

            Kernel.Bind<ClientInformationControl>().ToSelf().InSingletonScope();
            Kernel.Bind<MarketplaceControl>().ToSelf().InSingletonScope();
            Kernel.Bind<MaintenanceControl>().ToSelf().InSingletonScope();

            Kernel.Bind<VehicleEditListEmployeeControl>().ToSelf().InSingletonScope();
            Kernel.Bind<VehicleCreateEmployeeControl>().ToSelf().InSingletonScope();
            Kernel.Bind<AcceptSaleEmployeeControl>().ToSelf().InSingletonScope();
            Kernel.Bind<SaleListEmployeeControl>().ToSelf().InSingletonScope();
            Kernel.Bind<ClientListEmployeeControl>().ToSelf().InSingletonScope();
            Kernel.Bind<MaintenanceEditEmployeeControl>().ToSelf().InSingletonScope();

            Kernel.Bind<InitializeResolutionControl>().ToSelf().InSingletonScope();
            Kernel.Bind<ResolutionChartControl>().ToSelf().InSingletonScope();
        }

        private void InjectViewModels()
        {
            Kernel.Bind<AdministartorWindowViewModel>().ToSelf().InSingletonScope();
            Kernel.Bind<LoginWindowViewModel>().ToSelf().InSingletonScope();
            Kernel.Bind<EmployeeWindowViewModel>().ToSelf().InSingletonScope();
            Kernel.Bind<RegisterWindowViewModel>().ToSelf().InSingletonScope();
            Kernel.Bind<ClientWindowViewModel>().ToSelf().InSingletonScope();

            Kernel.Bind<VehiclesListViewModel>().ToSelf().InSingletonScope();
            Kernel.Bind<VehicleEditListViewModel>().ToSelf().InSingletonScope();
            Kernel.Bind<VehicleCreateViewModel>().ToSelf().InSingletonScope();

            Kernel.Bind<UserListViewModel>().ToSelf().InSingletonScope();
            Kernel.Bind<UserEditViewModel>().ToSelf().InSingletonScope();
            Kernel.Bind<UserCreateViewModel>().ToSelf().InSingletonScope();

            Kernel.Bind<ClientEditViewModel>().ToSelf().InSingletonScope();
            Kernel.Bind<ClientListViewModel>().ToSelf().InSingletonScope();

            Kernel.Bind<SaleListViewModel>().ToSelf().InSingletonScope();
            Kernel.Bind<AcceptSalesViewModel>().ToSelf().InSingletonScope();

            Kernel.Bind<MaintenanceListViewModel>().ToSelf().InSingletonScope();
            Kernel.Bind<MaintenanceEditViewModel>().ToSelf().InSingletonScope();

            Kernel.Bind<InformationControlViewModel>().ToSelf().InSingletonScope();
            Kernel.Bind<MarketplaceViewModel>().ToSelf().InSingletonScope();
            Kernel.Bind<ClientMaintenanceViewModel>().ToSelf().InSingletonScope();

            Kernel.Bind<InitializeResolutionViewModel>().ToSelf().InSingletonScope();
            Kernel.Bind<ResolutionChartViewModel>().ToSelf().InSingletonScope();
        }

        private void InjectTcpHandler()
        {
            Kernel.Bind<ITcpTransferHandler>().To<TcpTransferHandler>().InSingletonScope();
            Kernel.Bind<BaseClientHandler>().ToSelf().InRequestScope();
        }

        private void InjectHandlers()
        {
            Kernel.Bind<IRegisterHandler>().To<RegisterHandler>().InRequestScope();
            Kernel.Bind<ILoginHandler>().To<LoginHandler>().InRequestScope();
            Kernel.Bind<ICreateVehicleHandler>().To<CreateVehicleHandler>().InRequestScope();
            Kernel.Bind<IEditVehicleHandler>().To<EditVehicleHandler>().InRequestScope();
            Kernel.Bind<IGetVehicleListHandler>().To<GetVehicleListHandler>().InRequestScope();
            Kernel.Bind<ISearchVehiclesHandler>().To<SearchVehiclesHandler>().InRequestScope();
            Kernel.Bind<IDeleteVehicleHandler>().To<DeleteVehicleHandler>().InRequestScope();
            Kernel.Bind<ICreateUserHandler>().To<CreateUserHandler>().InRequestScope();
            Kernel.Bind<IGetUserListHandler>().To<GetUserListHandler>().InRequestScope();
            Kernel.Bind<IDeleteUserHandler>().To<DeleteUserHandler>().InRequestScope();
            Kernel.Bind<IEditUserHandler>().To<EditUserHandler>().InRequestScope();
            Kernel.Bind<IGetClientListHandler>().To<GetClientListHandler>().InRequestScope();
            Kernel.Bind<IEditClientHandler>().To<EditClientHandler>().InRequestScope();
            Kernel.Bind<IDeleteClientHandler>().To<DeleteClientHandler>().InRequestScope();
            Kernel.Bind<IGetClientDealInfoHandler>().To<GetClientDealInfoHandler>().InRequestScope();
            Kernel.Bind<IGetSalesListHandler>().To<GetSalesListHandler>().InRequestScope();
            Kernel.Bind<IAcceptSaleHandler>().To<AcceptSaleHandler>().InRequestScope();
            Kernel.Bind<IEditMaintenanceHandler>().To<EditMaintenanceHandler>().InRequestScope();
            Kernel.Bind<IGetMaintenancesHandler>().To<GetMaintenancesHandler>().InRequestScope();
            Kernel.Bind<IGetClientByUserIdHandler>().To<GetClientByUserIdHandler>().InRequestScope();
            Kernel.Bind<ICreateSaleHandler>().To<CreateSaleHandler>().InRequestScope();
            Kernel.Bind<ISearchSailingVehiclesHandler>().To<SearchSailingVehiclesHandler>().InRequestScope();
            Kernel.Bind<IGetClientMaintenancesHandler>().To<GetClientMaintenancesHandler>().InRequestScope();
            Kernel.Bind<IGetMaintenanceStatisticsHandler>().To<GetMaintenanceStatisticsHandler>().InRequestScope();
            Kernel.Bind<IGetClientVehiclesHandler>().To<GetClientVehiclesHandler>().InRequestScope();
            Kernel.Bind<ICreateMaintenanceHandler>().To<CreateMaintenanceHandler>().InRequestScope();
            Kernel.Bind<IGetResolutionValuesHandler>().To<GetResolutionValuesHandler>().InRequestScope();
            Kernel.Bind<ISetResolutionValuesHandler>().To<SetResolutionValuesHandler>().InRequestScope();
            Kernel.Bind<IGetResolutionResultHandler>().To<GetResolutionResultHandler>().InRequestScope();
        }
    }
}