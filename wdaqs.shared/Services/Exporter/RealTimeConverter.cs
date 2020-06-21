using System;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace wdaqs.shared.Services.Exporter
{
    public class RealTimeConverter : ITypeConverter
    {
        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            var date = value is DateTime ? (DateTime) value : (DateTime?) null;
            if (date.HasValue)
            {
                DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                TimeSpan diff = date.Value.ToUniversalTime() - origin;
                return Math.Floor(diff.TotalSeconds).ToString(CultureInfo.CurrentCulture);
            }

            return string.Empty;
        }

        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            var time = long.Parse(text);

            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(time);
        }
    }
}