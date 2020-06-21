using System;
using System.IO;
using Newtonsoft.Json;
using wdaqs.shared.Model;

namespace wdaqs.shared.Services.Settings
{
    class WdaqSettingService : IWdaqSettingService
    {
        private readonly string _settingPath;

        private const string FOLDER = "wdaqs";

        private readonly string _basePath;

        public WdaqSettingService()
        {
            _basePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), FOLDER);
            if (!Directory.Exists(_basePath))
            {
                Directory.CreateDirectory(_basePath);
            }

            _settingPath = $"{_basePath}\\config\\setting.json";
            
            var settingsFolder = $"{_basePath}\\config";

            if (!Directory.Exists(settingsFolder))
            {
                Directory.CreateDirectory(settingsFolder);


                SaveSetting(new WdaqSetting
                {
                    RunFolder = _basePath
                });
            }
        }

        public WdaqSetting LoadSetting()
        {
            var data = System.IO.File.ReadAllText(_settingPath);

            return JsonConvert.DeserializeObject<WdaqSetting>(data);
        }

        public void SaveSetting(WdaqSetting setting)
        {
            if (setting == null)
            {
                return;
            }

            var data = JsonConvert.SerializeObject(setting);

            System.IO.File.WriteAllText(_settingPath, data);
        }

        public string GetBasePath()
        {
            return _basePath;
        }
    }
}