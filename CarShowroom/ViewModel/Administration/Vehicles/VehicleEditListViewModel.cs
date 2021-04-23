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
using CarShowroom.Entities.Models.TransferModels.Vehicles;
using CarShowroom.Handlers.Interfaces.Vehicles;
using CarShowroom.Models.Vehicles;
using CarShowroom.ViewModel.Base;
using GalaSoft.MvvmLight.CommandWpf;
using Newtonsoft.Json;
using Ninject;

namespace CarShowroom.ViewModel.Administration.Vehicles
{
    public class VehicleEditListViewModel : BaseViewModel
    {
        [Inject]
        public IGetVehicleListHandler GetVehicleListHandler { get; set; }

        [Inject]
        public ISearchVehiclesHandler SearchVehiclesHandler { get; set; }

        [Inject]
        public IEditVehicleHandler EditVehicleHandler { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        private ObservableCollection<VehicleGridModel> _vehicleCollection;
        public ObservableCollection<VehicleGridModel> VehicleCollection
        {
            get => _vehicleCollection;
            set
            { _vehicleCollection = value; OnPropertyChanged(); }
        }

        private SearchVehicleModel _searchVehicleModel;
        public SearchVehicleModel SearchModel
        {
            get => _searchVehicleModel;
            set { _searchVehicleModel = value; OnPropertyChanged(); }
        }

        public ICommand SearchVehicles { get; set; }

        public ICommand SaveVehicleCommand { get; set; }

        public VehicleEditListViewModel()
        {
            _vehicleCollection = new ObservableCollection<VehicleGridModel>();
            VehicleCollection.Add(new VehicleGridModel()
            {
                Id = Guid.NewGuid(),
                Number = 1,
                Cost = 2420.3m,
                IsMaintaining = true,
                IsSaled = false,
                Salable = true,
                Mark = "Mercedes-Benz",
                Model = "C-64"
            });
            VehicleCollection.Add(new VehicleGridModel()
            {
                Id = Guid.NewGuid(),
                Number = 2,
                Cost = 4750.5m,
                IsMaintaining = false,
                IsSaled = true,
                Salable = false,
                Mark = "BMW",
                Model = "X6"
            });

            SaveVehicleCommand = new RelayCommand<Guid>(SaveVehicleCommandExecuted);
            SearchVehicles = new RelayCommand(SearchVehiclesCommandExecuted);
        }

        private void SearchVehiclesCommandExecuted()
        {
            var recievedData = SearchVehiclesHandler.SearchVehicles(SearchModel);

            if (recievedData.RequestResult == RequestResult.Success)
            {
                var vehiclesList = JsonConvert.DeserializeObject<List<VehicleAnswerModel>>(recievedData.Object);
                var gridList = Mapper.Map<List<VehicleGridModel>>(vehiclesList);

                VehicleCollection = new ObservableCollection<VehicleGridModel>(gridList);
            }
        }

        private void SaveVehicleCommandExecuted(Guid vehicleId)
        {
            var choosedAuto = VehicleCollection.FirstOrDefault(v => v.Id == vehicleId);
            var editVehicle = Mapper.Map<EditVehicleModel>(choosedAuto);

            var recievedData = EditVehicleHandler.EditVehicle(editVehicle);

            if (recievedData.RequestResult == RequestResult.Success)
            {
                var vehicleResult = JsonConvert.DeserializeObject<VehicleAnswerModel>(recievedData.Object);
                
                var vehicleGridItem = Mapper.Map<VehicleGridModel>(vehicleResult);
                vehicleGridItem.Number = choosedAuto.Number;

                VehicleCollection[VehicleCollection.IndexOf(choosedAuto)] = vehicleGridItem;
            }
        }

        public override async Task SetDefaultValues()
        {
            SearchModel = new SearchVehicleModel();
            await Application.Current.Dispatcher.Invoke(async () =>
            {
                var recievedData = GetVehicleListHandler.GetVehicleList();

                if (recievedData.RequestResult == RequestResult.Success)
                {
                    var vehiclesList = JsonConvert.DeserializeObject<List<VehicleAnswerModel>>(recievedData.Object);
                    var gridList = Mapper.Map<List<VehicleGridModel>>(vehiclesList);

                    int counter = 1;
                    gridList.ForEach(gl => gl.Number = counter++);

                    VehicleCollection = new ObservableCollection<VehicleGridModel>(gridList);
                }
            });
        }
    }
}