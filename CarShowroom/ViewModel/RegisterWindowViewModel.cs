using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels;
using CarShowroom.Handlers.Interfaces.Login;
using CarShowroom.Interfaces;
using CarShowroom.View;
using CarShowroom.ViewModel.Base;
using GalaSoft.MvvmLight.CommandWpf;
using Ninject;
using RelayCommand = GalaSoft.MvvmLight.CommandWpf.RelayCommand;

namespace CarShowroom.ViewModel
{
    public class RegisterWindowViewModel : BaseViewModel
    {
        [Inject]
        public RegisterWindow RegisterWindow { get; set; }

        [Inject]
        public IRegisterHandler RegisterHandler { get; set; }

        private RegisterModel _registerModel;
        public RegisterModel RegisterModel
        {
            get => _registerModel;
            set { _registerModel = value; OnPropertyChanged(); }
        }

        private string _selectedRole;
        public string SelectedRole
        {
            get => _selectedRole;
            set
            {
                _selectedRole = value;

                AdministratorVisibility = _selectedRole == EnumRoles.Administrator.ToString() ? Visibility.Visible : Visibility.Hidden;

                OnPropertyChanged();
            }
        }

        private string _repeatPassword;
        public string RepeatPassword
        {
            get => _repeatPassword;
            set { _repeatPassword = value; OnPropertyChanged(); }
        }

        private Visibility _administratorVisibility;
        public Visibility AdministratorVisibility
        {
            get => _administratorVisibility;
            set { _administratorVisibility = value; OnPropertyChanged(); }
        }

        private string _status;
        public string Status
        {
            get => _status;
            set { _status = value; OnPropertyChanged(); }
        }

        public ICommand SaveUserCommand { get; set; }

        public ICommand BackToLoginCommand { get; set; }

        public RegisterWindowViewModel()
        {
            SetDefaultValues();

            SaveUserCommand = new RelayCommand<IWindow>(SaveUserCommandExecuted, f =>
            {
                return !String.IsNullOrEmpty(RegisterModel.Login) &&
                       !String.IsNullOrEmpty(RegisterModel.Name) &&
                       !String.IsNullOrEmpty(RegisterModel.Password) &&
                       !String.IsNullOrEmpty(RepeatPassword) &&
                       RepeatPassword.Equals(RegisterModel.Password, StringComparison.Ordinal) &&
                       !(SelectedRole == EnumRoles.Administrator.ToString() &&
                         String.IsNullOrEmpty(RegisterModel.SecretPassword));
            });

            BackToLoginCommand = new RelayCommand(BackToLoginCommandExecuted);
        }

        private void SaveUserCommandExecuted(IWindow window)
        {
            Enum.TryParse(SelectedRole, true, out EnumRoles role);
            RegisterModel.Role = role;

            var serverAnswer = RegisterHandler.RegisterExecute(RegisterModel);

            if (serverAnswer.RequestResult == RequestResult.Success)
            {
                window.CloseWindow();
            }
            else
            {
                Status = serverAnswer.Message;
            }
        }

        private void BackToLoginCommandExecuted()
        {
            RegisterWindow.CloseWindow();
        }

        public override Task SetDefaultValues()
        {
            RegisterModel = new RegisterModel();
            RepeatPassword = String.Empty;

            return Task.CompletedTask;
        }
    }
}