using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CarShowroom.Entities.Models.AnswerModels.Resolutions;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Resolutions;
using CarShowroom.Handlers.Interfaces.Resolutions;
using CarShowroom.Models.Resolutions;
using CarShowroom.ViewModel.Base;
using Newtonsoft.Json;
using Ninject;

namespace CarShowroom.ViewModel.Employee.Resolutions
{
    public class ResolutionChartViewModel : BaseViewModel
    {
        [Inject]
        public IGetResolutionResultHandler GetResolutionResultHandler { get; set; }

        private int _resolutionResult;
        public int ResolutionResult
        {
            get { return _resolutionResult; }
            set { _resolutionResult = value; OnPropertyChanged(); }
        }

        private int _secondLevelBestResult1;
        public int SecondLevelBestResult1
        {
            get => _secondLevelBestResult1;
            set { _secondLevelBestResult1 = value; OnPropertyChanged(); }
        }

        private int _secondLevelBestResult2;
        public int SecondLevelBestResult2
        {
            get => _secondLevelBestResult2;
            set { _secondLevelBestResult2 = value; OnPropertyChanged(); }
        }


        private ResolutionResultModel _level1Resolution;
        public ResolutionResultModel Level1Resolution
        {
            get => _level1Resolution;
            set { _level1Resolution = value; OnPropertyChanged(); }
        }

        private ResolutionResultModel _level2Resolution;
        public ResolutionResultModel Level2Resolution
        {
            get => _level2Resolution;
            set { _level2Resolution = value; OnPropertyChanged(); }
        }

        private ResolutionResultModel _level3Resolution;
        public ResolutionResultModel Level3Resolution
        {
            get => _level3Resolution;
            set { _level3Resolution = value; OnPropertyChanged(); }
        }

        private ResolutionResultModel _level4Resolution;
        public ResolutionResultModel Level4Resolution
        {
            get => _level4Resolution;
            set { _level4Resolution = value; OnPropertyChanged(); }
        }

        private void SetResolutionCaseResult(ResolutionAnswerModel model)
        {
            switch (model.ResolutionActions)
            {
                case ResolutionActions.BothCases:
                    {
                        Level1Resolution = new ResolutionResultModel()
                        {
                            ExpectedValue = model.ExpectedValue,
                            SuccessPercent = model.SuccessPercent,
                            FailPercent = model.FailPercent,
                            FailDisplayText = $"С шансом {model.FailPercent}% будет потеряно {model.Expenses}$",
                            SuccessDisplayText = $"При выполнении обоих условий, как результат ожидаемый доход = {model.ExpectedValue}$ c шансом {model.SuccessPercent}%"
                        };

                        break;
                    }
                case ResolutionActions.EmployeeCase:
                    {
                        Level2Resolution = new ResolutionResultModel()
                        {
                            ExpectedValue = model.ExpectedValue,
                            SuccessPercent = model.SuccessPercent,
                            FailPercent = model.FailPercent,
                            FailDisplayText = $"С шансом {model.FailPercent}% будет потеряно {model.Expenses}$",
                            SuccessDisplayText = $"При найме квалифицированных работников ожидаемый доход = {model.ExpectedValue}$ c шансом {model.SuccessPercent}%"
                        };

                        break;
                    }
                case ResolutionActions.EquipmentCase:
                    {

                        Level3Resolution = new ResolutionResultModel()
                        {
                            ExpectedValue = model.ExpectedValue,
                            SuccessPercent = model.SuccessPercent,
                            FailPercent = model.FailPercent,
                            FailDisplayText = $"С шансом {model.FailPercent}% будет потеряно {model.Expenses}$",
                            SuccessDisplayText = $"При закупке необходимого оборудования ожидаемый доход = {model.ExpectedValue}$ c шансом {model.SuccessPercent}%"
                        };

                        break;
                    }
                case ResolutionActions.ZeroCases:
                    {
                        Level4Resolution = new ResolutionResultModel()
                        {
                            ExpectedValue = model.ExpectedValue,
                            SuccessPercent = model.SuccessPercent,
                            FailPercent = model.FailPercent,
                            FailDisplayText = $"С шансом {model.FailPercent}% будет потеряно {model.Expenses}$",
                            SuccessDisplayText = $"Ни одно из действий не выполняется, поэтому, как результат ожидаемый доход = {model.ExpectedValue}$ c шансом {model.SuccessPercent}%"
                        };

                        break;
                    }
            }
        }

        public override async Task SetDefaultValues()
        {
            Level1Resolution = new ResolutionResultModel();
            Level2Resolution = new ResolutionResultModel();
            Level3Resolution = new ResolutionResultModel();
            Level4Resolution = new ResolutionResultModel();

            await Application.Current.Dispatcher.Invoke(async () =>
            {
                var recievedData = GetResolutionResultHandler.GetResolutionResult(new GetResolutionResultModel());

                if (recievedData.RequestResult == RequestResult.Success)
                {
                    var resolutions = JsonConvert.DeserializeObject<List<ResolutionAnswerModel>>(recievedData.Object);

                    ResolutionResult = (int)resolutions.OrderByDescending(r => r.ExpectedValue).FirstOrDefault().ResolutionActions;

                    while (resolutions.Count > 0)
                    {
                        var currentResolution = resolutions.FirstOrDefault();
                        SetResolutionCaseResult(currentResolution);

                        resolutions.Remove(currentResolution);
                    }

                    SecondLevelBestResult1 = Level1Resolution.ExpectedValue >= Level2Resolution.ExpectedValue ? 1 : 2;
                    SecondLevelBestResult2 = Level3Resolution.ExpectedValue >= Level4Resolution.ExpectedValue ? 3 : 4;
                    ResolutionResult++;
                }
            });
        }
    }
}