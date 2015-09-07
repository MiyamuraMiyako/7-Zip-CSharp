using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FW_Zip
{
    class Util
    {
        public static string HommizationSize(long size)
        {
            if (size < 1024L)
            {
                return size + "Byte";
            }
            else if (size < 1024L * 1024L)
            {
                return (size / 1024F) + "KB";
            }
            else if (size < 1024L * 1024L * 1024L)
            {
                return (size / 1024F / 1024F) + "MB";
            }
            else if (size < 1024L * 1024L * 1024L * 1024L)
            {
                return (size / 1024F / 1024F / 1024F) + "GB";
            }
            return size.ToString();//TB Level File?
        }
    }
}
