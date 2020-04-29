using System.Threading;
using wdaqs.shared.Model;
using wdaqs.shared.Services.File;

namespace wdaqs.shared.Services
{
    public class WdaqService : IWdaqService
    {
        private readonly IWdaqFileService _wdaqFileService;

        private string currentFile;

        private Thread _thread;

        public WdaqService(IWdaqFileService wdaqFileService)
        {
            _wdaqFileService = wdaqFileService;
        }

        public void Start(WdaqRequest request)
        {
            currentFile = _wdaqFileService.StartNewRecord(request);

            _thread = new Thread(ReadFromPort);
            _thread.Start();
        }

        public void Stop()
        {
            _thread.Abort();
        }

        private void ReadFromPort()
        {

            while (true)
            {
                // Do stuff here
            }
        }
    }
}