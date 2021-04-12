using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CarShowroom.NinjectDependencyInjection;
using CarShowroom.TransferHandlers.Interfaces;
using CarShowroom.View;
using CarShowroom.ViewModel;
using CarShowroom.ViewModel.Base;
using Ninject;
using Ninject.Modules;

namespace CarShowroom
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            NinjectDI ninject = new NinjectDI();
            ninject.Load();

            var tcpConnection = ninject.Kernel.Get<ITcpTransferHandler>();
            tcpConnection.CreateConnection("127.0.0.1", 5545);
            
            var window = ninject.Kernel.Get<LoginWindow>();
            window.Show();
            
            base.OnStartup(e);
        }
    }
}
