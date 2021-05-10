using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CarShowroom.Entities.Models.AnswerModels.Resolutions;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Resolutions;
using CarShowroom.Handlers.Interfaces.Resolutions;
using CarShowroom.Models.Resolutions;
using CarShowroom.Services.Interfaces;
using CarShowroom.View;
using CarShowroom.ViewModel.Base;
using GalaSoft.MvvmLight.CommandWpf;
using Newtonsoft.Json;
using Ninject;

namespace CarShowroom.ViewModel.Employee.Resolutions
{
    public class ResolutionChartViewModel : BaseViewModel
    {
        [Inject]
        public IGetResolutionResultHandler GetResolutionResultHandler { get; set; }

        [Inject]
        public IPdfService PdfService { get; set; }

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

        public ICommand SaveChartToPdfFileCommand { get; set; }

        public ResolutionChartViewModel()
        {
            SaveChartToPdfFileCommand = new RelayCommand(SaveChartToPdfFileCommandExecuted);
        }

        private async void SaveChartToPdfFileCommandExecuted()
        {
            try
            {
                var w = 8000;
                var h = 4000;

                var screen = Application.Current.Windows.OfType<EmployeeWindow>().SingleOrDefault(x => x.IsActive);

                var visual = new DrawingVisual();
                using (var context = visual.RenderOpen())
                {
                    context.DrawRectangle(new VisualBrush(screen),
                        null,
                        new Rect(new Point(), new Size(screen.Width, screen.Height)));
                }

                visual.Transform = new ScaleTransform(w / screen.ActualWidth, h / screen.ActualHeight);

                var rtb = new RenderTargetBitmap(w, h, 96, 96, PixelFormats.Pbgra32);
                rtb.Render(visual);

                var enc = new PngBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(rtb));

                var fileName = Guid.NewGuid() + DateTime.Now.ToString("ddMMyyyy-hhmmss") + ".png";
                using (var stm = File.Create(fileName))
                {
                    enc.Save(stm);
                }

                PdfService.GeneratePDF("Отчет по решению.pdf", fileName);
                MessageBox.Show("Отчет успешно создан", "Успех", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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