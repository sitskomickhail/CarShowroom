using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using CarShowroom.Entities.DatabaseModels.Context;
using CarShowroom.Entities.Models.AnswerModels.Resolutions;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Resolutions;
using CarShowroom.Server.HandlerServices.Interfaces;
using Ninject;

namespace CarShowroom.Server.HandlerServices.Resolutions
{
    public class GetResolutionResultHandlerService : IHandlerService<GetResolutionResultModel, List<ResolutionAnswerModel>>
    {
        [Inject]
        public SqlServerContext SqlServerContext { get; set; }

        private const float EarnedCountOfMoney = 70000;

        public async Task<List<ResolutionAnswerModel>> ExecuteAsync(GetResolutionResultModel model)
        {
            List<ResolutionAnswerModel> resolutions = new List<ResolutionAnswerModel>();

            var resolutionValues = await SqlServerContext.Resolutions.FirstOrDefaultAsync();

            var bothResolution = new ResolutionAnswerModel()
            {
                SuccessPercent = resolutionValues.EmployeeSuccess_EquipmentSuccessChance,
                FailPercent = 100 - resolutionValues.EmployeeSuccess_EquipmentSuccessChance,
                Expenses = resolutionValues.ResolutionExpenses,
                ResolutionActions = ResolutionActions.BothCases
            };
            CalculateResolutionExpectedValue(bothResolution);
            resolutions.Add(bothResolution);

            var employeeResolution = new ResolutionAnswerModel()
            {
                SuccessPercent = resolutionValues.EmployeeSuccess_EquipmentFailChance,
                FailPercent = 100 - resolutionValues.EmployeeSuccess_EquipmentFailChance,
                Expenses = resolutionValues.ResolutionExpenses,
                ResolutionActions = ResolutionActions.EmployeeCase
            };
            CalculateResolutionExpectedValue(employeeResolution);
            resolutions.Add(employeeResolution);

            var equipmentResolution = new ResolutionAnswerModel()
            {
                SuccessPercent = resolutionValues.EmployeeFail_EquipmentSuccessChance,
                FailPercent = 100 - resolutionValues.EmployeeFail_EquipmentSuccessChance,
                Expenses = resolutionValues.ResolutionExpenses,
                ResolutionActions = ResolutionActions.EquipmentCase
            };
            CalculateResolutionExpectedValue(equipmentResolution);
            resolutions.Add(equipmentResolution);

            var bothFail = new ResolutionAnswerModel()
            {
                SuccessPercent = resolutionValues.EmployeeFail_EquipmentFailChance,
                FailPercent = 100 - resolutionValues.EmployeeFail_EquipmentFailChance,
                Expenses = resolutionValues.ResolutionExpenses,
                ResolutionActions = ResolutionActions.ZeroCases
            };
            CalculateResolutionExpectedValue(bothFail);
            resolutions.Add(bothFail);

            return resolutions;
        }

        private static void CalculateResolutionExpectedValue(ResolutionAnswerModel model)
        {
            double successCoefficient = model.SuccessPercent / 100.0;
            double failCoefficient = model.FailPercent / 100.0;

            double earnRisk = successCoefficient * EarnedCountOfMoney;
            double leftRisk = failCoefficient * model.Expenses;

            model.ExpectedValue = earnRisk - leftRisk;
        }
    }
}