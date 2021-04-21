﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CarShowroom.Controls.Administration;
using CarShowroom.Models.Vehicles;
using CarShowroom.ViewModel.Base;
using GalaSoft.MvvmLight.CommandWpf;
using Ninject;

namespace CarShowroom.ViewModel.Administration.Vehicles
{
    public class VehiclesListViewModel : BaseViewModel
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

        public VehiclesListViewModel()
        {
            _vehicleCollection = new ObservableCollection<VehicleGridModel>();
            VehicleCollection.Add(new VehicleGridModel()
            {
                Number = 1,
                Cost = 2420.3m,
                IsMaintaining = false,
                IsSaled = false,
                Salable = true,
                Mark = "Mercedes-Benz",
                Model = "C-64"
            });

            SearchVehicles = new RelayCommand(SearchVehiclesCommandExecuted);
        }

        private void SearchVehiclesCommandExecuted()
        {

        }

        public override void SetDefaultValues() { }
    }
}
