using System;
using System.Collections.Generic;
using System.Text;

namespace wdaqs.shared.Model
{
    public class WdaqReading
    {
        public Temperature Temperature { get; set; }

        public BarometricPressure Pressure { get; set; }

        public Humidity Humidity { get; set; }

        public DateTime Time { get; set; }
    }
}
