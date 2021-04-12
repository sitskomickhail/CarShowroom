using System;
using CarShowroom.Entities.Models.Enums;

namespace CarShowroom.Entities.Models.DataTransfers
{
    [Serializable]
    public class DataReciever
    {
        public RequestResult RequestResult { get; set; }
        
        public string Message { get; set; }

        public string Object { get; set; }
    }
}