using FW_Zip.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }

        private void FileLinkDialog_Load(object sender, EventArgs e)
        {

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
                FileInfo fiTo = new FileInfo(textLinkTo.Text);
                DirectoryInfo diFm = new DirectoryInfo(textLinkFrom.Text);
                FileInfo fiFm = new FileInfo(textLinkFrom.Text);
                if (fiTo.Exists)
                {
                    if (!diFm.Exists && !fiFm.Exists)
                    {
                        if (fiFm.Directory.Root.Name.Equals(fiTo.Directory.Root.Name))
                        {
                            CreateHardLink(fiFm.FullName, fiTo.FullName, IntPtr.Zero);
                        }
                        else
                        {
                            MessageBox.Show(I18N.GetString("Must create hard link in same drive!"));
                        }
                    }
                    else
                    {
                        MessageBox.Show(I18N.GetString("Target file exist!"));
                    }
                }
                else
                {
                    if(diFm.Exists)
                    {
                        MessageBox.Show(I18N.GetString("Only file can create hard link!"));
                    }
                    else
                    {
                        MessageBox.Show(I18N.GetString(""));
                    }
                }
            }
            else if (radioSymbolLink.Checked)
            {
                //
            }
            else if (radioDirSymbolLink.Checked)
            {
                //
            }
            else
            {
                //
            }
        }
    }
}
