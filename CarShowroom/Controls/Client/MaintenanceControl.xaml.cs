using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CarShowroom.Interfaces;
using CarShowroom.ViewModel.Client;

namespace CarShowroom.Controls.Client
{
    /// <summary>
    /// Interaction logic for MaintenanceControl.xaml
    /// </summary>
    public partial class MaintenanceControl : UserControl, IControl
    {
        public ClientMaintenanceViewModel ViewModel { get; set; }

        public MaintenanceControl(ClientMaintenanceViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = ViewModel;

            InitializeComponent();
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            e.Handled = true;
        }

        private void StartRepair_OnClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            Guid vehicleId = Guid.Parse(clickedButton.DataContext.ToString());

            ViewModel.AddRepairCommand.Execute(vehicleId);
        }

        public async Task LoadInitialData()
        {
            await ViewModel.SetDefaultValues();
        }
    }
}