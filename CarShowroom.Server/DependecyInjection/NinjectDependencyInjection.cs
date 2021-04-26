using System.Collections.Generic;
using AutoMapper;
using CarShowroom.Entities.DatabaseModels.Context;
using CarShowroom.Entities.Models.AnswerModels.Users;
using CarShowroom.Entities.Models.AnswerModels.Vehicles;
using CarShowroom.Entities.Models.TransferModels;
using CarShowroom.Entities.Models.TransferModels.Vehicles;
using CarShowroom.Server.Factories;
using CarShowroom.Server.Handlers;
using CarShowroom.Server.Handlers.Base;
using CarShowroom.Server.Handlers.Interfaces;
using CarShowroom.Server.HandlerServices.Interfaces;
using CarShowroom.Server.HandlerServices.Users;
using CarShowroom.Server.HandlerServices.Vehicles;
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
            InjectServices();
        }

        private void InjectMsSqlServer()
        {
            Kernel.Bind<SqlServerContext>().ToSelf().InRequestScope();
        }

        private void InjectFactory()
        {
            Kernel.Bind<TcpHandlerFactory>().ToSelf().InSingletonScope();
        }

        public void InjectListenerService()
        {
            Kernel.Bind<IClientListenerService>().To<ClientListenerService>().InSingletonScope();
        }

        public void InjectHandlers()
        {
            Kernel.Bind<IHandlerExecutor>().To<HandlerExecutor>().InRequestScope();
            Kernel.Bind<IHandler>().To<Handler<LoginModel, UserAnswerModel>>().InRequestScope();
            Kernel.Bind<IHandler>().To<Handler<RegisterModel, UserAnswerModel>>().InRequestScope();
        }

        public void InjectHandlerServices()
        {
            Kernel.Bind<IHandlerService<LoginModel, UserAnswerModel>>().To<LoginHandlerService>().InRequestScope();
            Kernel.Bind<IHandlerService<RegisterModel, UserAnswerModel>>().To<RegistrateHandlerService>().InRequestScope();
            Kernel.Bind<IHandlerService<CreateVehicleModel, VehicleAnswerModel>>().To<CreateVehicleHandlerService>().InRequestScope();
            Kernel.Bind<IHandlerService<SearchVehicleModel, List<VehicleAnswerModel>>>().To<SearchVehiclesHandlerService>().InRequestScope();
            Kernel.Bind<IHandlerService<GetVehicleListModel, List<VehicleAnswerModel>>>().To<GetVehiclesHandlerService>().InRequestScope();
            Kernel.Bind<IHandlerService<EditVehicleModel, VehicleAnswerModel>>().To<EditVehicleHandlerService>().InRequestScope();
        }

        private void InjectMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<VehicleProfile>();
            });

            Kernel.Bind<IMapper>().ToConstructor(c => new Mapper(mapperConfiguration)).InSingletonScope();
        }

        public void InjectServices()
        {
        }
    }
}