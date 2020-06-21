using wdaqs.shared.Model;

namespace wdaqs.shared.Services.Settings
{
    public interface IWdaqSettingService
    {
        WdaqSetting LoadSetting();

        string GetBasePath();

        void SaveSetting(WdaqSetting setting);
    }
}