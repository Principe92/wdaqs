using System;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace wdaqs.shared.Services.Log
{
    public class LogService : ILogService
    {
        private Logger GetLogger()
        {
            var configuration = new LoggerConfiguration()
                .ReadFrom.AppSettings()
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .Enrich.WithProcessId()
                .Enrich.WithProcessName();

            configuration.WriteTo.Seq("http://localhost:5341");

            return configuration.CreateLogger();
        }

        public void Log(LogEventLevel level, string message, params object[] param)
        {
            using (var log = GetLogger())
            {
                log.ForContext<WdaqService>().Write(level, message, param);
            }
        }

        public void Log(Exception ex, LogEventLevel level, string message, params object[] param)
        {
            using (var log = GetLogger())
            {
                log.ForContext<WdaqService>().Write(level, ex, message, param);
            }
        }
    }
}