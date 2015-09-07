namespace FW_Zip
{
    partial class FileLinkDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textLinkFrom = new System.Windows.Forms.TextBox();
            this.textLinkTo = new System.Windows.Forms.TextBox();
            this.groupBoxLinkType = new System.Windows.Forms.GroupBox();
            this.radioDirJunction = new System.Windows.Forms.RadioButton();
            this.radioDirSymbolLink = new System.Windows.Forms.RadioButton();
            this.radioSymbolLink = new System.Windows.Forms.RadioButton();
            this.radioHardLink = new System.Windows.Forms.RadioButton();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonLinkFromBrowse = new System.Windows.Forms.Button();
            this.buttonLinkToBrowse = new System.Windows.Forms.Button();
            this.groupBoxLinkType.SuspendLayout();
            this.SuspendLayout();
            // 
            // textLinkFrom
            // 
            this.textLinkFrom.Location = new System.Drawing.Point(12, 22);
            this.textLinkFrom.Name = "textLinkFrom";
            this.textLinkFrom.Size = new System.Drawing.Size(368, 21);
            this.textLinkFrom.TabIndex = 0;
            this.textLinkFrom.Text = "Link From...";
            // 
            // textLinkTo
            // 
            this.textLinkTo.Location = new System.Drawing.Point(12, 63);
            this.textLinkTo.Name = "textLinkTo";
            this.textLinkTo.Size = new System.Drawing.Size(368, 21);
            this.textLinkTo.TabIndex = 1;
            this.textLinkTo.Text = "Link To...";
            // 
            // groupBoxLinkType
            // 
            this.groupBoxLinkType.Controls.Add(this.radioDirJunction);
            this.groupBoxLinkType.Controls.Add(this.radioDirSymbolLink);
            this.groupBoxLinkType.Controls.Add(this.radioSymbolLink);
            this.groupBoxLinkType.Controls.Add(this.radioHardLink);
            this.groupBoxLinkType.Location = new System.Drawing.Point(12, 114);
            this.groupBoxLinkType.Name = "groupBoxLinkType";
            this.groupBoxLinkType.Size = new System.Drawing.Size(449, 109);
            this.groupBoxLinkType.TabIndex = 2;
            this.groupBoxLinkType.TabStop = false;
            this.groupBoxLinkType.Text = "Link Type";
            // 
            // radioDirJunction
            // 
            this.radioDirJunction.AutoSize = true;
            this.radioDirJunction.Location = new System.Drawing.Point(6, 86);
            this.radioDirJunction.Name = "radioDirJunction";
            this.radioDirJunction.Size = new System.Drawing.Size(131, 16);
            this.radioDirJunction.TabIndex = 3;
            this.radioDirJunction.TabStop = true;
            this.radioDirJunction.Text = "Directory Junction";
            this.radioDirJunction.UseVisualStyleBackColor = true;
            // 
            // radioDirSymbolLink
            // 
            this.radioDirSymbolLink.AutoSize = true;
            this.radioDirSymbolLink.Location = new System.Drawing.Point(6, 64);
            this.radioDirSymbolLink.Name = "radioDirSymbolLink";
            this.radioDirSymbolLink.Size = new System.Drawing.Size(149, 16);
            this.radioDirSymbolLink.TabIndex = 2;
            this.radioDirSymbolLink.TabStop = true;
            this.radioDirSymbolLink.Text = "Directory Symbol Link";
            this.radioDirSymbolLink.UseVisualStyleBackColor = true;
            // 
            // radioSymbolLink
            // 
            this.radioSymbolLink.AutoSize = true;
            this.radioSymbolLink.Location = new System.Drawing.Point(6, 42);
            this.radioSymbolLink.Name = "radioSymbolLink";
            this.radioSymbolLink.Size = new System.Drawing.Size(119, 16);
            this.radioSymbolLink.TabIndex = 1;
            this.radioSymbolLink.TabStop = true;
            this.radioSymbolLink.Text = "File Symbol Link";
            this.radioSymbolLink.UseVisualStyleBackColor = true;
            this.radioSymbolLink.CheckedChanged += new System.EventHandler(this.radioSymbolLink_CheckedChanged);
            // 
            // radioHardLink
            // 
            this.radioHardLink.AutoSize = true;
            this.radioHardLink.Location = new System.Drawing.Point(6, 20);
            this.radioHardLink.Name = "radioHardLink";
            this.radioHardLink.Size = new System.Drawing.Size(77, 16);
            this.radioHardLink.TabIndex = 0;
            this.radioHardLink.TabStop = true;
            this.radioHardLink.Text = "Hard Link";
            this.radioHardLink.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(305, 247);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(386, 247);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonLinkFromBrowse
            // 
            this.buttonLinkFromBrowse.Location = new System.Drawing.Point(386, 20);
            this.buttonLinkFromBrowse.Name = "buttonLinkFromBrowse";
            this.buttonLinkFromBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonLinkFromBrowse.TabIndex = 5;
            this.buttonLinkFromBrowse.Text = "Browse...";
            this.buttonLinkFromBrowse.UseVisualStyleBackColor = true;
            this.buttonLinkFromBrowse.Click += new System.EventHandler(this.buttonLinkFromBrowse_Click);
            // 
            // buttonLinkToBrowse
            // 
            this.buttonLinkToBrowse.Location = new System.Drawing.Point(386, 61);
            this.buttonLinkToBrowse.Name = "buttonLinkToBrowse";
            this.buttonLinkToBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonLinkToBrowse.TabIndex = 6;
            this.buttonLinkToBrowse.Text = "Browse...";
            this.buttonLinkToBrowse.UseVisualStyleBackColor = true;
            this.buttonLinkToBrowse.Click += new System.EventHandler(this.buttonLinkToBrowse_Click);
            // 
            // FileLinkDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 282);
            this.Controls.Add(this.buttonLinkToBrowse);
            this.Controls.Add(this.buttonLinkFromBrowse);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBoxLinkType);
            this.Controls.Add(this.textLinkTo);
            this.Controls.Add(this.textLinkFrom);
            this.Name = "FileLinkDialog";
            this.Text = "FileLinkDialog";
            this.Load += new System.EventHandler(this.FileLinkDialog_Load);
            this.groupBoxLinkType.ResumeLayout(false);
            this.groupBoxLinkType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textLinkFrom;
        private System.Windows.Forms.TextBox textLinkTo;
        private System.Windows.Forms.GroupBox groupBoxLinkType;
        private System.Windows.Forms.RadioButton radioDirJunction;
        private System.Windows.Forms.RadioButton radioDirSymbolLink;
        private System.Windows.Forms.RadioButton radioSymbolLink;
        private System.Windows.Forms.RadioButton radioHardLink;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonLinkFromBrowse;
        private System.Windows.Forms.Button buttonLinkToBrowse;
    }
}