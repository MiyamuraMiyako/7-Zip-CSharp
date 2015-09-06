using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW_Zip
{
    public static class   Log
    {
        private static  StreamWriter sw = File.AppendText("Logs.txt");

        public static void ToFile(string tag,string data)
        {
            try
            {
                sw.WriteLine(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + " " + tag + ": " + data);
                sw.Flush();
                sw.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void CleanLog()
        {
            try
            {
                FileInfo file = new FileInfo("Logs.txt");
                if(file.Exists)
                {
                    file.Delete();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
