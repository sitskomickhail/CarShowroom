using CarShowroom.Entities.Models.Enums;

namespace CarShowroom.Entities.Models.AnswerModels.Resolutions
{
    public class ResolutionAnswerModel
    {
        public int Percent { get; set; }

        public float ExpectedValue { get; set; }

        public ResolutionActions ResolutionActions { get; set; }
    }
}