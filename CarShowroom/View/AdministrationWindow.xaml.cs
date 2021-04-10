using System.Windows;
using CarShowroom.Interfaces;

namespace CarShowroom.View
{
    /// <summary>
    /// Interaction logic for AdministrationWindow.xaml
    /// </summary>
    public partial class AdministrationWindow : Window, IClosable
    {
        public AdministrationWindow()
        {
            InitializeComponent();
        }

        public void CloseWindow()
        {
            this.Close();
        }
    }
}