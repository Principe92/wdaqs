using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;
using Serilog.Events;
using wdaqs.shared.Model;
using wdaqs.shared.Services.Log;

namespace wdaqs.shared.Services.File
{
    class WdaqFileService : IWdaqFileService
    {
        private const string FOLDER = "wdaqs";

        private readonly string _fullFolder;

        private readonly ILogService _logService;

        private ConcurrentBag<WdaqReading> _cache;

        private const int MAX_SIZE = 1000;

        private SemaphoreSlim _lock;

        public WdaqFileService(ILogService logService)
        {
            _logService = logService;
            _fullFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), FOLDER);
            if (!Directory.Exists(_fullFolder))
            {
                Directory.CreateDirectory(_fullFolder);
            }

            _lock = new SemaphoreSlim(1);
        }

        public string StartNewRecord(WdaqRequest request)
        {
            var fileName = $"{DateTime.Now:yyyy.MM.dd.HH.mm.ss}.wdaqs.{request.PortNumber}.json";

            var path = $"{_fullFolder}\\{fileName}";

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

            System.IO.File.WriteAllText(currentFile, JsonConvert.SerializeObject(run));

            _logService.Log(LogEventLevel.Information, "Saved data for run file: {file}", currentFile);

        }
    }
}