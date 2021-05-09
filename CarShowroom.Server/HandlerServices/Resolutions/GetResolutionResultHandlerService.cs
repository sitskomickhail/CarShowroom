using System;
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

        public async Task<List<ResolutionAnswerModel>> ExecuteAsync(GetResolutionResultModel model)
        {
            List<ResolutionAnswerModel> resolutions = new List<ResolutionAnswerModel>();

            var resolutionValues = await SqlServerContext.Resolutions.FirstOrDefaultAsync();

            var bothResolution = new ResolutionAnswerModel()
            {
                ResolutionActions = ResolutionActions.BothCases
            };
            bothResolution.Percent = (resolutionValues.EmployeeHiringChance + resolutionValues.EquipmentPurchaseChance) / 2;


            throw new NotImplementedException();
        }
    }
}