using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CarShowroom.Entities.Models.AnswerModels.Resolutions;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Resolutions;
using CarShowroom.Handlers.Interfaces.Resolutions;
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
        public int EmployeeSuccess_EquipmentSuccessChance
        {
            get => _employeeHiringSuccessChance;
            set { _employeeHiringSuccessChance = value; OnPropertyChanged(); }
        }

        private int _employeeSuccessEquipmentFailChance;
        public int EmployeeSuccess_EquipmentFailChance
        {
            get => _employeeSuccessEquipmentFailChance;
            set { _employeeSuccessEquipmentFailChance = value; OnPropertyChanged(); }
        }

        private int _employeeFailEquipmentSuccessChance;
        public int EmployeeFail_EquipmentSuccessChance
        {
            get => _employeeFailEquipmentSuccessChance;
            set
            {
                _employeeFailEquipmentSuccessChance = value; OnPropertyChanged();
            }
        }

        private int _employeeFailEquipmentFailChance;
        public int EmployeeFail_EquipmentFailChance
        {
            get => _employeeFailEquipmentFailChance;
            set { _employeeFailEquipmentFailChance = value; OnPropertyChanged(); }
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
                EmployeeSuccess_EquipmentSuccessChance = EmployeeSuccess_EquipmentSuccessChance,
                EmployeeFail_EquipmentSuccessChance = EmployeeFail_EquipmentSuccessChance,
                EmployeeFail_EquipmentFailChance = EmployeeFail_EquipmentFailChance,
                EmployeeSuccess_EquipmentFailChance = EmployeeSuccess_EquipmentFailChance
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

            ResolutionExpenses = 15000;
            EmployeeSuccess_EquipmentSuccessChance = 95;
            EmployeeSuccess_EquipmentFailChance = 65;
            EmployeeFail_EquipmentSuccessChance = 40;
            EmployeeFail_EquipmentFailChance = 15;
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

                    EmployeeSuccess_EquipmentSuccessChance = resolutionValues.EmployeeSuccess_EquipmentSuccessChance;
                    EmployeeSuccess_EquipmentFailChance = resolutionValues.EmployeeSuccess_EquipmentFailChance;
                    EmployeeFail_EquipmentSuccessChance = resolutionValues.EmployeeFail_EquipmentSuccessChance;
                    EmployeeFail_EquipmentFailChance = resolutionValues.EmployeeFail_EquipmentFailChance;
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