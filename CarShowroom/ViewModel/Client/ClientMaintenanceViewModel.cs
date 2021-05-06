using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AutoMapper;
using CarShowroom.Handlers.Interfaces.Maintenances;
using CarShowroom.Handlers.Interfaces.Vehicles;
using CarShowroom.Models.Maintenances;
using CarShowroom.Models.Vehicles;
using CarShowroom.ViewModel.Base;
using GalaSoft.MvvmLight.CommandWpf;
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

        private void AddRepairCommandExecuted(Guid vehicleId)
        {

        }

        public override Task SetDefaultValues()
        {
            MaintenanceCollection = new ObservableCollection<MaintenanceGridModel>();
            VehicleCollection = new ObservableCollection<VehicleGridModel>();
            MaintenanceStatistics = new ObservableCollection<MaintenanceStatisticsGridModel>();

            return Task.CompletedTask;
        }
    }
}