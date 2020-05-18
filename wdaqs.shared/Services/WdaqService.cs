using System;
using System.Linq;
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

        private readonly IWdaqDataParser _dataParser;

        private string _currentFile;

        private Thread _thread;

        private SerialPortStream _stream;

        private WdaqRequest _request;

        private readonly ILogService _logService;

        public WdaqService(IWdaqFileService wdaqFileService, ILogService logService, IWdaqDataParser dataParser)
        {
            _wdaqFileService = wdaqFileService;
            _logService = logService;
            _dataParser = dataParser;
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
            try
            {
                _stream?.Dispose();
                _thread?.Abort();
                _wdaqFileService.CleanUp(_currentFile);
            }
            catch (Exception exception)
            {
                _logService.Log(exception, LogEventLevel.Fatal, "An exception has occurred aborting thread");
            }
        }

        public void Load(string file)
        {
            _currentFile = file;

            var tr = new Thread(LoadFile);
            tr.Start();
        }

        private void LoadFile()
        {
            var run = _wdaqFileService.Read(_currentFile);

            if (run?.Readings != null)
            {
                foreach (var reading in run.Readings.OrderBy(x => x.Timestamp))
                {
                    DataReceived?.Invoke(this, reading);
                }
            }
        }

        public event EventHandler<WdaqReading> DataReceived;

        private void ReadFromPort()
        {
            try
            {
                // _stream = new SerialPortStream(_request.PortNumber, 115200, 8, Parity.None, StopBits.One);

                var index = 0;

                while (true)
                {
                    // var data = _stream.ReadLine();

                    Thread.Sleep(TimeSpan.FromSeconds(5));

                    index += 10;

                    var now = DateTime.UtcNow;

                    var data = $"  2211407185 {now.Year}/{now.Month}/{now.Day} {now.Hour}:{now.Minute}:{now.Second} {index} {index} 7784 -507 976 1280 232 0 9999 9999 9999 0 {index} 30366 1180 6812 7040 354";

                    if (string.IsNullOrWhiteSpace(data))
                    {
                        _logService.Log(LogEventLevel.Information, "Line read is null");
                        continue;
                    }

                    _logService.Log(LogEventLevel.Information, "data: {data}", data);

                    var reading = _dataParser.GetReading(data);

                    DataReceived?.Invoke(this, reading);

                    _wdaqFileService.WriteToFile(reading, _currentFile);
                }
            }
            catch (Exception e)
            {
                _logService.Log(e, LogEventLevel.Fatal, "An exception has occurred reading data from stream");
            }
            finally
            {
                _stream?.Dispose();
            }
        }

       
    }
}