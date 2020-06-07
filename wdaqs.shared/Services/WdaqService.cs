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
                _stream = new SerialPortStream(_request.PortNumber, _request.BaudRate, 8, Parity.None, StopBits.One);
                _stream.Open();

                try
                {
                    while (true)
                    {
                        var data = _stream.ReadLine();

                        if (!IsValid(data))
                        {
                            _logService.Log(LogEventLevel.Information, "Line read is null or invalid");
                            continue;
                        }


                        _logService.Log(LogEventLevel.Information, "data: {data}", data);

                        var reading = _dataParser.GetReading(data);

                        DataReceived?.Invoke(this, reading);

                        _wdaqFileService.WriteToFile(reading, _currentFile);
                    }
                }
                catch (Exception exception)
                {
                    _logService.Log(exception, LogEventLevel.Fatal, "An exception has occurred processing data from stream");
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

        private bool IsValid(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                return false;
            }

            var items = data.Trim().Split(' ');

            return long.TryParse(items.First(), out var time);
        }
    }
}