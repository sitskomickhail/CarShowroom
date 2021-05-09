using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Resolutions;
using CarShowroom.Handlers.Interfaces.Resolutions;

namespace CarShowroom.Handlers.Resolutions
{
    public class GetResolutionResultHandler : BaseClientHandler, IGetResolutionResultHandler
    {
        public override RequestAction RequestAction => RequestAction.GetResolutionResult;

        public DataReciever GetResolutionResult(GetResolutionResultModel model)
        {
            return SendObject(model);
        }
    }
}