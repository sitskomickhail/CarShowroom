using System;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;
using CarShowroom.Entities.DatabaseModels;
using CarShowroom.ViewModel.Administration.Vehicles;
using Ninject;

namespace CarShowroom.Controls.Administration.Vehicles
{
    /// <summary>
    /// Interaction logic for VehicleCreateControl.xaml
    /// </summary>
    public partial class VehicleCreateControl : UserControl
    {
        public VehiclesListViewModel ViewModel { get; set; }

        public VehicleCreateControl(VehiclesListViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = ViewModel;
            InitializeComponent();
        }

        private void VehicleCreateControl_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("qqqqq");
        }
    }
}
