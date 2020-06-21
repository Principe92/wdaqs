using System.Globalization;
using System.IO;
using CsvHelper;
using wdaqs.shared.Model.Exporter;
using wdaqs.shared.Services.File;

namespace wdaqs.shared.Services.Exporter
{
    class CsvDataExporter : IDataExporter
    {
        private readonly IWdaqFileService _fileService;

        public CsvDataExporter(IWdaqFileService fileService)
        {
            _fileService = fileService;
        }

        public string Export(ExportRequest request)
        {
            var run = _fileService.Read(request.File);

            var csvPath = request.File.Replace(".json", ".csv");

            using (var writer = new StreamWriter(csvPath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Configuration.RegisterClassMap<WdaqReadingMap>();
                csv.WriteRecords(run.Readings);
            }

            return csvPath;
        }
    }
}