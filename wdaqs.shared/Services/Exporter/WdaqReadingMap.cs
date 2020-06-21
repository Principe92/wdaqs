using System.Globalization;
using CsvHelper.Configuration;
using wdaqs.shared.Model;

namespace wdaqs.shared.Services.Exporter
{
    public class WdaqReadingMap : ClassMap<WdaqReading>
    {
        public WdaqReadingMap()
        {
            AutoMap(CultureInfo.CurrentCulture);
            Map(m => m.RealTimeClock).TypeConverter<RealTimeConverter>();
        }
    }
}