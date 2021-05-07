using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CarShowroom.Interfaces;
using CarShowroom.ViewModel.Administration.Vehicles;

namespace CarShowroom.Controls.Employee.Vehicles
{
    /// <summary>
    /// Interaction logic for VehicleEditListEmployeeControl.xaml
    /// </summary>
    public partial class VehicleEditListEmployeeControl : UserControl, IControl
    {
        public VehicleEditListViewModel ViewModel { get; set; }

        public VehicleEditListEmployeeControl(VehicleEditListViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = ViewModel;

            InitializeComponent();
        }
        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            Guid vehicleId = Guid.Parse(clickedButton.DataContext.ToString());

            ViewModel.SaveVehicleCommand.Execute(vehicleId);
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Do you really want to delete this vehicle?",
                "Warning",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question,
                MessageBoxResult.No);

            if (result == MessageBoxResult.Yes)
            {
                Button clickedButton = sender as Button;
                Guid vehicleId = Guid.Parse(clickedButton.DataContext.ToString());

                ViewModel.DeleteVehicleCommand.Execute(vehicleId);
            }
        }

        public async Task LoadInitialData()
        {
            await ViewModel.SetDefaultValues();
        }
    }
}
