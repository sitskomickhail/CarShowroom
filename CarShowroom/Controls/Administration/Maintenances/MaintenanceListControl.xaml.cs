using System.Threading.Tasks;
using System.Windows.Controls;
using CarShowroom.Interfaces;
using CarShowroom.ViewModel.Administration.Maintenances;

namespace CarShowroom.Controls.Administration.Maintenances
{
    /// <summary>
    /// Interaction logic for MaintenanceListControl.xaml
    /// </summary>
    public partial class MaintenanceListControl : UserControl, IControl
    {
        public MaintenanceListViewModel ViewModel { get; set; }

        public MaintenanceListControl(MaintenanceListViewModel viewModel)
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