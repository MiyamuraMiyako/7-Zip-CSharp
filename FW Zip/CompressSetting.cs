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
            SEVENZIP, BZIP2, GZIP, TAR, WIM, XZ, ZIP
        }
        public enum CompressionLevel
        {
            STORE, FASTEST, FAST, NORMAL, MAXIMUM, ULTRA
        }
        public enum CompressionMethod
        {
            LZMA2, LZMA, PPMd, BZIP2
        }
        public enum UpdateMode
        {
            ADD_AND_REPLACE, UPDATE_AND_ADD, FRESHEN_EXISTING, SYNCHRONIZE
        }
        public enum PathMode
        {
            RELATIVE, FULL, ABSOLUTE
        }

        private ArchiveFormat aformat = ArchiveFormat.SEVENZIP;
        private CompressionLevel cLvl = CompressionLevel.NORMAL;
        private CompressionMethod cMethod = CompressionMethod.LZMA2;
        private UpdateMode uMode = UpdateMode.ADD_AND_REPLACE;
        private PathMode pMode = PathMode.RELATIVE;

        private int dicSize = 1024 * 64;//KB
        private int wordSize = 64;
        private int sbSize = 1024 * 4;//MB,-1=Non-Solid,-2=Solid
        private int cpuThreads = Environment.ProcessorCount;

        public CompressSetting()
        {
            InitializeComponent();
        }

        private void CompressSetting_Load(object sender, EventArgs e)
        {
            comboArchiveFormat.SelectedIndex = 0;
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
            for (int i = 1; i <= cpuThreads; i++)
            {
                comboCPUThreads.Items.Add(i);
            }
        }

        private void ComboBoxClear()
        {
            comboCompressionLevel.Items.Clear();
            comboCompressionMethod.Items.Clear();
            comboDictionarySize.Items.Clear();
            comboWordSize.Items.Clear();
            comboSolidBlockSize.Items.Clear();
            comboCPUThreads.Items.Clear();
            comboEncryptMethod.Items.Clear();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                textPath.Text = ofd.FileName;
            }
        }

        private void comboArchiveFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboArchiveFormat.SelectedItem.ToString())
            {
            case "7z":
                comboCompressionMethod.Enabled = true;
                comboDictionarySize.Enabled = true;
                comboWordSize.Enabled = true;
                comboSolidBlockSize.Enabled = true;
                comboCPUThreads.Enabled = true;
                groupBoxEncryption.Enabled = true;
                chkboxSFX.Enabled = true;
                //
                groupBoxNTFS.Hide();
                //
                ComboBoxClear();
                //
                comboCompressionLevel.Items.AddRange(new string[] { "Store", "Fastest", "Fast", "Normal", "Maximum", "Ultra" });
                comboCompressionMethod.Items.AddRange(new string[] { "LZMA2", "LZMA", "PPMd", "BZip2" });
                comboDictionarySize.Items.AddRange(new string[] { "64 KB", "1 MB", "2 MB", "3 MB", "4 MB", "6 MB", "8 MB", "12 MB", "16 MB", "24 MB", "32 MB", "48 MB", "64 MB", "96 MB", "128 MB", "192 MB", "256 MB", "384 MB", "512 MB", "768 MB", "1024 MB", "1536 MB" });
                comboWordSize.Items.AddRange(new string[] { "8", "12", "16", "24", "32", "48", "64", "96", "128", "192", "256", "273" });
                comboSolidBlockSize.Items.AddRange(new string[] { "Non-Solid", "1 MB", "2 MB", "4 MB", "8 MB", "16 MB", "32 MB", "64 MB", "128 MB", "256 MB", "512 MB", "1 GB", "2 GB", "4 GB", "8GB", "16 GB", "32 GB", "64 GB", "Solid" });
                for (int i = 1; i <= cpuThreads; i++)
                {
                    comboCPUThreads.Items.Add(i);
                }
                comboEncryptMethod.Items.Add("AES-256");
                //
                comboCompressionLevel.SelectedIndex = 2;
                comboCompressionMethod.SelectedIndex = 0;
                comboDictionarySize.SelectedIndex = 12;
                comboWordSize.SelectedIndex = 6;
                comboSolidBlockSize.SelectedIndex = 13;
                comboCPUThreads.SelectedIndex = 0;
                comboEncryptMethod.SelectedIndex = 0;
                break;
            case "bzip2":
                comboCompressionMethod.Enabled = true;
                comboDictionarySize.Enabled = true;
                comboWordSize.Enabled = false;
                comboSolidBlockSize.Enabled = false;
                comboCPUThreads.Enabled = true;
                groupBoxEncryption.Enabled = false;
                chkboxSFX.Enabled = false;
                //
                groupBoxNTFS.Hide();
                //
                ComboBoxClear();
                //
                comboCompressionLevel.Items.AddRange(new string[] { "Fastest", "Fast", "Normal", "Maximum", "Ultra" });
                comboCompressionMethod.Items.AddRange(new string[] { "BZip2" });
                comboDictionarySize.Items.AddRange(new string[] { "100 KB", "200 KB", "300 KB", "400 KB", "500 KB", "600 KB", "700 KB", "800 KB", "900 KB" });
                for (int i = 1; i <= cpuThreads; i++)
                {
                    comboCPUThreads.Items.Add(i);
                }
                //
                comboCompressionLevel.SelectedIndex = 3;
                comboCompressionMethod.SelectedIndex = 0;
                comboDictionarySize.SelectedIndex = 8;
                comboCPUThreads.SelectedIndex = 0;
                break;
            case "gzip":
                comboCompressionMethod.Enabled = true;
                comboDictionarySize.Enabled = true;
                comboWordSize.Enabled = true;
                comboSolidBlockSize.Enabled = false;
                comboCPUThreads.Enabled = false;
                groupBoxEncryption.Enabled = false;
                chkboxSFX.Enabled = false;
                //
                groupBoxNTFS.Hide();
                //
                ComboBoxClear();
                //
                comboCompressionLevel.Items.AddRange(new string[] { "Fastest", "Normal", "Maximum", "Ultra" });
                comboCompressionMethod.Items.AddRange(new string[] { "Deflate" });
                comboDictionarySize.Items.AddRange(new string[] { "32 KB" });
                comboWordSize.Items.AddRange(new string[] { "8", "12", "16", "24", "32", "48", "64", "96", "128", "192", "256", "258" });
                //
                comboCompressionLevel.SelectedIndex = 1;
                comboCompressionMethod.SelectedIndex = 0;
                comboDictionarySize.SelectedIndex = 0;
                comboWordSize.SelectedIndex = 4;
                break;
            case "tar":
                comboCompressionMethod.Enabled = false;
                comboDictionarySize.Enabled = false;
                comboWordSize.Enabled = false;
                comboSolidBlockSize.Enabled = false;
                comboCPUThreads.Enabled = false;
                groupBoxEncryption.Enabled = false;
                chkboxSFX.Enabled = false;
                //
                groupBoxNTFS.Show();
                //
                ComboBoxClear();
                //
                comboCompressionLevel.Items.AddRange(new string[] { "Store", });
                //
                comboCompressionLevel.SelectedIndex = 0;
                //
                chkboxStoreAltDatStream.Hide();
                chkboxStoreFileSecurity.Hide();
                //
                break;
            case "wim":
                comboCompressionMethod.Enabled = false;
                comboDictionarySize.Enabled = false;
                comboWordSize.Enabled = false;
                comboSolidBlockSize.Enabled = false;
                comboCPUThreads.Enabled = false;
                groupBoxEncryption.Enabled = false;
                chkboxSFX.Enabled = false;
                //
                groupBoxNTFS.Show();
                //
                ComboBoxClear();
                //
                comboCompressionLevel.Items.AddRange(new string[] { "Store", });
                //
                comboCompressionLevel.SelectedIndex = 0;
                //
                chkboxStoreAltDatStream.Show();
                chkboxStoreFileSecurity.Show();
                //
                break;
            case "xz":
                comboCompressionMethod.Enabled = true;
                comboDictionarySize.Enabled = true;
                comboWordSize.Enabled = true;
                comboSolidBlockSize.Enabled = false;
                comboCPUThreads.Enabled = true;
                groupBoxEncryption.Enabled = false;
                chkboxSFX.Enabled = false;
                //
                groupBoxNTFS.Hide();
                //
                ComboBoxClear();
                //
                comboCompressionLevel.Items.AddRange(new string[] { "Fastest", "Fast", "Normal", "Maximum", "Ultra" });
                comboCompressionMethod.Items.AddRange(new string[] { "LZMA2" });
                comboDictionarySize.Items.AddRange(new string[] { "64 KB", "1 MB", "2 MB", "3 MB", "4 MB", "6 MB", "8 MB", "12 MB", "16 MB", "24 MB", "32 MB", "48 MB", "64 MB", "96 MB", "128 MB", "192 MB", "256 MB", "384 MB", "512 MB", "768 MB", "1024 MB", "1536 MB" });
                comboWordSize.Items.AddRange(new string[] { "8", "12", "16", "24", "32", "48", "64", "96", "128", "192", "256", "273" });
                for (int i = 1; i <= cpuThreads; i++)
                {
                    comboCPUThreads.Items.Add(i);
                }
                //
                comboCompressionLevel.SelectedIndex = 2;
                comboCompressionMethod.SelectedIndex = 0;
                comboDictionarySize.SelectedIndex = 8;
                comboWordSize.SelectedIndex = 4;
                comboCPUThreads.SelectedIndex = 0;
                break;
            case "zip":
                comboCompressionMethod.Enabled = true;
                comboDictionarySize.Enabled = true;
                comboWordSize.Enabled = true;
                comboSolidBlockSize.Enabled = false;
                comboCPUThreads.Enabled = true;
                groupBoxEncryption.Enabled = true;
                chkboxSFX.Enabled = false;
                //
                groupBoxNTFS.Hide();
                //
                ComboBoxClear();
                //
                comboCompressionLevel.Items.AddRange(new string[] {"Store", "Fastest", "Normal", "Maximum", "Ultra" });
                comboCompressionMethod.Items.AddRange(new string[] { "Deflate", "Deflate64","BZip2","LZMA","PPMd" });
                comboDictionarySize.Items.AddRange(new string[] { "32 KB" });
                comboWordSize.Items.AddRange(new string[] { "8", "12", "16", "24", "32", "48", "64", "96", "128", "192", "256", "258" });
                for (int i = 1; i <= cpuThreads; i++)
                {
                    comboCPUThreads.Items.Add(i);
                }
                comboEncryptMethod.Items.Add("ZipCrypto");
                comboEncryptMethod.Items.Add("AES-256");
                //
                comboCompressionLevel.SelectedIndex = 3;
                comboCompressionMethod.SelectedIndex = 0;
                comboDictionarySize.SelectedIndex = 0;
                comboWordSize.SelectedIndex = 4;
                comboCPUThreads.SelectedIndex = 0;
                comboEncryptMethod.SelectedIndex = 0;
                break;
            }
        }
    }
}
