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
            ClientModel = new GetClientListModel();
            ClientCollection = new ObservableCollection<ClientGridModel>();
            
            SearchClientsCommand = new RelayCommand(SearchClientsCommandExecuted);
            SaveClientCommand = new RelayCommand<Guid>(SaveClientCommandExecuted);
            DeleteClientCommand = new RelayCommand<Guid>(DeleteClientCommandExecuted);
        }

        private void SearchClientsCommandExecuted()
        {
            var recievedData = GetClientListHandler.GetClientList(ClientModel);

            if (recievedData.RequestResult == RequestResult.Success)
            {
                var vehiclesList = JsonConvert.DeserializeObject<List<ClientAnswerModel>>(recievedData.Object);
                var gridList = Mapper.Map<List<ClientGridModel>>(vehiclesList);

                int counter = 1;
                gridList.ForEach(gl => gl.Position = counter++);

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
            else
            {
                MessageBox.Show(recievedData.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveClientCommandExecuted(Guid clientId)
        {
            var choosedClient = ClientCollection.FirstOrDefault(u => u.Id == clientId);

            var editClient = Mapper.Map<EditClientModel>(choosedClient);

            var recievedData = EditClientHandler.EditClient(editClient);

            if (recievedData.RequestResult == RequestResult.Success)
            {
                var clientResult = JsonConvert.DeserializeObject<ClientAnswerModel>(recievedData.Object);

                var clientGridItem = Mapper.Map<ClientGridModel>(clientResult);
                clientGridItem.Position = choosedClient.Position;

                ClientCollection[ClientCollection.IndexOf(choosedClient)] = clientGridItem;
                MessageBox.Show("Client info saved successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show(recievedData.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override async Task SetDefaultValues()
        {
            ClientModel = new GetClientListModel();
            ClientCollection = new ObservableCollection<ClientGridModel>();

            await Application.Current.Dispatcher.Invoke(async () =>
            {
                var recievedData = GetClientListHandler.GetClientList(ClientModel);

                if (recievedData.RequestResult == RequestResult.Success)
                {
                    var clientList = JsonConvert.DeserializeObject<List<ClientAnswerModel>>(recievedData.Object);
                    var gridList = Mapper.Map<List<ClientGridModel>>(clientList);

                    int counter = 1;
                    gridList.ForEach(gl => gl.Position = counter++);

                    ClientCollection = new ObservableCollection<ClientGridModel>(gridList);
                }
            });
        }
    }
}