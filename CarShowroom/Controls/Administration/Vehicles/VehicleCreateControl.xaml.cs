using System.Threading.Tasks;
using System.Windows.Controls;
using CarShowroom.Interfaces;
using CarShowroom.ViewModel.Administration.Vehicles;

namespace CarShowroom.Controls.Administration.Vehicles
{
    /// <summary>
    /// Interaction logic for VehicleCreateControl.xaml
    /// </summary>
    public partial class VehicleCreateControl : UserControl, IControl
    {
        public VehicleCreateViewModel ViewModel { get; set; }

        public VehicleCreateControl(VehicleCreateViewModel viewModel)
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