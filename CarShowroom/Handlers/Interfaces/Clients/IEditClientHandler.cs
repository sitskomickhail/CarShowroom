using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShowroom.Entities.Models.DataTransfers;
using CarShowroom.Entities.Models.TransferModels.Clients;

namespace CarShowroom.Handlers.Interfaces.Clients
{
    public interface IEditClientHandler
    {
        DataReciever EditClient(EditClientModel model);
    }
}
