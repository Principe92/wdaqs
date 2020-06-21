using System;
using wdaqs.shared.Model;

namespace wdaqs.shared.Services
{
    public interface IWdaqService
    {
        void Start(WdaqRequest request);
        void Stop();
        void Load(string file);

        event EventHandler<WdaqReading> DataReceived;

        event EventHandler<string> CsvExported;

        void ExportToCsv();
        void UpdateRunFolder(string path);
        event EventHandler<string> FilePath;
    }
}
