using System;
using Serilog.Core;
using Serilog.Events;

namespace wdaqs.shared.Services.Log
{
    public interface ILogService
    {
        void Log(LogEventLevel level, string message, params object[] param);
        void Log(Exception ex, LogEventLevel level, string message, params object[] param);
    }
}