using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShowroom.Models.Vehicles;
using CarShowroom.ViewModel.Base;

namespace CarShowroom.ViewModel.Administration.Vehicles
{
    public class VehiclesListViewModel : BaseViewModel
    {
        private ObservableCollection<VehicleGridModel> _vehicleCollection;
        public ObservableCollection<VehicleGridModel> VehicleCollection
        {
            get => _vehicleCollection;
            set => _vehicleCollection = value;
        }

        public VehiclesListViewModel()
        {
            _vehicleCollection = new ObservableCollection<VehicleGridModel>();
        }

        public override void SetDefaultValues() { }
    }
}
