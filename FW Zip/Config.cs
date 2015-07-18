using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace FW_Zip
{
    public static class Config
    {
        public static string GetConnectionStringsConfig(string connectionName)
        {
            //指定config文件读取
            string file = System.Windows.Forms.Application.ExecutablePath;
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(file);
            string connectionString =
                config.ConnectionStrings.ConnectionStrings[connectionName].ConnectionString.ToString();
            return connectionString;
        }

        public static void SetInt(int i)
        {
            //
        }
    }
}
