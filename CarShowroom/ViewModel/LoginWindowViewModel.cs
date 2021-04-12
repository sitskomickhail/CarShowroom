using System;
using System.Diagnostics;
using System.Windows.Input;
using CarShowroom.Interfaces;
using CarShowroom.TransferHandlers.Interfaces;
using CarShowroom.View;
using CarShowroom.ViewModel.Base;
using GalaSoft.MvvmLight.CommandWpf;
using Ninject;

namespace CarShowroom.ViewModel
{
    public class LoginWindowViewModel : BaseViewModel
    {
        [Inject]
        public AdministrationWindow AdministrationWindow { get; set; }

        [Inject]
        public EmployeeWindow EmployeeWindow { get; set; }

        [Inject]
        public ITcpTransferHandler TcpTransferHandler { get; set; }

        private string _login;
        public string Login
        {
            get { return _login; }
            set { _login = value; OnPropertyChanged(); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; set; }

        public LoginWindowViewModel()
        {
            LoginCommand = new RelayCommand<IWindow>(OnLoginCommandExecuted, f => !String.IsNullOrEmpty(_login) && !String.IsNullOrEmpty(_password));
        }

        private void OnLoginCommandExecuted(IWindow currentWindow)
        {
            TcpTransferHandler.WriteStream($"{Login} + {Password}");

            var result = TcpTransferHandler.ReadStream();
            
            Debug.WriteLine(result);
            
            AdministrationWindow.Show();
            
            EmployeeWindow.Show();

            currentWindow.CloseWindow();
        }

        public override void SetDefaultValues()
        {
            this.Login = String.Empty;
            this.Password = String.Empty;
        }
    }
}