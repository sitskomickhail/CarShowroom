using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CarShowroom.Interfaces;
using CarShowroom.ViewModel.Client;

namespace CarShowroom.Controls.Client
{
    /// <summary>
    /// Interaction logic for MarketplaceControl.xaml
    /// </summary>
    public partial class MarketplaceControl : UserControl, IControl
    {
        public MarketplaceViewModel ViewModel { get; set; }

        public MarketplaceControl(MarketplaceViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = ViewModel;

            InitializeComponent();
        }

        private void AddToCart_OnClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            Guid vehicleId = Guid.Parse(clickedButton.DataContext.ToString());

            ViewModel.AddToCartCommand.Execute(vehicleId);
        }

        public async Task LoadInitialData()
        {
            await ViewModel.SetDefaultValues();
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            e.Handled = true;
        }
    }
}