using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CarShowroom.Interfaces;
using CarShowroom.ViewModel.Administration.Vehicles;

namespace CarShowroom.Controls.Administration.Vehicles
{
    /// <summary>
    /// Interaction logic for VehicleListEditControl.xaml
    /// </summary>
    public partial class VehicleListEditControl : UserControl, IControl
    {
        public VehicleEditListViewModel ViewModel { get; set; }

        public VehicleListEditControl(VehicleEditListViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = ViewModel;

            InitializeComponent();
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            Guid vehicleId = Guid.Parse(clickedButton.DataContext.ToString());

            ViewModel.SaveVehicleCommand.Execute(vehicleId);
        }

        public async Task LoadInitialData()
        {
            ViewModel.SetDefaultValues();
        }
    }
}