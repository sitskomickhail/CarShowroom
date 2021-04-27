using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class UserListViewModel : BaseViewModel
    {
        [Inject]
        public IGetUserListHandler GetUserListHandler { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        private GetUsersListModel _usersListModel;
        public GetUsersListModel UserListModel
        {
            get => _usersListModel;
            set { _usersListModel = value; OnPropertyChanged(); }
        }

        public ObservableCollection<UserGridModel> UserCollection { get; set; }

        public ICommand SearchUsersCommand { get; set; }

        public UserListViewModel()
        {
            UserCollection = new ObservableCollection<UserGridModel>();

            SearchUsersCommand = new RelayCommand(SearchUsersCommandExecuted);
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

        public override async Task SetDefaultValues()
        {
            UserCollection = new ObservableCollection<UserGridModel>();

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
