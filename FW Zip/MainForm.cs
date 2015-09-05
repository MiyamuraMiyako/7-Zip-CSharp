using FW_Zip.Utils;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

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

        [StructLayout(LayoutKind.Sequential)]
        public struct SHELLEXECUTEINFO
        {
            public int cbSize;
            public uint fMask;
            public IntPtr hwnd;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpVerb;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpParameters;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpDirectory;
            public int nShow;
            public IntPtr hInstApp;
            public IntPtr lpIDList;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpClass;
            public IntPtr hkeyClass;
            public uint dwHotKey;
            public IntPtr hIcon;
            public IntPtr hProcess;
        }

        private const int SW_SHOW = 5;
        private const uint SEE_MASK_INVOKEIDLIST = 12;

        [DllImport("shell32.dll")]
        static extern bool ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);

        public enum ListType
        {
            Computer, Dir, Package
        }

        //
        static ListType curList = ListType.Computer;
        static DirectoryInfo curDir = new DirectoryInfo(Environment.ExpandEnvironmentVariables("%SystemDrive%"));
        static ImageList smallIcon = new ImageList();
        static ImageList largeIcon = new ImageList();

        public MainForm()
        {
            InitializeComponent();

            listFiles.MouseDoubleClick += new MouseEventHandler(listFiles_MouseDoubleClick);
            listFiles.MouseClick += new MouseEventHandler(listFiles_MouseClick);

            InitLanguageFilesAndFillLanguageMenu();//fill language menu

            Console.WriteLine();
            I18N.LoadLanguage();
            FillList();
            UpdateLanguage();


            listFiles.SmallImageList = smallIcon;
            listFiles.LargeImageList = largeIcon;
            smallIcon.ColorDepth = ColorDepth.Depth32Bit;
            largeIcon.ColorDepth = ColorDepth.Depth32Bit;
            smallIcon.ImageSize = new Size(20, 20);
            largeIcon.ImageSize = new Size(48, 48);

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
            //
            switch (curList)
            {
                case ListType.Computer:
                    listFiles.Columns[0].Text = I18N.GetString("Name");
                    listFiles.Columns[1].Text = I18N.GetString("Total Size");
                    listFiles.Columns[2].Text = I18N.GetString("Free Size");
                    listFiles.Columns[3].Text = I18N.GetString("Type");
                    listFiles.Columns[4].Text = I18N.GetString("Label");
                    listFiles.Columns[5].Text = I18N.GetString("File System");
                    listFiles.Columns[6].Text = I18N.GetString("Cluster Size");
                    break;
                case ListType.Dir:
                    listFiles.Columns[0].Text = I18N.GetString("Name");
                    listFiles.Columns[1].Text = I18N.GetString("Size");
                    listFiles.Columns[2].Text = I18N.GetString("Modified");
                    listFiles.Columns[3].Text = I18N.GetString("Create");
                    listFiles.Columns[4].Text = I18N.GetString("Type");
                    break;
                case ListType.Package:
                    break;
            }
        }

        private void EnterPath(string name)
        {
            switch (curList)
            {
                case ListType.Computer:
                    DriveInfo di = new DriveInfo(name);
                    if (di.IsReady)
                    {
                        curList = ListType.Dir;
                        curDir = new DirectoryInfo(name);
                        FillList();
                    }
                    break;
                case ListType.Dir:
                    DirectoryInfo dir = new DirectoryInfo(curDir.FullName + Path.DirectorySeparatorChar + name);
                    FileInfo fi = new FileInfo(curDir.FullName + Path.DirectorySeparatorChar + name);
                    if (dir.Exists)
                    {
                        curDir = dir;
                        FillList();
                    }
                    else
                    {
                        //file open 
                    }
                    break;
                case ListType.Package:
                    break;
            }
        }

        private void FillList()
        {
            listFiles.BeginUpdate();
            if (listFiles.View == View.Details)
            {
                listFiles.Columns.Clear();
                switch (curList)
                {
                    case ListType.Computer:
                        listFiles.Columns.Add(I18N.GetString("Name"));
                        listFiles.Columns.Add(I18N.GetString("Total Size"));
                        listFiles.Columns.Add(I18N.GetString("Free Size"));
                        listFiles.Columns.Add(I18N.GetString("Type"));
                        listFiles.Columns.Add(I18N.GetString("Label"));
                        listFiles.Columns.Add(I18N.GetString("File System"));
                        listFiles.Columns.Add(I18N.GetString("Cluster Size"));
                        break;
                    case ListType.Dir:
                        listFiles.Columns.Add(I18N.GetString("Name"));
                        listFiles.Columns.Add(I18N.GetString("Size"));
                        listFiles.Columns.Add(I18N.GetString("Modified"));
                        listFiles.Columns.Add(I18N.GetString("Create"));
                        listFiles.Columns.Add(I18N.GetString("Type"));
                        break;
                    case ListType.Package:
                        listFiles.Columns.Add(I18N.GetString("Name"));
                        listFiles.Columns.Add(I18N.GetString("Total Size"));
                        listFiles.Columns.Add(I18N.GetString("Free Size"));
                        listFiles.Columns.Add(I18N.GetString("Type"));
                        listFiles.Columns.Add(I18N.GetString("Label"));
                        listFiles.Columns.Add(I18N.GetString("File System"));
                        listFiles.Columns.Add(I18N.GetString("Cluster Size"));
                        break;
                }
            }

            listFiles.Items.Clear();
            smallIcon.Images.Clear();
            largeIcon.Images.Clear();

            int index = 0;
            switch (curList)
            {
                case ListType.Computer:
                    foreach (DriveInfo drive in DriveInfo.GetDrives())
                    {
                        largeIcon.Images.Add(GetLargeIcon(drive.Name));
                        smallIcon.Images.Add(GetSmallIcon(drive.Name));

                        ListViewItem lvi = new ListViewItem();
                        lvi.SubItems[0].Text = drive.Name;
                        if (drive.IsReady)
                        {
                            lvi.SubItems.Add(Util.HommizationSize(drive.TotalSize));
                            lvi.SubItems.Add(Util.HommizationSize(drive.AvailableFreeSpace));
                            lvi.SubItems.Add(drive.DriveType.ToString());
                            lvi.SubItems.Add(drive.VolumeLabel);
                            lvi.SubItems.Add(drive.DriveFormat);
                            lvi.ImageIndex = index++;
                            //
                            uint cluster, bt, c, d;
                            GetDiskFreeSpace(drive.Name, out cluster, out bt, out c, out d);
                            //
                            lvi.SubItems.Add(Convert.ToString(cluster * bt));
                        }
                        listFiles.Items.Add(lvi);
                    }
                    textAddress.Text = "";
                    break;
                case ListType.Dir:
                    foreach (DirectoryInfo d in curDir.GetDirectories())
                    {
                        largeIcon.Images.Add(GetLargeIcon(d.FullName));
                        smallIcon.Images.Add(GetSmallIcon(d.FullName));

                        if (d.Attributes.HasFlag(FileAttributes.Hidden))
                        {
                            continue;
                        }
                        ListViewItem lvi = new ListViewItem();
                        lvi.SubItems[0].Text = d.Name;
                        lvi.SubItems.Add("");
                        lvi.SubItems.Add(d.LastWriteTime.ToString());
                        lvi.SubItems.Add(d.CreationTime.ToString());
                        lvi.ImageIndex = index++;
                        lvi.Tag = d;
                        listFiles.Items.Add(lvi);
                    }

                    foreach (FileInfo f in curDir.GetFiles())
                    {
                        largeIcon.Images.Add(GetLargeIcon(f.FullName));
                        smallIcon.Images.Add(GetSmallIcon(f.FullName));

                        if (f.Attributes.HasFlag(FileAttributes.Hidden))
                        {
                            //add setting to set display hide file.
                            continue;
                        }
                        ListViewItem lvi = new ListViewItem();
                        lvi.SubItems[0].Text = f.Name;
                        lvi.SubItems.Add(Util.HommizationSize(f.Length));
                        lvi.SubItems.Add(f.LastWriteTime.ToString());
                        lvi.SubItems.Add(f.CreationTime.ToString());
                        lvi.ImageIndex = index++;
                        lvi.Tag = f;
                        listFiles.Items.Add(lvi);
                    }
                    textAddress.Text = curDir.FullName;
                    break;
                case ListType.Package:
                    break;
            }

            for (int i = 0; i < listFiles.Columns.Count; i++)
            {
                listFiles.Columns[i].Width = -1;
            }
            listFiles.EndUpdate();
        }

        private Icon GetSmallIcon(string file)
        {
            return ShellEx.GetIconFromPath(file, ShellEx.IconSizeEnum.ExtraLargeIcon);
        }

        private Icon GetLargeIcon(string file)
        {
            return ShellEx.GetIconFromPath(file, ShellEx.IconSizeEnum.ExtraLargeIcon);
        }

        private void ChangeMenuAndToolbarStatus()
        {
            //
            upOneLevelToolStripMenuItem.Enabled = true;
            if (curList == ListType.Computer)
            {
                upOneLevelToolStripMenuItem.Enabled = false;
                renameToolStripMenuItem.Enabled = false;
                copyToToolStripMenuItem.Enabled = false;
                moveToToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
            }
            else if (curList == ListType.Dir)
            {
                renameToolStripMenuItem.Enabled = true;
                copyToToolStripMenuItem.Enabled = true;
                moveToToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem.Enabled = true;
            }
            //
            if (listFiles.SelectedItems.Count > 0)
            {
                openToolStripMenuItem.Enabled = true;
                openInsideToolStripMenuItem.Enabled = true;
                openOutsideToolStripMenuItem.Enabled = true;
                splitFileToolStripMenuItem.Enabled = true;
                combineFileToolStripMenuItem.Enabled = true;
                propertiesToolStripMenuItem.Enabled = true;
                linkToolStripMenuItem.Enabled = true;
                //
                toolAdd.Enabled = true;
                toolExtract.Enabled = true;
                toolTest.Enabled = true;
                toolCopy.Enabled = true;
                toolMove.Enabled = true;
                toolDelete.Enabled = true;
                toolInfo.Enabled = true;
            }
            else
            {
                openToolStripMenuItem.Enabled = false;
                openInsideToolStripMenuItem.Enabled = false;
                openOutsideToolStripMenuItem.Enabled = false;
                splitFileToolStripMenuItem.Enabled = false;
                combineFileToolStripMenuItem.Enabled = false;
                propertiesToolStripMenuItem.Enabled = false;
                linkToolStripMenuItem.Enabled = false;
                //
                toolAdd.Enabled = false;
                toolExtract.Enabled = false;
                toolTest.Enabled = false;
                toolCopy.Enabled = false;
                toolMove.Enabled = false;
                toolDelete.Enabled = false;
                toolInfo.Enabled = false;
                //
                renameToolStripMenuItem.Enabled = false;
                copyToToolStripMenuItem.Enabled = false;
                moveToToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnterPath(listFiles.SelectedItems[0].Text);
            ChangeMenuAndToolbarStatus();
        }

        private void openInsideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnterPath(listFiles.SelectedItems[0].Text);
            ChangeMenuAndToolbarStatus();
        }

        private void openOutsideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curList == ListType.Computer)
            {
                Process.Start(listFiles.SelectedItems[0].Text);
            }
            else if (curList == ListType.Dir)
            {
                Process.Start(curDir.FullName + Path.DirectorySeparatorChar + listFiles.SelectedItems[0].Text);
            }
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
            SHELLEXECUTEINFO info = new SHELLEXECUTEINFO();
            info.cbSize = Marshal.SizeOf(info);
            info.lpVerb = "properties";
            if (curList == ListType.Computer)
            {
                info.lpFile = (listFiles.SelectedItems[0].Text);
            }
            else if (curList == ListType.Dir)
            {
                info.lpFile = (curDir.FullName + Path.DirectorySeparatorChar + listFiles.SelectedItems[0].Text);
            }
            info.nShow = SW_SHOW;
            info.fMask = SEE_MASK_INVOKEIDLIST;
            ShellExecuteEx(ref info);
        }

        private void createFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(curList==ListType.Dir)
            {
                string name=Interaction.InputBox("Please input new folder name:", "New Folder", "New Folder");
                DirectoryInfo di = new DirectoryInfo(curDir.FullName + Path.DirectorySeparatorChar + name);
                if(di.Exists)
                {
                    MessageBox.Show("Directory is exist");
                    return;
                }
                di.Create();
            }
        }

        private void createFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curList == ListType.Dir)
            {
                string name = Interaction.InputBox("Please input new folder name:", "New File", "New File");
                FileInfo fi = new FileInfo(curDir.FullName + Path.DirectorySeparatorChar + name);
                if(fi.Exists)
                {
                    MessageBox.Show("File is exist!");
                }
                fi.Create();
            }
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
            listFiles.SelectedItems[0].BeginEdit();
        }

        private void copyToToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void moveToToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curList == ListType.Dir)
            {
                for (int i = 0; i < listFiles.SelectedItems.Count; i++)
                {
                    DirectoryInfo di = new DirectoryInfo(curDir.FullName + Path.DirectorySeparatorChar + listFiles.SelectedItems[i].Text);
                    FileInfo fi = new FileInfo(curDir.FullName + Path.DirectorySeparatorChar + listFiles.SelectedItems[i].Text);
                    //
                    if (di.Exists)
                    {
                        di.Delete(true);//may be need to tip user?
                    }
                    else if (fi.Exists)
                    {
                        fi.Delete();
                    }
                }
                FillList();
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listFiles.Items)
            {
                lvi.Selected = true;
            }
        }

        private void invertSelectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listFiles.Items)
            {
                lvi.Selected = !lvi.Selected;
            }
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
            //listFiles.ListViewItemSorter = new ListSorter(curDir, ListSorter.TYPE);
            //listFiles.Sort();
        }

        private void dateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listFiles.ListViewItemSorter = new ListSorter(curDir, ListSorter.DATE);
            listFiles.Sort();
        }

        private void sizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listFiles.ListViewItemSorter = new ListSorter(curDir, ListSorter.SIZE);
            listFiles.Sort();
        }

        private void unsortedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Do nothing
        }

        private void upOneLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curDir.Parent != null)
            {
                curDir = curDir.Parent;
                EnterPath("");
            }
            else
            {
                curList = ListType.Computer;
                FillList();
            }
            ChangeMenuAndToolbarStatus();
        }

        private void freshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FillList();
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
            MessageBox.Show("Do you really need help?","Help",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
            if (curList == ListType.Dir)
            {
                for (int i = 0; i < listFiles.SelectedItems.Count; i++)
                {
                    DirectoryInfo di = new DirectoryInfo(curDir.FullName + Path.DirectorySeparatorChar + listFiles.SelectedItems[i].Text);
                    FileInfo fi = new FileInfo(curDir.FullName + Path.DirectorySeparatorChar + listFiles.SelectedItems[i].Text);
                    //
                    if (di.Exists)
                    {
                        di.Delete(true);//may be need to tip user?
                    }
                    else if (fi.Exists)
                    {
                        fi.Delete();
                    }
                }
                FillList();
            }
        }

        private void toolInfo_Click(object sender, EventArgs e)
        {
            SHELLEXECUTEINFO info = new SHELLEXECUTEINFO();
            info.cbSize = Marshal.SizeOf(info);
            info.lpVerb = "properties";
            if (curList == ListType.Computer)
            {
                info.lpFile = (listFiles.SelectedItems[0].Text);
            }
            else if (curList == ListType.Dir)
            {
                info.lpFile = (curDir.FullName + Path.DirectorySeparatorChar + listFiles.SelectedItems[0].Text);
            }
            info.nShow = SW_SHOW;
            info.fMask = SEE_MASK_INVOKEIDLIST;
            ShellExecuteEx(ref info);
        }

        private void buttonUpward_Click(object sender, EventArgs e)
        {
            if(curList==ListType.Dir)
            {
                if (curDir.Parent != null)
                {
                    curDir = curDir.Parent;
                    EnterPath("");
                }
                else
                {
                    curList = ListType.Computer;
                    FillList();
                }
            }
            
            ChangeMenuAndToolbarStatus();
        }

        private void listFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            statusLblSelected.Text = string.Format(I18N.GetString("{0} object(s) selected"), listFiles.SelectedItems.Count);
            ChangeMenuAndToolbarStatus();
        }

        private void listFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem lvi = listFiles.GetItemAt(e.X, e.Y);
            if (lvi != null)
            {
                EnterPath(lvi.Text);
                ChangeMenuAndToolbarStatus();
            }
        }

        private void listFiles_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem lvi = listFiles.GetItemAt(e.X, e.Y);
                if (lvi != null)
                {
                    Point point = PointToClient(listFiles.PointToScreen(new Point(e.X, e.Y)));
                    listFilesContextMenuStrip.Show(this, point);
                }
            }
        }

        private void languageSubMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem t = (ToolStripMenuItem)sender;
            Properties.Settings.Default.Language = t.Tag.ToString();
            I18N.LoadLanguage();
            UpdateLanguage();
            Properties.Settings.Default.IsUserSetLanguage = true;
            Properties.Settings.Default.Save();
        }
    }
}
