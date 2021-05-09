using System.Data.Entity;
using System.Threading.Tasks;
using AutoMapper;
using CarShowroom.Entities.DatabaseModels;
using CarShowroom.Entities.DatabaseModels.Context;
using CarShowroom.Entities.Models.AnswerModels.Resolutions;
using CarShowroom.Entities.Models.TransferModels.Resolutions;
using CarShowroom.Server.HandlerServices.Interfaces;
using Ninject;

namespace CarShowroom.Server.HandlerServices.Resolutions
{
    public class SetResolutionValuesHandlerService : IHandlerService<InitResolutionModel, ResolutionValuesAnswerModel>
    {
        [Inject]
        public SqlServerContext SqlContext { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public async Task<ResolutionValuesAnswerModel> ExecuteAsync(InitResolutionModel model)
        {
            var resolution = await SqlContext.Resolutions.FirstOrDefaultAsync();

            if (resolution == null)
            {
                resolution = new Resolution();
                SqlContext.Resolutions.Add(resolution);
            }

            MapModels(resolution, model);

            await SqlContext.SaveChangesAsync();

            var answerModel = Mapper.Map<ResolutionValuesAnswerModel>(resolution);
            return answerModel;
        }

        private static void MapModels(Resolution resolution, InitResolutionModel model)
        {
            resolution.EmployeeFail_EquipmentFailChance = model.EmployeeFail_EquipmentFailChance;
            resolution.EmployeeFail_EquipmentSuccessChance = model.EmployeeFail_EquipmentSuccessChance;
            resolution.EmployeeSuccess_EquipmentFailChance = model.EmployeeSuccess_EquipmentFailChance;
            resolution.EmployeeSuccess_EquipmentSuccessChance = model.EmployeeSuccess_EquipmentSuccessChance;

            resolution.ResolutionExpenses = model.ResolutionExpenses;
        }
    }
}