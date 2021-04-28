using System;

namespace CarShowroom.Entities.Models.AnswerModels.Clients
{
    public class ClientAnswerModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Number { get; set; }

        public bool HaveSales { get; set; }

        public bool HaveMaintenances { get; set; }
    }
}