using System.Windows;
using CarShowroom.Interfaces;

namespace CarShowroom.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window, IClosable
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        public void CloseWindow()
        {
            this.Close();
        }
    }
}