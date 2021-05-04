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
    public class SaleListViewModel : BaseViewModel
    {
        [Inject]
        public IGetSalesListHandler GetSalesListHandler { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        private GetSalesListModel _getSalesList;
        public GetSalesListModel GetSalesListModel
        {
            get => _getSalesList;
            set { _getSalesList = value; OnPropertyChanged(); }
        }

        private ObservableCollection<SaleGridModel> _saleCollection;
        public ObservableCollection<SaleGridModel> SaleCollection
        {
            get => _saleCollection;
            set { _saleCollection = value; OnPropertyChanged(); }
        }

        public ICommand SearchSalesCommand { get; set; }

        public SaleListViewModel()
        {
            SaleCollection = new ObservableCollection<SaleGridModel>();
            GetSalesListModel = new GetSalesListModel();
            GetSalesListModel.AcceptedSale = true;

            SearchSalesCommand = new RelayCommand(SearchSalesCommandExecuted);
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

        public override async Task SetDefaultValues()
        {
            SaleCollection = new ObservableCollection<SaleGridModel>();
            GetSalesListModel = new GetSalesListModel();
            GetSalesListModel.AcceptedSale = true;

            await Application.Current.Dispatcher.Invoke(async () =>
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
            });
        }
    }
}