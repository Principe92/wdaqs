using wdaqs.shared.Model.Exporter;

namespace wdaqs.shared.Services.Exporter
{
    public interface IDataExporter
    {
        string Export(ExportRequest request);
    }
}
