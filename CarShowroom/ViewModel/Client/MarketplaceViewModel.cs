using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AutoMapper;
using CarShowroom.Entities.Models.AnswerModels.Vehicles;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Sales;
using CarShowroom.Entities.Models.TransferModels.Vehicles;
using CarShowroom.Handlers.Interfaces.Sales;
using CarShowroom.Handlers.Interfaces.Vehicles;
using CarShowroom.Models.Vehicles;
using CarShowroom.ViewModel.Base;
using GalaSoft.MvvmLight.CommandWpf;
using Newtonsoft.Json;
using Ninject;

namespace CarShowroom.ViewModel.Client
{
    public class MarketplaceViewModel : BaseViewModel
    {
        [Inject]
        public IGetVehicleListHandler GetVehicleListHandler { get; set; }

        [Inject]
        public ISearchSailingVehiclesHandler SearchSailingVehiclesHandler { get; set; }

        [Inject]
        public ICreateSaleHandler CreateSaleHandler { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public Guid CurrentUserId { get; set; }

        private ObservableCollection<VehicleGridModel> _vehicleCollection;
        public ObservableCollection<VehicleGridModel> VehicleCollection
        {
            get => _vehicleCollection;
            set
            { _vehicleCollection = value; OnPropertyChanged(); }
        }

        private ObservableCollection<VehicleGridModel> _vehicleCartCollection;
        public ObservableCollection<VehicleGridModel> VehicleCartCollection
        {
            get => _vehicleCartCollection;
            set { _vehicleCartCollection = value; OnPropertyChanged(); }
        }

        private GetSailingVehiclesModel _searchModel;
        public GetSailingVehiclesModel SearchModel
        {
            get { return _searchModel; }
            set { _searchModel = value; OnPropertyChanged(); }
        }

        private string _paymentMethod;
        public string PaymentMethod
        {
            get => _paymentMethod;
            set { _paymentMethod = value; OnPropertyChanged(); }
        }

        private decimal _totalCartCost;
        public decimal TotalCartCost
        {
            get => _totalCartCost;
            set { _totalCartCost = value; OnPropertyChanged(); }
        }
        
        public ICommand SearchVehicles { get; set; }

        public ICommand AddToCartCommand { get; set; }

        public ICommand ClearCartCommand { get; set; }

        public ICommand PurchaseVehiclesCommand { get; set; }

        public MarketplaceViewModel()
        {
            SearchVehicles = new RelayCommand(SearchVehiclesCommandExecuted);
            ClearCartCommand = new RelayCommand(ClearCartCommandExecuted);
            PurchaseVehiclesCommand = new RelayCommand(PurchaseVehiclesCommandExecuted);
            AddToCartCommand = new RelayCommand<Guid>(AddToCartCommandExecuted);
        }

        private void AddToCartCommandExecuted(Guid vehicleId)
        {
            var vehicle = VehicleCollection.FirstOrDefault(v => v.Id == vehicleId);

            VehicleCartCollection.Add(vehicle);
            VehicleCollection.Remove(vehicle);

            TotalCartCost += vehicle.Cost;
        }

        private async void PurchaseVehiclesCommandExecuted()
        {
            var saleModel = Mapper.Map<CreateSaleModel>(VehicleCartCollection);
            saleModel.UserId = CurrentUserId;
            saleModel.PaymentMethod = PaymentMethod;

            var recievedData = CreateSaleHandler.CreateSale(saleModel);

            if (recievedData.RequestResult == RequestResult.Success)
            {
                await SetDefaultValues();
                MessageBox.Show("Sale created successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show(recievedData.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ClearCartCommandExecuted()
        {
            await SetDefaultValues();
        }

        private void SearchVehiclesCommandExecuted()
        {
            var recievedData = SearchSailingVehiclesHandler.SearchSailingVehicles(SearchModel);

            if (recievedData.RequestResult == RequestResult.Success)
            {
                if (recievedData.RequestResult == RequestResult.Success)
                {
                    var vehiclesList = JsonConvert.DeserializeObject<List<VehicleAnswerModel>>(recievedData.Object);
                    var gridList = Mapper.Map<List<VehicleGridModel>>(vehiclesList);

                    int counter = 1;
                    gridList.ForEach(gl => gl.Number = counter++);

                    VehicleCollection = new ObservableCollection<VehicleGridModel>(gridList);
                    
                    foreach (var cartVehicle in VehicleCartCollection)
                    {
                        VehicleCollection.Remove(VehicleCollection.FirstOrDefault(v => v.Id == cartVehicle.Id));
                    }
                }
            }
        }

        public override async Task SetDefaultValues()
        {
            VehicleCollection = new ObservableCollection<VehicleGridModel>();
            VehicleCartCollection = new ObservableCollection<VehicleGridModel>();
            SearchModel = new GetSailingVehiclesModel();
            SearchModel.UserId = CurrentUserId;

            PaymentMethod = "Банковская карта";
            TotalCartCost = 0;

            await Application.Current.Dispatcher.Invoke(async () =>
            {
                SearchVehiclesCommandExecuted();
            });
        }
    }
}