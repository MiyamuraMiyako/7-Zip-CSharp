namespace FW_Zip
{
    partial class CompressSetting
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
            this.label1 = new System.Windows.Forms.Label();
            this.textPath = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboArchiveFormat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboCompressionLevel = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboCompressionMethod = new System.Windows.Forms.ComboBox();
            this.comboDictionarySize = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboWordSize = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboCPUThreads = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMaxProcessorCount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDecompressingMemUsage = new System.Windows.Forms.Label();
            this.lblCompressingMemUsage = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.comboSplitSize = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblReenterPwd = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.comboUpdateMode = new System.Windows.Forms.ComboBox();
            this.comboPathMode = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkboxDelFilesAfterCompression = new System.Windows.Forms.CheckBox();
            this.chkboxCompressShareFiles = new System.Windows.Forms.CheckBox();
            this.chkboxSFX = new System.Windows.Forms.CheckBox();
            this.groupBoxEncryption = new System.Windows.Forms.GroupBox();
            this.chkboxEncryptFilesNames = new System.Windows.Forms.CheckBox();
            this.comboEncryptMethod = new System.Windows.Forms.ComboBox();
            this.chkboxShowPwd = new System.Windows.Forms.CheckBox();
            this.textReenterPwd = new System.Windows.Forms.TextBox();
            this.textPwd = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textParam = new System.Windows.Forms.TextBox();
            this.comboSolidBlockSize = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBoxNTFS = new System.Windows.Forms.GroupBox();
            this.chkboxStoreFileSecurity = new System.Windows.Forms.CheckBox();
            this.chkboxStoreAltDatStream = new System.Windows.Forms.CheckBox();
            this.chkboxHardLink = new System.Windows.Forms.CheckBox();
            this.chkboxStoreSymbolLink = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBoxEncryption.SuspendLayout();
            this.groupBoxNTFS.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Archive:";
            // 
            // textPath
            // 
            this.textPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.textPath.Location = new System.Drawing.Point(71, 12);
            this.textPath.Name = "textPath";
            this.textPath.Size = new System.Drawing.Size(420, 21);
            this.textPath.TabIndex = 1;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(497, 10);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 2;
            this.buttonBrowse.Text = "Browse...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Archive Format:";
            // 
            // comboArchiveFormat
            // 
            this.comboArchiveFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboArchiveFormat.FormattingEnabled = true;
            this.comboArchiveFormat.Items.AddRange(new object[] {
            "7z",
            "bzip2",
            "gzip",
            "tar",
            "wim",
            "xz",
            "zip"});
            this.comboArchiveFormat.Location = new System.Drawing.Point(141, 45);
            this.comboArchiveFormat.Name = "comboArchiveFormat";
            this.comboArchiveFormat.Size = new System.Drawing.Size(113, 20);
            this.comboArchiveFormat.TabIndex = 4;
            this.comboArchiveFormat.SelectedIndexChanged += new System.EventHandler(this.comboArchiveFormat_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Compression Level:";
            // 
            // comboCompressionLevel
            // 
            this.comboCompressionLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCompressionLevel.FormattingEnabled = true;
            this.comboCompressionLevel.Items.AddRange(new object[] {
            "Store",
            "Fastest",
            "Fast",
            "Normal",
            "Maximum",
            "Ultra"});
            this.comboCompressionLevel.Location = new System.Drawing.Point(141, 71);
            this.comboCompressionLevel.Name = "comboCompressionLevel";
            this.comboCompressionLevel.Size = new System.Drawing.Size(113, 20);
            this.comboCompressionLevel.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Compression Method:";
            // 
            // comboCompressionMethod
            // 
            this.comboCompressionMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCompressionMethod.FormattingEnabled = true;
            this.comboCompressionMethod.Items.AddRange(new object[] {
            "LZMA2",
            "LZMA",
            "PPMd",
            "BZip2"});
            this.comboCompressionMethod.Location = new System.Drawing.Point(141, 97);
            this.comboCompressionMethod.Name = "comboCompressionMethod";
            this.comboCompressionMethod.Size = new System.Drawing.Size(113, 20);
            this.comboCompressionMethod.TabIndex = 8;
            // 
            // comboDictionarySize
            // 
            this.comboDictionarySize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDictionarySize.FormattingEnabled = true;
            this.comboDictionarySize.Items.AddRange(new object[] {
            "64KB",
            "1MB",
            "2MB",
            "3MB",
            "4MB",
            "6MB",
            "8MB",
            "12MB",
            "16MB",
            "24MB",
            "32MB",
            "48MB",
            "64MB",
            "96MB",
            "128MB",
            "192MB",
            "256MB",
            "384MB",
            "512MB",
            "768MB",
            "1024MB",
            "1536MB"});
            this.comboDictionarySize.Location = new System.Drawing.Point(141, 123);
            this.comboDictionarySize.Name = "comboDictionarySize";
            this.comboDictionarySize.Size = new System.Drawing.Size(113, 20);
            this.comboDictionarySize.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "Dictionary Size:";
            // 
            // comboWordSize
            // 
            this.comboWordSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboWordSize.FormattingEnabled = true;
            this.comboWordSize.Items.AddRange(new object[] {
            "8",
            "12",
            "16",
            "24",
            "32",
            "48",
            "64",
            "96",
            "128",
            "192",
            "256",
            "273"});
            this.comboWordSize.Location = new System.Drawing.Point(141, 149);
            this.comboWordSize.Name = "comboWordSize";
            this.comboWordSize.Size = new System.Drawing.Size(113, 20);
            this.comboWordSize.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "Word Size:";
            // 
            // comboCPUThreads
            // 
            this.comboCPUThreads.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCPUThreads.FormattingEnabled = true;
            this.comboCPUThreads.Location = new System.Drawing.Point(155, 201);
            this.comboCPUThreads.Name = "comboCPUThreads";
            this.comboCPUThreads.Size = new System.Drawing.Size(64, 20);
            this.comboCPUThreads.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "Number Of CPU Threads:";
            // 
            // lblMaxProcessorCount
            // 
            this.lblMaxProcessorCount.AutoSize = true;
            this.lblMaxProcessorCount.Location = new System.Drawing.Point(225, 204);
            this.lblMaxProcessorCount.Name = "lblMaxProcessorCount";
            this.lblMaxProcessorCount.Size = new System.Drawing.Size(17, 12);
            this.lblMaxProcessorCount.TabIndex = 15;
            this.lblMaxProcessorCount.Text = "/1";
            this.lblMaxProcessorCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 244);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(179, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "Memory Usage For Compressing:";
            // 
            // lblDecompressingMemUsage
            // 
            this.lblDecompressingMemUsage.AutoSize = true;
            this.lblDecompressingMemUsage.Location = new System.Drawing.Point(209, 272);
            this.lblDecompressingMemUsage.Name = "lblDecompressingMemUsage";
            this.lblDecompressingMemUsage.Size = new System.Drawing.Size(23, 12);
            this.lblDecompressingMemUsage.TabIndex = 17;
            this.lblDecompressingMemUsage.Text = "N/A";
            // 
            // lblCompressingMemUsage
            // 
            this.lblCompressingMemUsage.AutoSize = true;
            this.lblCompressingMemUsage.Location = new System.Drawing.Point(209, 244);
            this.lblCompressingMemUsage.Name = "lblCompressingMemUsage";
            this.lblCompressingMemUsage.Size = new System.Drawing.Size(23, 12);
            this.lblCompressingMemUsage.TabIndex = 18;
            this.lblCompressingMemUsage.Text = "N/A";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 272);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(191, 12);
            this.label12.TabIndex = 19;
            this.label12.Text = "Memory Usage For Decompressing:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 311);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(137, 12);
            this.label13.TabIndex = 20;
            this.label13.Text = "Split To Volumes,Byte:";
            // 
            // comboSplitSize
            // 
            this.comboSplitSize.FormattingEnabled = true;
            this.comboSplitSize.Items.AddRange(new object[] {
            "10M",
            "650M - CD",
            "700M - CD",
            "4092M - FAT",
            "4480M - DVD",
            "8128M - DVD DL",
            "23040M - BD",
            "1457664 - 3.5\" floppy"});
            this.comboSplitSize.Location = new System.Drawing.Point(14, 330);
            this.comboSplitSize.Name = "comboSplitSize";
            this.comboSplitSize.Size = new System.Drawing.Size(240, 20);
            this.comboSplitSize.TabIndex = 21;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 361);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 12);
            this.label14.TabIndex = 22;
            this.label14.Text = "Parameters:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(298, 48);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 12);
            this.label15.TabIndex = 24;
            this.label15.Text = "Update Mode:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(4, 134);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(113, 12);
            this.label17.TabIndex = 26;
            this.label17.Text = "Encryption Method:";
            // 
            // lblReenterPwd
            // 
            this.lblReenterPwd.AutoSize = true;
            this.lblReenterPwd.Location = new System.Drawing.Point(6, 68);
            this.lblReenterPwd.Name = "lblReenterPwd";
            this.lblReenterPwd.Size = new System.Drawing.Size(107, 12);
            this.lblReenterPwd.TabIndex = 27;
            this.lblReenterPwd.Text = "Reenter Password:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(8, 24);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(95, 12);
            this.label19.TabIndex = 28;
            this.label19.Text = "Enter Password:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(298, 74);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 12);
            this.label20.TabIndex = 29;
            this.label20.Text = "Path Mode:";
            // 
            // comboUpdateMode
            // 
            this.comboUpdateMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboUpdateMode.FormattingEnabled = true;
            this.comboUpdateMode.Items.AddRange(new object[] {
            "Add and replace files",
            "Update and add files",
            "Freshen exists files",
            "Synchronize files"});
            this.comboUpdateMode.Location = new System.Drawing.Point(423, 45);
            this.comboUpdateMode.Name = "comboUpdateMode";
            this.comboUpdateMode.Size = new System.Drawing.Size(149, 20);
            this.comboUpdateMode.TabIndex = 30;
            // 
            // comboPathMode
            // 
            this.comboPathMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPathMode.FormattingEnabled = true;
            this.comboPathMode.Items.AddRange(new object[] {
            "Relative pathnames",
            "Full path names",
            "Absolute path names"});
            this.comboPathMode.Location = new System.Drawing.Point(423, 71);
            this.comboPathMode.Name = "comboPathMode";
            this.comboPathMode.Size = new System.Drawing.Size(149, 20);
            this.comboPathMode.TabIndex = 31;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkboxDelFilesAfterCompression);
            this.groupBox1.Controls.Add(this.chkboxCompressShareFiles);
            this.groupBox1.Controls.Add(this.chkboxSFX);
            this.groupBox1.Location = new System.Drawing.Point(300, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 89);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // chkboxDelFilesAfterCompression
            // 
            this.chkboxDelFilesAfterCompression.AutoSize = true;
            this.chkboxDelFilesAfterCompression.Location = new System.Drawing.Point(6, 64);
            this.chkboxDelFilesAfterCompression.Name = "chkboxDelFilesAfterCompression";
            this.chkboxDelFilesAfterCompression.Size = new System.Drawing.Size(204, 16);
            this.chkboxDelFilesAfterCompression.TabIndex = 2;
            this.chkboxDelFilesAfterCompression.Text = "Delete Files After Compression";
            this.chkboxDelFilesAfterCompression.UseVisualStyleBackColor = true;
            // 
            // chkboxCompressShareFiles
            // 
            this.chkboxCompressShareFiles.AutoSize = true;
            this.chkboxCompressShareFiles.Location = new System.Drawing.Point(6, 42);
            this.chkboxCompressShareFiles.Name = "chkboxCompressShareFiles";
            this.chkboxCompressShareFiles.Size = new System.Drawing.Size(144, 16);
            this.chkboxCompressShareFiles.TabIndex = 1;
            this.chkboxCompressShareFiles.Text = "Compress Share Files";
            this.chkboxCompressShareFiles.UseVisualStyleBackColor = true;
            // 
            // chkboxSFX
            // 
            this.chkboxSFX.AutoSize = true;
            this.chkboxSFX.Location = new System.Drawing.Point(6, 20);
            this.chkboxSFX.Name = "chkboxSFX";
            this.chkboxSFX.Size = new System.Drawing.Size(132, 16);
            this.chkboxSFX.TabIndex = 0;
            this.chkboxSFX.Text = "Create SFX Archive";
            this.chkboxSFX.UseVisualStyleBackColor = true;
            // 
            // groupBoxEncryption
            // 
            this.groupBoxEncryption.Controls.Add(this.chkboxEncryptFilesNames);
            this.groupBoxEncryption.Controls.Add(this.comboEncryptMethod);
            this.groupBoxEncryption.Controls.Add(this.chkboxShowPwd);
            this.groupBoxEncryption.Controls.Add(this.textReenterPwd);
            this.groupBoxEncryption.Controls.Add(this.textPwd);
            this.groupBoxEncryption.Controls.Add(this.label19);
            this.groupBoxEncryption.Controls.Add(this.lblReenterPwd);
            this.groupBoxEncryption.Controls.Add(this.label17);
            this.groupBoxEncryption.Location = new System.Drawing.Point(300, 196);
            this.groupBoxEncryption.Name = "groupBoxEncryption";
            this.groupBoxEncryption.Size = new System.Drawing.Size(272, 186);
            this.groupBoxEncryption.TabIndex = 33;
            this.groupBoxEncryption.TabStop = false;
            this.groupBoxEncryption.Text = "Encryption";
            // 
            // chkboxEncryptFilesNames
            // 
            this.chkboxEncryptFilesNames.AutoSize = true;
            this.chkboxEncryptFilesNames.Location = new System.Drawing.Point(6, 157);
            this.chkboxEncryptFilesNames.Name = "chkboxEncryptFilesNames";
            this.chkboxEncryptFilesNames.Size = new System.Drawing.Size(132, 16);
            this.chkboxEncryptFilesNames.TabIndex = 33;
            this.chkboxEncryptFilesNames.Text = "Encrypt File names";
            this.chkboxEncryptFilesNames.UseVisualStyleBackColor = true;
            // 
            // comboEncryptMethod
            // 
            this.comboEncryptMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEncryptMethod.FormattingEnabled = true;
            this.comboEncryptMethod.Items.AddRange(new object[] {
            "AES-256"});
            this.comboEncryptMethod.Location = new System.Drawing.Point(123, 131);
            this.comboEncryptMethod.Name = "comboEncryptMethod";
            this.comboEncryptMethod.Size = new System.Drawing.Size(121, 20);
            this.comboEncryptMethod.TabIndex = 32;
            // 
            // chkboxShowPwd
            // 
            this.chkboxShowPwd.AutoSize = true;
            this.chkboxShowPwd.Location = new System.Drawing.Point(6, 110);
            this.chkboxShowPwd.Name = "chkboxShowPwd";
            this.chkboxShowPwd.Size = new System.Drawing.Size(102, 16);
            this.chkboxShowPwd.TabIndex = 31;
            this.chkboxShowPwd.Text = "Show Password";
            this.chkboxShowPwd.UseVisualStyleBackColor = true;
            // 
            // textReenterPwd
            // 
            this.textReenterPwd.Location = new System.Drawing.Point(6, 83);
            this.textReenterPwd.Name = "textReenterPwd";
            this.textReenterPwd.Size = new System.Drawing.Size(238, 21);
            this.textReenterPwd.TabIndex = 30;
            this.textReenterPwd.UseSystemPasswordChar = true;
            // 
            // textPwd
            // 
            this.textPwd.Location = new System.Drawing.Point(6, 39);
            this.textPwd.Name = "textPwd";
            this.textPwd.Size = new System.Drawing.Size(238, 21);
            this.textPwd.TabIndex = 29;
            this.textPwd.UseSystemPasswordChar = true;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(416, 495);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 34;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(497, 495);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 35;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // textParam
            // 
            this.textParam.Location = new System.Drawing.Point(14, 376);
            this.textParam.Name = "textParam";
            this.textParam.Size = new System.Drawing.Size(240, 21);
            this.textParam.TabIndex = 36;
            // 
            // comboSolidBlockSize
            // 
            this.comboSolidBlockSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSolidBlockSize.FormattingEnabled = true;
            this.comboSolidBlockSize.Items.AddRange(new object[] {
            "Non-Solid",
            "1MB",
            "2MB",
            "4MB",
            "8MB",
            "12MB",
            "32MB",
            "64MB",
            "128MB",
            "256MB",
            "512MB",
            "1GB",
            "2GB",
            "4GB",
            "8GB",
            "16GB",
            "32GB",
            "64GB",
            "Solid"});
            this.comboSolidBlockSize.Location = new System.Drawing.Point(141, 175);
            this.comboSolidBlockSize.Name = "comboSolidBlockSize";
            this.comboSolidBlockSize.Size = new System.Drawing.Size(113, 20);
            this.comboSolidBlockSize.TabIndex = 38;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 178);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(107, 12);
            this.label16.TabIndex = 37;
            this.label16.Text = "Solid Block Size:";
            // 
            // groupBoxNTFS
            // 
            this.groupBoxNTFS.Controls.Add(this.chkboxStoreFileSecurity);
            this.groupBoxNTFS.Controls.Add(this.chkboxStoreAltDatStream);
            this.groupBoxNTFS.Controls.Add(this.chkboxHardLink);
            this.groupBoxNTFS.Controls.Add(this.chkboxStoreSymbolLink);
            this.groupBoxNTFS.Location = new System.Drawing.Point(14, 403);
            this.groupBoxNTFS.Name = "groupBoxNTFS";
            this.groupBoxNTFS.Size = new System.Drawing.Size(240, 120);
            this.groupBoxNTFS.TabIndex = 39;
            this.groupBoxNTFS.TabStop = false;
            this.groupBoxNTFS.Text = "NTFS";
            // 
            // chkboxStoreFileSecurity
            // 
            this.chkboxStoreFileSecurity.AutoSize = true;
            this.chkboxStoreFileSecurity.Location = new System.Drawing.Point(7, 89);
            this.chkboxStoreFileSecurity.Name = "chkboxStoreFileSecurity";
            this.chkboxStoreFileSecurity.Size = new System.Drawing.Size(138, 16);
            this.chkboxStoreFileSecurity.TabIndex = 3;
            this.chkboxStoreFileSecurity.Text = "Store File Security";
            this.chkboxStoreFileSecurity.UseVisualStyleBackColor = true;
            // 
            // chkboxStoreAltDatStream
            // 
            this.chkboxStoreAltDatStream.AutoSize = true;
            this.chkboxStoreAltDatStream.Location = new System.Drawing.Point(7, 67);
            this.chkboxStoreAltDatStream.Name = "chkboxStoreAltDatStream";
            this.chkboxStoreAltDatStream.Size = new System.Drawing.Size(186, 16);
            this.chkboxStoreAltDatStream.TabIndex = 2;
            this.chkboxStoreAltDatStream.Text = "Store Altemate Data Streams";
            this.chkboxStoreAltDatStream.UseVisualStyleBackColor = true;
            // 
            // chkboxHardLink
            // 
            this.chkboxHardLink.AutoSize = true;
            this.chkboxHardLink.Location = new System.Drawing.Point(7, 44);
            this.chkboxHardLink.Name = "chkboxHardLink";
            this.chkboxHardLink.Size = new System.Drawing.Size(120, 16);
            this.chkboxHardLink.TabIndex = 1;
            this.chkboxHardLink.Text = "Store Hard Links";
            this.chkboxHardLink.UseVisualStyleBackColor = true;
            // 
            // chkboxStoreSymbolLink
            // 
            this.chkboxStoreSymbolLink.AutoSize = true;
            this.chkboxStoreSymbolLink.Location = new System.Drawing.Point(7, 21);
            this.chkboxStoreSymbolLink.Name = "chkboxStoreSymbolLink";
            this.chkboxStoreSymbolLink.Size = new System.Drawing.Size(144, 16);
            this.chkboxStoreSymbolLink.TabIndex = 0;
            this.chkboxStoreSymbolLink.Text = "Store Symbolic Links";
            this.chkboxStoreSymbolLink.UseVisualStyleBackColor = true;
            // 
            // CompressSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 535);
            this.Controls.Add(this.groupBoxNTFS);
            this.Controls.Add(this.comboSolidBlockSize);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.textParam);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.groupBoxEncryption);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboPathMode);
            this.Controls.Add(this.comboUpdateMode);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.comboSplitSize);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblCompressingMemUsage);
            this.Controls.Add(this.lblDecompressingMemUsage);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblMaxProcessorCount);
            this.Controls.Add(this.comboCPUThreads);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboWordSize);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboDictionarySize);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboCompressionMethod);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboCompressionLevel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboArchiveFormat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.textPath);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CompressSetting";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "CompressSetting";
            this.Load += new System.EventHandler(this.CompressSetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxEncryption.ResumeLayout(false);
            this.groupBoxEncryption.PerformLayout();
            this.groupBoxNTFS.ResumeLayout(false);
            this.groupBoxNTFS.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textPath;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboArchiveFormat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboCompressionLevel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboCompressionMethod;
        private System.Windows.Forms.ComboBox comboDictionarySize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboWordSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboCPUThreads;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblMaxProcessorCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblDecompressingMemUsage;
        private System.Windows.Forms.Label lblCompressingMemUsage;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboSplitSize;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblReenterPwd;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox comboUpdateMode;
        private System.Windows.Forms.ComboBox comboPathMode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkboxDelFilesAfterCompression;
        private System.Windows.Forms.CheckBox chkboxCompressShareFiles;
        private System.Windows.Forms.CheckBox chkboxSFX;
        private System.Windows.Forms.GroupBox groupBoxEncryption;
        private System.Windows.Forms.CheckBox chkboxEncryptFilesNames;
        private System.Windows.Forms.ComboBox comboEncryptMethod;
        private System.Windows.Forms.CheckBox chkboxShowPwd;
        private System.Windows.Forms.TextBox textReenterPwd;
        private System.Windows.Forms.TextBox textPwd;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textParam;
        private System.Windows.Forms.ComboBox comboSolidBlockSize;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBoxNTFS;
        private System.Windows.Forms.CheckBox chkboxStoreFileSecurity;
        private System.Windows.Forms.CheckBox chkboxStoreAltDatStream;
        private System.Windows.Forms.CheckBox chkboxHardLink;
        private System.Windows.Forms.CheckBox chkboxStoreSymbolLink;
    }
}