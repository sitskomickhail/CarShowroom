using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Users;
using CarShowroom.Handlers.Interfaces.Users;
using CarShowroom.Helpers;
using CarShowroom.ViewModel.Base;
using Ninject;

namespace CarShowroom.ViewModel.Administration.Users
{
    public class UserCreateViewModel : BaseViewModel
    {
        [Inject]
        public ICreateUserHandler CreateUserHandler { get; set; }

        private CreateUserModel _createUser;
        public CreateUserModel CreateUser
        {
            get => _createUser;
            set { _createUser = value; OnPropertyChanged(); }
        }

        private string _role;
        public string Role
        {
            get => _role;
            set
            {
                _role = value;
                _createUser.Role = EnumRoles.Administrator.ToString() == value ? EnumRoles.Administrator : EnumRoles.Employee;
                OnPropertyChanged();
            }
        }

        public ICommand CreateUserCommand { get; set; }

        public UserCreateViewModel()
        {
            CreateUser = new CreateUserModel();
            CreateUserCommand = new RelayCommand(CreateUserCommandExecuted, f => !String.IsNullOrEmpty(_createUser.Login)
                                                                              && !String.IsNullOrEmpty(_createUser.Password)
                                                                              && !String.IsNullOrEmpty(_createUser.Name));
        }

        private void CreateUserCommandExecuted(object obj)
        {
            var recievedData = CreateUserHandler.CreateUser(CreateUser);

            if (recievedData.RequestResult == RequestResult.Success)
            {
                MessageBox.Show("User created successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                CreateUser = new CreateUserModel();
            }
            else
            {
                MessageBox.Show(recievedData.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override Task SetDefaultValues()
        {
            CreateUser = new CreateUserModel();
            Role = EnumRoles.Administrator.ToString();

            return Task.CompletedTask;
        }
    }
}