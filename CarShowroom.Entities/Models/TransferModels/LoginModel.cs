using System;

namespace CarShowroom.Entities.Models.TransferModels
{
    [Serializable]
    public class LoginModel
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }
}