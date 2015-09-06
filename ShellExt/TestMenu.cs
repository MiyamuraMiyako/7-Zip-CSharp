using SharpShell.Attributes;
using SharpShell.SharpContextMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShellExt
{
    [ComVisible(true)]
    [COMServerAssociation(AssociationType.AllFiles)]
    class TestMenu : SharpContextMenu
    {
        protected override bool CanShowMenu()
        {
            return true;
        }

        protected override ContextMenuStrip CreateMenu()
        {
            ContextMenuStrip cms = new ContextMenuStrip();
            //this.SelectedItemPaths.ToString();
            
            cms.Items.Add(this.SelectedItemPaths.ToList()[0]);
            cms.Items.Add("Decompress");
            cms.Click += new EventHandler(ContextMenu_Clicked);
            return cms;
        }

        private void ContextMenu_Clicked(object sender,EventArgs e)
        {
            //
        }
    }
}
