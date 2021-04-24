using System.ComponentModel;
using System.Windows;
using CarShowroom.Interfaces;
using CarShowroom.ViewModel;

namespace CarShowroom.View
{
    /// <summary>
    /// Interaction logic for AdministrationWindow.xaml
    /// </summary>
    public partial class AdministrationWindow : IWindow
    {
        public AdministartorWindowViewModel ViewModel { get; set; }

        public AdministrationWindow(AdministartorWindowViewModel viewModel)
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

        private void AdministrationWindow_OnClosing(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}