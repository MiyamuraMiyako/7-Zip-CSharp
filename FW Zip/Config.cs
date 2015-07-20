using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace FW_Zip
{
    public static class Config
    {
        private static string languageFilesPath= System.Windows.Forms.Application.StartupPath + Path.DirectorySeparatorChar + "Languages";

        public static List<String> LoadLanguages()
        {
            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + Path.DirectorySeparatorChar + "Languages");
            List<String> langs=new List<string>();
            
            if(dir.Exists)
            {
                foreach(FileInfo lang in dir.EnumerateFiles())
                {
                    //
                }
            }

            return langs;
        }
        
        public static void echo()
        {
            ExeConfigurationFileMap langs = new ExeConfigurationFileMap();
            langs.ExeConfigFilename = languageFilesPath + @"\zh_CN.config";
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(langs, ConfigurationUserLevel.None);

            config = config.GetSection("Language").CurrentConfiguration;
            MessageBox.Show(config.AppSettings.Settings.Count.ToString());
            foreach (string key in config.AppSettings.Settings.AllKeys)
            {
                Console.WriteLine(key);
            }
        }

        public static void UpdateAppConfig(string newKey, string newValue)
        {
            string file = System.Windows.Forms.Application.ExecutablePath + Path.DirectorySeparatorChar + "Languages";
            Configuration config = ConfigurationManager.OpenExeConfiguration("zh_CN.config");
            bool exist = false;
            foreach (string key in config.AppSettings.Settings.AllKeys)
            {
                if (key == newKey)
                {
                    exist = true;
                }
            }
            if (exist)
            {
                config.AppSettings.Settings.Remove(newKey);
            }
            config.AppSettings.Settings.Add(newKey, newValue);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
