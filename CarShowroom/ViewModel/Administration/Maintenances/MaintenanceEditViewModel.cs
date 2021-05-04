using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AutoMapper;
using CarShowroom.Entities.Models.AnswerModels.Maintenances;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Maintenances;
using CarShowroom.Handlers.Interfaces.Maintenances;
using CarShowroom.Models.Maintenances;
using CarShowroom.ViewModel.Base;
using GalaSoft.MvvmLight.CommandWpf;
using Newtonsoft.Json;
using Ninject;
using RelayCommand = GalaSoft.MvvmLight.Command.RelayCommand;

namespace CarShowroom.ViewModel.Administration.Maintenances
{
    public class MaintenanceEditViewModel : BaseViewModel
    {
        [Inject]
        public IGetMaintenancesHandler GetMaintenancesHandler { get; set; }

        [Inject]
        public IEditMaintenanceHandler EditMaintenanceHandler { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        private GetMaintenanceListModel _maintenanceListModel;
        public GetMaintenanceListModel GetMaintenanceListModel
        {
            get => _maintenanceListModel;
            set { _maintenanceListModel = value; OnPropertyChanged(); }
        }

        private ObservableCollection<MaintenanceGridModel> _maintenanceCollection;
        public ObservableCollection<MaintenanceGridModel> MaintenanceCollection
        {
            get => _maintenanceCollection;
            set { _maintenanceCollection = value; OnPropertyChanged(); }
        }

        public ICommand SearchMaintenancesCommand { get; set; }

        public ICommand SaveMaintenanceCommand { get; set; }

        public MaintenanceEditViewModel()
        {
            GetMaintenanceListModel = new GetMaintenanceListModel();
            MaintenanceCollection = new ObservableCollection<MaintenanceGridModel>();

            SearchMaintenancesCommand = new RelayCommand(SearchMaintenancesCommandExecuted);
            SaveMaintenanceCommand = new RelayCommand<Guid>(EditMaintenanceCommandExecuted);
        }

        private void SearchMaintenancesCommandExecuted()
        {
            var recievedData = GetMaintenancesHandler.GetMaintenances(GetMaintenanceListModel);

            if (recievedData.RequestResult == RequestResult.Success)
            {
                var maintenanceList = JsonConvert.DeserializeObject<List<MaintenanceAnswerModel>>(recievedData.Object);
                var gridList = Mapper.Map<List<MaintenanceGridModel>>(maintenanceList);

                int counter = 1;
                gridList.ForEach(gl => gl.Position = counter++);

                MaintenanceCollection = new ObservableCollection<MaintenanceGridModel>(gridList);
            }
        }

        private void EditMaintenanceCommandExecuted(Guid maintenanceId)
        {
            var maintenance = MaintenanceCollection.FirstOrDefault(m => m.Id == maintenanceId);
            var editedMaintenance = Mapper.Map<EditMaintenanceModel>(maintenance);

            var recievedData = EditMaintenanceHandler.EditMaintenance(editedMaintenance);
            if (recievedData.RequestResult == RequestResult.Success)
            {
                SearchMaintenancesCommandExecuted();
            }
        }

        public override async Task SetDefaultValues()
        {
            GetMaintenanceListModel = new GetMaintenanceListModel();
            MaintenanceCollection = new ObservableCollection<MaintenanceGridModel>();

            await Application.Current.Dispatcher.Invoke(async () =>
            {
                SearchMaintenancesCommandExecuted();
            });
        }
    }
}