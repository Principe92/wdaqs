using Serilog.Core;

namespace wdaqs.shared.Services.Log
{
    public interface ILogService
    {
        Logger GetLogger();
    }
}