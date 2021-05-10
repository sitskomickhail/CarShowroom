using System.Security.AccessControl;
using CarShowroom.Entities.Models.Enums;

namespace CarShowroom.Entities.Models.AnswerModels.Resolutions
{
    public class ResolutionAnswerModel
    {
        public int SuccessPercent { get; set; }

        public int FailPercent { get; set; }

        public double ExpectedValue { get; set; }

        public int Expenses { get; set; }

        public ResolutionActions ResolutionActions { get; set; }
    }
}