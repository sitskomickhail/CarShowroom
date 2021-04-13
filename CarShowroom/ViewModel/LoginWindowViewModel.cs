using System;
using System.Windows.Input;
using CarShowroom.Entities.Models.AnswerModels.Users;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels;
using CarShowroom.Handlers.Interfaces.Login;
using CarShowroom.Interfaces;
using CarShowroom.View;
using CarShowroom.ViewModel.Base;
using GalaSoft.MvvmLight.CommandWpf;
using Newtonsoft.Json;
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
        public ILoginHandler LoginHandler { get; set; }
        
        private string _infoMessage = "Welcome! Enter your credentials";

        public string InfoMessage
        {
            get { return _infoMessage; }
            set { _infoMessage = value; OnPropertyChanged(); }
        }

        private LoginModel _loginModel;

        public LoginModel LoginModel
        {
            get { return _loginModel; }
            set { _loginModel = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        public LoginWindowViewModel()
        {
            SetDefaultValues();

            LoginCommand = new RelayCommand<IWindow>(OnLoginCommandExecuted, f => !String.IsNullOrEmpty(_loginModel.Login) && !String.IsNullOrEmpty(_loginModel.Password));
            RegisterCommand = new RelayCommand(OnRegisterCommandExecuted);
        }

        private void OnLoginCommandExecuted(IWindow currentWindow)
        {
            var serverAnswer = LoginHandler.LoginExecute(LoginModel);

            if (serverAnswer.RequestResult == RequestResult.Success)
            {
                var userModel = JsonConvert.DeserializeObject<UserAnswerModel>(serverAnswer.Object);

                switch (userModel.Role)
                {
                    case EnumRoles.Administrator: AdministrationWindow.Show(); break;
                    case EnumRoles.Employee: EmployeeWindow.Show(); break;
                }

                currentWindow.CloseWindow();
            }
            else
            {
                InfoMessage = serverAnswer.Message;
            }
        }

        private void OnRegisterCommandExecuted()
        {

        }
        
        public override void SetDefaultValues()
        {
            this.LoginModel = new LoginModel();
            this.InfoMessage = "Welcome! Enter your credentials";
        }
    }
}