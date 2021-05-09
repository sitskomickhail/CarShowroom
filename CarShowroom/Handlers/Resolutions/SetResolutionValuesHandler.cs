using System;
using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.Enums;
using CarShowroom.Entities.Models.TransferModels.Resolutions;
using CarShowroom.Handlers.Interfaces.Resolutions;

namespace CarShowroom.Handlers.Resolutions
{
    public class SetResolutionValuesHandler : BaseClientHandler, ISetResolutionValuesHandler
    {
        public override RequestAction RequestAction => RequestAction.SetResolutionValues;

        public DataReciever SetResolutionValues(InitResolutionModel model)
        {
            return SendObject(model);
        }
    }
}