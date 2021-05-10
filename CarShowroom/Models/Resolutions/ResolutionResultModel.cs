namespace CarShowroom.Models.Resolutions
{
    public class ResolutionResultModel
    {
        public string SuccessDisplayText { get; set; }
        
        public string FailDisplayText { get; set; }

        public double ExpectedValue { get; set; }

        public int SuccessPercent { get; set; }
        
        public int FailPercent { get; set; }
    }
}