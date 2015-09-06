using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FW_Zip.Utils
{
    class I18N
    {
        public static Dictionary<string, string> GetLanguageList()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            DirectoryInfo di = new DirectoryInfo(Path.Combine(Application.StartupPath, "Languages"));

            foreach (FileInfo f in di.EnumerateFiles())
            {
                StreamReader sr = new StreamReader(f.OpenRead());
                while (true)
                {
                    string line = sr.ReadLine();
                    if (line != null)
                    {
                        if(line.StartsWith("#"))
                        {
                            continue;
                        }

                        string[] str = Regex.Split(line, "=");
                        if (str.Length == 2 && str[0].Equals(f.Name.Replace(".txt", "")))
                        {
                            dic.Add(str[0], str[1]);
                        }
                        continue;
                    }
                    break;
                }
            }
            //
            return dic;
        }

        static Dictionary<string, string> trans;
        public static void LoadLanguage()
        {
            FileInfo curLng = new FileInfo(@".\Languages\" + Properties.Settings.Default.Language + ".txt");
            trans = new Dictionary<string, string>();

            if (Properties.Settings.Default.Language.Equals("en-US"))
            {
                return;
            }

            StreamReader sr = new StreamReader(curLng.OpenRead());
            while (true)
            {
                string line = sr.ReadLine();
                Console.WriteLine(line);
                if (line == null)
                {
                    break;
                }
                string[] str = Regex.Split(line, "=");
                if (str.Length == 2)
                {
                    trans[str[0]] = str[1];
                }
            }
            sr.Close();
        }

        public static string GetString(string eng)
        {
            if (trans.ContainsKey(eng))
            {
                return trans[eng];
            }
            return eng;
        }
    }
}
