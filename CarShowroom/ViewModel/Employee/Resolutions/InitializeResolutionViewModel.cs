using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AutoMapper;
using CarShowroom.Entities.Models.AnswerModels.Resolutions;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Resolutions;
using CarShowroom.Handlers.Interfaces.Resolutions;
using CarShowroom.Models.Clients;
using CarShowroom.ViewModel.Base;
using GalaSoft.MvvmLight.CommandWpf;
using Newtonsoft.Json;
using Ninject;

namespace CarShowroom.ViewModel.Employee.Resolutions
{
    public class InitializeResolutionViewModel : BaseViewModel
    {
        [Inject]
        public IGetResolutionValuesHandler GetResolutionValuesHandler { get; set; }

        [Inject]
        public ISetResolutionValuesHandler SetResolutionValuesHandler { get; set; }

        private int _employeeHiringSuccessChance;
        public int EmployeeHiringSuccessChance
        {
            get => _employeeHiringSuccessChance;
            set
            {
                _employeeHiringSuccessChance = value;
                EmployeeHiringFailChance = 100 - value;

                OnPropertyChanged();
            }
        }

        private int _employeeHiringFailChance;
        public int EmployeeHiringFailChance
        {
            get => _employeeHiringFailChance;
            set { _employeeHiringFailChance = value; OnPropertyChanged(); }
        }

        private int _equipmentPurchaseSuccessChance;
        public int EquipmentPurchaseSuccessChance
        {
            get => _equipmentPurchaseSuccessChance;
            set
            {
                _equipmentPurchaseSuccessChance = value;
                EquipmentPurchaseFailChance = 100 - value;

                OnPropertyChanged();
            }
        }

        private int _equipmentPurchaseFailChance;
        public int EquipmentPurchaseFailChance
        {
            get => _equipmentPurchaseFailChance;
            set { _equipmentPurchaseFailChance = value; OnPropertyChanged(); }
        }

        private int _resolutionExpenses;
        public int ResolutionExpenses
        {
            get => _resolutionExpenses;
            set { _resolutionExpenses = value; OnPropertyChanged(); }
        }

        private bool _isEditingEnabled;
        public bool IsEditingEnabled
        {
            get => _isEditingEnabled;
            set { _isEditingEnabled = value; OnPropertyChanged(); }
        }

        public ICommand SetDefaultResolutionValues { get; set; }

        public ICommand EditResolutionCommand { get; set; }

        public ICommand SaveResolutionCommand { get; set; }

        public InitializeResolutionViewModel()
        {
            SetDefaultResolutionValues = new RelayCommand(SetDefaultResolutionValuesExecuted);
            EditResolutionCommand = new RelayCommand(EditResolutionCommandExecuted);
            SaveResolutionCommand = new RelayCommand(SaveResolutionCommandExecuted);
        }

        private void SaveResolutionCommandExecuted()
        {
            var initModel = new InitResolutionModel()
            {
                ResolutionExpenses = ResolutionExpenses,
                EmployeeHiringChance = EmployeeHiringSuccessChance,
                EquipmentPurchaseChance = EquipmentPurchaseSuccessChance
            };
            
            var recievedData = SetResolutionValuesHandler.SetResolutionValues(initModel);
            if (recievedData.RequestResult == RequestResult.Success)
            {
                GetResoltionValues();
                MessageBox.Show("Resolution info saved successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show(recievedData.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditResolutionCommandExecuted()
        {
            IsEditingEnabled = !IsEditingEnabled;
        }

        private void SetDefaultResolutionValuesExecuted()
        {
            IsEditingEnabled = true;

            ResolutionExpenses = 10000;
            EquipmentPurchaseSuccessChance = 65;
            EmployeeHiringSuccessChance = 50;
        }

        private void GetResoltionValues()
        {
            var recievedData = GetResolutionValuesHandler.GetResolutionValues(new GetResolutionValuesModel());

            if (recievedData.RequestResult == RequestResult.Success)
            {
                var resolutionValues = JsonConvert.DeserializeObject<ResolutionValuesAnswerModel>(recievedData.Object);

                if (resolutionValues != null)
                {
                    ResolutionExpenses = resolutionValues.ResolutionExpenses;
                    EquipmentPurchaseSuccessChance = resolutionValues.EquipmentPurchaseChance;
                    EmployeeHiringSuccessChance = resolutionValues.EmployeeHiringChance;
                }
            }
        }

        public override async Task SetDefaultValues()
        {
            IsEditingEnabled = false;

            await Application.Current.Dispatcher.Invoke(async () =>
            {
                GetResoltionValues();
            });
        }
    }
}