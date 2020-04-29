using Serilog;
using Serilog.Core;

namespace wdaqs.shared.Services.Log
{
    public class LogService : ILogService
    {
        public Logger GetLogger()
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
    }
}