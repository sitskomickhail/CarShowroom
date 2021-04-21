using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CarShowroom.ViewModel.Base;
using GalaSoft.MvvmLight.CommandWpf;

namespace CarShowroom.ViewModel.Administration.Vehicles
{
    public class VehicleCreateViewModel : BaseViewModel
    {
        public ICommand SaveVehicleCommand { get; set; }

        public VehicleCreateViewModel()
        {
            SaveVehicleCommand = new RelayCommand(SaveVehicleCommandExecuted);
        }

        private void SaveVehicleCommandExecuted()
        {
            
        }

        public override void SetDefaultValues() { }
    }
}
