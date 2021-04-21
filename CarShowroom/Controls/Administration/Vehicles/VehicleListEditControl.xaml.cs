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
using CarShowroom.Entities.DatabaseModels;
using CarShowroom.ViewModel.Administration.Vehicles;

namespace CarShowroom.Controls.Administration.Vehicles
{
    /// <summary>
    /// Interaction logic for VehicleListEditControl.xaml
    /// </summary>
    public partial class VehicleListEditControl : UserControl
    {
        public VehicleEditListViewModel ViewModel { get; set; }

        public VehicleListEditControl(VehicleEditListViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = ViewModel;
            InitializeComponent();
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {

        }
    }
}