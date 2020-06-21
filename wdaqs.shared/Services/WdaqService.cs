using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RJCP.IO.Ports;
using Serilog.Events;
using wdaqs.shared.Model;
using wdaqs.shared.Model.Exporter;
using wdaqs.shared.Services.Exporter;
using wdaqs.shared.Services.File;
using wdaqs.shared.Services.Log;
using wdaqs.shared.Services.Settings;

namespace wdaqs.shared.Services
{
    public class WdaqService : IWdaqService
    {
        private readonly IWdaqFileService _wdaqFileService;

        private readonly IWdaqDataParser _dataParser;

        private readonly IWdaqSettingService _settingService;

        private string _currentFile;

        private Thread _thread;

        private SerialPortStream _stream;

        private WdaqRequest _request;

        private readonly ILogService _logService;

        private readonly IDataExporter _dataExporter;

        public WdaqService(
            IWdaqFileService wdaqFileService, 
            ILogService logService, 
            IWdaqDataParser dataParser, 
            IDataExporter dataExporter, 
            IWdaqSettingService settingService)
        {
            _wdaqFileService = wdaqFileService;
            _logService = logService;
            _dataParser = dataParser;
            _dataExporter = dataExporter;
            _settingService = settingService;
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
                _logService.Log(exception, LogEventLevel.Fatal, "Ha occurrido un error");
            }
        }

        public event EventHandler<WdaqReading> DataReceived;

        public event EventHandler<string> CsvExported;

        public event EventHandler<string> FilePath;

        public void ExportToCsv()
        {
            Task.Factory.StartNew(() =>
            {
                var res = _dataExporter.Export(new ExportRequest
                {
                    File = _currentFile
                });

                CsvExported?.Invoke(this, res);
            });
        }

        public void Load(string file)
        {
            _currentFile = file;

            new Thread(LoadFile).Start();
        }

        public void UpdateRunFolder(string path)
        {
            Task.Factory.StartNew(() =>
            {
                var setting = _settingService.LoadSetting();

                setting.RunFolder = path;

                _settingService.SaveSetting(setting);
            });
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
                            _logService.Log(LogEventLevel.Information, "Dato invalido");
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
                    _logService.Log(exception, LogEventLevel.Fatal, "Ha occurrido un error");
                }
            }
            catch (Exception e)
            {
                _logService.Log(e, LogEventLevel.Fatal, "Ha occurrido un error");
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