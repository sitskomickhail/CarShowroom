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

namespace CarShowroom.Controls.Administration.Sales
{
    /// <summary>
    /// Interaction logic for CreateSaleControl.xaml
    /// </summary>
    public partial class CreateSaleControl : UserControl, IControl
    {
        public CreateSaleControl()
        {
            InitializeComponent();
        }

        public Task LoadInitialData()
        {
            return Task.CompletedTask;
        }
    }
}
