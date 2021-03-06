using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AutoMapper;
using CarShowroom.Entities.Models.AnswerModels.Users;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Users;
using CarShowroom.Handlers.Interfaces.Users;
using CarShowroom.Models.Users;
using CarShowroom.ViewModel.Base;
using GalaSoft.MvvmLight.CommandWpf;
using Newtonsoft.Json;
using Ninject;

namespace CarShowroom.ViewModel.Administration.Users
{
    public class UserEditViewModel : BaseViewModel
    {
        [Inject]
        public IGetUserListHandler GetUserListHandler { get; set; }

        [Inject]
        public IEditUserHandler EditUserHandler { get; set; }

        [Inject]
        public IDeleteUserHandler DeleteUserHandler { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        private GetUsersListModel _usersListModel;
        public GetUsersListModel UserListModel
        {
            get => _usersListModel;
            set { _usersListModel = value; OnPropertyChanged(); }
        }

        private ObservableCollection<UserGridModel> _userCollection;
        public ObservableCollection<UserGridModel> UserCollection
        {
            get => _userCollection;
            set
            { _userCollection = value; OnPropertyChanged(); }
        }

        public ICommand SearchUsersCommand { get; set; }

        public ICommand SaveUserCommand { get; set; }

        public ICommand DeleteUserCommand { get; set; }

        public UserEditViewModel()
        {
            UserCollection = new ObservableCollection<UserGridModel>();
            UserListModel = new GetUsersListModel();

            SearchUsersCommand = new RelayCommand(SearchUsersCommandExecuted);
            SaveUserCommand = new RelayCommand<Guid>(SaveUserCommandExecuted);
            DeleteUserCommand = new RelayCommand<Guid>(DeleteUserCommandExecuted);
        }

        private void SearchUsersCommandExecuted()
        {
            var recievedData = GetUserListHandler.GetUserList(UserListModel);

            if (recievedData.RequestResult == RequestResult.Success)
            {
                var vehiclesList = JsonConvert.DeserializeObject<List<UserAnswerModel>>(recievedData.Object);
                var gridList = Mapper.Map<List<UserGridModel>>(vehiclesList);

                int counter = 1;
                gridList.ForEach(gl => gl.Number = counter++);

                UserCollection = new ObservableCollection<UserGridModel>(gridList);
            }
        }

        public void SaveUserCommandExecuted(Guid userId)
        {
            var choosedUser = UserCollection.FirstOrDefault(u => u.Id == userId);
            var editUser = Mapper.Map<EditUserModel>(choosedUser);

            var recievedData = EditUserHandler.SaveUser(editUser);

            if (recievedData.RequestResult == RequestResult.Success)
            {
                var userResult = JsonConvert.DeserializeObject<UserAnswerModel>(recievedData.Object);

                var userGridItem = Mapper.Map<UserGridModel>(userResult);
                userGridItem.Number = choosedUser.Number;

                UserCollection[UserCollection.IndexOf(choosedUser)] = userGridItem;
                MessageBox.Show("User info saved successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show(recievedData.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void DeleteUserCommandExecuted(Guid userId)
        {
            var choosedUser = UserCollection.FirstOrDefault(u => u.Id == userId);
            var deleteUser = Mapper.Map<DeleteUserModel>(choosedUser);

            var recievedData = DeleteUserHandler.DeleteUser(deleteUser);

            if (recievedData.RequestResult == RequestResult.Success)
            {
                UserCollection.Remove(choosedUser);
            }
            else
            {
                MessageBox.Show(recievedData.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override async Task SetDefaultValues()
        {
            UserListModel = new GetUsersListModel();
            _userCollection = new ObservableCollection<UserGridModel>();

            await Application.Current.Dispatcher.Invoke(async () =>
            {
                var recievedData = GetUserListHandler.GetUserList(UserListModel);

                if (recievedData.RequestResult == RequestResult.Success)
                {
                    var vehiclesList = JsonConvert.DeserializeObject<List<UserAnswerModel>>(recievedData.Object);
                    var gridList = Mapper.Map<List<UserGridModel>>(vehiclesList);

                    int counter = 1;
                    gridList.ForEach(gl => gl.Number = counter++);

                    UserCollection = new ObservableCollection<UserGridModel>(gridList);
                }
            });
        }
    }
}
