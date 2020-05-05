using System;
using System.Threading;
using RJCP.IO.Ports;
using Serilog.Events;
using wdaqs.shared.Model;
using wdaqs.shared.Services.File;
using wdaqs.shared.Services.Log;

namespace wdaqs.shared.Services
{
    public class WdaqService : IWdaqService
    {
        private readonly IWdaqFileService _wdaqFileService;

        private string _currentFile;

        private Thread _thread;

        private SerialPortStream _stream;

        private WdaqRequest _request;

        private ILogService _logService;

        public WdaqService(IWdaqFileService wdaqFileService, ILogService logService)
        {
            _wdaqFileService = wdaqFileService;
            _logService = logService;
        }

        public void Start(WdaqRequest request)
        {
            _request = request;
            _currentFile = _wdaqFileService.StartNewRecord(request);

            _thread = new Thread(ReadFromPort);
            _thread.Start();
        }

        public void Stop()
        {
            _stream.Dispose();
            _thread.Abort();
        }

        public void Load(string file)
        {
            _currentFile = file;

            _wdaqFileService.Read(file);
        }

        private void ReadFromPort()
        {
            try
            {
                _stream = new SerialPortStream(_request.PortNumber, 9600, 8, Parity.None, StopBits.One);

                while (true)
                {
                    // Do stuff here

                    var data = _stream.ReadLine();

                    _logService.Log(LogEventLevel.Information, "data: {data}", data);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                _stream.Dispose();
            }
        }
    }
}