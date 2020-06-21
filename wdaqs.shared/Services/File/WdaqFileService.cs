using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;
using Serilog.Events;
using wdaqs.shared.Model;
using wdaqs.shared.Services.Log;
using wdaqs.shared.Services.Settings;

namespace wdaqs.shared.Services.File
{
    class WdaqFileService : IWdaqFileService
    {
        private readonly ILogService _logService;

        private readonly IWdaqSettingService _settingService;

        private ConcurrentBag<WdaqReading> _cache;

        private const int MAX_SIZE = 1000;

        private readonly SemaphoreSlim _lock;

        public WdaqFileService(ILogService logService, IWdaqSettingService settingService)
        {
            _logService = logService;
            _settingService = settingService;

            _lock = new SemaphoreSlim(1);
        }

        public string StartNewRecord(WdaqRequest request)
        {
            var fileName = $"{DateTime.Now:yyyy.MM.dd.HH.mm.ss}.wdaqs.{request.PortNumber}.json";

            var setting = _settingService.LoadSetting();

            var path = $"{setting.RunFolder}\\{fileName}";

            System.IO.File.WriteAllText(path, string.Empty);

            _logService.Log(LogEventLevel.Information, "started a new run file: {file}", path);

            return path;
        }

        public WdaqRun Read(string file)
        {
            var data = System.IO.File.ReadAllText(file);

            _logService.Log(LogEventLevel.Information, "Loaded run file: {file}", file);

            return JsonConvert.DeserializeObject<WdaqRun>(data);
        }


        public void WriteToFile(WdaqReading reading, string currentFile)
        {
            _lock.Wait();
            
            if (_cache == null)
            {
                _cache = new ConcurrentBag<WdaqReading>();
            }

            if (_cache.Count == MAX_SIZE)
            {
                var data = _cache.ToList();
                var tr = new Thread(() => StoreFile(data, currentFile));
                tr.Start();

                _cache = null;
            }
            else
            {
                _cache.Add(reading);
            }

            _lock.Release();
        }

        public void CleanUp(string currentFile)
        {
            if (_cache != null)
            {
                StoreFile(_cache.ToList(), currentFile);
            }

            _cache = null;
        }

        private void StoreFile(List<WdaqReading> wdaqReadings, string currentFile)
        {
            var run = Read(currentFile) ?? new WdaqRun();

            if (run.Readings == null)
            {
                run.Readings = new List<WdaqReading>();
            }

            run.Readings.AddRange(wdaqReadings);

            var data = JsonConvert.SerializeObject(run);
            data = data.Replace(",", $",{Environment.NewLine}");

            System.IO.File.WriteAllText(currentFile, data);

            _logService.Log(LogEventLevel.Information, "Saved data for run file: {file}", currentFile);

        }
    }
}