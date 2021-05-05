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

        }

        private void OnBackToLoginCommandExecuted(IWindow currentWindow)
        {
            LoginWindow.SetDefault();
            LoginWindow.Show();

            currentWindow.CloseWindow();
        }

        public override Task SetDefaultValues()
        {
            InformationControl.ViewModel.CurrentUserId = CurrentUserId;

            return Task.CompletedTask;
        }
    }
}