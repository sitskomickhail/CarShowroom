using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShowroom.TransferHandlers;
using CarShowroom.TransferHandlers.Interfaces;
using CarShowroom.View;
using CarShowroom.ViewModel;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;

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
            InjectWindows();
            InjectViewModels();
            InjectTcpHandler();
        }

        private void InjectWindows()
        {
            Kernel.Bind<LoginWindow>().ToSelf().InSingletonScope();
            Kernel.Bind<AdministrationWindow>().ToSelf().InSingletonScope();
            Kernel.Bind<EmployeeWindow>().ToSelf().InSingletonScope();
        }

        private void InjectViewModels()
        {
            Kernel.Bind<AdministartorWindowViewModel>().ToSelf().InSingletonScope();
            Kernel.Bind<LoginWindowViewModel>().ToSelf().InSingletonScope();
            Kernel.Bind<EmployeeWindowViewModel>().ToSelf().InSingletonScope();
        }

        private void InjectTcpHandler()
        {
            Kernel.Bind<ITcpTransferHandler>().To<TcpTransferHandler>().InSingletonScope();
        }
    }
}