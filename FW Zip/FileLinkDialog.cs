using FW_Zip.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FW_Zip
{
    public partial class FileLinkDialog : Form
    {
        [DllImport("Kernel32.dll", CharSet = CharSet.Unicode)]
        static extern bool CreateHardLink(
        string lpFileName,
        string lpExistingFileName,
        IntPtr lpSecurityAttributes);

        [DllImport("kernel32.dll")]
        static extern bool CreateSymbolicLink(
            string lpSymlinkFileName,
            string lpTargetFileName, int dwFlags);

        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, IntPtr lParam);

        const uint BCM_SETSHIELD = 0x160C;

        public FileLinkDialog(string linkFile)
        {
            InitializeComponent();
            textLinkFrom.GotFocus += new EventHandler(textLink_Click);
            textLinkTo.GotFocus += new EventHandler(textLink_Click);

            textLinkTo.Text = linkFile;
            //
            if (new DirectoryInfo(linkFile).Exists)
            {
                radioDirSymbolLink.Checked = true;
            }
            else if (new FileInfo(linkFile).Exists)
            {
                radioSymbolLink.Checked = true;
            }
            //
            if (radioSymbolLink.Checked && !IsInAdmin())
            {
                buttonOK.FlatStyle = FlatStyle.System;
                SendMessage(buttonOK.Handle, BCM_SETSHIELD, 0, (IntPtr)1);
            }
            else
            {
                buttonOK.FlatStyle = FlatStyle.System;
                SendMessage(buttonOK.Handle, BCM_SETSHIELD, 0, (IntPtr)0);
            }
        }

        private void FileLinkDialog_Load(object sender, EventArgs e)
        {

        }

        private bool IsInAdmin()
        {
            System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
            return principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
        }

        private void RunElevated(string fileName)
        {
            if (IsInAdmin())
            {
                //Application.Run(new Form1());
            }
            else
            {
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.UseShellExecute = true;
                proc.WorkingDirectory = Environment.CurrentDirectory;
                proc.FileName = Application.ExecutablePath;
                proc.Verb = "runas";
                try
                {
                    Process.Start(proc);
                }
                catch (Win32Exception)
                {
                    MessageBox.Show("FAILED~");
                }
                Application.Exit();
            }
        }

        private void textLink_Click(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                ((TextBox)sender).SelectAll();
            });
        }

        private void buttonLinkFromBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                textLinkFrom.Text = ofd.FileName;
            }
        }

        private void buttonLinkToBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                textLinkTo.Text = ofd.FileName;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Dispose(true);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (radioHardLink.Checked)
            {
                FileInfo fiToHL = new FileInfo(textLinkTo.Text);
                DirectoryInfo diFmHL = new DirectoryInfo(textLinkFrom.Text);
                FileInfo fiFmHL = new FileInfo(textLinkFrom.Text);

                if (!fiToHL.Exists)
                {
                    MessageBox.Show(I18N.GetString("Target file not exist!"));
                    return;
                }

                if (diFmHL.Exists)
                {
                    MessageBox.Show(I18N.GetString("Only file can create hard link!"));
                    return;
                }

                if (fiFmHL.Exists)
                {
                    MessageBox.Show(I18N.GetString(diFmHL.Name + " exist!"));
                    return;
                }

                if (fiFmHL.Directory.Root.Name.ToLower().Equals(fiToHL.Directory.Root.Name.ToLower()))
                {
                    bool success = CreateHardLink(fiFmHL.FullName, fiToHL.FullName, IntPtr.Zero);
                    if (!success)
                    {
                        MessageBox.Show(I18N.GetString("Create Failed!"));
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(I18N.GetString("Must create hard link in same drive!"));
                    return;
                }
            }
            else if (radioSymbolLink.Checked)
            {
                FileInfo fiToSL = new FileInfo(textLinkTo.Text);
                DirectoryInfo diFmSL = new DirectoryInfo(textLinkFrom.Text);
                FileInfo fiFmSL = new FileInfo(textLinkFrom.Text);

                if (!fiToSL.Exists)
                {
                    MessageBox.Show(I18N.GetString("Target file not exist!"));
                    return;
                }

                if (diFmSL.Exists)
                {
                    MessageBox.Show(I18N.GetString("Only file can create hard link!"));
                    return;
                }

                if (fiFmSL.Exists)
                {
                    MessageBox.Show(I18N.GetString(diFmSL.Name + " exist!"));
                    return;
                }

                //TODO: How to process UAC to create symboliclink
                bool success = CreateSymbolicLink(fiFmSL.FullName, fiToSL.FullName, 0);
                if (!success)
                {
                    MessageBox.Show(I18N.GetString("Create Failed!"));
                    return;
                }
            }
            else if (radioDirSymbolLink.Checked)
            {
                DirectoryInfo diToDSL = new DirectoryInfo(textLinkTo.Text);
                FileInfo fiFmDSL = new FileInfo(textLinkFrom.Text);
                DirectoryInfo diFmDSL = new DirectoryInfo(textLinkFrom.Text);

                if (!diToDSL.Exists)
                {
                    MessageBox.Show(I18N.GetString("Target directory not exist!"));
                    return;
                }

                if (fiFmDSL.Exists)
                {
                    MessageBox.Show(I18N.GetString("Only directory can create directory symbol link!"));
                    return;
                }

                if (diFmDSL.Exists)
                {
                    MessageBox.Show(I18N.GetString(diFmDSL.Name + " exist!"));
                    return;
                }

                //TODO: How to process UAC to create symboliclink
                bool success = CreateSymbolicLink(diFmDSL.FullName, diToDSL.FullName, 1);//1:dir,0:file
                if (!success)
                {
                    MessageBox.Show(I18N.GetString("Create Failed!"));
                    return;
                }
            }
            else if (radioDirJunction.Checked)
            {
                DirectoryInfo diToDJ = new DirectoryInfo(textLinkTo.Text);
                FileInfo fiFmDJ = new FileInfo(textLinkFrom.Text);
                DirectoryInfo diFmDJ = new DirectoryInfo(textLinkFrom.Text);

                if (!diToDJ.Exists)
                {
                    MessageBox.Show(I18N.GetString("Target directory not exist!"));
                    return;
                }

                if (fiFmDJ.Exists)
                {
                    MessageBox.Show(I18N.GetString("Only directory can create directory symbol link!"));
                    return;
                }

                if (diFmDJ.Exists)
                {
                    MessageBox.Show(string.Format(I18N.GetString("{0} exist!")), diFmDJ.Name);
                    return;
                }

                bool success = JunctionPoint.Create(diFmDJ.FullName, diToDJ.FullName);
                if (!success)
                {
                    MessageBox.Show(I18N.GetString("Create Failed!"));
                    return;
                }
            }
            else
            {
                MessageBox.Show(I18N.GetString("Must select one link mode!"));
            }
            Dispose(true);
        }

        private void radioSymbolLink_CheckedChanged(object sender, EventArgs e)
        {
            if (radioSymbolLink.Checked && !IsInAdmin())
            {
                buttonOK.FlatStyle = FlatStyle.System;
                SendMessage(buttonOK.Handle, BCM_SETSHIELD, 0, (IntPtr)1);
            }
            else
            {
                buttonOK.FlatStyle = FlatStyle.System;
                SendMessage(buttonOK.Handle, BCM_SETSHIELD, 0, (IntPtr)0);
            }
        }
    }
}
