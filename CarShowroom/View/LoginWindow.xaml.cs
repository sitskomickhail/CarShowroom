using System;
using System.ComponentModel;
using System.Windows;
using CarShowroom.Controls;
using CarShowroom.Interfaces;
using CarShowroom.ViewModel;

namespace CarShowroom.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : IWindow
    {
        public LoginWindowViewModel ViewModel { get; set; }

        public LoginWindow(LoginWindowViewModel viewModel)
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

            var passwordControl = this.FindName("passwordBox") as PasswordControl;
            passwordControl.SecurePassword = String.Empty;

            this.DataContext = ViewModel;
        }

        private void LoginWindow_OnClosing(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}