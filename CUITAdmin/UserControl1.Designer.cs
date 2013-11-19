namespace CUITAdmin {
    partial class UserControl1 {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        /// 


        private void InitializeComponent() {
            this.button1 = new System.Windows.Forms.Button();
            this.grpExportPath = new System.Windows.Forms.GroupBox();
            this.lblExportPath = new System.Windows.Forms.Label();
            this.txtInvoiceExportPath = new System.Windows.Forms.TextBox();
            this.btnSetInvoiceExportPath = new System.Windows.Forms.Button();
            this.grpInvoiceExport = new System.Windows.Forms.GroupBox();
            this.chkGLSU = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExportAll = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxSelectAccount = new System.Windows.Forms.ComboBox();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.btnExportSingle = new System.Windows.Forms.Button();
            this.txtMonth = new System.Windows.Forms.TextBox();
            this.comboBoxSelectMonth = new System.Windows.Forms.ComboBox();
            this.grpStandaloneFileExport = new System.Windows.Forms.GroupBox();
            this.btnImportStandalone = new System.Windows.Forms.Button();
            this.chkFullScreen = new System.Windows.Forms.CheckBox();
            this.chkStandalone = new System.Windows.Forms.CheckBox();
            this.btnImportLogs = new System.Windows.Forms.Button();
            this.btnExportStandaloneFile = new System.Windows.Forms.Button();
            this.grpExportPath.SuspendLayout();
            this.grpInvoiceExport.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpStandaloneFileExport.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(317, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // grpExportPath
            // 
            this.grpExportPath.Controls.Add(this.lblExportPath);
            this.grpExportPath.Controls.Add(this.txtInvoiceExportPath);
            this.grpExportPath.Controls.Add(this.btnSetInvoiceExportPath);
            this.grpExportPath.Location = new System.Drawing.Point(131, 124);
            this.grpExportPath.Name = "grpExportPath";
            this.grpExportPath.Size = new System.Drawing.Size(438, 100);
            this.grpExportPath.TabIndex = 1;
            this.grpExportPath.TabStop = false;
            this.grpExportPath.Text = "Export Invoice";
            // 
            // lblExportPath
            // 
            this.lblExportPath.AutoSize = true;
            this.lblExportPath.Location = new System.Drawing.Point(25, 29);
            this.lblExportPath.Name = "lblExportPath";
            this.lblExportPath.Size = new System.Drawing.Size(93, 13);
            this.lblExportPath.TabIndex = 3;
            this.lblExportPath.Text = "Enter Export Path:";
            // 
            // txtInvoiceExportPath
            // 
            this.txtInvoiceExportPath.Location = new System.Drawing.Point(25, 60);
            this.txtInvoiceExportPath.Name = "txtInvoiceExportPath";
            this.txtInvoiceExportPath.Size = new System.Drawing.Size(276, 20);
            this.txtInvoiceExportPath.TabIndex = 1;
            // 
            // btnSetInvoiceExportPath
            // 
            this.btnSetInvoiceExportPath.Location = new System.Drawing.Point(307, 58);
            this.btnSetInvoiceExportPath.Name = "btnSetInvoiceExportPath";
            this.btnSetInvoiceExportPath.Size = new System.Drawing.Size(103, 23);
            this.btnSetInvoiceExportPath.TabIndex = 2;
            this.btnSetInvoiceExportPath.Text = "Browse";
            this.btnSetInvoiceExportPath.UseVisualStyleBackColor = true;
            this.btnSetInvoiceExportPath.Click += new System.EventHandler(this.btnSetInvoiceExportPath_Click);
            // 
            // grpInvoiceExport
            // 
            this.grpInvoiceExport.Controls.Add(this.chkGLSU);
            this.grpInvoiceExport.Controls.Add(this.groupBox1);
            this.grpInvoiceExport.Controls.Add(this.groupBox2);
            this.grpInvoiceExport.Controls.Add(this.txtMonth);
            this.grpInvoiceExport.Controls.Add(this.comboBoxSelectMonth);
            this.grpInvoiceExport.Location = new System.Drawing.Point(131, 230);
            this.grpInvoiceExport.Name = "grpInvoiceExport";
            this.grpInvoiceExport.Size = new System.Drawing.Size(243, 232);
            this.grpInvoiceExport.TabIndex = 2;
            this.grpInvoiceExport.TabStop = false;
            this.grpInvoiceExport.Text = "Export Invoice";
            // 
            // chkGLSU
            // 
            this.chkGLSU.AutoSize = true;
            this.chkGLSU.Checked = true;
            this.chkGLSU.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGLSU.Location = new System.Drawing.Point(80, 29);
            this.chkGLSU.Name = "chkGLSU";
            this.chkGLSU.Size = new System.Drawing.Size(135, 17);
            this.chkGLSU.TabIndex = 3;
            this.chkGLSU.Text = "Export GLSU Template";
            this.chkGLSU.UseVisualStyleBackColor = true;
            this.chkGLSU.Click += new System.EventHandler(this.chkGLSU_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExportAll);
            this.groupBox1.Location = new System.Drawing.Point(6, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 48);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "All Accounts";
            // 
            // btnExportAll
            // 
            this.btnExportAll.Location = new System.Drawing.Point(73, 16);
            this.btnExportAll.Name = "btnExportAll";
            this.btnExportAll.Size = new System.Drawing.Size(121, 23);
            this.btnExportAll.TabIndex = 5;
            this.btnExportAll.Text = "Export";
            this.btnExportAll.UseVisualStyleBackColor = true;
            this.btnExportAll.Click += new System.EventHandler(this.btnExportAll_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxSelectAccount);
            this.groupBox2.Controls.Add(this.txtAccount);
            this.groupBox2.Controls.Add(this.btnExportSingle);
            this.groupBox2.Location = new System.Drawing.Point(7, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 90);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Single Account";
            // 
            // comboBoxSelectAccount
            // 
            this.comboBoxSelectAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectAccount.FormattingEnabled = true;
            this.comboBoxSelectAccount.Items.AddRange(new object[] {
            "AccountA",
            "AccountB",
            "AccountC"});
            this.comboBoxSelectAccount.Location = new System.Drawing.Point(73, 31);
            this.comboBoxSelectAccount.Name = "comboBoxSelectAccount";
            this.comboBoxSelectAccount.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSelectAccount.TabIndex = 6;
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(70, 15);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(50, 20);
            this.txtAccount.TabIndex = 5;
            this.txtAccount.Text = "Account:";
            // 
            // btnExportSingle
            // 
            this.btnExportSingle.Location = new System.Drawing.Point(73, 58);
            this.btnExportSingle.Name = "btnExportSingle";
            this.btnExportSingle.Size = new System.Drawing.Size(121, 23);
            this.btnExportSingle.TabIndex = 7;
            this.btnExportSingle.Text = " Export";
            this.btnExportSingle.Click += new System.EventHandler(this.btnExportSingle_Click);
            // 
            // txtMonth
            // 
            this.txtMonth.Location = new System.Drawing.Point(18, 57);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(40, 20);
            this.txtMonth.TabIndex = 4;
            this.txtMonth.Text = "Month:";
            // 
            // comboBoxSelectMonth
            // 
            this.comboBoxSelectMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectMonth.FormattingEnabled = true;
            this.comboBoxSelectMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.comboBoxSelectMonth.Location = new System.Drawing.Point(79, 54);
            this.comboBoxSelectMonth.Name = "comboBoxSelectMonth";
            this.comboBoxSelectMonth.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSelectMonth.TabIndex = 4;
            // 
            // grpStandaloneFileExport
            // 
            this.grpStandaloneFileExport.Controls.Add(this.btnImportStandalone);
            this.grpStandaloneFileExport.Controls.Add(this.chkFullScreen);
            this.grpStandaloneFileExport.Controls.Add(this.chkStandalone);
            this.grpStandaloneFileExport.Controls.Add(this.btnImportLogs);
            this.grpStandaloneFileExport.Controls.Add(this.btnExportStandaloneFile);
            this.grpStandaloneFileExport.Location = new System.Drawing.Point(380, 230);
            this.grpStandaloneFileExport.Name = "grpStandaloneFileExport";
            this.grpStandaloneFileExport.Size = new System.Drawing.Size(189, 232);
            this.grpStandaloneFileExport.TabIndex = 3;
            this.grpStandaloneFileExport.TabStop = false;
            this.grpStandaloneFileExport.Text = "Standalone Files";
            // 
            // btnImportStandalone
            // 
            this.btnImportStandalone.Location = new System.Drawing.Point(34, 58);
            this.btnImportStandalone.Name = "btnImportStandalone";
            this.btnImportStandalone.Size = new System.Drawing.Size(121, 23);
            this.btnImportStandalone.TabIndex = 9;
            this.btnImportStandalone.Text = "Import Standalone";
            this.btnImportStandalone.UseVisualStyleBackColor = true;
            // 
            // chkFullScreen
            // 
            this.chkFullScreen.AutoSize = true;
            this.chkFullScreen.Location = new System.Drawing.Point(34, 183);
            this.chkFullScreen.Name = "chkFullScreen";
            this.chkFullScreen.Size = new System.Drawing.Size(79, 17);
            this.chkFullScreen.TabIndex = 12;
            this.chkFullScreen.Text = "Full Screen";
            this.chkFullScreen.UseVisualStyleBackColor = true;
            this.chkFullScreen.Click += new System.EventHandler(this.chkFullScreen_Click);
            // 
            // chkStandalone
            // 
            this.chkStandalone.AutoSize = true;
            this.chkStandalone.Location = new System.Drawing.Point(34, 165);
            this.chkStandalone.Name = "chkStandalone";
            this.chkStandalone.Size = new System.Drawing.Size(110, 17);
            this.chkStandalone.TabIndex = 11;
            this.chkStandalone.Text = "Standalone Mode";
            this.chkStandalone.UseVisualStyleBackColor = true;
            this.chkStandalone.Click += new System.EventHandler(this.chkStandalone_Click);
            // 
            // btnImportLogs
            // 
            this.btnImportLogs.Location = new System.Drawing.Point(34, 108);
            this.btnImportLogs.Name = "btnImportLogs";
            this.btnImportLogs.Size = new System.Drawing.Size(121, 23);
            this.btnImportLogs.TabIndex = 10;
            this.btnImportLogs.Text = "Import Logs";
            this.btnImportLogs.UseVisualStyleBackColor = true;
            this.btnImportLogs.Click += new System.EventHandler(this.btnImportLogs_Click);
            // 
            // btnExportStandaloneFile
            // 
            this.btnExportStandaloneFile.Location = new System.Drawing.Point(34, 29);
            this.btnExportStandaloneFile.Name = "btnExportStandaloneFile";
            this.btnExportStandaloneFile.Size = new System.Drawing.Size(121, 23);
            this.btnExportStandaloneFile.TabIndex = 8;
            this.btnExportStandaloneFile.Text = "Export Standalone";
            this.btnExportStandaloneFile.UseVisualStyleBackColor = true;
            this.btnExportStandaloneFile.Click += new System.EventHandler(this.btnExportStandaloneFile_Click);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(852, 697);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.grpExportPath.ResumeLayout(false);
            this.grpExportPath.PerformLayout();
            this.grpInvoiceExport.ResumeLayout(false);
            this.grpInvoiceExport.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpStandaloneFileExport.ResumeLayout(false);
            this.grpStandaloneFileExport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox grpExportPath;
        private System.Windows.Forms.Label lblExportPath;
        private System.Windows.Forms.TextBox txtInvoiceExportPath;
        private System.Windows.Forms.Button btnSetInvoiceExportPath;
        private System.Windows.Forms.GroupBox grpInvoiceExport;
        private System.Windows.Forms.CheckBox chkGLSU;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExportAll;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxSelectAccount;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Button btnExportSingle;
        private System.Windows.Forms.TextBox txtMonth;
        private System.Windows.Forms.ComboBox comboBoxSelectMonth;
        private System.Windows.Forms.GroupBox grpStandaloneFileExport;
        private System.Windows.Forms.Button btnImportStandalone;
        private System.Windows.Forms.CheckBox chkFullScreen;
        private System.Windows.Forms.CheckBox chkStandalone;
        private System.Windows.Forms.Button btnImportLogs;
        private System.Windows.Forms.Button btnExportStandaloneFile;
    }
}
