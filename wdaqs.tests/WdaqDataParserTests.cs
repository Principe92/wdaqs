using System;
using wdaqs.shared.Services;
using Xunit;

namespace wdaqs.tests
{
    public class WdaqDataParserTests
    {

        private readonly WdaqDataParser _target;

        public WdaqDataParserTests()
        {
            _target = new WdaqDataParser();
        }


        [Fact]
        public void ParseReading()
        {
            // Arrange
            var data = "  2211407185 2020/05/17 17:44:05 12435 9843 7784 -507 976 1280 232 0 9999 9999 9999 0 234 30366 1180 6812 7040 354";

            // Act
            var res = _target.GetReading(data);

            // Assert
            Assert.NotNull(res);

            Assert.Equal(2211407185L, (res.RealTimeClock - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
            Assert.Equal(new DateTime(2020, 05, 17, 17, 44, 5), res.Timestamp);

            Assert.Equal(12435, res.Temperature);
            Assert.Equal(9843, res.Humidity);

            Assert.NotNull(res.Accelerometer);
            Assert.Equal(7784, res.Accelerometer.XValue);
            Assert.Equal(-507, res.Accelerometer.YValue);
            Assert.Equal(976, res.Accelerometer.ZValue);

            Assert.NotNull(res.Compass);
            Assert.Equal(1280, res.Compass.XValue);
            Assert.Equal(232, res.Compass.YValue);
            Assert.Equal(0, res.Compass.ZValue);

            Assert.NotNull(res.Gyroscope);
            Assert.Equal(9999, res.Gyroscope.XValue);
            Assert.Equal(9999, res.Gyroscope.YValue);
            Assert.Equal(9999, res.Gyroscope.ZValue);

            Assert.NotNull(res.Pressure);
            Assert.Equal(0, res.Pressure.Temperature);
            Assert.Equal(234, res.Pressure.Pressure);
            Assert.Equal(30366, res.Pressure.Altitude);

            Assert.NotNull(res.WindSensor);
            Assert.Equal(1180, res.WindSensor.WindMph);
            Assert.Equal(6812, res.WindSensor.Temperature);
            Assert.Equal(7040, res.WindSensor.Voltage);
            Assert.Equal(354, res.WindSensor.WindAdUnit);
        }
    }
}
