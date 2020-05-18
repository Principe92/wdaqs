using System;

namespace wdaqs.shared.Model
{
    public class WdaqReading : EventArgs
    {
        public DateTime RealTimeClock { get; set; }

        public DateTime Timestamp { get; set; }

        public decimal Temperature { get; set; }

        public decimal Humidity { get; set; }

        public Accelerometer Accelerometer { get; set; }

        public Compass Compass { get; set; }

        public Gyroscope Gyroscope { get; set; }

        public BarometricPressure Pressure { get; set; }

        public WindSensor WindSensor { get; set; }
    }
}
