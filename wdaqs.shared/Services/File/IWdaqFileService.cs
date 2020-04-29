using wdaqs.shared.Model;

namespace wdaqs.shared.Services.File
{
    public interface IWdaqFileService
    {
        string StartNewRecord(WdaqRequest request);
        void Read(string file);
    }
}