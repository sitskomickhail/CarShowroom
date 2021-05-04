using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class VehiclesListViewModel : BaseViewModel
    {
        [Inject]
        public IGetVehicleListHandler GetVehicleListHandler { get; set; }

        [Inject]
        public ISearchVehiclesHandler SearchVehiclesHandler { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        private ObservableCollection<VehicleGridModel> _vehicleCollection;
        public ObservableCollection<VehicleGridModel> VehicleCollection
        {
            get => _vehicleCollection;
            set
            { _vehicleCollection = value; OnPropertyChanged(); }
        }

        private SearchVehicleModel _searchModel;
        public SearchVehicleModel SearchModel
        {
            get { return _searchModel; }
            set { _searchModel = value; OnPropertyChanged(); }
        }

        public ICommand SearchVehicles { get; set; }

        public VehiclesListViewModel()
        {
            _vehicleCollection = new ObservableCollection<VehicleGridModel>();
            
            SearchVehicles = new RelayCommand(SearchVehiclesCommandExecuted);
        }

        private void SearchVehiclesCommandExecuted()
        {
            var recievedData = SearchVehiclesHandler.SearchVehicles(SearchModel);

            if (recievedData.RequestResult == RequestResult.Success)
            {
                if (recievedData.RequestResult == RequestResult.Success)
                {
                    var vehiclesList = JsonConvert.DeserializeObject<List<VehicleAnswerModel>>(recievedData.Object);
                    var gridList = Mapper.Map<List<VehicleGridModel>>(vehiclesList);

                    int counter = 1;
                    gridList.ForEach(gl => gl.Number = counter++);

                    VehicleCollection = new ObservableCollection<VehicleGridModel>(gridList);
                }
            }
        }

        public override async Task SetDefaultValues()
        {
            SearchModel = new SearchVehicleModel();
            await Application.Current.Dispatcher.Invoke(async () =>
            {
                var recievedData = GetVehicleListHandler.GetVehicleList(new GetVehicleListModel());

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
