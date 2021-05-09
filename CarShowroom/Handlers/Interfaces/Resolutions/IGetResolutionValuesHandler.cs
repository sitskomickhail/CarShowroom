using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.TransferModels.Resolutions;

namespace CarShowroom.Handlers.Interfaces.Resolutions
{
    public interface IGetResolutionValuesHandler
    {
        DataReciever GetResolutionValues(GetResolutionValuesModel model);
    }
}