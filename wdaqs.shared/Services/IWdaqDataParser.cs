using System;
using wdaqs.shared.Model;

namespace wdaqs.shared.Services
{
    public interface IWdaqDataParser
    {
        WindSensor GetWindSensor(string[] data);
        BarometricPressure GetPressure(string[] data);
        Gyroscope GetGyroscope(string[] data);
        Compass GetCompass(string[] data);
        Accelerometer GetAccelerometer(string[] data);
        decimal GetHumidity(string[] data);
        decimal GetTemperature(string[] data);
        DateTime GetTimestamp(string[] data);
        DateTime GetRealTimeClock(string[] data);
        WdaqReading GetReading(string data);
    }
}
