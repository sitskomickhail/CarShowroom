using System;

namespace CarShowroom.Models.Clients
{
    public class ClientGridModel
    {
        public Guid Id { get; set; }

        public int Position { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public bool HaveSales { get; set; }

        public bool HaveMaintenances { get; set; }
    }
}