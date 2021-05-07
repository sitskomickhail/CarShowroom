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
using CarShowroom.Interfaces;
using CarShowroom.ViewModel.Administration.Sales;

namespace CarShowroom.Controls.Employee.Sales
{
    /// <summary>
    /// Interaction logic for SaleListEmployeeControl.xaml
    /// </summary>
    public partial class SaleListEmployeeControl : UserControl, IControl
    {
        public SaleListViewModel ViewModel { get; set; }

        public SaleListEmployeeControl(SaleListViewModel viewModel)
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