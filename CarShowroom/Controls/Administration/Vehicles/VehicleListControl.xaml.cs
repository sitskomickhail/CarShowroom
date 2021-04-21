﻿using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;
using CarShowroom.ViewModel.Administration.Vehicles;
using Ninject;

namespace CarShowroom.Controls.Administration.Vehicles
{
    /// <summary>
    /// Interaction logic for VehicleListControl.xaml
    /// </summary>
    public partial class VehicleListControl : UserControl
    {
        public VehiclesListViewModel ViewModel { get; set; }

        public VehicleListControl(VehiclesListViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = ViewModel;

            InitializeComponent();
        }

        private void VehicleListControl_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("list see");
        }
    }
}