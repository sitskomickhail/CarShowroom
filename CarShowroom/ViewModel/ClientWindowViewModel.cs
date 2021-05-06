using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using CarShowroom.Controls.Client;
using CarShowroom.Interfaces;
using CarShowroom.View;
using CarShowroom.ViewModel.Base;
using GalaSoft.MvvmLight.CommandWpf;
using Ninject;

namespace CarShowroom.ViewModel
{
    public class ClientWindowViewModel : BaseViewModel
    {
        [Inject]
        public LoginWindow LoginWindow { get; set; }

        [Inject]
        public ClientInformationControl InformationControl { get; set; }

        [Inject]
        public MarketplaceControl MarketplaceControl { get; set; }

        [Inject]
        public MaintenanceControl MaintenanceControl { get; set; }

        public ICommand BackToLoginCommand { get; set; }

        public ICommand TabItemChooseCommand { get; set; }

        public Guid CurrentUserId { get; set; }

        public ClientWindowViewModel()
        {
            BackToLoginCommand = new RelayCommand<IWindow>(OnBackToLoginCommandExecuted);
            TabItemChooseCommand = new RelayCommand(OnTabItemChooseCommandExecuted);
        }

        private async void OnTabItemChooseCommandExecuted()
        {
            await InformationControl.LoadInitialData();
            await MarketplaceControl.LoadInitialData();
            await MaintenanceControl.LoadInitialData();
        }

        private void OnBackToLoginCommandExecuted(IWindow currentWindow)
        {
            LoginWindow.SetDefault();
            LoginWindow.Show();

            currentWindow.CloseWindow();
        }

        public override async Task SetDefaultValues()
        {
            InformationControl.ViewModel.CurrentUserId = CurrentUserId;
            MarketplaceControl.ViewModel.CurrentUserId = CurrentUserId;
            MaintenanceControl.ViewModel.CurrentUserId = CurrentUserId;

            await InformationControl.LoadInitialData();
        }
    }
}