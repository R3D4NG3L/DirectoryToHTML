namespace DirectoryToHtml
{
    partial class MainForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.panel4 = new System.Windows.Forms.Panel();
			this.lbl_EstimatedTime = new System.Windows.Forms.Label();
			this.lbl_CurrentFileName = new System.Windows.Forms.Label();
			this.lbl_FolderNumber = new System.Windows.Forms.Label();
			this.lbl_FilesNumber = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.btn_Scan = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.grpBox_Phase1 = new System.Windows.Forms.GroupBox();
			this.btn_SaveLocation = new System.Windows.Forms.Button();
			this.txt_SaveLocation = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btn_folderBrowser = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txt_FolderSelected = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.grpBox_Phase1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.lbl_EstimatedTime);
			this.panel4.Controls.Add(this.lbl_CurrentFileName);
			this.panel4.Controls.Add(this.lbl_FolderNumber);
			this.panel4.Controls.Add(this.lbl_FilesNumber);
			this.panel4.Controls.Add(this.label7);
			this.panel4.Controls.Add(this.label6);
			this.panel4.Controls.Add(this.label5);
			this.panel4.Controls.Add(this.label4);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(3, 278);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(678, 77);
			this.panel4.TabIndex = 11;
			// 
			// lbl_EstimatedTime
			// 
			this.lbl_EstimatedTime.AutoSize = true;
			this.lbl_EstimatedTime.Location = new System.Drawing.Point(109, 35);
			this.lbl_EstimatedTime.Name = "lbl_EstimatedTime";
			this.lbl_EstimatedTime.Size = new System.Drawing.Size(0, 13);
			this.lbl_EstimatedTime.TabIndex = 7;
			// 
			// lbl_CurrentFileName
			// 
			this.lbl_CurrentFileName.AutoSize = true;
			this.lbl_CurrentFileName.Location = new System.Drawing.Point(370, 35);
			this.lbl_CurrentFileName.Name = "lbl_CurrentFileName";
			this.lbl_CurrentFileName.Size = new System.Drawing.Size(0, 13);
			this.lbl_CurrentFileName.TabIndex = 6;
			// 
			// lbl_FolderNumber
			// 
			this.lbl_FolderNumber.AutoSize = true;
			this.lbl_FolderNumber.Location = new System.Drawing.Point(369, 10);
			this.lbl_FolderNumber.Name = "lbl_FolderNumber";
			this.lbl_FolderNumber.Size = new System.Drawing.Size(24, 13);
			this.lbl_FolderNumber.TabIndex = 5;
			this.lbl_FolderNumber.Text = "0/0";
			// 
			// lbl_FilesNumber
			// 
			this.lbl_FilesNumber.AutoSize = true;
			this.lbl_FilesNumber.Location = new System.Drawing.Point(106, 10);
			this.lbl_FilesNumber.Name = "lbl_FilesNumber";
			this.lbl_FilesNumber.Size = new System.Drawing.Size(24, 13);
			this.lbl_FilesNumber.TabIndex = 4;
			this.lbl_FilesNumber.Text = "0/0";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(9, 35);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(82, 13);
			this.label7.TabIndex = 3;
			this.label7.Text = "Estimated Time:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(270, 35);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(63, 13);
			this.label6.TabIndex = 2;
			this.label6.Text = "Current File:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(270, 10);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(44, 13);
			this.label5.TabIndex = 1;
			this.label5.Text = "Folders:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 10);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(31, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "Files:";
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.btn_Scan);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(3, 201);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(678, 71);
			this.panel3.TabIndex = 10;
			// 
			// btn_Scan
			// 
			this.btn_Scan.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btn_Scan.Location = new System.Drawing.Point(259, 21);
			this.btn_Scan.Name = "btn_Scan";
			this.btn_Scan.Size = new System.Drawing.Size(118, 26);
			this.btn_Scan.TabIndex = 7;
			this.btn_Scan.Text = "Scan Now";
			this.btn_Scan.UseVisualStyleBackColor = true;
			this.btn_Scan.Click += new System.EventHandler(this.btn_Scan_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.grpBox_Phase1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(3, 115);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(678, 80);
			this.panel2.TabIndex = 9;
			// 
			// grpBox_Phase1
			// 
			this.grpBox_Phase1.Controls.Add(this.btn_SaveLocation);
			this.grpBox_Phase1.Controls.Add(this.txt_SaveLocation);
			this.grpBox_Phase1.Controls.Add(this.label2);
			this.grpBox_Phase1.Controls.Add(this.btn_folderBrowser);
			this.grpBox_Phase1.Controls.Add(this.label1);
			this.grpBox_Phase1.Controls.Add(this.txt_FolderSelected);
			this.grpBox_Phase1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpBox_Phase1.Location = new System.Drawing.Point(0, 0);
			this.grpBox_Phase1.Name = "grpBox_Phase1";
			this.grpBox_Phase1.Size = new System.Drawing.Size(678, 80);
			this.grpBox_Phase1.TabIndex = 8;
			this.grpBox_Phase1.TabStop = false;
			this.grpBox_Phase1.Text = "Phase 1: Select folder and destination file";
			// 
			// btn_SaveLocation
			// 
			this.btn_SaveLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_SaveLocation.Location = new System.Drawing.Point(552, 50);
			this.btn_SaveLocation.Name = "btn_SaveLocation";
			this.btn_SaveLocation.Size = new System.Drawing.Size(118, 26);
			this.btn_SaveLocation.TabIndex = 5;
			this.btn_SaveLocation.Text = "Browse...";
			this.btn_SaveLocation.UseVisualStyleBackColor = true;
			this.btn_SaveLocation.Click += new System.EventHandler(this.btn_SaveLocation_Click);
			// 
			// txt_SaveLocation
			// 
			this.txt_SaveLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_SaveLocation.Location = new System.Drawing.Point(83, 54);
			this.txt_SaveLocation.Name = "txt_SaveLocation";
			this.txt_SaveLocation.Size = new System.Drawing.Size(463, 20);
			this.txt_SaveLocation.TabIndex = 4;
			this.txt_SaveLocation.Text = "C:\\FolderContent.csv";
			this.txt_SaveLocation.TextChanged += new System.EventHandler(this.txt_SaveLocation_TextChanged);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 61);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Save file in:";
			// 
			// btn_folderBrowser
			// 
			this.btn_folderBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_folderBrowser.Location = new System.Drawing.Point(552, 21);
			this.btn_folderBrowser.Name = "btn_folderBrowser";
			this.btn_folderBrowser.Size = new System.Drawing.Size(118, 26);
			this.btn_folderBrowser.TabIndex = 2;
			this.btn_folderBrowser.Text = "Browse...";
			this.btn_folderBrowser.UseVisualStyleBackColor = true;
			this.btn_folderBrowser.Click += new System.EventHandler(this.folderToScan_OnClick);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Folder to scan:";
			// 
			// txt_FolderSelected
			// 
			this.txt_FolderSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_FolderSelected.Location = new System.Drawing.Point(83, 25);
			this.txt_FolderSelected.Name = "txt_FolderSelected";
			this.txt_FolderSelected.Size = new System.Drawing.Size(463, 20);
			this.txt_FolderSelected.TabIndex = 0;
			this.txt_FolderSelected.Text = "C:\\";
			this.txt_FolderSelected.TextChanged += new System.EventHandler(this.txt_FolderSelected_TextChanged);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Controls.Add(this.menuStrip1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(678, 106);
			this.panel1.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Calibri", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.Maroon;
			this.label3.Location = new System.Drawing.Point(224, 27);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(424, 64);
			this.label3.TabIndex = 16;
			this.label3.Text = "Directory To HTML";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(10, 27);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(182, 65);
			this.pictureBox1.TabIndex = 15;
			this.pictureBox1.TabStop = false;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(678, 24);
			this.menuStrip1.TabIndex = 17;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurationToolStripMenuItem});
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.settingsToolStripMenuItem.Text = "Settings";
			// 
			// configurationToolStripMenuItem
			// 
			this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
			this.configurationToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.configurationToolStripMenuItem.Text = "Configuration";
			this.configurationToolStripMenuItem.Click += new System.EventHandler(this.configurationToolStripMenuItem_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 3);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.75676F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.24324F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(684, 358);
			this.tableLayoutPanel1.TabIndex = 9;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(684, 358);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "Directory To HTML - gTechSolutions.it";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_OnLoad);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.grpBox_Phase1.ResumeLayout(false);
			this.grpBox_Phase1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbl_EstimatedTime;
        private System.Windows.Forms.Label lbl_CurrentFileName;
        private System.Windows.Forms.Label lbl_FolderNumber;
        private System.Windows.Forms.Label lbl_FilesNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_Scan;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox grpBox_Phase1;
        private System.Windows.Forms.Button btn_SaveLocation;
        private System.Windows.Forms.TextBox txt_SaveLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_folderBrowser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_FolderSelected;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

