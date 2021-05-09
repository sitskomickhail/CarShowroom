using System.Threading.Tasks;
using System.Windows.Controls;
using CarShowroom.Interfaces;
using CarShowroom.ViewModel.Employee.Resolutions;

namespace CarShowroom.Controls.Employee.Resolutions
{
    /// <summary>
    /// Interaction logic for InitializeResolutionControl.xaml
    /// </summary>
    public partial class InitializeResolutionControl : UserControl, IControl
    {
        public InitializeResolutionViewModel ViewModel { get; set; }

        public InitializeResolutionControl(InitializeResolutionViewModel viewModel)
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