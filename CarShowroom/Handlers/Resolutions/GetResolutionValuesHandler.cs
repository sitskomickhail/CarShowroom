using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Resolutions;
using CarShowroom.Handlers.Interfaces.Resolutions;

namespace CarShowroom.Handlers.Resolutions
{
    public class GetResolutionValuesHandler : BaseClientHandler, IGetResolutionValuesHandler
    {
        public override RequestAction RequestAction => RequestAction.GetResolutionValues;

        public DataReciever GetResolutionValues(GetResolutionValuesModel model)
        {
            return SendObject(model);
        }
    }
}