using System;

namespace CarShowroom.Models.Users
{
    public class UserGridModel
    {
        public Guid Id { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        public bool IsBlocked { get; set; }

        public string Role { get; set; }
    }
}