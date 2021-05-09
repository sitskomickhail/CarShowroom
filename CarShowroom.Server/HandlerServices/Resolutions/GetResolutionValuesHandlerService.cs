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
    public class GetResolutionValuesHandlerService : IHandlerService<GetResolutionValuesModel, ResolutionValuesAnswerModel>
    {
        [Inject]
        public SqlServerContext SqlContext { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }
        
        public async Task<ResolutionValuesAnswerModel> ExecuteAsync(GetResolutionValuesModel model)
        {
            var resolution = await SqlContext.Resolutions.FirstOrDefaultAsync();

            if (resolution == null)
            {
                resolution = new Resolution();
            }

            var answerModel = Mapper.Map<ResolutionValuesAnswerModel>(resolution);
            return answerModel;
        }
    }
}