using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AutoMapper;
using CarShowroom.Entities.Models.AnswerModels.Clients;
using CarShowroom.Entities.Models.AnswerModels.Users;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Clients;
using CarShowroom.Handlers.Interfaces.Clients;
using CarShowroom.Models.Clients;
using CarShowroom.Validators;
using CarShowroom.ViewModel.Base;
using GalaSoft.MvvmLight.CommandWpf;
using Newtonsoft.Json;
using Ninject;

namespace CarShowroom.ViewModel.Administration.Clients
{
    public class ClientEditViewModel : BaseViewModel
    {
        [Inject]
        public IGetClientListHandler GetClientListHandler { get; set; }

        [Inject] 
        public IDeleteClientHandler DeleteClientHandler { get; set; }

        [Inject]
        public IEditClientHandler EditClientHandler { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        private GetClientListModel _getClientListModel;
        public GetClientListModel ClientModel
        {
            get => _getClientListModel;
            set { _getClientListModel = value; OnPropertyChanged(); }
        }

        private ObservableCollection<ClientGridModel> _clientCollection;
        public ObservableCollection<ClientGridModel> ClientCollection
        {
            get => _clientCollection;
            set { _clientCollection = value; OnPropertyChanged(); }
        }

        public ICommand SearchClientsCommand { get; set; }

        public ICommand SaveClientCommand { get; set; }

        public ICommand DeleteClientCommand { get; set; }
        
        public ClientEditViewModel()
        {
            _getClientListModel = new GetClientListModel();
            _clientCollection = new ObservableCollection<ClientGridModel>();

            ClientCollection.Add(new ClientGridModel()
            {
                Number = 1,
                PhoneNumber = "+375297807148",
                Address = "Street 1",
                HaveMaintenances = true,
                HaveSales = false,
                Email = "rztzs@gmail.com",
                Name = "Mathias Bavro",
                Id = Guid.NewGuid()
            });

            SearchClientsCommand = new RelayCommand(SearchClientsCommandExecuted);
            SaveClientCommand = new RelayCommand<Guid>(SaveClientCommandExecuted);
            DeleteClientCommand = new RelayCommand<Guid>(DeleteClientCommandExecuted);
        }

        private void SearchClientsCommandExecuted()
        {
            var recievedData = GetClientListHandler.GetClientList(ClientModel);

            if (recievedData.RequestResult == RequestResult.Success)
            {
                var vehiclesList = JsonConvert.DeserializeObject<List<UserAnswerModel>>(recievedData.Object);
                var gridList = Mapper.Map<List<ClientGridModel>>(vehiclesList);

                int counter = 1;
                gridList.ForEach(gl => gl.Number = counter++);

                ClientCollection = new ObservableCollection<ClientGridModel>(gridList);
            }
        }

        private void DeleteClientCommandExecuted(Guid clientId)
        {
            var choosedClient = ClientCollection.FirstOrDefault(u => u.Id == clientId);
            var deleteClient = Mapper.Map<DeleteClientModel>(choosedClient);

            var recievedData = DeleteClientHandler.DeleteClient(deleteClient);

            if (recievedData.RequestResult == RequestResult.Success)
            {
                ClientCollection.Remove(choosedClient);
            }
        }

        private void SaveClientCommandExecuted(Guid clientId)
        {
            var choosedClient = ClientCollection.FirstOrDefault(u => u.Id == clientId);

            if (!ModelValid(choosedClient))
            {
                MessageBox.Show("Inputed info doesn't valid", "Validation error", MessageBoxButton.OK,
                    MessageBoxImage.Error, MessageBoxResult.OK);
                return;
            }

            var editClient = Mapper.Map<EditClientModel>(choosedClient);

            var recievedData = EditClientHandler.EditClient(editClient);

            if (recievedData.RequestResult == RequestResult.Success)
            {
                var clientResult = JsonConvert.DeserializeObject<ClientAnswerModel>(recievedData.Object);

                var clientGridItem = Mapper.Map<ClientGridModel>(clientResult);
                clientGridItem.Number = choosedClient.Number;

                ClientCollection[ClientCollection.IndexOf(choosedClient)] = clientGridItem;
            }
        }

        public override async Task SetDefaultValues()
        {
            _getClientListModel = new GetClientListModel();
            ClientCollection = new ObservableCollection<ClientGridModel>();

            await Application.Current.Dispatcher.Invoke(async () =>
            {
                var recievedData = GetClientListHandler.GetClientList(ClientModel);

                if (recievedData.RequestResult == RequestResult.Success)
                {
                    var clientList = JsonConvert.DeserializeObject<List<ClientAnswerModel>>(recievedData.Object);
                    var gridList = Mapper.Map<List<ClientGridModel>>(clientList);

                    int counter = 1;
                    gridList.ForEach(gl => gl.Number = counter++);

                    ClientCollection = new ObservableCollection<ClientGridModel>(gridList);
                }
            });

            ClientCollection.Add(new ClientGridModel()
            {
                Number = 1,
                PhoneNumber = "+375(29)7807148",
                Address = "Street 1",
                HaveMaintenances = true,
                HaveSales = false,
                Email = "rztzs@gmail.com",
                Name = "Mathias Bavro",
                Id = Guid.NewGuid()
            });
        }
    }
}
