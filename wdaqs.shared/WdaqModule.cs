using Ninject.Modules;
using wdaqs.shared.Services;
using wdaqs.shared.Services.File;
using wdaqs.shared.Services.Log;

namespace wdaqs.shared
{
    public class WdaqModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IWdaqService>().To<WdaqService>().InSingletonScope();

            Bind<IWdaqFileService>().To<WdaqFileService>().InSingletonScope();

            Bind<ILogService>().To<LogService>().InSingletonScope();
        }
    }
}
