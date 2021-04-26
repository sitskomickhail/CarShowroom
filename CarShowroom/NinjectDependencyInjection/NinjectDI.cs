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
using System;
using AutoMapper;
using CarShowroom.Handlers;
using CarShowroom.Profiles;

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
        }

        private void InjectMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<VehicleProfile>();
            });

            Kernel.Bind<IMapper>().ToConstructor(c => new Mapper(mapperConfiguration)).InSingletonScope();
        }

        private void InjectWindows()
        {
            Kernel.Bind<LoginWindow>().ToSelf().InSingletonScope();
            Kernel.Bind<AdministrationWindow>().ToSelf().InSingletonScope();
            Kernel.Bind<EmployeeWindow>().ToSelf().InSingletonScope();
            Kernel.Bind<RegisterWindow>().ToSelf().InSingletonScope();
        }

        private void InjectControls()
        {
            Kernel.Bind<AdministrationBaseControl>().ToSelf().InSingletonScope();

            Kernel.Bind<VehicleListControl>().ToSelf().InSingletonScope();
            Kernel.Bind<VehicleCreateControl>().ToSelf().InSingletonScope();
            Kernel.Bind<VehicleListEditControl>().ToSelf().InSingletonScope();
        }

        private void InjectViewModels()
        {
            Kernel.Bind<AdministartorWindowViewModel>().ToSelf().InSingletonScope();
            Kernel.Bind<LoginWindowViewModel>().ToSelf().InSingletonScope();
            Kernel.Bind<EmployeeWindowViewModel>().ToSelf().InSingletonScope();
            Kernel.Bind<RegisterWindowViewModel>().ToSelf().InSingletonScope();

            Kernel.Bind<VehiclesListViewModel>().ToSelf().InSingletonScope();
            Kernel.Bind<VehicleEditListViewModel>().ToSelf().InSingletonScope();
            Kernel.Bind<VehicleCreateViewModel>().ToSelf().InSingletonScope();
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
        }
    }
}