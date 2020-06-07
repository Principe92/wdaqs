using wdaqs.shared.Model;

namespace wdaqs.shared.Services.File
{
    public interface IWdaqFileService
    {
        string StartNewRecord(WdaqRequest request);
        WdaqRun Read(string file);
        void WriteToFile(WdaqReading reading, string currentFile);
        void CleanUp(string currentFile);
    }
}