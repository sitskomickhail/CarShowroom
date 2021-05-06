using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AutoMapper;
using CarShowroom.Entities.Models.AnswerModels.Maintenances;
using CarShowroom.Entities.Models.AnswerModels.Vehicles;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Maintenances;
using CarShowroom.Entities.Models.TransferModels.Vehicles;
using CarShowroom.Handlers.Interfaces.Maintenances;
using CarShowroom.Handlers.Interfaces.Vehicles;
using CarShowroom.Models.Maintenances;
using CarShowroom.Models.Vehicles;
using CarShowroom.ViewModel.Base;
using GalaSoft.MvvmLight.CommandWpf;
using Newtonsoft.Json;
using Ninject;

namespace CarShowroom.ViewModel.Client
{
    public class ClientMaintenanceViewModel : BaseViewModel
    {
        [Inject]
        public IGetMaintenanceStatisticsHandler GetMaintenanceStatisticsHandler { get; set; }

        [Inject]
        public IGetClientMaintenancesHandler GetClientMaintenancesHandler { get; set; }

        [Inject]
        public IGetClientVehiclesHandler GetClientVehiclesHandler { get; set; }

        [Inject]
        public ICreateMaintenanceHandler CreateMaintenanceHandler { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public Guid CurrentUserId { get; set; }

        private ObservableCollection<MaintenanceGridModel> _maintenanceCollection;
        public ObservableCollection<MaintenanceGridModel> MaintenanceCollection
        {
            get => _maintenanceCollection;
            set { _maintenanceCollection = value; OnPropertyChanged(); }
        }

        private ObservableCollection<VehicleGridModel> _vehicleCollection;
        public ObservableCollection<VehicleGridModel> VehicleCollection
        {
            get => _vehicleCollection;
            set
            { _vehicleCollection = value; OnPropertyChanged(); }
        }

        private ObservableCollection<MaintenanceStatisticsGridModel> _maintenanceStatistics;
        public ObservableCollection<MaintenanceStatisticsGridModel> MaintenanceStatistics
        {
            get { return _maintenanceStatistics; }
            set { _maintenanceStatistics = value; }
        }

        public ICommand AddRepairCommand { get; set; }

        public ClientMaintenanceViewModel()
        {
            AddRepairCommand = new RelayCommand<Guid>(AddRepairCommandExecuted);
        }

        private void GetMaintenanceStatistics()
        {
            var recievedData = GetMaintenanceStatisticsHandler.GetMaintenanceStatistics(new GetMaintenanceStatisticModel() { UserId = CurrentUserId });
            if (recievedData.RequestResult == RequestResult.Success)
            {
                var vehiclesList = JsonConvert.DeserializeObject<List<MaintenanceStatisticAnswerModel>>(recievedData.Object);
                var gridList = Mapper.Map<List<MaintenanceStatisticsGridModel>>(vehiclesList);

                MaintenanceStatistics = new ObservableCollection<MaintenanceStatisticsGridModel>(gridList);
            }
        }

        private void GetClientMaintenances()
        {
            var recievedData = GetClientVehiclesHandler.GetClientVehicles(new GetClientVehiclesModel() { UserId = CurrentUserId });

            if (recievedData.RequestResult == RequestResult.Success)
            {
                var vehiclesList = JsonConvert.DeserializeObject<List<MaintenanceAnswerModel>>(recievedData.Object);
                var gridList = Mapper.Map<List<MaintenanceGridModel>>(vehiclesList);

                MaintenanceCollection = new ObservableCollection<MaintenanceGridModel>(gridList);
            }
        }

        private void GetClientVehicles()
        {
            var recievedData = GetClientVehiclesHandler.GetClientVehicles(new GetClientVehiclesModel() { UserId = CurrentUserId });
            if (recievedData.RequestResult == RequestResult.Success)
            {
                var vehiclesList = JsonConvert.DeserializeObject<List<VehicleAnswerModel>>(recievedData.Object);
                var gridList = Mapper.Map<List<VehicleGridModel>>(vehiclesList);

                int counter = 1;
                gridList.ForEach(gl => gl.Number = counter++);

                VehicleCollection = new ObservableCollection<VehicleGridModel>(gridList);
            }
        }

        private async void AddRepairCommandExecuted(Guid vehicleId)
        {
            CreateMaintenanceModel createModel = new CreateMaintenanceModel()
            {
                UserId = CurrentUserId,
                VehicleId = vehicleId
            };

            var recievedData = CreateMaintenanceHandler.CreateMaintenance(createModel);
            if (recievedData.RequestResult == RequestResult.Success)
            {
                await SetDefaultValues();
                MessageBox.Show("Vehicle added to cart successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show(recievedData.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override async Task SetDefaultValues()
        {
            MaintenanceCollection = new ObservableCollection<MaintenanceGridModel>();
            VehicleCollection = new ObservableCollection<VehicleGridModel>();
            MaintenanceStatistics = new ObservableCollection<MaintenanceStatisticsGridModel>();

            await Application.Current.Dispatcher.Invoke(async () =>
            {
                GetClientVehicles();
                GetClientMaintenances();
                GetMaintenanceStatistics();
            });
        }
    }
}