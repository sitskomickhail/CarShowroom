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
            ViewModel.SetDefaultValues();
        }
    }
}