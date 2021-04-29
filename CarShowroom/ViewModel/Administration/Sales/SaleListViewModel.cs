using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CarShowroom.Entities.Models.TransferModels.Sales;
using CarShowroom.Models.Sales;
using CarShowroom.ViewModel.Base;

namespace CarShowroom.ViewModel.Administration.Sales
{
    public class SaleListViewModel : BaseViewModel
    {
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
        }

        public override Task SetDefaultValues()
        {
            SaleCollection = new ObservableCollection<SaleGridModel>();
            GetSalesListModel = new GetSalesListModel();



            return Task.CompletedTask;
        }
    }
}