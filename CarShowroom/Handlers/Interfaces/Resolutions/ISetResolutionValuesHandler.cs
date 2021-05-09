using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.TransferModels.Resolutions;

namespace CarShowroom.Handlers.Interfaces.Resolutions
{
    public interface  ISetResolutionValuesHandler
    {
        DataReciever SetResolutionValues(InitResolutionModel model);
    }
}