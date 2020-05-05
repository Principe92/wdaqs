﻿using System;
using System.IO;
using Serilog.Events;
using wdaqs.shared.Model;
using wdaqs.shared.Services.Log;

namespace wdaqs.shared.Services.File
{
    class WdaqFileService : IWdaqFileService
    {
        private const string FOLDER = "wdaqs";
        private const string TEMPFOLDER = "wdaqs";

        private readonly string _fullFolder;
        private readonly string _fullTempFolder;

        private readonly ILogService _logService;

        public WdaqFileService(ILogService logService)
        {
            _logService = logService;
            _fullFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), FOLDER);
            if (!Directory.Exists(_fullFolder))
            {
                Directory.CreateDirectory(_fullFolder);
            }

            _fullTempFolder = Path.Combine(Path.GetTempPath(), TEMPFOLDER);
            if (!Directory.Exists(_fullTempFolder))
            {
                Directory.CreateDirectory(_fullTempFolder);
            }
        }

        public string StartNewRecord(WdaqRequest request)
        {
            var fileName = $"{DateTime.Now:yyyy.MM.dd.HH.mm.ss}.wdaqs.{request.PortNumber}.json";

            var path = $"{_fullFolder}\\{fileName}";

            System.IO.File.WriteAllText(path, string.Empty);

            _logService.Log(LogEventLevel.Information, "started a new run file: {file}", path);

            return path;
        }

        public void Read(string file)
        {
            var data = System.IO.File.ReadAllText(file);

            _logService.Log(LogEventLevel.Information, "Loaded run file: {file}", file);
        }
    }
}