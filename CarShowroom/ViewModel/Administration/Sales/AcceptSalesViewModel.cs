using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AutoMapper;
using CarShowroom.Entities.Models.AnswerModels.Sales;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Sales;
using CarShowroom.Handlers.Interfaces.Sales;
using CarShowroom.Models.Sales;
using CarShowroom.ViewModel.Base;
using GalaSoft.MvvmLight.CommandWpf;
using Newtonsoft.Json;
using Ninject;

namespace CarShowroom.ViewModel.Administration.Sales
{
    public class AcceptSalesViewModel : BaseViewModel
    {
        [Inject]
        public IGetSalesListHandler GetSalesListHandler { get; set; }

        [Inject]
        public IAcceptSaleHandler AcceptSaleHandler { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        private GetSalesListModel _getSalesList;
        public GetSalesListModel GetSalesListModel
        {
            get => _getSalesList;
            set { _getSalesList = value; OnPropertyChanged(); }
        }

        public ICommand AcceptSaleCommand { get; set; }

        public ICommand DeclineSaleCommand { get; set; }

        public ICommand SearchSalesCommand { get; set; }

        private ObservableCollection<SaleGridModel> _saleCollection;
        public ObservableCollection<SaleGridModel> SaleCollection
        {
            get => _saleCollection;
            set { _saleCollection = value; OnPropertyChanged(); }
        }

        public AcceptSalesViewModel()
        {
            SaleCollection = new ObservableCollection<SaleGridModel>();
            GetSalesListModel = new GetSalesListModel();
            GetSalesListModel.AcceptedSale = false;

            SaleCollection.Add(new SaleGridModel()
            {
                Client = "Temp client",
                PaymentAbove = DateTime.Now,
                SaleTime = DateTime.Now,
                PaymentMethod = "Card",
                Position = 1,
                TotalCost = 1400,
                Status = SaleStatus.Waiting.ToString(),
                Vehicle = "Porcshe"
            });

            SearchSalesCommand = new RelayCommand(SearchSalesCommandExecuted);
            AcceptSaleCommand = new RelayCommand<Guid>(AcceptSaleCommandExecuted);
            DeclineSaleCommand = new RelayCommand<Guid>(DeclineSaleCommandExecuted);
        }

        private void SearchSalesCommandExecuted()
        {
            var recievedData = GetSalesListHandler.GetClientList(GetSalesListModel);

            if (recievedData.RequestResult == RequestResult.Success)
            {
                var clientList = JsonConvert.DeserializeObject<List<SaleAnswerModel>>(recievedData.Object);
                var gridList = Mapper.Map<List<SaleGridModel>>(clientList);

                int counter = 1;
                gridList.ForEach(gl => gl.Position = counter++);

                SaleCollection = new ObservableCollection<SaleGridModel>(gridList);
            }
        }

        private void AcceptSaleCommandExecuted(Guid saleId)
        {
            var acceptModel = new AcceptSaleModel() { Id = saleId, IsAccepted = true };
            var recievedData = AcceptSaleHandler.ChangeSaleStatus(acceptModel);

            if (recievedData.RequestResult == RequestResult.Success)
            {
                SearchSalesCommandExecuted();
            }
            else
            {
                MessageBox.Show(recievedData.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeclineSaleCommandExecuted(Guid saleId)
        {
            var acceptModel = new AcceptSaleModel() { Id = saleId, IsAccepted = false };
            var recievedData = AcceptSaleHandler.ChangeSaleStatus(acceptModel);

            if (recievedData.RequestResult == RequestResult.Success)
            {
                SearchSalesCommandExecuted();
            }
            else
            {
                MessageBox.Show(recievedData.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override async Task SetDefaultValues()
        {
            SaleCollection = new ObservableCollection<SaleGridModel>();
            GetSalesListModel = new GetSalesListModel();
            GetSalesListModel.AcceptedSale = false;

            await Application.Current.Dispatcher.Invoke(async () =>
            {
                SearchSalesCommandExecuted();
            });
        }
    }
}