using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels;
using CarShowroom.Handlers.Interfaces.Login;
using CarShowroom.Helpers;
using CarShowroom.Interfaces;
using CarShowroom.View;
using CarShowroom.ViewModel.Base;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Ninject;
using RelayCommand = GalaSoft.MvvmLight.CommandWpf.RelayCommand;

namespace CarShowroom.ViewModel
{
    public class RegisterWindowViewModel : BaseViewModel
    {
        [Inject]
        public RegisterWindow RegisterWindow { get; set; }

        public IRegisterHandler RegisterHandler { get; set; }

        private RegisterModel _registerModel;
        public RegisterModel RegisterModel
        {
            get { return _registerModel; }
            set { _registerModel = value; OnPropertyChanged(); }
        }

        private string _selectedRole;
        public string SelectedRole
        {
            get { return _selectedRole; }
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
            get { return _repeatPassword; }
            set { _repeatPassword = value; OnPropertyChanged(); }
        }

        private Visibility _administratorVisibility;
        public Visibility AdministratorVisibility
        {
            get { return _administratorVisibility; }
            set { _administratorVisibility = value; OnPropertyChanged(); }
        }
        
        public ICommand SaveUserCommand { get; set; }

        public ICommand BackToLoginCommand { get; set; }

        public RegisterWindowViewModel()
        {
            SetDefaultValues();

            SaveUserCommand = new RelayCommand<IWindow>(SaveUserCommandExecuted);
            BackToLoginCommand = new RelayCommand(BackToLoginCommandExecuted);
        }

        private void SaveUserCommandExecuted(IWindow window)
        {
            var serverAnswer = RegisterHandler.RegisterExecute(RegisterModel);

            if (serverAnswer.RequestResult == RequestResult.Success)
            {

            }
            else
            {

            }

            window.CloseWindow();
        }

        private void BackToLoginCommandExecuted()
        {
            RegisterWindow.CloseWindow();
        }

        public override void SetDefaultValues()
        {
            RegisterModel = new RegisterModel();
            RepeatPassword = String.Empty;
        }
    }
}