using System;
using System.Diagnostics;
using System.Windows.Input;
using CarShowroom.Interfaces;
using CarShowroom.View;
using CarShowroom.ViewModel.Base;
using GalaSoft.MvvmLight.CommandWpf;

namespace CarShowroom.ViewModel
{
    public class LoginWindowViewModel : BaseViewModel
    {
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
            LoginCommand = new RelayCommand<IClosable>(OnLoginCommandExecuted, f => !String.IsNullOrEmpty(_login) && !String.IsNullOrEmpty(_password));
        }

        private void OnLoginCommandExecuted(IClosable currentWindow)
        {
            Debug.WriteLine($"Current state: {Login} : {Password}");
            
            AdministrationWindow window = new AdministrationWindow();
            window.Show();

            currentWindow.CloseWindow();
        }
    }
}