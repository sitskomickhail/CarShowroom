using System.Collections.Generic;
using CarShowroom.Entities.Models.AnswerModels.Maintenances;
using CarShowroom.Entities.Models.AnswerModels.Sales;

namespace CarShowroom.Entities.Models.AnswerModels.Clients
{
    public class ClientDealsAnswerModel
    {
        public string Name { get; set; }

        public IEnumerable<SaleAnswerModel> Sales { get; set; }

        public IEnumerable<MaintenanceAnswerModel> Maintenances { get; set; }
    }
}