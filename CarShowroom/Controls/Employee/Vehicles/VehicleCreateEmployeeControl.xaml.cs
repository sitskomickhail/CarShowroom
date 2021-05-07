using System.Threading.Tasks;
using System.Windows.Controls;
using CarShowroom.Interfaces;
using CarShowroom.ViewModel.Administration.Vehicles;

namespace CarShowroom.Controls.Employee.Vehicles
{
    /// <summary>
    /// Interaction logic for VehicleCreateEmployeeControl.xaml
    /// </summary>
    public partial class VehicleCreateEmployeeControl : UserControl, IControl
    {
        public VehicleCreateViewModel ViewModel { get; set; }

        public VehicleCreateEmployeeControl(VehicleCreateViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = ViewModel;

            InitializeComponent();
        }

        public async Task LoadInitialData()
        {
            await ViewModel.SetDefaultValues();
        }
    }
}