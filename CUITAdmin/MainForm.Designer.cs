namespace CUITAdmin
{
    partial class frmCUITAdminMain
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
            this.tbpExports = new System.Windows.Forms.TabPage();
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
            this.txtAccount = new System.Windows.Forms.Label();
            this.btnExportSingle = new System.Windows.Forms.Button();
            this.txtMonth = new System.Windows.Forms.Label();
            this.comboBoxSelectMonth = new System.Windows.Forms.ComboBox();
            this.grpStandaloneFileExport = new System.Windows.Forms.GroupBox();
            this.btnExportLogs = new System.Windows.Forms.Button();
            this.btnImportStandalone = new System.Windows.Forms.Button();
            this.chkFullScreen = new System.Windows.Forms.CheckBox();
            this.chkStandalone = new System.Windows.Forms.CheckBox();
            this.btnImportLogs = new System.Windows.Forms.Button();
            this.btnExportStandaloneFile = new System.Windows.Forms.Button();
            this.tbpAccountAdmin = new System.Windows.Forms.TabPage();
            this.btnAdminClear = new System.Windows.Forms.Button();
            this.chkAdminIncludeInactive = new System.Windows.Forms.CheckBox();
            this.btnAccountAdminNew = new System.Windows.Forms.Button();
            this.cboAccountAdminNew = new System.Windows.Forms.ComboBox();
            this.btnAccountAdminSearch = new System.Windows.Forms.Button();
            this.lblAccountAdminView = new System.Windows.Forms.Label();
            this.cboAccountAdminView = new System.Windows.Forms.ComboBox();
            this.txtAccountAdminSearch = new System.Windows.Forms.TextBox();
            this.dgvAdmin = new System.Windows.Forms.DataGridView();
            this.tbpBilling = new System.Windows.Forms.TabPage();
            this.grpManualEntries = new System.Windows.Forms.GroupBox();
            this.grpBillingSupplies = new System.Windows.Forms.GroupBox();
            this.btnBillingSupplyAdd = new System.Windows.Forms.Button();
            this.txtBillingSupplyQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.cboBillingSupplyFunding = new System.Windows.Forms.ComboBox();
            this.lblSupplyFunding = new System.Windows.Forms.Label();
            this.cboBillingSupplyName = new System.Windows.Forms.ComboBox();
            this.lblSupplyName = new System.Windows.Forms.Label();
            this.grpManualTimeLog = new System.Windows.Forms.GroupBox();
            this.dtpManualLog = new System.Windows.Forms.DateTimePicker();
            this.lblManualLogInstrument = new System.Windows.Forms.Label();
            this.lblManualLogUser = new System.Windows.Forms.Label();
            this.cboManualLogInstrument = new System.Windows.Forms.ComboBox();
            this.cboManualLogUser = new System.Windows.Forms.ComboBox();
            this.cboManualLogFunding = new System.Windows.Forms.ComboBox();
            this.txtManualLogDuration = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblManualLogDuration = new System.Windows.Forms.Label();
            this.lblManualLogFunding = new System.Windows.Forms.Label();
            this.grpTimeLogExceptions = new System.Windows.Forms.GroupBox();
            this.cboBillingExceptions = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvTimeLogRequests = new System.Windows.Forms.DataGridView();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.InvoiceExportPath = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tbpTracking = new System.Windows.Forms.TabPage();
            this.tbpManualRequests = new System.Windows.Forms.TabPage();
            this.grpAccountSettings = new System.Windows.Forms.GroupBox();
            this.lblAcctManagementPwMessage = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lineSeparator1 = new CUITAdmin.LineSeparator();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAcctManagementPhone = new System.Windows.Forms.TextBox();
            this.txtAcctManagementEmail = new System.Windows.Forms.TextBox();
            this.txtAcctManagementZip = new System.Windows.Forms.TextBox();
            this.cboAcctManagementState = new System.Windows.Forms.ComboBox();
            this.txtAcctManagementCity = new System.Windows.Forms.TextBox();
            this.txtAcctManagementStreet = new System.Windows.Forms.TextBox();
            this.btnAcctManagementSubmit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAcctManagementPw = new System.Windows.Forms.Label();
            this.lblAcctManagementUn = new System.Windows.Forms.Label();
            this.txtAcctManagementConfirmPw = new System.Windows.Forms.TextBox();
            this.txtAcctManagementNewPw = new System.Windows.Forms.TextBox();
            this.txtAcctManagementPassword = new System.Windows.Forms.TextBox();
            this.txtAcctManagementUsername = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lblManualSuppliesValidated = new System.Windows.Forms.Label();
            this.btnManualSupplyValidate = new System.Windows.Forms.Button();
            this.txtManualSupplyPassword = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtManualSupplyUsername = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnManualSupplyAdd = new System.Windows.Forms.Button();
            this.txtManualSupplyQuantity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboManualSupplyAccount = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboManualSupplyItem = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.lblValidate = new System.Windows.Forms.Label();
            this.btnManualTimeValidate = new System.Windows.Forms.Button();
            this.txtManualTimePassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtManualTimeUsername = new System.Windows.Forms.TextBox();
            this.dtpManualTimeDate = new System.Windows.Forms.DateTimePicker();
            this.lblInstrument = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.cboManualTimeInstrument = new System.Windows.Forms.ComboBox();
            this.cboManualTimeAccount = new System.Windows.Forms.ComboBox();
            this.txtManualTimeDuration = new System.Windows.Forms.TextBox();
            this.btnManualTimeAdd = new System.Windows.Forms.Button();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblFundingSource = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.tbpExports.SuspendLayout();
            this.grpExportPath.SuspendLayout();
            this.grpInvoiceExport.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpStandaloneFileExport.SuspendLayout();
            this.tbpAccountAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdmin)).BeginInit();
            this.tbpBilling.SuspendLayout();
            this.grpManualEntries.SuspendLayout();
            this.grpBillingSupplies.SuspendLayout();
            this.grpManualTimeLog.SuspendLayout();
            this.grpTimeLogExceptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeLogRequests)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.tbpManualRequests.SuspendLayout();
            this.grpAccountSettings.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbpExports
            // 
            this.tbpExports.Controls.Add(this.grpExportPath);
            this.tbpExports.Controls.Add(this.grpInvoiceExport);
            this.tbpExports.Controls.Add(this.grpStandaloneFileExport);
            this.tbpExports.Location = new System.Drawing.Point(4, 22);
            this.tbpExports.Name = "tbpExports";
            this.tbpExports.Padding = new System.Windows.Forms.Padding(3);
            this.tbpExports.Size = new System.Drawing.Size(683, 589);
            this.tbpExports.TabIndex = 2;
            this.tbpExports.Text = "Exports";
            this.tbpExports.UseVisualStyleBackColor = true;
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
            this.txtAccount.AutoSize = true;
            this.txtAccount.Location = new System.Drawing.Point(70, 15);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(50, 13);
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
            this.txtMonth.AutoSize = true;
            this.txtMonth.Location = new System.Drawing.Point(18, 57);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(40, 13);
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
            this.grpStandaloneFileExport.Controls.Add(this.btnExportLogs);
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
            // btnExportLogs
            // 
            this.btnExportLogs.Location = new System.Drawing.Point(34, 58);
            this.btnExportLogs.Name = "btnExportLogs";
            this.btnExportLogs.Size = new System.Drawing.Size(121, 23);
            this.btnExportLogs.TabIndex = 13;
            this.btnExportLogs.Text = "Export Logs";
            this.btnExportLogs.UseVisualStyleBackColor = true;
            this.btnExportLogs.Click += new System.EventHandler(this.btnExportLogs_Click);
            // 
            // btnImportStandalone
            // 
            this.btnImportStandalone.Location = new System.Drawing.Point(34, 100);
            this.btnImportStandalone.Name = "btnImportStandalone";
            this.btnImportStandalone.Size = new System.Drawing.Size(121, 23);
            this.btnImportStandalone.TabIndex = 9;
            this.btnImportStandalone.Text = "Import Standalone";
            this.btnImportStandalone.UseVisualStyleBackColor = true;
            this.btnImportStandalone.Click += new System.EventHandler(this.btnImportStandalone_Click);
            // 
            // chkFullScreen
            // 
            this.chkFullScreen.AutoSize = true;
            this.chkFullScreen.Location = new System.Drawing.Point(34, 188);
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
            this.chkStandalone.Location = new System.Drawing.Point(34, 170);
            this.chkStandalone.Name = "chkStandalone";
            this.chkStandalone.Size = new System.Drawing.Size(110, 17);
            this.chkStandalone.TabIndex = 11;
            this.chkStandalone.Text = "Standalone Mode";
            this.chkStandalone.UseVisualStyleBackColor = true;
            this.chkStandalone.Click += new System.EventHandler(this.chkStandalone_Click);
            // 
            // btnImportLogs
            // 
            this.btnImportLogs.Location = new System.Drawing.Point(34, 129);
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
            // tbpAccountAdmin
            // 
            this.tbpAccountAdmin.Controls.Add(this.btnAdminClear);
            this.tbpAccountAdmin.Controls.Add(this.chkAdminIncludeInactive);
            this.tbpAccountAdmin.Controls.Add(this.btnAccountAdminNew);
            this.tbpAccountAdmin.Controls.Add(this.cboAccountAdminNew);
            this.tbpAccountAdmin.Controls.Add(this.btnAccountAdminSearch);
            this.tbpAccountAdmin.Controls.Add(this.lblAccountAdminView);
            this.tbpAccountAdmin.Controls.Add(this.cboAccountAdminView);
            this.tbpAccountAdmin.Controls.Add(this.txtAccountAdminSearch);
            this.tbpAccountAdmin.Controls.Add(this.dgvAdmin);
            this.tbpAccountAdmin.Location = new System.Drawing.Point(4, 22);
            this.tbpAccountAdmin.Name = "tbpAccountAdmin";
            this.tbpAccountAdmin.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAccountAdmin.Size = new System.Drawing.Size(683, 589);
            this.tbpAccountAdmin.TabIndex = 1;
            this.tbpAccountAdmin.Text = "Account Admin";
            this.tbpAccountAdmin.UseVisualStyleBackColor = true;
            // 
            // btnAdminClear
            // 
            this.btnAdminClear.Location = new System.Drawing.Point(331, 36);
            this.btnAdminClear.Name = "btnAdminClear";
            this.btnAdminClear.Size = new System.Drawing.Size(75, 23);
            this.btnAdminClear.TabIndex = 8;
            this.btnAdminClear.Text = "Clear";
            this.btnAdminClear.UseVisualStyleBackColor = true;
            this.btnAdminClear.Visible = false;
            this.btnAdminClear.Click += new System.EventHandler(this.btnAdminClear_Click);
            // 
            // chkAdminIncludeInactive
            // 
            this.chkAdminIncludeInactive.AutoSize = true;
            this.chkAdminIncludeInactive.Location = new System.Drawing.Point(18, 36);
            this.chkAdminIncludeInactive.Name = "chkAdminIncludeInactive";
            this.chkAdminIncludeInactive.Size = new System.Drawing.Size(145, 17);
            this.chkAdminIncludeInactive.TabIndex = 2;
            this.chkAdminIncludeInactive.Text = "Include Inactive Records";
            this.chkAdminIncludeInactive.UseVisualStyleBackColor = true;
            this.chkAdminIncludeInactive.CheckedChanged += new System.EventHandler(this.chkAdminIncludeInactive_CheckedChanged);
            // 
            // btnAccountAdminNew
            // 
            this.btnAccountAdminNew.Location = new System.Drawing.Point(475, 8);
            this.btnAccountAdminNew.Name = "btnAccountAdminNew";
            this.btnAccountAdminNew.Size = new System.Drawing.Size(75, 23);
            this.btnAccountAdminNew.TabIndex = 5;
            this.btnAccountAdminNew.Text = "Add New";
            this.btnAccountAdminNew.UseVisualStyleBackColor = true;
            this.btnAccountAdminNew.Click += new System.EventHandler(this.btnAccountAdminNew_Click);
            // 
            // cboAccountAdminNew
            // 
            this.cboAccountAdminNew.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccountAdminNew.FormattingEnabled = true;
            this.cboAccountAdminNew.Items.AddRange(new object[] {
            "Account",
            "Instrument",
            "Rate Type",
            "Supply",
            "User",
            "Point of Contact"});
            this.cboAccountAdminNew.Location = new System.Drawing.Point(556, 9);
            this.cboAccountAdminNew.Name = "cboAccountAdminNew";
            this.cboAccountAdminNew.Size = new System.Drawing.Size(121, 21);
            this.cboAccountAdminNew.TabIndex = 6;
            // 
            // btnAccountAdminSearch
            // 
            this.btnAccountAdminSearch.Location = new System.Drawing.Point(330, 8);
            this.btnAccountAdminSearch.Name = "btnAccountAdminSearch";
            this.btnAccountAdminSearch.Size = new System.Drawing.Size(75, 23);
            this.btnAccountAdminSearch.TabIndex = 4;
            this.btnAccountAdminSearch.Text = "Search";
            this.btnAccountAdminSearch.UseVisualStyleBackColor = true;
            this.btnAccountAdminSearch.Click += new System.EventHandler(this.btnAccountAdminSearch_Click);
            // 
            // lblAccountAdminView
            // 
            this.lblAccountAdminView.AutoSize = true;
            this.lblAccountAdminView.Location = new System.Drawing.Point(6, 12);
            this.lblAccountAdminView.Name = "lblAccountAdminView";
            this.lblAccountAdminView.Size = new System.Drawing.Size(33, 13);
            this.lblAccountAdminView.TabIndex = 3;
            this.lblAccountAdminView.Text = "View:";
            // 
            // cboAccountAdminView
            // 
            this.cboAccountAdminView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccountAdminView.FormattingEnabled = true;
            this.cboAccountAdminView.Items.AddRange(new object[] {
            "Accounts",
            "Contacts",
            "Users",
            "Instruments",
            "Rate Types",
            "Supplies"});
            this.cboAccountAdminView.Location = new System.Drawing.Point(42, 9);
            this.cboAccountAdminView.Name = "cboAccountAdminView";
            this.cboAccountAdminView.Size = new System.Drawing.Size(121, 21);
            this.cboAccountAdminView.TabIndex = 1;
            this.cboAccountAdminView.SelectedValueChanged += new System.EventHandler(this.adminEditViewLoad);
            // 
            // txtAccountAdminSearch
            // 
            this.txtAccountAdminSearch.Location = new System.Drawing.Point(224, 9);
            this.txtAccountAdminSearch.Name = "txtAccountAdminSearch";
            this.txtAccountAdminSearch.Size = new System.Drawing.Size(100, 20);
            this.txtAccountAdminSearch.TabIndex = 3;
            // 
            // dgvAdmin
            // 
            this.dgvAdmin.AllowUserToAddRows = false;
            this.dgvAdmin.AllowUserToDeleteRows = false;
            this.dgvAdmin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdmin.Location = new System.Drawing.Point(6, 62);
            this.dgvAdmin.Name = "dgvAdmin";
            this.dgvAdmin.ReadOnly = true;
            this.dgvAdmin.Size = new System.Drawing.Size(671, 521);
            this.dgvAdmin.TabIndex = 7;
            this.dgvAdmin.TabStop = false;
            this.dgvAdmin.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AdminDataGridView_CellDoubleClick);
            // 
            // tbpBilling
            // 
            this.tbpBilling.AutoScroll = true;
            this.tbpBilling.Controls.Add(this.grpManualEntries);
            this.tbpBilling.Controls.Add(this.grpTimeLogExceptions);
            this.tbpBilling.Location = new System.Drawing.Point(4, 22);
            this.tbpBilling.Name = "tbpBilling";
            this.tbpBilling.Padding = new System.Windows.Forms.Padding(3);
            this.tbpBilling.Size = new System.Drawing.Size(683, 589);
            this.tbpBilling.TabIndex = 0;
            this.tbpBilling.Text = "Billing";
            this.tbpBilling.UseVisualStyleBackColor = true;
            // 
            // grpManualEntries
            // 
            this.grpManualEntries.Controls.Add(this.grpBillingSupplies);
            this.grpManualEntries.Controls.Add(this.grpManualTimeLog);
            this.grpManualEntries.Location = new System.Drawing.Point(6, 6);
            this.grpManualEntries.Name = "grpManualEntries";
            this.grpManualEntries.Size = new System.Drawing.Size(671, 220);
            this.grpManualEntries.TabIndex = 0;
            this.grpManualEntries.TabStop = false;
            this.grpManualEntries.Text = "Manual Entries";
            // 
            // grpBillingSupplies
            // 
            this.grpBillingSupplies.Controls.Add(this.btnBillingSupplyAdd);
            this.grpBillingSupplies.Controls.Add(this.txtBillingSupplyQuantity);
            this.grpBillingSupplies.Controls.Add(this.lblQuantity);
            this.grpBillingSupplies.Controls.Add(this.cboBillingSupplyFunding);
            this.grpBillingSupplies.Controls.Add(this.lblSupplyFunding);
            this.grpBillingSupplies.Controls.Add(this.cboBillingSupplyName);
            this.grpBillingSupplies.Controls.Add(this.lblSupplyName);
            this.grpBillingSupplies.Location = new System.Drawing.Point(339, 15);
            this.grpBillingSupplies.Name = "grpBillingSupplies";
            this.grpBillingSupplies.Size = new System.Drawing.Size(326, 199);
            this.grpBillingSupplies.TabIndex = 2;
            this.grpBillingSupplies.TabStop = false;
            this.grpBillingSupplies.Text = "Supplies";
            // 
            // btnBillingSupplyAdd
            // 
            this.btnBillingSupplyAdd.Location = new System.Drawing.Point(199, 88);
            this.btnBillingSupplyAdd.Name = "btnBillingSupplyAdd";
            this.btnBillingSupplyAdd.Size = new System.Drawing.Size(75, 23);
            this.btnBillingSupplyAdd.TabIndex = 10;
            this.btnBillingSupplyAdd.Text = "Add";
            this.btnBillingSupplyAdd.UseVisualStyleBackColor = true;
            this.btnBillingSupplyAdd.Click += new System.EventHandler(this.btnBillingSupplyAdd_Click);
            // 
            // txtBillingSupplyQuantity
            // 
            this.txtBillingSupplyQuantity.Location = new System.Drawing.Point(126, 90);
            this.txtBillingSupplyQuantity.Name = "txtBillingSupplyQuantity";
            this.txtBillingSupplyQuantity.Size = new System.Drawing.Size(67, 20);
            this.txtBillingSupplyQuantity.TabIndex = 9;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(36, 91);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(49, 13);
            this.lblQuantity.TabIndex = 9;
            this.lblQuantity.Text = "Quantity:";
            // 
            // cboBillingSupplyFunding
            // 
            this.cboBillingSupplyFunding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBillingSupplyFunding.FormattingEnabled = true;
            this.cboBillingSupplyFunding.Location = new System.Drawing.Point(126, 63);
            this.cboBillingSupplyFunding.Name = "cboBillingSupplyFunding";
            this.cboBillingSupplyFunding.Size = new System.Drawing.Size(148, 21);
            this.cboBillingSupplyFunding.TabIndex = 8;
            // 
            // lblSupplyFunding
            // 
            this.lblSupplyFunding.AutoSize = true;
            this.lblSupplyFunding.Location = new System.Drawing.Point(35, 66);
            this.lblSupplyFunding.Name = "lblSupplyFunding";
            this.lblSupplyFunding.Size = new System.Drawing.Size(85, 13);
            this.lblSupplyFunding.TabIndex = 8;
            this.lblSupplyFunding.Text = "Funding Source:";
            // 
            // cboBillingSupplyName
            // 
            this.cboBillingSupplyName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBillingSupplyName.FormattingEnabled = true;
            this.cboBillingSupplyName.Location = new System.Drawing.Point(126, 37);
            this.cboBillingSupplyName.Name = "cboBillingSupplyName";
            this.cboBillingSupplyName.Size = new System.Drawing.Size(148, 21);
            this.cboBillingSupplyName.TabIndex = 7;
            // 
            // lblSupplyName
            // 
            this.lblSupplyName.AutoSize = true;
            this.lblSupplyName.Location = new System.Drawing.Point(35, 40);
            this.lblSupplyName.Name = "lblSupplyName";
            this.lblSupplyName.Size = new System.Drawing.Size(61, 13);
            this.lblSupplyName.TabIndex = 6;
            this.lblSupplyName.Text = "Item Name:";
            // 
            // grpManualTimeLog
            // 
            this.grpManualTimeLog.Controls.Add(this.dtpManualLog);
            this.grpManualTimeLog.Controls.Add(this.lblManualLogInstrument);
            this.grpManualTimeLog.Controls.Add(this.lblManualLogUser);
            this.grpManualTimeLog.Controls.Add(this.cboManualLogInstrument);
            this.grpManualTimeLog.Controls.Add(this.cboManualLogUser);
            this.grpManualTimeLog.Controls.Add(this.cboManualLogFunding);
            this.grpManualTimeLog.Controls.Add(this.txtManualLogDuration);
            this.grpManualTimeLog.Controls.Add(this.btnAdd);
            this.grpManualTimeLog.Controls.Add(this.lblManualLogDuration);
            this.grpManualTimeLog.Controls.Add(this.lblManualLogFunding);
            this.grpManualTimeLog.Location = new System.Drawing.Point(7, 15);
            this.grpManualTimeLog.Name = "grpManualTimeLog";
            this.grpManualTimeLog.Size = new System.Drawing.Size(314, 199);
            this.grpManualTimeLog.TabIndex = 1;
            this.grpManualTimeLog.TabStop = false;
            this.grpManualTimeLog.Text = "Time Log";
            // 
            // dtpManualLog
            // 
            this.dtpManualLog.Location = new System.Drawing.Point(34, 118);
            this.dtpManualLog.Name = "dtpManualLog";
            this.dtpManualLog.Size = new System.Drawing.Size(236, 20);
            this.dtpManualLog.TabIndex = 4;
            // 
            // lblManualLogInstrument
            // 
            this.lblManualLogInstrument.AutoSize = true;
            this.lblManualLogInstrument.Location = new System.Drawing.Point(31, 93);
            this.lblManualLogInstrument.Name = "lblManualLogInstrument";
            this.lblManualLogInstrument.Size = new System.Drawing.Size(59, 13);
            this.lblManualLogInstrument.TabIndex = 5;
            this.lblManualLogInstrument.Text = "Instrument:";
            // 
            // lblManualLogUser
            // 
            this.lblManualLogUser.AutoSize = true;
            this.lblManualLogUser.Location = new System.Drawing.Point(31, 38);
            this.lblManualLogUser.Name = "lblManualLogUser";
            this.lblManualLogUser.Size = new System.Drawing.Size(58, 13);
            this.lblManualLogUser.TabIndex = 14;
            this.lblManualLogUser.Text = "Username:";
            // 
            // cboManualLogInstrument
            // 
            this.cboManualLogInstrument.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboManualLogInstrument.FormattingEnabled = true;
            this.cboManualLogInstrument.Location = new System.Drawing.Point(122, 90);
            this.cboManualLogInstrument.Name = "cboManualLogInstrument";
            this.cboManualLogInstrument.Size = new System.Drawing.Size(148, 21);
            this.cboManualLogInstrument.TabIndex = 3;
            this.cboManualLogInstrument.SelectedIndexChanged += new System.EventHandler(this.cboManualLogInstrument_SelectedIndexChanged);
            // 
            // cboManualLogUser
            // 
            this.cboManualLogUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboManualLogUser.FormattingEnabled = true;
            this.cboManualLogUser.Items.AddRange(new object[] {
            "Test",
            "John Doe",
            "Jane Doe",
            "Tom Ato"});
            this.cboManualLogUser.Location = new System.Drawing.Point(122, 35);
            this.cboManualLogUser.Name = "cboManualLogUser";
            this.cboManualLogUser.Size = new System.Drawing.Size(148, 21);
            this.cboManualLogUser.TabIndex = 1;
            // 
            // cboManualLogFunding
            // 
            this.cboManualLogFunding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboManualLogFunding.FormattingEnabled = true;
            this.cboManualLogFunding.Location = new System.Drawing.Point(122, 62);
            this.cboManualLogFunding.Name = "cboManualLogFunding";
            this.cboManualLogFunding.Size = new System.Drawing.Size(148, 21);
            this.cboManualLogFunding.TabIndex = 2;
            // 
            // txtManualLogDuration
            // 
            this.txtManualLogDuration.Location = new System.Drawing.Point(122, 146);
            this.txtManualLogDuration.Name = "txtManualLogDuration";
            this.txtManualLogDuration.Size = new System.Drawing.Size(67, 20);
            this.txtManualLogDuration.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(195, 144);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblManualLogDuration
            // 
            this.lblManualLogDuration.AutoSize = true;
            this.lblManualLogDuration.Location = new System.Drawing.Point(31, 149);
            this.lblManualLogDuration.Name = "lblManualLogDuration";
            this.lblManualLogDuration.Size = new System.Drawing.Size(75, 13);
            this.lblManualLogDuration.TabIndex = 9;
            this.lblManualLogDuration.Text = "Duration: (min)";
            // 
            // lblManualLogFunding
            // 
            this.lblManualLogFunding.AutoSize = true;
            this.lblManualLogFunding.Location = new System.Drawing.Point(31, 65);
            this.lblManualLogFunding.Name = "lblManualLogFunding";
            this.lblManualLogFunding.Size = new System.Drawing.Size(85, 13);
            this.lblManualLogFunding.TabIndex = 4;
            this.lblManualLogFunding.Text = "Funding Source:";
            // 
            // grpTimeLogExceptions
            // 
            this.grpTimeLogExceptions.Controls.Add(this.cboBillingExceptions);
            this.grpTimeLogExceptions.Controls.Add(this.btnRefresh);
            this.grpTimeLogExceptions.Controls.Add(this.dgvTimeLogRequests);
            this.grpTimeLogExceptions.Controls.Add(this.btnSubmit);
            this.grpTimeLogExceptions.Location = new System.Drawing.Point(6, 232);
            this.grpTimeLogExceptions.Name = "grpTimeLogExceptions";
            this.grpTimeLogExceptions.Size = new System.Drawing.Size(671, 354);
            this.grpTimeLogExceptions.TabIndex = 3;
            this.grpTimeLogExceptions.TabStop = false;
            this.grpTimeLogExceptions.Text = "Usage Exceptions";
            // 
            // cboBillingExceptions
            // 
            this.cboBillingExceptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBillingExceptions.FormattingEnabled = true;
            this.cboBillingExceptions.Items.AddRange(new object[] {
            "Time Logs",
            "Supplies"});
            this.cboBillingExceptions.Location = new System.Drawing.Point(7, 326);
            this.cboBillingExceptions.Name = "cboBillingExceptions";
            this.cboBillingExceptions.Size = new System.Drawing.Size(121, 21);
            this.cboBillingExceptions.TabIndex = 11;
            this.cboBillingExceptions.SelectedIndexChanged += new System.EventHandler(this.cboBillingExceptions_SelectedIndexChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(509, 325);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvTimeLogRequests
            // 
            this.dgvTimeLogRequests.AllowUserToAddRows = false;
            this.dgvTimeLogRequests.AllowUserToDeleteRows = false;
            this.dgvTimeLogRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimeLogRequests.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvTimeLogRequests.Location = new System.Drawing.Point(7, 20);
            this.dgvTimeLogRequests.Name = "dgvTimeLogRequests";
            this.dgvTimeLogRequests.Size = new System.Drawing.Size(658, 299);
            this.dgvTimeLogRequests.TabIndex = 8;
            this.dgvTimeLogRequests.TabStop = false;
            this.dgvTimeLogRequests.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTimeLogRequests_CellEndEdit);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(590, 325);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 13;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tbpBilling);
            this.tabControlMain.Controls.Add(this.tbpAccountAdmin);
            this.tabControlMain.Controls.Add(this.tbpExports);
            this.tabControlMain.Controls.Add(this.tbpTracking);
            this.tabControlMain.Controls.Add(this.tbpManualRequests);
            this.tabControlMain.Location = new System.Drawing.Point(12, 12);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(691, 615);
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.TabStop = false;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // tbpTracking
            // 
            this.tbpTracking.AutoScroll = true;
            this.tbpTracking.Location = new System.Drawing.Point(4, 22);
            this.tbpTracking.Name = "tbpTracking";
            this.tbpTracking.Padding = new System.Windows.Forms.Padding(3);
            this.tbpTracking.Size = new System.Drawing.Size(683, 589);
            this.tbpTracking.TabIndex = 3;
            this.tbpTracking.Text = "Tracking";
            this.tbpTracking.UseVisualStyleBackColor = true;
            // 
            // tbpManualRequests
            // 
            this.tbpManualRequests.Controls.Add(this.grpAccountSettings);
            this.tbpManualRequests.Controls.Add(this.groupBox7);
            this.tbpManualRequests.Location = new System.Drawing.Point(4, 22);
            this.tbpManualRequests.Name = "tbpManualRequests";
            this.tbpManualRequests.Padding = new System.Windows.Forms.Padding(3);
            this.tbpManualRequests.Size = new System.Drawing.Size(683, 589);
            this.tbpManualRequests.TabIndex = 4;
            this.tbpManualRequests.Text = "Account Requests";
            this.tbpManualRequests.UseVisualStyleBackColor = true;
            // 
            // grpAccountSettings
            // 
            this.grpAccountSettings.Controls.Add(this.lblAcctManagementPwMessage);
            this.grpAccountSettings.Controls.Add(this.label14);
            this.grpAccountSettings.Controls.Add(this.label15);
            this.grpAccountSettings.Controls.Add(this.label13);
            this.grpAccountSettings.Controls.Add(this.lineSeparator1);
            this.grpAccountSettings.Controls.Add(this.label11);
            this.grpAccountSettings.Controls.Add(this.label8);
            this.grpAccountSettings.Controls.Add(this.label7);
            this.grpAccountSettings.Controls.Add(this.label6);
            this.grpAccountSettings.Controls.Add(this.txtAcctManagementPhone);
            this.grpAccountSettings.Controls.Add(this.txtAcctManagementEmail);
            this.grpAccountSettings.Controls.Add(this.txtAcctManagementZip);
            this.grpAccountSettings.Controls.Add(this.cboAcctManagementState);
            this.grpAccountSettings.Controls.Add(this.txtAcctManagementCity);
            this.grpAccountSettings.Controls.Add(this.txtAcctManagementStreet);
            this.grpAccountSettings.Controls.Add(this.btnAcctManagementSubmit);
            this.grpAccountSettings.Controls.Add(this.label5);
            this.grpAccountSettings.Controls.Add(this.label1);
            this.grpAccountSettings.Controls.Add(this.lblAcctManagementPw);
            this.grpAccountSettings.Controls.Add(this.lblAcctManagementUn);
            this.grpAccountSettings.Controls.Add(this.txtAcctManagementConfirmPw);
            this.grpAccountSettings.Controls.Add(this.txtAcctManagementNewPw);
            this.grpAccountSettings.Controls.Add(this.txtAcctManagementPassword);
            this.grpAccountSettings.Controls.Add(this.txtAcctManagementUsername);
            this.grpAccountSettings.Location = new System.Drawing.Point(6, 253);
            this.grpAccountSettings.Name = "grpAccountSettings";
            this.grpAccountSettings.Size = new System.Drawing.Size(671, 330);
            this.grpAccountSettings.TabIndex = 13;
            this.grpAccountSettings.TabStop = false;
            this.grpAccountSettings.Text = "Account Management";
            // 
            // lblAcctManagementPwMessage
            // 
            this.lblAcctManagementPwMessage.AutoSize = true;
            this.lblAcctManagementPwMessage.Location = new System.Drawing.Point(166, 211);
            this.lblAcctManagementPwMessage.Name = "lblAcctManagementPwMessage";
            this.lblAcctManagementPwMessage.Size = new System.Drawing.Size(0, 13);
            this.lblAcctManagementPwMessage.TabIndex = 21;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(70, 229);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "Email:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(69, 256);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 13);
            this.label15.TabIndex = 15;
            this.label15.Text = "Phone:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(376, 272);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(126, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "( - all fields are optional - )";
            // 
            // lineSeparator1
            // 
            this.lineSeparator1.Location = new System.Drawing.Point(48, 126);
            this.lineSeparator1.MaximumSize = new System.Drawing.Size(2000, 2);
            this.lineSeparator1.MinimumSize = new System.Drawing.Size(0, 2);
            this.lineSeparator1.Name = "lineSeparator1";
            this.lineSeparator1.Size = new System.Drawing.Size(578, 2);
            this.lineSeparator1.TabIndex = 19;
            this.lineSeparator1.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(346, 244);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Zip:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(346, 218);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "State:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(346, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "City:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(346, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Street:";
            // 
            // txtAcctManagementPhone
            // 
            this.txtAcctManagementPhone.Location = new System.Drawing.Point(164, 253);
            this.txtAcctManagementPhone.Name = "txtAcctManagementPhone";
            this.txtAcctManagementPhone.Size = new System.Drawing.Size(144, 20);
            this.txtAcctManagementPhone.TabIndex = 21;
            // 
            // txtAcctManagementEmail
            // 
            this.txtAcctManagementEmail.Location = new System.Drawing.Point(164, 226);
            this.txtAcctManagementEmail.Name = "txtAcctManagementEmail";
            this.txtAcctManagementEmail.Size = new System.Drawing.Size(144, 20);
            this.txtAcctManagementEmail.TabIndex = 20;
            // 
            // txtAcctManagementZip
            // 
            this.txtAcctManagementZip.Location = new System.Drawing.Point(390, 241);
            this.txtAcctManagementZip.Name = "txtAcctManagementZip";
            this.txtAcctManagementZip.Size = new System.Drawing.Size(188, 20);
            this.txtAcctManagementZip.TabIndex = 25;
            // 
            // cboAcctManagementState
            // 
            this.cboAcctManagementState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAcctManagementState.FormattingEnabled = true;
            this.cboAcctManagementState.Location = new System.Drawing.Point(390, 215);
            this.cboAcctManagementState.Name = "cboAcctManagementState";
            this.cboAcctManagementState.Size = new System.Drawing.Size(188, 21);
            this.cboAcctManagementState.TabIndex = 24;
            // 
            // txtAcctManagementCity
            // 
            this.txtAcctManagementCity.Location = new System.Drawing.Point(390, 189);
            this.txtAcctManagementCity.Name = "txtAcctManagementCity";
            this.txtAcctManagementCity.Size = new System.Drawing.Size(188, 20);
            this.txtAcctManagementCity.TabIndex = 23;
            // 
            // txtAcctManagementStreet
            // 
            this.txtAcctManagementStreet.Location = new System.Drawing.Point(390, 163);
            this.txtAcctManagementStreet.Name = "txtAcctManagementStreet";
            this.txtAcctManagementStreet.Size = new System.Drawing.Size(188, 20);
            this.txtAcctManagementStreet.TabIndex = 22;
            // 
            // btnAcctManagementSubmit
            // 
            this.btnAcctManagementSubmit.Location = new System.Drawing.Point(503, 267);
            this.btnAcctManagementSubmit.Name = "btnAcctManagementSubmit";
            this.btnAcctManagementSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnAcctManagementSubmit.TabIndex = 26;
            this.btnAcctManagementSubmit.Text = "Submit";
            this.btnAcctManagementSubmit.UseVisualStyleBackColor = true;
            this.btnAcctManagementSubmit.Click += new System.EventHandler(this.btnAcctManagementSubmit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(69, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Confirm Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "New Password:";
            // 
            // lblAcctManagementPw
            // 
            this.lblAcctManagementPw.AutoSize = true;
            this.lblAcctManagementPw.Location = new System.Drawing.Point(208, 75);
            this.lblAcctManagementPw.Name = "lblAcctManagementPw";
            this.lblAcctManagementPw.Size = new System.Drawing.Size(56, 13);
            this.lblAcctManagementPw.TabIndex = 5;
            this.lblAcctManagementPw.Text = "Password:";
            // 
            // lblAcctManagementUn
            // 
            this.lblAcctManagementUn.AutoSize = true;
            this.lblAcctManagementUn.Location = new System.Drawing.Point(206, 49);
            this.lblAcctManagementUn.Name = "lblAcctManagementUn";
            this.lblAcctManagementUn.Size = new System.Drawing.Size(58, 13);
            this.lblAcctManagementUn.TabIndex = 4;
            this.lblAcctManagementUn.Text = "Username:";
            // 
            // txtAcctManagementConfirmPw
            // 
            this.txtAcctManagementConfirmPw.Location = new System.Drawing.Point(164, 189);
            this.txtAcctManagementConfirmPw.Name = "txtAcctManagementConfirmPw";
            this.txtAcctManagementConfirmPw.PasswordChar = '*';
            this.txtAcctManagementConfirmPw.Size = new System.Drawing.Size(144, 20);
            this.txtAcctManagementConfirmPw.TabIndex = 19;
            this.txtAcctManagementConfirmPw.TextChanged += new System.EventHandler(this.txtAcctManagementConfirmPw_TextChanged);
            // 
            // txtAcctManagementNewPw
            // 
            this.txtAcctManagementNewPw.Location = new System.Drawing.Point(164, 163);
            this.txtAcctManagementNewPw.Name = "txtAcctManagementNewPw";
            this.txtAcctManagementNewPw.PasswordChar = '*';
            this.txtAcctManagementNewPw.Size = new System.Drawing.Size(144, 20);
            this.txtAcctManagementNewPw.TabIndex = 18;
            this.txtAcctManagementNewPw.TextChanged += new System.EventHandler(this.txtAcctManagementNewPw_TextChanged);
            // 
            // txtAcctManagementPassword
            // 
            this.txtAcctManagementPassword.Location = new System.Drawing.Point(270, 72);
            this.txtAcctManagementPassword.Name = "txtAcctManagementPassword";
            this.txtAcctManagementPassword.PasswordChar = '*';
            this.txtAcctManagementPassword.Size = new System.Drawing.Size(144, 20);
            this.txtAcctManagementPassword.TabIndex = 17;
            // 
            // txtAcctManagementUsername
            // 
            this.txtAcctManagementUsername.Location = new System.Drawing.Point(270, 46);
            this.txtAcctManagementUsername.Name = "txtAcctManagementUsername";
            this.txtAcctManagementUsername.Size = new System.Drawing.Size(144, 20);
            this.txtAcctManagementUsername.TabIndex = 16;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.groupBox8);
            this.groupBox7.Controls.Add(this.groupBox9);
            this.groupBox7.Location = new System.Drawing.Point(6, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(671, 240);
            this.groupBox7.TabIndex = 12;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Manual Entries";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.lblManualSuppliesValidated);
            this.groupBox8.Controls.Add(this.btnManualSupplyValidate);
            this.groupBox8.Controls.Add(this.txtManualSupplyPassword);
            this.groupBox8.Controls.Add(this.label9);
            this.groupBox8.Controls.Add(this.txtManualSupplyUsername);
            this.groupBox8.Controls.Add(this.label10);
            this.groupBox8.Controls.Add(this.btnManualSupplyAdd);
            this.groupBox8.Controls.Add(this.txtManualSupplyQuantity);
            this.groupBox8.Controls.Add(this.label2);
            this.groupBox8.Controls.Add(this.cboManualSupplyAccount);
            this.groupBox8.Controls.Add(this.label3);
            this.groupBox8.Controls.Add(this.cboManualSupplyItem);
            this.groupBox8.Controls.Add(this.label4);
            this.groupBox8.Location = new System.Drawing.Point(339, 15);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(326, 218);
            this.groupBox8.TabIndex = 18;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Supplies";
            // 
            // lblManualSuppliesValidated
            // 
            this.lblManualSuppliesValidated.AutoSize = true;
            this.lblManualSuppliesValidated.Location = new System.Drawing.Point(144, 80);
            this.lblManualSuppliesValidated.Name = "lblManualSuppliesValidated";
            this.lblManualSuppliesValidated.Size = new System.Drawing.Size(51, 13);
            this.lblManualSuppliesValidated.TabIndex = 23;
            this.lblManualSuppliesValidated.Text = "Validated";
            this.lblManualSuppliesValidated.Visible = false;
            // 
            // btnManualSupplyValidate
            // 
            this.btnManualSupplyValidate.Location = new System.Drawing.Point(201, 75);
            this.btnManualSupplyValidate.Name = "btnManualSupplyValidate";
            this.btnManualSupplyValidate.Size = new System.Drawing.Size(75, 23);
            this.btnManualSupplyValidate.TabIndex = 11;
            this.btnManualSupplyValidate.Text = "Validate";
            this.btnManualSupplyValidate.UseVisualStyleBackColor = true;
            this.btnManualSupplyValidate.Click += new System.EventHandler(this.btnManualSupplyValidate_Click);
            // 
            // txtManualSupplyPassword
            // 
            this.txtManualSupplyPassword.Location = new System.Drawing.Point(128, 51);
            this.txtManualSupplyPassword.Name = "txtManualSupplyPassword";
            this.txtManualSupplyPassword.PasswordChar = '*';
            this.txtManualSupplyPassword.Size = new System.Drawing.Size(148, 20);
            this.txtManualSupplyPassword.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Password:";
            // 
            // txtManualSupplyUsername
            // 
            this.txtManualSupplyUsername.Location = new System.Drawing.Point(128, 25);
            this.txtManualSupplyUsername.Name = "txtManualSupplyUsername";
            this.txtManualSupplyUsername.Size = new System.Drawing.Size(148, 20);
            this.txtManualSupplyUsername.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(37, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Username:";
            // 
            // btnManualSupplyAdd
            // 
            this.btnManualSupplyAdd.Location = new System.Drawing.Point(201, 155);
            this.btnManualSupplyAdd.Name = "btnManualSupplyAdd";
            this.btnManualSupplyAdd.Size = new System.Drawing.Size(75, 23);
            this.btnManualSupplyAdd.TabIndex = 15;
            this.btnManualSupplyAdd.Text = "Add";
            this.btnManualSupplyAdd.UseVisualStyleBackColor = true;
            this.btnManualSupplyAdd.Click += new System.EventHandler(this.btnManualSupplyAdd_Click);
            // 
            // txtManualSupplyQuantity
            // 
            this.txtManualSupplyQuantity.Location = new System.Drawing.Point(128, 157);
            this.txtManualSupplyQuantity.Name = "txtManualSupplyQuantity";
            this.txtManualSupplyQuantity.Size = new System.Drawing.Size(67, 20);
            this.txtManualSupplyQuantity.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Quantity:";
            // 
            // cboManualSupplyAccount
            // 
            this.cboManualSupplyAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboManualSupplyAccount.FormattingEnabled = true;
            this.cboManualSupplyAccount.Location = new System.Drawing.Point(128, 130);
            this.cboManualSupplyAccount.Name = "cboManualSupplyAccount";
            this.cboManualSupplyAccount.Size = new System.Drawing.Size(148, 21);
            this.cboManualSupplyAccount.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Funding Source:";
            // 
            // cboManualSupplyItem
            // 
            this.cboManualSupplyItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboManualSupplyItem.FormattingEnabled = true;
            this.cboManualSupplyItem.Location = new System.Drawing.Point(128, 104);
            this.cboManualSupplyItem.Name = "cboManualSupplyItem";
            this.cboManualSupplyItem.Size = new System.Drawing.Size(148, 21);
            this.cboManualSupplyItem.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Item Name:";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.lblValidate);
            this.groupBox9.Controls.Add(this.btnManualTimeValidate);
            this.groupBox9.Controls.Add(this.txtManualTimePassword);
            this.groupBox9.Controls.Add(this.lblPassword);
            this.groupBox9.Controls.Add(this.txtManualTimeUsername);
            this.groupBox9.Controls.Add(this.dtpManualTimeDate);
            this.groupBox9.Controls.Add(this.lblInstrument);
            this.groupBox9.Controls.Add(this.lblUsername);
            this.groupBox9.Controls.Add(this.cboManualTimeInstrument);
            this.groupBox9.Controls.Add(this.cboManualTimeAccount);
            this.groupBox9.Controls.Add(this.txtManualTimeDuration);
            this.groupBox9.Controls.Add(this.btnManualTimeAdd);
            this.groupBox9.Controls.Add(this.lblDuration);
            this.groupBox9.Controls.Add(this.lblFundingSource);
            this.groupBox9.Location = new System.Drawing.Point(7, 15);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(314, 218);
            this.groupBox9.TabIndex = 17;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Time Log";
            // 
            // lblValidate
            // 
            this.lblValidate.AutoSize = true;
            this.lblValidate.Location = new System.Drawing.Point(136, 80);
            this.lblValidate.Name = "lblValidate";
            this.lblValidate.Size = new System.Drawing.Size(51, 13);
            this.lblValidate.TabIndex = 19;
            this.lblValidate.Text = "Validated";
            this.lblValidate.Visible = false;
            // 
            // btnManualTimeValidate
            // 
            this.btnManualTimeValidate.Location = new System.Drawing.Point(193, 75);
            this.btnManualTimeValidate.Name = "btnManualTimeValidate";
            this.btnManualTimeValidate.Size = new System.Drawing.Size(75, 23);
            this.btnManualTimeValidate.TabIndex = 3;
            this.btnManualTimeValidate.Text = "Validate";
            this.btnManualTimeValidate.UseVisualStyleBackColor = true;
            this.btnManualTimeValidate.Click += new System.EventHandler(this.btnManualTimeValidate_Click);
            // 
            // txtManualTimePassword
            // 
            this.txtManualTimePassword.Location = new System.Drawing.Point(120, 51);
            this.txtManualTimePassword.Name = "txtManualTimePassword";
            this.txtManualTimePassword.PasswordChar = '*';
            this.txtManualTimePassword.Size = new System.Drawing.Size(148, 20);
            this.txtManualTimePassword.TabIndex = 2;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(29, 54);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 16;
            this.lblPassword.Text = "Password:";
            // 
            // txtManualTimeUsername
            // 
            this.txtManualTimeUsername.Location = new System.Drawing.Point(120, 25);
            this.txtManualTimeUsername.Name = "txtManualTimeUsername";
            this.txtManualTimeUsername.Size = new System.Drawing.Size(148, 20);
            this.txtManualTimeUsername.TabIndex = 1;
            // 
            // dtpManualTimeDate
            // 
            this.dtpManualTimeDate.CustomFormat = "Da\'t\'e: M-dd-yyyy Ti\'m\'e: hh:mm tt";
            this.dtpManualTimeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpManualTimeDate.Location = new System.Drawing.Point(32, 160);
            this.dtpManualTimeDate.Name = "dtpManualTimeDate";
            this.dtpManualTimeDate.Size = new System.Drawing.Size(236, 20);
            this.dtpManualTimeDate.TabIndex = 6;
            // 
            // lblInstrument
            // 
            this.lblInstrument.AutoSize = true;
            this.lblInstrument.Location = new System.Drawing.Point(29, 107);
            this.lblInstrument.Name = "lblInstrument";
            this.lblInstrument.Size = new System.Drawing.Size(59, 13);
            this.lblInstrument.TabIndex = 5;
            this.lblInstrument.Text = "Instrument:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(29, 28);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 14;
            this.lblUsername.Text = "Username:";
            // 
            // cboManualTimeInstrument
            // 
            this.cboManualTimeInstrument.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboManualTimeInstrument.FormattingEnabled = true;
            this.cboManualTimeInstrument.Location = new System.Drawing.Point(120, 104);
            this.cboManualTimeInstrument.Name = "cboManualTimeInstrument";
            this.cboManualTimeInstrument.Size = new System.Drawing.Size(148, 21);
            this.cboManualTimeInstrument.TabIndex = 4;
            this.cboManualTimeInstrument.SelectedIndexChanged += new System.EventHandler(this.cboManualTimeInstrument_SelectedIndexChanged);
            // 
            // cboManualTimeAccount
            // 
            this.cboManualTimeAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboManualTimeAccount.FormattingEnabled = true;
            this.cboManualTimeAccount.Location = new System.Drawing.Point(120, 130);
            this.cboManualTimeAccount.Name = "cboManualTimeAccount";
            this.cboManualTimeAccount.Size = new System.Drawing.Size(148, 21);
            this.cboManualTimeAccount.TabIndex = 5;
            // 
            // txtManualTimeDuration
            // 
            this.txtManualTimeDuration.Location = new System.Drawing.Point(120, 186);
            this.txtManualTimeDuration.Name = "txtManualTimeDuration";
            this.txtManualTimeDuration.Size = new System.Drawing.Size(67, 20);
            this.txtManualTimeDuration.TabIndex = 7;
            // 
            // btnManualTimeAdd
            // 
            this.btnManualTimeAdd.Location = new System.Drawing.Point(193, 184);
            this.btnManualTimeAdd.Name = "btnManualTimeAdd";
            this.btnManualTimeAdd.Size = new System.Drawing.Size(75, 23);
            this.btnManualTimeAdd.TabIndex = 8;
            this.btnManualTimeAdd.Text = "Add";
            this.btnManualTimeAdd.UseVisualStyleBackColor = true;
            this.btnManualTimeAdd.Click += new System.EventHandler(this.btnManualTimeAdd_Click);
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(29, 189);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(75, 13);
            this.lblDuration.TabIndex = 9;
            this.lblDuration.Text = "Duration: (min)";
            // 
            // lblFundingSource
            // 
            this.lblFundingSource.AutoSize = true;
            this.lblFundingSource.Location = new System.Drawing.Point(29, 133);
            this.lblFundingSource.Name = "lblFundingSource";
            this.lblFundingSource.Size = new System.Drawing.Size(85, 13);
            this.lblFundingSource.TabIndex = 4;
            this.lblFundingSource.Text = "Funding Source:";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(612, 5);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnAdminLogin_Click);
            // 
            // frmCUITAdminMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(712, 667);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.tabControlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmCUITAdminMain";
            this.Text = "CUIT - Clarion University Instrument Tracking";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.frmCUITAdminMain_Resize);
            this.tbpExports.ResumeLayout(false);
            this.grpExportPath.ResumeLayout(false);
            this.grpExportPath.PerformLayout();
            this.grpInvoiceExport.ResumeLayout(false);
            this.grpInvoiceExport.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpStandaloneFileExport.ResumeLayout(false);
            this.grpStandaloneFileExport.PerformLayout();
            this.tbpAccountAdmin.ResumeLayout(false);
            this.tbpAccountAdmin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdmin)).EndInit();
            this.tbpBilling.ResumeLayout(false);
            this.grpManualEntries.ResumeLayout(false);
            this.grpBillingSupplies.ResumeLayout(false);
            this.grpBillingSupplies.PerformLayout();
            this.grpManualTimeLog.ResumeLayout(false);
            this.grpManualTimeLog.PerformLayout();
            this.grpTimeLogExceptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeLogRequests)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.tbpManualRequests.ResumeLayout(false);
            this.grpAccountSettings.ResumeLayout(false);
            this.grpAccountSettings.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.TabPage tbpExports;
        private System.Windows.Forms.GroupBox grpStandaloneFileExport;
        private System.Windows.Forms.Button btnImportLogs;
        private System.Windows.Forms.Button btnExportStandaloneFile;
        private System.Windows.Forms.TabPage tbpAccountAdmin;
        private System.Windows.Forms.Button btnAccountAdminNew;
        private System.Windows.Forms.ComboBox cboAccountAdminNew;
        private System.Windows.Forms.Button btnAccountAdminSearch;
        private System.Windows.Forms.Label lblAccountAdminView;
        private System.Windows.Forms.ComboBox cboAccountAdminView;
        private System.Windows.Forms.TextBox txtAccountAdminSearch;
        private System.Windows.Forms.DataGridView dgvAdmin;
        private System.Windows.Forms.TabPage tbpBilling;
        private System.Windows.Forms.GroupBox grpManualEntries;
        private System.Windows.Forms.GroupBox grpBillingSupplies;
        private System.Windows.Forms.Button btnBillingSupplyAdd;
        private System.Windows.Forms.TextBox txtBillingSupplyQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.ComboBox cboBillingSupplyFunding;
        private System.Windows.Forms.Label lblSupplyFunding;
        private System.Windows.Forms.ComboBox cboBillingSupplyName;
        private System.Windows.Forms.Label lblSupplyName;
        private System.Windows.Forms.GroupBox grpManualTimeLog;
        private System.Windows.Forms.DateTimePicker dtpManualLog;
        private System.Windows.Forms.Label lblManualLogInstrument;
        private System.Windows.Forms.Label lblManualLogUser;
        private System.Windows.Forms.ComboBox cboManualLogInstrument;
        private System.Windows.Forms.ComboBox cboManualLogUser;
        private System.Windows.Forms.ComboBox cboManualLogFunding;
        private System.Windows.Forms.TextBox txtManualLogDuration;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblManualLogDuration;
        private System.Windows.Forms.Label lblManualLogFunding;
        private System.Windows.Forms.GroupBox grpTimeLogExceptions;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tbpTracking;
        private System.Windows.Forms.DataGridView dgvTimeLogRequests;
        private System.Windows.Forms.Button btnExportSingle;
        private System.Windows.Forms.FolderBrowserDialog InvoiceExportPath;
        private System.Windows.Forms.GroupBox grpInvoiceExport;
        private System.Windows.Forms.TabPage tbpManualRequests;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btnManualSupplyAdd;
        private System.Windows.Forms.TextBox txtManualSupplyQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboManualSupplyAccount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboManualSupplyItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtManualTimeUsername;
        private System.Windows.Forms.DateTimePicker dtpManualTimeDate;
        private System.Windows.Forms.Label lblInstrument;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.ComboBox cboManualTimeInstrument;
        private System.Windows.Forms.ComboBox cboManualTimeAccount;
        private System.Windows.Forms.TextBox txtManualTimeDuration;
        private System.Windows.Forms.Button btnManualTimeAdd;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblFundingSource;
        private System.Windows.Forms.TextBox txtManualTimePassword;
        private System.Windows.Forms.TextBox txtManualSupplyPassword;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtManualSupplyUsername;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnManualSupplyValidate;
        private System.Windows.Forms.Button btnManualTimeValidate;
        private System.Windows.Forms.Label lblValidate;
        private System.Windows.Forms.Label lblManualSuppliesValidated;
        private System.Windows.Forms.ComboBox comboBoxSelectMonth;
        private System.Windows.Forms.ComboBox comboBoxSelectAccount;
        private System.Windows.Forms.Label txtAccount;
        private System.Windows.Forms.Label txtMonth;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExportAll;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox grpAccountSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAcctManagementPw;
        private System.Windows.Forms.Label lblAcctManagementUn;
        private System.Windows.Forms.TextBox txtAcctManagementConfirmPw;
        private System.Windows.Forms.TextBox txtAcctManagementNewPw;
        private System.Windows.Forms.TextBox txtAcctManagementPassword;
        private System.Windows.Forms.TextBox txtAcctManagementUsername;
        private System.Windows.Forms.TextBox txtAcctManagementCity;
        private System.Windows.Forms.TextBox txtAcctManagementStreet;
        private System.Windows.Forms.Button btnAcctManagementSubmit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAcctManagementZip;
        private System.Windows.Forms.ComboBox cboAcctManagementState;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAcctManagementPhone;
        private System.Windows.Forms.TextBox txtAcctManagementEmail;
        private LineSeparator lineSeparator1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox grpExportPath;
        private System.Windows.Forms.Label lblExportPath;
        private System.Windows.Forms.TextBox txtInvoiceExportPath;
        private System.Windows.Forms.Button btnSetInvoiceExportPath;
        private System.Windows.Forms.CheckBox chkStandalone;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblAcctManagementPwMessage;
        private System.Windows.Forms.CheckBox chkFullScreen;
        private System.Windows.Forms.ComboBox cboBillingExceptions;
        private System.Windows.Forms.CheckBox chkGLSU;
        private System.Windows.Forms.Button btnImportStandalone;
        private System.Windows.Forms.CheckBox chkAdminIncludeInactive;
        private System.Windows.Forms.Button btnAdminClear;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnExportLogs;
    }
}

