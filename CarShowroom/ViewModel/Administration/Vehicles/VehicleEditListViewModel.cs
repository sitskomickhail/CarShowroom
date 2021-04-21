using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CarShowroom.Models.Vehicles;
using CarShowroom.ViewModel.Base;
using GalaSoft.MvvmLight.CommandWpf;

namespace CarShowroom.ViewModel.Administration.Vehicles
{
    public class VehicleEditListViewModel : BaseViewModel
    {
        private ObservableCollection<VehicleGridModel> _vehicleCollection;
        public ObservableCollection<VehicleGridModel> VehicleCollection
        {
            get => _vehicleCollection;
            set
            { _vehicleCollection = value; OnPropertyChanged(); }
        }

        private string _searchParameter;
        public string SearchParameter
        {
            get { return _searchParameter; }
            set { _searchParameter = value; OnPropertyChanged(); }
        }

        public ICommand SearchVehicles { get; set; }

        public ICommand SaveVehicleCommand { get; set; }

        public ICommand EditVehicleCommand { get; set; }

        public VehicleEditListViewModel()
        {
            _vehicleCollection = new ObservableCollection<VehicleGridModel>();
            VehicleCollection.Add(new VehicleGridModel()
            {
                Id = Guid.NewGuid(),
                Number = 1,
                Cost = 2420.3m,
                IsMaintaining = false,
                IsSaled = false,
                Salable = true,
                Mark = "Mercedes-Benz",
                Model = "C-64"
            });

            SaveVehicleCommand = new RelayCommand(SaveVehicleCommandExecuted);
            SearchVehicles = new RelayCommand(SearchVehiclesCommandExecuted);
            EditVehicleCommand = new RelayCommand(EditVehicleCommandExecuted);
        }

        private void EditVehicleCommandExecuted()
        {
            Debug.WriteLine($"Edit button clicked");
        }

        private void SearchVehiclesCommandExecuted()
        {
            Debug.WriteLine($"Search button clicked = {SearchParameter}");
        }

        private void SaveVehicleCommandExecuted()
        {
            //Debug.WriteLine($"Saved button clicked = {vehicleId}");
            Debug.WriteLine($"Saved button clicked ");
        }

        public override void SetDefaultValues() { }
    }
}