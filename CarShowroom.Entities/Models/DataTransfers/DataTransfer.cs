using System;
using CarShowroom.Entities.Models.Enums;

namespace CarShowroom.Entities.Models.DataTransfers
{
    [Serializable]
    public class DataTransfer
    {
        public RequestAction Action { get; set; }

        public string Object { get; set; }
    }
}