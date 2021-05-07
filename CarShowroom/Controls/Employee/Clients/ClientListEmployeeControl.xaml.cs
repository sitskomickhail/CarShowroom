using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CarShowroom.ViewModel.Administration.Clients;

namespace CarShowroom.Controls.Employee.Clients
{
    /// <summary>
    /// Interaction logic for ClientListEmployeeControl.xaml
    /// </summary>
    public partial class ClientListEmployeeControl : UserControl
    {
        public ClientListViewModel ViewModel { get; set; }

        public ClientListEmployeeControl(ClientListViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = ViewModel;

            InitializeComponent();
        }

        private void ViewButton_OnClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            Guid clientId = Guid.Parse(clickedButton.DataContext.ToString());

            ViewModel.ViewClientInfoCommand.Execute(clientId);
        }

        public async Task LoadInitialData()
        {
            await ViewModel.SetDefaultValues();
        }
    }
}