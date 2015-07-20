using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FW_Zip
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitLanguageFilesAndFillLanguageMenu();
        }

        private void InitLanguageFilesAndFillLanguageMenu()
        {
            List<string> langs = Config.LoadLanguages();
            if (langs.Count > 0)
            {
                //填充菜单
            }
        }

        private void SwitchLanguage()
        {
            //Application.StartupPath + Path.DirectorySeparatorChar + Properties.Settings.Default.Language;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ConfigurationManager.
            //NameValueCollection appSettings = ConfigurationManager.AppSettings;
            //String str = ConfigurationManager.AppSettings.Get("Language");
            //MessageBox.Show(str);
            Language.LoadFile(Application.StartupPath+@"\Languages","zh_CN");
            foreach(string id in Language.trans.Keys)
            {
                Console.WriteLine(id + "$" + Language.trans[id]);
            }
        }

        private void openInsideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("OpenInside");
        }

        private void openOutsideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("OpenOutside");
        }

        private void splitFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SplitFile");
        }

        private void combineFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CombineFile");
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Properties");
        }

        private void createFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void createFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CreateFile");
        }

        private void linkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Link");
        }

        private void exitXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void copyToToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void moveToToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void invertSelectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void selectByTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deselectByTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void largeIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //largeIconToolStripMenuItem.Checked = !largeIconToolStripMenuItem.Checked;
        }

        private void smallIconToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void detailToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void typeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sizeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void unsortedToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void upOneLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void freshToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
