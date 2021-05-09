using System.Threading.Tasks;
using System.Windows.Controls;
using CarShowroom.Interfaces;
using CarShowroom.ViewModel.Employee.Resolutions;

namespace CarShowroom.Controls.Employee.Resolutions
{
    /// <summary>
    /// Interaction logic for ResolutionChartControl.xaml
    /// </summary>
    public partial class ResolutionChartControl : UserControl, IControl
    {
        public ResolutionChartViewModel ViewModel { get; set; }

        public ResolutionChartControl(ResolutionChartViewModel viewModel)
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