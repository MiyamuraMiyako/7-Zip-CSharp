using FW_Zip.Utils;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FW_Zip
{
    public partial class MainForm : Form
    {
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool GetDiskFreeSpace(string lpRootPathName,
                                            out uint lpSectorsPerCluster,
                                            out uint lpBytesPerSector,
                                            out uint lpNumberOfFreeClusters,
                                            out uint lpTotalNumberOfClusters);

        public enum ListType
        {
            Computer, Dir, Package
        }

        //
        public static ListType CurList = ListType.Computer;
        public static DirectoryInfo CurDir = new DirectoryInfo(Environment.ExpandEnvironmentVariables("%SystemDrive%"));

        public MainForm()
        {
            InitializeComponent();
            InitLanguageFilesAndFillLanguageMenu();//fill language menu
            I18N.LoadLanguage();
            UpdateLanguage();
            FillList();
            Log.CleanLog();
        }

        private void InitLanguageFilesAndFillLanguageMenu()
        {
            Dictionary<string, string> lst = I18N.GetLanguageList();
            if (lst.Count > 0)
            {
                foreach (string k in lst.Keys)
                {
                    ToolStripMenuItem tsmi = new ToolStripMenuItem(lst[k], null, languageSubMenuToolStripMenuItem_Click);
                    tsmi.Tag = k;
                    languageToolStripMenuItem.DropDownItems.Add(tsmi);
                }
            }
        }

        private void UpdateLanguage()
        {
            fileToolStripMenuItem.Text = I18N.GetString("File(&F)");
            openToolStripMenuItem.Text = I18N.GetString("Open");
            openInsideToolStripMenuItem.Text = I18N.GetString("Open Inside");
            openOutsideToolStripMenuItem.Text = I18N.GetString("Open Outside");
            splitFileToolStripMenuItem.Text = I18N.GetString("Split File...");
            combineFileToolStripMenuItem.Text = I18N.GetString("Combine File...");
            propertiesToolStripMenuItem.Text = I18N.GetString("Properties...");
            createFolderToolStripMenuItem.Text = I18N.GetString("Create Folder...");
            createFileToolStripMenuItem.Text = I18N.GetString("Create File...");
            linkToolStripMenuItem.Text = I18N.GetString("Link...");
            exitXToolStripMenuItem.Text = I18N.GetString("Exit(&X)");
            //
            editEToolStripMenuItem.Text = I18N.GetString("Edit(&E)");
            renameToolStripMenuItem.Text = I18N.GetString("Rename");
            copyToToolStripMenuItem.Text = I18N.GetString("Copy To...");
            moveToToolStripMenuItem.Text = I18N.GetString("Move To...");
            deleteToolStripMenuItem.Text = I18N.GetString("Delete");
            selectAllToolStripMenuItem.Text = I18N.GetString("Select All");
            invertSelectToolStripMenuItem.Text = I18N.GetString("Invert Select");
            selectByTypeToolStripMenuItem.Text = I18N.GetString("Select By Type");
            deselectByTypeToolStripMenuItem.Text = I18N.GetString("Deselect By Type");
            //
            viewVToolStripMenuItem.Text = I18N.GetString("View(&V)");
            largeIconToolStripMenuItem.Text = I18N.GetString("Large Icons");
            smallIconToolStripMenuItem.Text = I18N.GetString("Small Icons");
            listToolStripMenuItem.Text = I18N.GetString("List");
            detailToolStripMenuItem.Text = I18N.GetString("Details");
            nameToolStripMenuItem.Text = I18N.GetString("Name");
            typeToolStripMenuItem.Text = I18N.GetString("Type");
            dateToolStripMenuItem.Text = I18N.GetString("Date");
            sizeToolStripMenuItem.Text = I18N.GetString("Size");
            unsortedToolStripMenuItem.Text = I18N.GetString("Unsorted");
            upOneLevelToolStripMenuItem.Text = I18N.GetString("Up One Level");
            freshToolStripMenuItem.Text = I18N.GetString("Fresh");
            //
            toolsTToolStripMenuItem.Text = I18N.GetString("Tools(&T)");
            optionsToolStripMenuItem.Text = I18N.GetString("Options...");
            languageToolStripMenuItem.Text = I18N.GetString("Language");
            benchmarkTestToolStripMenuItem.Text = I18N.GetString("Benchmark...");
            //
            helpHToolStripMenuItem.Text = I18N.GetString("Help(&H)");
            openHelpToolStripMenuItem.Text = I18N.GetString("Open Help...");
            aboutToolStripMenuItem.Text = I18N.GetString("About FW Zip...");
            //
            toolAdd.Text = I18N.GetString("Add");
            toolExtract.Text = I18N.GetString("Extract");
            toolTest.Text = I18N.GetString("Test");
            toolCopy.Text = I18N.GetString("Copy");
            toolMove.Text = I18N.GetString("Move");
            toolDelete.Text = I18N.GetString("Delete");
            toolInfo.Text = I18N.GetString("Info");
        }

        private void SwitchListHeader()
        {
            listFiles.Clear();
            switch (CurList)
            {
                case ListType.Computer:
                    break;
                case ListType.Dir:
                    break;
                case ListType.Package:
                    break;
            }
        }

        private void FillHeader()
        {
            if (listFiles.View != View.Details)
            {
                return;
            }
            switch (CurList)
            {
                case ListType.Computer:
                    listFiles.Columns.Add("Name");
                    listFiles.Columns.Add("Total Size");
                    listFiles.Columns.Add("Free Size");
                    listFiles.Columns.Add("Type");
                    listFiles.Columns.Add("Label");
                    listFiles.Columns.Add("File System");
                    listFiles.Columns.Add("Cluster Size");
                    break;
                case ListType.Dir:
                    listFiles.Columns.Add("Name");
                    listFiles.Columns.Add("Size");
                    listFiles.Columns.Add("Modified");
                    listFiles.Columns.Add("Create");
                    listFiles.Columns.Add("Type");
                    break;
                case ListType.Package:
                    listFiles.Columns.Add("Name");
                    listFiles.Columns.Add("Total Size");
                    listFiles.Columns.Add("Free Size");
                    listFiles.Columns.Add("Type");
                    listFiles.Columns.Add("Label");
                    listFiles.Columns.Add("File System");
                    listFiles.Columns.Add("Cluster Size");
                    break;
            }
        }

        private void FillList()
        {
            listFiles.Items.Clear();
            FillHeader();
            switch (CurList)
            {
                case ListType.Computer:
                    foreach (DriveInfo drive in DriveInfo.GetDrives())
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.SubItems[0].Text = drive.Name;
                        if (drive.IsReady)
                        {
                            lvi.SubItems.Add(Util.HommizationSize(drive.TotalSize));
                            lvi.SubItems.Add(Util.HommizationSize(drive.AvailableFreeSpace));
                            lvi.SubItems.Add(drive.DriveType.ToString());
                            lvi.SubItems.Add(drive.VolumeLabel);
                            lvi.SubItems.Add(drive.DriveFormat);
                            //
                            uint cluster, bt, c, d;
                            GetDiskFreeSpace(drive.Name,out cluster,out bt,out c,out d);
                            //
                            lvi.SubItems.Add((cluster*bt) +"");

                        }
                        listFiles.Items.Add(lvi);
                    }
                    break;
                case ListType.Dir:
                    foreach (DirectoryInfo d in CurDir.EnumerateDirectories())
                    {
                        if (d.Attributes.HasFlag(FileAttributes.Hidden))
                        {
                            continue;
                        }
                        ListViewItem lvi = new ListViewItem();
                        lvi.SubItems[0].Text = d.Name;
                        lvi.SubItems.Add("");
                        lvi.SubItems.Add(d.LastWriteTime.ToString());
                        lvi.SubItems.Add(d.CreationTime.ToString());
                        lvi.Tag = d;
                        listFiles.Items.Add(lvi);
                    }

                    foreach (FileInfo f in CurDir.EnumerateFiles())
                    {
                        if (f.Attributes.HasFlag(FileAttributes.Hidden))
                        {
                            continue;
                        }
                        ListViewItem lvi = new ListViewItem();
                        lvi.SubItems[0].Text = f.Name;
                        lvi.SubItems.Add(Util.HommizationSize(f.Length));
                        lvi.SubItems.Add(f.LastWriteTime.ToString());
                        lvi.SubItems.Add(f.CreationTime.ToString());
                        lvi.Tag = f;
                        listFiles.Items.Add(lvi);
                    }
                    listFiles.EndUpdate();
                    textAddress.Text = CurDir.FullName;
                    break;
                case ListType.Package:
                    break;
            }
            listFiles.EndUpdate();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            if (!largeIconToolStripMenuItem.Checked)
            {
                largeIconToolStripMenuItem.Checked = true;
                smallIconToolStripMenuItem.Checked = false;
                listToolStripMenuItem.Checked = false;
                detailToolStripMenuItem.Checked = false;
                //
                listFiles.View = View.LargeIcon;
                listFiles.Update();
            }
        }

        private void smallIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!smallIconToolStripMenuItem.Checked)
            {
                largeIconToolStripMenuItem.Checked = false;
                smallIconToolStripMenuItem.Checked = true;
                listToolStripMenuItem.Checked = false;
                detailToolStripMenuItem.Checked = false;
                //
                listFiles.View = View.SmallIcon;
                listFiles.Update();
            }
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!listToolStripMenuItem.Checked)
            {
                largeIconToolStripMenuItem.Checked = false;
                smallIconToolStripMenuItem.Checked = false;
                listToolStripMenuItem.Checked = true;
                detailToolStripMenuItem.Checked = false;
                //
                listFiles.View = View.List;
                listFiles.Update();
            }
        }

        private void detailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!detailToolStripMenuItem.Checked)
            {
                largeIconToolStripMenuItem.Checked = false;
                smallIconToolStripMenuItem.Checked = false;
                listToolStripMenuItem.Checked = false;
                detailToolStripMenuItem.Checked = true;
                //
                listFiles.View = View.Details;
                listFiles.Update();
            }
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
            new OptionsForm().ShowDialog();
        }

        private void basicTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
        }

        private void openHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {

        }

        private void toolExtract_Click(object sender, EventArgs e)
        {

        }

        private void toolTest_Click(object sender, EventArgs e)
        {

        }

        private void toolCopy_Click(object sender, EventArgs e)
        {

        }

        private void toolMove_Click(object sender, EventArgs e)
        {

        }

        private void toolDelete_Click(object sender, EventArgs e)
        {

        }

        private void toolInfo_Click(object sender, EventArgs e)
        {

        }

        private void buttonUpward_Click(object sender, EventArgs e)
        {

        }

        private void listFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            statusLblSelected.Text = string.Format(I18N.GetString("{0} object(s) selected"), listFiles.SelectedItems.Count);
            if (listFiles.SelectedItems.Count > 0)
            {
                //
               
            }
            else
            {
                //
            }
        }

        private void listFiles_DoubleClick(object sender,EventArgs e)
        {
            //
        }

        private void languageSubMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem t = (ToolStripMenuItem)sender;
            Properties.Settings.Default.Language = t.Tag.ToString();
            I18N.LoadLanguage();
            UpdateLanguage();
        }
    }
}
