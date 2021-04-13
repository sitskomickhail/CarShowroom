using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using CarShowroom.Interfaces;
using CarShowroom.ViewModel;

namespace CarShowroom.View
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : IWindow
    {
        public RegisterWindowViewModel ViewModel { get; set; }

        public RegisterWindow(RegisterWindowViewModel viewModel)
        {
            ViewModel = viewModel;
            this.DataContext = ViewModel;

            InitializeComponent();
        }

        public void CloseWindow()
        {
            this.Visibility = Visibility.Hidden;
        }

        public void SetDefault()
        {
            ViewModel.SetDefaultValues();
        }

        private void RegisterWindow_OnClosing(object sender, CancelEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}