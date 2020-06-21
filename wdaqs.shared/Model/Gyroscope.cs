using CsvHelper.Configuration.Attributes;

namespace wdaqs.shared.Model
{
    public class Gyroscope
    {
        [Name("GyroscopeX")]
        public decimal XValue { get; set; }

        [Name("GyroscopeY")]
        public decimal YValue { get; set; }

        [Name("GyroscopeZ")]
        public decimal ZValue { get; set; }
    }
}