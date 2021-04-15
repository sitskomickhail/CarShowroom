using System.Windows;
using System.Windows.Input;
using CarShowroom.Interfaces;
using CarShowroom.View;
using CarShowroom.ViewModel.Base;
using GalaSoft.MvvmLight.CommandWpf;
using Ninject;

namespace CarShowroom.ViewModel
{
    public class AdministartorWindowViewModel : BaseViewModel
    {
        [Inject]
        public LoginWindow LoginWindow { get; set; }

        public ICommand BackToLoginCommand { get; set; }

        public ICommand MenuElementCommand { get; set; }
        
        public AdministartorWindowViewModel()
        {
            BackToLoginCommand = new RelayCommand<IWindow>(OnBackToLoginCommandExecuted, null);
        }

        private void OnBackToLoginCommandExecuted(IWindow currentWindow)
        {
            LoginWindow.SetDefault();
            LoginWindow.Show();

            currentWindow.CloseWindow();
        }

        public override void SetDefaultValues() { }
    }
}