using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Vehicles;
using CarShowroom.Handlers.Interfaces.Vehicles;
using CarShowroom.Helpers;
using CarShowroom.ViewModel.Base;
using Ninject;

namespace CarShowroom.ViewModel.Administration.Vehicles
{
    public class VehicleCreateViewModel : BaseViewModel
    {
        [Inject]
        public ICreateVehicleHandler CreateVehicleHandler { get; set; }

        private CreateVehicleModel _createVehicle;
        public CreateVehicleModel CreateVehicle
        {
            get => _createVehicle;
            set { _createVehicle = value; OnPropertyChanged(); }
        }

        public ICommand SaveVehicleCommand { get; set; }

        private string _isSalable;
        public string IsSalable
        {
            get => _isSalable;
            set
            {
                _isSalable = value;
                CreateVehicle.Salable = value == "Yes";
                OnPropertyChanged();
            }
        }

        public VehicleCreateViewModel()
        {
            SetDefaultValues();
            SaveVehicleCommand = new RelayCommand(SaveVehicleCommandExecuted, f => !String.IsNullOrEmpty(_createVehicle.Mark) 
                                                                                    && !String.IsNullOrEmpty(_createVehicle.Model) 
                                                                                    && _createVehicle.Cost > 0
                                                                                    && !String.IsNullOrEmpty(IsSalable));
        }

        private void SaveVehicleCommandExecuted(object obj)
        {
            var recievedData = CreateVehicleHandler.CreateVehicle(CreateVehicle);

            if (recievedData.RequestResult == RequestResult.Success)
            {
                MessageBox.Show("Vehicle created successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                CreateVehicle = new CreateVehicleModel();
            }
            else
            {
                MessageBox.Show(recievedData.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override Task SetDefaultValues()
        {
            CreateVehicle = new CreateVehicleModel();
            IsSalable = "Yes";

            return Task.CompletedTask;
        }
    }
}
