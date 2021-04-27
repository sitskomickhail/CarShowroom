using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CarShowroom.Interfaces;
using CarShowroom.ViewModel.Administration.Clients;

namespace CarShowroom.Controls.Administration.Clients
{
    /// <summary>
    /// Interaction logic for ClientEditControl.xaml
    /// </summary>
    public partial class ClientEditControl : UserControl, IControl
    {
        public ClientEditViewModel ViewModel { get; set; }

        public ClientEditControl(ClientEditViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = ViewModel;

            InitializeComponent();
        }



        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            Guid vehicleId = Guid.Parse(clickedButton.DataContext.ToString());

            ViewModel.SaveClientCommand.Execute(vehicleId);
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Do you really want to block this client?",
                "Warning",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question,
                MessageBoxResult.No);

            if (result == MessageBoxResult.Yes)
            {
                Button clickedButton = sender as Button;
                Guid vehicleId = Guid.Parse(clickedButton.DataContext.ToString());

                ViewModel.DeleteClientCommand.Execute(vehicleId);
            }
        }

        public async Task LoadInitialData()
        {
            await ViewModel.SetDefaultValues();
        }
    }
}