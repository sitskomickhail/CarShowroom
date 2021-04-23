using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CarShowroom.Interfaces;
using CarShowroom.View;
using CarShowroom.ViewModel.Base;
using GalaSoft.MvvmLight.CommandWpf;

namespace CarShowroom.ViewModel
{
    public class EmployeeWindowViewModel : BaseViewModel
    {
        public ICommand BackToLoginCommand { get; set; }

        public EmployeeWindowViewModel()
        {
            BackToLoginCommand = new RelayCommand<IWindow>(BackToLoginCommandExecute);
        }

        public void BackToLoginCommandExecute(IWindow currentWindow)
        {
            //LoginWindow window = new LoginWindow();
            //window.Show();

            currentWindow.CloseWindow();
        }

        public override Task SetDefaultValues() { return Task.CompletedTask; }
    }
}