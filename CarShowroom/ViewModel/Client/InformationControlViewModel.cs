using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AutoMapper;
using CarShowroom.Entities.Models.AnswerModels.Clients;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Clients;
using CarShowroom.Handlers.Interfaces.Clients;
using CarShowroom.Models.Clients;
using CarShowroom.ViewModel.Base;
using GalaSoft.MvvmLight.CommandWpf;
using Newtonsoft.Json;
using Ninject;

namespace CarShowroom.ViewModel.Client
{
    public class InformationControlViewModel : BaseViewModel
    {
        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public IGetClientByUserIdHandler GetClientByUserIdHandler { get; set; }

        [Inject]
        public IEditClientHandler EditClientHandler { get; set; }

        public Guid CurrentUserId { get; set; }

        private bool editEnabled;
        public bool EditEnabled
        {
            get => editEnabled;
            set { editEnabled = value; OnPropertyChanged(); }
        }

        private ClientInformationModel clientModel;
        public ClientInformationModel ClientModel
        {
            get => clientModel;
            set { clientModel = value; OnPropertyChanged(); }
        }

        public ICommand SaveClientCommand { get; set; }

        public ICommand EditClientCommand { get; set; }

        public InformationControlViewModel()
        {
            EditEnabled = false;
            ClientModel = new ClientInformationModel();

            EditClientCommand = new RelayCommand(EditClientCommandExecuted);
            SaveClientCommand = new RelayCommand(SaveClientCommandExecuted);
        }

        private void SaveClientCommandExecuted()
        {
            var editClient = Mapper.Map<EditClientModel>(ClientModel);

            var recievedData = EditClientHandler.EditClient(editClient);

            if (recievedData.RequestResult == RequestResult.Success)
            {
                SearchClientByCurrentId();
                MessageBox.Show("Client info saved successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show(recievedData.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditClientCommandExecuted()
        {
            EditEnabled = !EditEnabled;
        }

        public override async Task SetDefaultValues()
        {
            EditEnabled = false;
            ClientModel = new ClientInformationModel();

            await Application.Current.Dispatcher.Invoke(async () =>
            {
                SearchClientByCurrentId();
            });
        }

        private void SearchClientByCurrentId()
        {
            var recievedData = GetClientByUserIdHandler.GetClient(new GetClientByUserIdModel { Id = CurrentUserId });

            if (recievedData.RequestResult == RequestResult.Success)
            {
                var clientInfo = JsonConvert.DeserializeObject<ClientAnswerModel>(recievedData.Object);

                ClientModel = Mapper.Map<ClientInformationModel>(clientInfo);
            }
        }
    }
}