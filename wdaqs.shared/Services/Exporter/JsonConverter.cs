﻿using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Newtonsoft.Json;

namespace wdaqs.shared.Services.Exporter
{
    public class JsonConverter<T> : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            return JsonConvert.DeserializeObject<T>(text);
        }

        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}