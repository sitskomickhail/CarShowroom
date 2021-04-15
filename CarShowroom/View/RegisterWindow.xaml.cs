using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
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

        private void RegisterWindow_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }
    }
}