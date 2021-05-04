using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CarShowroom.Interfaces;
using CarShowroom.ViewModel.Administration.Sales;

namespace CarShowroom.Controls.Administration.Sales
{
    /// <summary>
    /// Interaction logic for AcceptSalesControl.xaml
    /// </summary>
    public partial class AcceptSalesControl : UserControl, IControl
    {
        public AcceptSalesViewModel ViewModel { get; set; }

        public AcceptSalesControl(AcceptSalesViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = ViewModel;

            InitializeComponent();
        }

        public async Task LoadInitialData()
        {
            await ViewModel.SetDefaultValues();
        }

        private void AcceptButton_OnClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            Guid clientId = Guid.Parse(clickedButton.DataContext.ToString());

            ViewModel.AcceptSaleCommand.Execute(clientId);
        }

        private void DeclineButton_OnClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            Guid clientId = Guid.Parse(clickedButton.DataContext.ToString());

            ViewModel.DeclineSaleCommand.Execute(clientId);
        }
    }
}