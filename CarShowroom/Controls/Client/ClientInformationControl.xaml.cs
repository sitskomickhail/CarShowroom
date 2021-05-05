using System.Threading.Tasks;
using System.Windows.Controls;
using CarShowroom.Interfaces;
using CarShowroom.ViewModel.Client;

namespace CarShowroom.Controls.Client
{
    /// <summary>
    /// Interaction logic for ClientInformationControl.xaml
    /// </summary>
    public partial class ClientInformationControl : UserControl, IControl
    {
        public InformationControlViewModel ViewModel { get; set; }

        public ClientInformationControl(InformationControlViewModel viewModel)
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