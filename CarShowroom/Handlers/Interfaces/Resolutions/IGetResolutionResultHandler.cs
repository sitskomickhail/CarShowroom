using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.TransferModels.Resolutions;

namespace CarShowroom.Handlers.Interfaces.Resolutions
{
    public interface IGetResolutionResultHandler
    {
        DataReciever GetResolutionResult(GetResolutionResultModel model);
    }
}