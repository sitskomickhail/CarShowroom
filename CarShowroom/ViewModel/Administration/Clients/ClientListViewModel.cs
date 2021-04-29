using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AutoMapper;
using CarShowroom.Controls.Administration.Clients;
using CarShowroom.Entities.Models.AnswerModels.Clients;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Clients;
using CarShowroom.Handlers.Interfaces.Clients;
using CarShowroom.Models.Clients;
using CarShowroom.ViewModel.Base;
using GalaSoft.MvvmLight.CommandWpf;
using Newtonsoft.Json;
using Ninject;

namespace CarShowroom.ViewModel.Administration.Clients
{
    public class ClientListViewModel : BaseViewModel
    {
        [Inject]
        public IGetClientListHandler GetClientListHandler { get; set; }

        [Inject]
        public IGetClientDealInfoHandler GetClientDealInfoHandler { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        private GetClientListModel _getClientListModel;
        public GetClientListModel ClientModel
        {
            get => _getClientListModel;
            set { _getClientListModel = value; OnPropertyChanged(); }
        }

        public ICommand ViewClientInfoCommand { get; set; }

        public ICommand SearchClientsCommand { get; set; }

        private ObservableCollection<ClientGridModel> _clientCollection;
        public ObservableCollection<ClientGridModel> ClientCollection
        {
            get => _clientCollection;
            set { _clientCollection = value; OnPropertyChanged(); }
        }

        public ClientListViewModel()
        {
            ClientModel = new GetClientListModel();
            ClientCollection = new ObservableCollection<ClientGridModel>();

            SearchClientsCommand = new RelayCommand(SearchClientsCommandExecuted);
            ViewClientInfoCommand = new RelayCommand<Guid>(ViewClientInfoCommandExecuted);
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

        private void ViewClientInfoCommandExecuted(Guid clientId)
        {
            var choosedClient = ClientCollection.FirstOrDefault(c => c.Id == clientId);
            var clientInfoModel = Mapper.Map<GetClientInfoModel>(choosedClient);

            var recievedData = GetClientDealInfoHandler.GetClientDeal(clientInfoModel);

            if (recievedData.RequestResult == RequestResult.Success)
            {
                var clientDealsInfo = JsonConvert.DeserializeObject<ClientDealsAnswerModel>(recievedData.Object);

                ClientDealsInfo dealsWindow = new ClientDealsInfo(clientDealsInfo);
                dealsWindow.Show();
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