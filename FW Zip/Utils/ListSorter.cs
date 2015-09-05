using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FW_Zip.Utils
{
    class ListSorter : IComparer
    {
        public static int NAME = 1;
        public static int TYPE = 2;
        public static int DATE = 3;
        public static int SIZE = 4;

        private int mode;
        
        public ListSorter(DirectoryInfo di, int sortmode)
        {
            mode = sortmode;
        }

        public int Compare(object x, object y)
        {
            switch(mode)
            {
                case 1:
                    return string.Compare(x.ToString(), y.ToString());
                case 2:

                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    break;
            }
            return 0;
        }
    }
}
