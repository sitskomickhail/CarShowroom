﻿using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using CarShowroom.Controls.Administration;
using CarShowroom.Controls.Administration.Clients;
using CarShowroom.Controls.Administration.Maintenances;
using CarShowroom.Controls.Administration.Sales;
using CarShowroom.Controls.Administration.Users;
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

        [Inject] public UserListControl UserListControl { get; set; }
        
        [Inject] public UserEditControl UserEditControl { get; set; }
        
        [Inject] public UserCreateControl UserCreateControl { get; set; }

        [Inject] public ClientEditControl ClientEditControl { get; set; }
        
        [Inject] public ClientListControl ClientListControl { get; set; }
        
        [Inject] public SaleListControl SaleListControl { get; set; }

        [Inject] public AcceptSalesControl AcceptSalesControl { get; set; }

        [Inject] public MaintenanceListControl MaintenanceListControl { get; set; }

        [Inject] public MaintenanceEditControl MaintenanceEditControl { get; set; }
        
        private UserControl _currentControl;
        public UserControl CurrentControl
        {
            get { return _currentControl; }
            set { _currentControl = value; OnPropertyChanged(); }
        }

        public ICommand BackToLoginCommand { get; set; }

        public ICommand TreeViewItemSelectionCommand { get; set; }

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
                case nameof(VehicleListControl): VehicleListControl.LoadInitialData(); CurrentControl = VehicleListControl; break;
                case nameof(VehicleCreateControl): VehicleCreateControl.LoadInitialData(); CurrentControl = VehicleCreateControl; break;
                case nameof(VehicleListEditControl): VehicleListEditControl.LoadInitialData(); CurrentControl = VehicleListEditControl; break;
                case nameof(UserListControl): UserListControl.LoadInitialData(); CurrentControl = UserListControl; break;
                case nameof(UserEditControl): UserEditControl.LoadInitialData(); CurrentControl = UserEditControl; break;
                case nameof(UserCreateControl): UserCreateControl.LoadInitialData(); CurrentControl = UserCreateControl; break;
                case nameof(ClientEditControl): ClientEditControl.LoadInitialData(); CurrentControl = ClientEditControl; break;
                case nameof(ClientListControl): ClientListControl.LoadInitialData(); CurrentControl = ClientListControl; break;
                case nameof(SaleListControl): SaleListControl.LoadInitialData(); CurrentControl = SaleListControl; break;
                case nameof(AcceptSalesControl): AcceptSalesControl.LoadInitialData(); CurrentControl = AcceptSalesControl; break;
                case nameof(MaintenanceListControl): MaintenanceListControl.LoadInitialData(); CurrentControl = MaintenanceListControl; break;
                case nameof(MaintenanceEditControl): MaintenanceEditControl.LoadInitialData(); CurrentControl = MaintenanceEditControl; break;
                default: CurrentControl = new AdministrationBaseControl(); break;
            }
        }

        private void OnBackToLoginCommandExecuted(IWindow currentWindow)
        {
            LoginWindow.SetDefault();
            LoginWindow.Show();

            currentWindow.CloseWindow();
        }

        public override Task SetDefaultValues() { return Task.CompletedTask; }
    }
}