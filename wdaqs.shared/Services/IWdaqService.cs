using wdaqs.shared.Model;

namespace wdaqs.shared.Services
{
    public interface IWdaqService
    {
        void Start(WdaqRequest request);
        void Stop();
    }
}
