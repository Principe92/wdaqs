using CsvHelper.Configuration.Attributes;

namespace wdaqs.shared.Model
{
    public class Accelerometer
    {
        [Name("AccelerometerX")]
        public decimal XValue { get; set; }

        [Name("AccelerometerY")]
        public decimal YValue { get; set; }

        [Name("AccelerometerZ")]
        public decimal ZValue { get; set; }
    }
}