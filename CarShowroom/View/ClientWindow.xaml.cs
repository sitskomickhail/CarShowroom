using System;
using System.ComponentModel;
using System.Windows;
using CarShowroom.Interfaces;
using CarShowroom.ViewModel;

namespace CarShowroom.View
{
    /// <summary>
    /// Interaction logic for ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window, IWindow
    {
        public ClientWindowViewModel ViewModel { get; set; }

        public ClientWindow(ClientWindowViewModel viewModel)
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
        
        private void ClientWindow_OnClosing(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}