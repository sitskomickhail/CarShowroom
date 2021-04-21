using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CarShowroom.Controls.Administration;
using CarShowroom.Controls.Administration.Vehicles;
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

        [Inject] public VehicleListControl VehicleListControl { get; set; }

        [Inject] public VehicleCreateControl VehicleCreateControl { get; set; }

        [Inject] public VehicleListEditControl VehicleListEditControl { get; set; }

        private UserControl _currentControl;
        public UserControl CurrentControl
        {
            get { return _currentControl; }
            set { _currentControl = value; OnPropertyChanged(); }
        }


        public ICommand BackToLoginCommand { get; set; }

        public ICommand TreeViewItemSelectionCommand { get; set; }

        private string _status;
        public string Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged(); }
        }


        public AdministartorWindowViewModel()
        {
            BackToLoginCommand = new RelayCommand<IWindow>(OnBackToLoginCommandExecuted);
            TreeViewItemSelectionCommand = new RelayCommand<string>(OnSelectionElementChoise);
            //CurrentControl = new AdministrationBaseControl();
            CurrentControl = new UserControl();
        }

        private void OnSelectionElementChoise(string control)
        {
            switch (control)
            {
                case nameof(VehicleListControl): CurrentControl = VehicleListControl; break;
                case nameof(VehicleCreateControl): CurrentControl = VehicleCreateControl; break;
                case nameof(VehicleListEditControl): CurrentControl = VehicleListEditControl; break;
                default: CurrentControl = new AdministrationBaseControl(); break;
            }
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