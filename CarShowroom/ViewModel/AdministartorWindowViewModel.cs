using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CarShowroom.Helpers;
using CarShowroom.Interfaces;
using CarShowroom.View;
using CarShowroom.ViewModel.Base;
using GalaSoft.MvvmLight.CommandWpf;

namespace CarShowroom.ViewModel
{
    public class AdministartorWindowViewModel : BaseViewModel
    {
        public ICommand BackToLoginCommand { get; set; }

        public AdministartorWindowViewModel()
        {
            BackToLoginCommand = new RelayCommand<IClosable>(OnBackToLoginCommandExecuted, null);
        }

        private void OnBackToLoginCommandExecuted(IClosable currentWindow)
        {
            LoginWindow window = new LoginWindow();
            window.Show();

            currentWindow.CloseWindow();
        }


    }
}