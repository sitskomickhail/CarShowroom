using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.TransferModels.Vehicles;

namespace CarShowroom.Handlers.Interfaces.Vehicles
{
    public interface IGetClientVehiclesHandler
    {
        DataReciever GetClientVehicles(GetClientVehiclesModel model);
    }
}