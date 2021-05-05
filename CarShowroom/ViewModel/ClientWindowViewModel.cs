using System;
using System.Threading.Tasks;
using System.Windows.Input;
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

        public ICommand BackToLoginCommand { get; set; }

        public Guid CurrentUserId { get; set; }

        public ClientWindowViewModel()
        {
            BackToLoginCommand = new RelayCommand<IWindow>(OnBackToLoginCommandExecuted);
        }

        private void OnBackToLoginCommandExecuted(IWindow currentWindow)
        {
            LoginWindow.SetDefault();
            LoginWindow.Show();

            currentWindow.CloseWindow();
        }

        public override Task SetDefaultValues() { return Task.CompletedTask; }
    }
}