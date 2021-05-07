using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using CarShowroom.Interfaces;
using CarShowroom.ViewModel;

namespace CarShowroom.View
{
    /// <summary>
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : IWindow
    {
        private const string _salesTabName = "Sales";
        private const string _vehiclesTabName = "Vehicles";

        public EmployeeWindowViewModel ViewModel { get; set; }

        public EmployeeWindow(EmployeeWindowViewModel viewModel)
        {
            ViewModel = viewModel;
            this.DataContext = viewModel;

            InitializeComponent();
        }

        public void CloseWindow()
        {
            this.Visibility = Visibility.Hidden;
        }

        public async void SetDefault()
        {
            await ViewModel.SetDefaultValues();
        }

        private void EmployeeWindow_OnClosing(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var tabControl = sender as TabControl;
                string name = tabControl.Name;

                Type sourceType = e.AddedItems[0].GetType();

                if (name.Equals(_vehiclesTabName, StringComparison.Ordinal) && sourceType == typeof(TabItem))
                {
                    ViewModel.ReloadVehicles();
                }
                else if (name.Equals(_salesTabName, StringComparison.Ordinal) && sourceType == typeof(TabItem))
                {
                    ViewModel.ReloadSales();
                }

                e.Handled = true;
            }
        }
    }
}