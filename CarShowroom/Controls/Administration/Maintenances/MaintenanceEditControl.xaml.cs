using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CarShowroom.Interfaces;
using CarShowroom.ViewModel.Administration.Maintenances;

namespace CarShowroom.Controls.Administration.Maintenances
{
    /// <summary>
    /// Interaction logic for MaintenanceEditControl.xaml
    /// </summary>
    public partial class MaintenanceEditControl : UserControl, IControl
    {
        public MaintenanceEditViewModel ViewModel { get; set; }

        public MaintenanceEditControl(MaintenanceEditViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = ViewModel;

            InitializeComponent();
        }

        public async Task LoadInitialData()
        {
            await ViewModel.SetDefaultValues();
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            Guid clientId = Guid.Parse(clickedButton.DataContext.ToString());

            ViewModel.SaveMaintenanceCommand.Execute(clientId);
        }
    }
}