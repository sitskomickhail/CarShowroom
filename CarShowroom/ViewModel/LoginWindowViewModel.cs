using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CarShowroom.Helpers;
using CarShowroom.View;
using CarShowroom.ViewModel.Base;

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
            LoginCommand = new RelayCommand(OnLoginCommandExecuted, f => !String.IsNullOrEmpty(_login) && !String.IsNullOrEmpty(_password));
        }

        private void OnLoginCommandExecuted(object obj)
        {
            Debug.WriteLine($"Current state: {Login} : {Password}");

            AdministratorWindow window = new AdministratorWindow();
        }
    }
}
