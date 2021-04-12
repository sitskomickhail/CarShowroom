using System.ComponentModel;
using System.Windows;
using CarShowroom.Interfaces;
using CarShowroom.ViewModel;

namespace CarShowroom.View
{
    /// <summary>
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : IWindow
    {
        public EmployeeWindowViewModel ViewModel { get; set; }
        
        public EmployeeWindow(EmployeeWindowViewModel viewModel)
        {
            ViewModel = viewModel;
            this.DataContext = viewModel;
            
            InitializeComponent();
        }

        public void CloseWindow()
        {
            this.Visibility = Visibility.Hidden;
        }

        public void SetDefault()
        {
            ViewModel.SetDefaultValues();

            this.DataContext = ViewModel;
        }

        private void EmployeeWindow_OnClosing(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}