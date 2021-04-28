using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CarShowroom.Interfaces;
using CarShowroom.ViewModel.Administration.Clients;

namespace CarShowroom.Controls.Administration.Clients
{
    /// <summary>
    /// Interaction logic for ClientListControl.xaml
    /// </summary>
    public partial class ClientListControl : UserControl, IControl
    {
        public ClientListViewModel ViewModel { get; set; }

        public ClientListControl(ClientListViewModel viewModel)
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