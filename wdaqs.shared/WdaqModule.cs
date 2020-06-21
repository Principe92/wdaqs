using Ninject.Modules;
using wdaqs.shared.Services;
using wdaqs.shared.Services.Exporter;
using wdaqs.shared.Services.File;
using wdaqs.shared.Services.Log;
using wdaqs.shared.Services.Settings;

namespace wdaqs.shared
{
    public class WdaqModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IWdaqService>().To<WdaqService>().InSingletonScope();

            Bind<IWdaqFileService>().To<WdaqFileService>().InSingletonScope();

            Bind<ILogService>().To<LogService>().InSingletonScope();

            Bind<IWdaqDataParser>().To<WdaqDataParser>().InSingletonScope();

            Bind<IDataExporter>().To<CsvDataExporter>().InSingletonScope().Named("csv");

            Bind<IWdaqSettingService>().To<WdaqSettingService>().InSingletonScope();
        }
    }
}
