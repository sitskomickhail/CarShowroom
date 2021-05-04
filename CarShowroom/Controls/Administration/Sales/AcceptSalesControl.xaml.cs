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
            var result = MessageBox.Show("Do you really want to block this client?",
                "Warning",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question,
                MessageBoxResult.No);

            if (result == MessageBoxResult.Yes)
            {
                Button clickedButton = sender as Button;
                Guid clientId = Guid.Parse(clickedButton.DataContext.ToString());

                ViewModel.DeclineSaleCommand.Execute(clientId);
            }
        }
    }
}