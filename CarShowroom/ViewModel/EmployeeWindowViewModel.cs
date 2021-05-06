using System.Threading.Tasks;
using System.Windows.Input;
using CarShowroom.Controls.Administration.Clients;
using CarShowroom.Controls.Administration.Maintenances;
using CarShowroom.Controls.Administration.Sales;
using CarShowroom.Controls.Administration.Vehicles;
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
        
        [Inject] public VehicleCreateControl VehicleCreateControl { get; set; }

        [Inject] public VehicleListEditControl VehicleListEditControl { get; set; }
        
        [Inject] public ClientListControl ClientListControl { get; set; }

        [Inject] public SaleListControl SaleListControl { get; set; }

        [Inject] public AcceptSalesControl AcceptSalesControl { get; set; }

        [Inject] public MaintenanceListControl MaintenanceListControl { get; set; }

        [Inject] public MaintenanceEditControl MaintenanceEditControl { get; set; }

        public ICommand BackToLoginCommand { get; set; }

        public ICommand TabItemChooseCommand { get; set; }

        public EmployeeWindowViewModel()
        {
            BackToLoginCommand = new RelayCommand<IWindow>(BackToLoginCommandExecute);
            TabItemChooseCommand = new RelayCommand(OnTabItemChooseCommandExecuted);
        }

        private async void OnTabItemChooseCommandExecuted()
        {
            await VehicleCreateControl.LoadInitialData();
            await VehicleListEditControl.LoadInitialData();
            await ClientListControl.LoadInitialData();
            await SaleListControl.LoadInitialData();
            await AcceptSalesControl.LoadInitialData();
            await MaintenanceListControl.LoadInitialData();
            await MaintenanceEditControl.LoadInitialData();
        }

        public void BackToLoginCommandExecute(IWindow currentWindow)
        {
            LoginWindow.SetDefault();
            LoginWindow.Show();

            currentWindow.CloseWindow();
        }

        public async void ReloadVehicles()
        {
            await VehicleCreateControl.LoadInitialData();
            await VehicleListEditControl.LoadInitialData();
        }

        public async void ReloadSales()
        {
            await SaleListControl.LoadInitialData();
            await AcceptSalesControl.LoadInitialData();
        }

        public override async Task SetDefaultValues()
        {
            await VehicleCreateControl.LoadInitialData();
            await VehicleListEditControl.LoadInitialData();
            await ClientListControl.LoadInitialData();
            await SaleListControl.LoadInitialData();
            await AcceptSalesControl.LoadInitialData();
            await MaintenanceListControl.LoadInitialData();
            await MaintenanceEditControl.LoadInitialData();
        }
    }
}