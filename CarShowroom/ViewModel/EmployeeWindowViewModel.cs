using System.Threading.Tasks;
using System.Windows.Input;
using CarShowroom.Controls.Employee.Clients;
using CarShowroom.Controls.Employee.Maintenances;
using CarShowroom.Controls.Employee.Resolutions;
using CarShowroom.Controls.Employee.Sales;
using CarShowroom.Controls.Employee.Vehicles;
using CarShowroom.Interfaces;
using CarShowroom.View;
using CarShowroom.ViewModel.Base;
using GalaSoft.MvvmLight.CommandWpf;
using Ninject;

namespace CarShowroom.ViewModel
{
    public class EmployeeWindowViewModel : BaseViewModel
    {
        [Inject]
        public LoginWindow LoginWindow { get; set; }

        [Inject] public VehicleCreateEmployeeControl VehicleCreateEmployeeControl { get; set; }

        [Inject] public VehicleEditListEmployeeControl VehicleEditListEmployeeControl { get; set; }

        [Inject] public ClientListEmployeeControl ClientListEmployeeControl { get; set; }

        [Inject] public SaleListEmployeeControl SaleListEmployeeControl { get; set; }

        [Inject] public AcceptSaleEmployeeControl AcceptSaleEmployeeControl { get; set; }

        [Inject] public MaintenanceEditEmployeeControl MaintenanceEditEmployeeControl { get; set; }

        [Inject] public InitializeResolutionControl InitializeResolutionControl { get; set; }

        public ICommand BackToLoginCommand { get; set; }

        public ICommand TabItemChooseCommand { get; set; }

        public EmployeeWindowViewModel()
        {
            BackToLoginCommand = new RelayCommand<IWindow>(BackToLoginCommandExecute);
            TabItemChooseCommand = new RelayCommand(OnTabItemChooseCommandExecuted);
        }

        private async void OnTabItemChooseCommandExecuted()
        {
            await VehicleCreateEmployeeControl.LoadInitialData();
            await VehicleEditListEmployeeControl.LoadInitialData();
            await ClientListEmployeeControl.LoadInitialData();
            await SaleListEmployeeControl.LoadInitialData();
            await AcceptSaleEmployeeControl.LoadInitialData();
            await MaintenanceEditEmployeeControl.LoadInitialData();
            await InitializeResolutionControl.LoadInitialData();
        }

        public void BackToLoginCommandExecute(IWindow currentWindow)
        {
            LoginWindow.SetDefault();
            LoginWindow.Show();

            currentWindow.CloseWindow();
        }

        public async void ReloadVehicles()
        {
            await VehicleCreateEmployeeControl.LoadInitialData();
            await VehicleEditListEmployeeControl.LoadInitialData();
        }

        public async void ReloadSales()
        {
            await SaleListEmployeeControl.LoadInitialData();
            await AcceptSaleEmployeeControl.LoadInitialData();
        }

        public async void ReloadResolution()
        {
            await InitializeResolutionControl.LoadInitialData();
        }

        public override async Task SetDefaultValues()
        {
            await VehicleEditListEmployeeControl.LoadInitialData();
            await ClientListEmployeeControl.LoadInitialData();
            await MaintenanceEditEmployeeControl.LoadInitialData();
        }
    }
}