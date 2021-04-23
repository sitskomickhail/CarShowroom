using System.Threading.Tasks;
using System.Windows.Controls;
using CarShowroom.Interfaces;
using CarShowroom.ViewModel.Administration.Vehicles;

namespace CarShowroom.Controls.Administration.Vehicles
{
    /// <summary>
    /// Interaction logic for VehicleListControl.xaml
    /// </summary>
    public partial class VehicleListControl : UserControl, IControl
    {
        public VehiclesListViewModel ViewModel { get; set; }

        public VehicleListControl(VehiclesListViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = ViewModel;

            InitializeComponent();
        }

        public async Task LoadInitialData()
        {
            ViewModel.SetDefaultValues();
        }
    }
}