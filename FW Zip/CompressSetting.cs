using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FW_Zip
{
    public partial class CompressSetting : Form
    {
        public enum ArchiveFormat
        {
            SEVENZIP,BZIP2,GZIP,TAR,WIM,XZ,ZIP
        }
        public enum CompressionLevel
        {
            STORE, FASTEST, FAST, NORMAL, MAXIMUM, ULTRA
        }
        public enum CompressionMethod
        {
            LZMA2,LZMA,PPMd,BZIP2
        }
        public enum UpdateMode
        {
            ADD_AND_REPLACE,UPDATE_AND_ADD,FRESHEN_EXISTING,SYNCHRONIZE
        }
        public enum PathMode
        {
            RELATIVE,FULL,ABSOLUTE
        }

        private ArchiveFormat aformat=ArchiveFormat.SEVENZIP;
        private CompressionLevel cLvl=CompressionLevel.NORMAL;
        private CompressionMethod cMethod = CompressionMethod.LZMA2;
        private UpdateMode uMode=UpdateMode.ADD_AND_REPLACE;
        private PathMode pMode=PathMode.RELATIVE;

        private int dicSize = 1024 * 64;//KB
        private int wordSize=64;
        private int sbSize=1024*4;//MB,-1=Non-Solid,-2=Solid
        private int cpuThreads = Environment.ProcessorCount;

        public CompressSetting()
        {
            InitializeComponent();
        }

        private void CompressSetting_Load(object sender, EventArgs e)
        {
            comboArchiveFormat.SelectedIndex=0;
            comboCompressionLevel.SelectedIndex = 3;
            comboCompressionMethod.SelectedIndex = 0;
            comboDictionarySize.SelectedIndex = 12;
            comboWordSize.SelectedIndex = 6;
            comboSolidBlockSize.SelectedIndex = 13;
            comboCPUThreads.SelectedIndex = 0;///
            comboUpdateMode.SelectedIndex = 0;
            comboPathMode.SelectedIndex = 0;
            comboEncryptMethod.SelectedIndex = 0;
            //
            lblMaxProcessorCount.Text = "/" + cpuThreads;
            for(int i=2;i<=cpuThreads;i++)
            {
                comboCPUThreads.Items.Add(i);
            }
        }
    }
}
