using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.TransferModels.Maintenances;

namespace CarShowroom.Handlers.Interfaces.Maintenances
{
    public interface ICreateMaintenanceHandler
    {
        DataReciever CreateMaintenance(CreateMaintenanceModel model);
    }
}