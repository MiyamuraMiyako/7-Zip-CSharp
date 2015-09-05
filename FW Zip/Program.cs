using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FW_Zip
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if(!Properties.Settings.Default.IsUserSetLanguage)
            {
                Properties.Settings.Default.Language = System.Globalization.CultureInfo.CurrentUICulture.TextInfo.CultureName;
                Properties.Settings.Default.Save();
            }
            Application.Run(new MainForm());
        }
    }
}
