using System;
using System.Linq;
using wdaqs.shared.Model;

namespace wdaqs.shared.Services
{
    public class WdaqDataParser : IWdaqDataParser
    {
        public WindSensor GetWindSensor(string[] data)
        {
            return new WindSensor
            {
                WindMph = decimal.Parse(data[17]),

                Temperature = decimal.Parse(data[18]),

                Voltage = decimal.Parse(data[19]),

                WindAdUnit = decimal.Parse(data[20])
            };
        }

        public BarometricPressure GetPressure(string[] data)
        {
            return new BarometricPressure
            {
                Temperature = decimal.Parse(data[14]),

                Pressure = decimal.Parse(data[15]),

                Altitude = decimal.Parse(data[16])
            };
        }

        public Gyroscope GetGyroscope(string[] data)
        {
            return new Gyroscope
            {
                XValue = decimal.Parse(data[11]),

                YValue = decimal.Parse(data[12]),

                ZValue = decimal.Parse(data[13])
            };
        }

        public Compass GetCompass(string[] data)
        {
            return new Compass
            {
                XValue = decimal.Parse(data[8]),

                YValue = decimal.Parse(data[9]),

                ZValue = decimal.Parse(data[10])
            };
        }

        public Accelerometer GetAccelerometer(string[] data)
        {
            return new Accelerometer
            {
                XValue = decimal.Parse(data[5]),

                YValue = decimal.Parse(data[6]),

                ZValue = decimal.Parse(data[7])
            };
        }

        public decimal GetHumidity(string[] data)
        {
            return decimal.Parse(data[4]);
        }

        public decimal GetTemperature(string[] data)
        {
            return decimal.Parse(data[3]);
        }

        public DateTime GetTimestamp(string[] data)
        {
            var dates = data[1].Split('/').Select(int.Parse).ToArray();
            var times = data[2].Split(':').Select(int.Parse).ToArray();

            return new DateTime(dates.First(), dates[1], dates.Last(), times.First(), times[1], times.Last());
        }

        public DateTime GetRealTimeClock(string[] data)
        {
            var time = long.Parse(data.First().Trim());

            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(time);
        }

        public WdaqReading GetReading(string data)
        {
            var item = data.Trim().Split(' ');

            return new WdaqReading
            {
                Timestamp = GetTimestamp(item),

                RealTimeClock = GetRealTimeClock(item),

                Compass = GetCompass(item),

                Accelerometer = GetAccelerometer(item),

                Humidity = GetHumidity(item),

                Gyroscope = GetGyroscope(item),

                Pressure = GetPressure(item),

                WindSensor = GetWindSensor(item),

                Temperature = GetTemperature(item)
            };
        }
    }
}