using System;

namespace CarShowroom.Entities.Models.TransferModels.Clients
{
    public class EditClientModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Number { get; set; }
    }
}