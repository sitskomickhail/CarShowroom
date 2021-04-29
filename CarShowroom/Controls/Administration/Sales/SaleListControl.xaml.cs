using System.Threading.Tasks;
using System.Windows.Controls;
using CarShowroom.Interfaces;
using CarShowroom.ViewModel.Administration.Sales;

namespace CarShowroom.Controls.Administration.Sales
{
    /// <summary>
    /// Interaction logic for SaleListControl.xaml
    /// </summary>
    public partial class SaleListControl : UserControl, IControl
    {
        public SaleListViewModel ViewModel { get; set; }

        public SaleListControl(SaleListViewModel viewModel)
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