using CsvHelper.Configuration.Attributes;

namespace wdaqs.shared.Model
{
    public class Compass
    {
        [Name("CompassX")]
        public decimal XValue { get; set; }

        [Name("CompassY")]
        public decimal YValue { get; set; }

        [Name("CompassZ")]
        public decimal ZValue { get; set; }
    }
}