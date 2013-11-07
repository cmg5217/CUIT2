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
            this.grpInvoiceExport = new System.Windows.Forms.GroupBox();
            this.txtAccount = new System.Windows.Forms.Label();
            this.txtMonth = new System.Windows.Forms.Label();
            this.comboBoxSelectAccount = new System.Windows.Forms.ComboBox();
            this.comboBoxSelectMonth = new System.Windows.Forms.ComboBox();
            this.btnInvoiceExport = new System.Windows.Forms.Button();
            this.grpBillingExport = new System.Windows.Forms.GroupBox();
            this.btnBillingExport = new System.Windows.Forms.Button();
            this.dtpBillingEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpBillingStartDate = new System.Windows.Forms.DateTimePicker();
            this.grpStandaloneFileExport = new System.Windows.Forms.GroupBox();
            this.btnImportLogs = new System.Windows.Forms.Button();
            this.btnExportStandaloneFile = new System.Windows.Forms.Button();
            this.tbpAccountAdmin = new System.Windows.Forms.TabPage();
            this.btnAccountAdminNew = new System.Windows.Forms.Button();
            this.cboAccountAdminNew = new System.Windows.Forms.ComboBox();
            this.btnAccountAdminSearch = new System.Windows.Forms.Button();
            this.lblAccountAdminView = new System.Windows.Forms.Label();
            this.cboAccountAdminView = new System.Windows.Forms.ComboBox();
            this.txtAccountAdminSearch = new System.Windows.Forms.TextBox();
            this.AdminDataGridView = new System.Windows.Forms.DataGridView();
            this.tbpBilling = new System.Windows.Forms.TabPage();
            this.grpManualEntries = new System.Windows.Forms.GroupBox();
            this.grpBillingSupplies = new System.Windows.Forms.GroupBox();
            this.btnBillingSupplyAdd = new System.Windows.Forms.Button();
            this.txtSupplyQuantity = new System.Windows.Forms.TextBox();
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
            this.dgvTimeLogRequests = new System.Windows.Forms.DataGridView();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.InvoiceExportPath = new System.Windows.Forms.FolderBrowserDialog();
            this.tbpSettings = new System.Windows.Forms.TabPage();
            this.chkStandalone = new System.Windows.Forms.CheckBox();
            this.grpExportPath = new System.Windows.Forms.GroupBox();
            this.lblExportPath = new System.Windows.Forms.Label();
            this.txtInvoiceExportPath = new System.Windows.Forms.TextBox();
            this.btnSetInvoiceExportPath = new System.Windows.Forms.Button();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tbpTracking = new System.Windows.Forms.TabPage();
            this.tbpManualRequests = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
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
            this.tbpExports.SuspendLayout();
            this.grpInvoiceExport.SuspendLayout();
            this.grpBillingExport.SuspendLayout();
            this.grpStandaloneFileExport.SuspendLayout();
            this.tbpAccountAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AdminDataGridView)).BeginInit();
            this.tbpBilling.SuspendLayout();
            this.grpManualEntries.SuspendLayout();
            this.grpBillingSupplies.SuspendLayout();
            this.grpManualTimeLog.SuspendLayout();
            this.grpTimeLogExceptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeLogRequests)).BeginInit();
            this.tbpSettings.SuspendLayout();
            this.grpExportPath.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tbpManualRequests.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbpExports
            // 
            this.tbpExports.Controls.Add(this.grpInvoiceExport);
            this.tbpExports.Controls.Add(this.grpBillingExport);
            this.tbpExports.Controls.Add(this.grpStandaloneFileExport);
            this.tbpExports.Location = new System.Drawing.Point(4, 22);
            this.tbpExports.Name = "tbpExports";
            this.tbpExports.Padding = new System.Windows.Forms.Padding(3);
            this.tbpExports.Size = new System.Drawing.Size(683, 589);
            this.tbpExports.TabIndex = 2;
            this.tbpExports.Text = "Exports";
            this.tbpExports.UseVisualStyleBackColor = true;
            this.tbpExports.Click += new System.EventHandler(this.tbpExports_Click);
            // 
            // grpInvoiceExport
            // 
            this.grpInvoiceExport.Controls.Add(this.txtAccount);
            this.grpInvoiceExport.Controls.Add(this.txtMonth);
            this.grpInvoiceExport.Controls.Add(this.comboBoxSelectAccount);
            this.grpInvoiceExport.Controls.Add(this.comboBoxSelectMonth);
            this.grpInvoiceExport.Controls.Add(this.btnInvoiceExport);
            this.grpInvoiceExport.Location = new System.Drawing.Point(232, 379);
            this.grpInvoiceExport.Name = "grpInvoiceExport";
            this.grpInvoiceExport.Size = new System.Drawing.Size(216, 175);
            this.grpInvoiceExport.TabIndex = 7;
            this.grpInvoiceExport.TabStop = false;
            this.grpInvoiceExport.Text = "Export Invoice";
            // 
            // txtAccount
            // 
            this.txtAccount.AutoSize = true;
            this.txtAccount.Location = new System.Drawing.Point(23, 80);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(50, 13);
            this.txtAccount.TabIndex = 5;
            this.txtAccount.Text = "Account:";
            // 
            // txtMonth
            // 
            this.txtMonth.AutoSize = true;
            this.txtMonth.Location = new System.Drawing.Point(22, 40);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(40, 13);
            this.txtMonth.TabIndex = 4;
            this.txtMonth.Text = "Month:";
            // 
            // comboBoxSelectAccount
            // 
            this.comboBoxSelectAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectAccount.FormattingEnabled = true;
            this.comboBoxSelectAccount.Items.AddRange(new object[] {
            "AccountA",
            "AccountB",
            "AccountC"});
            this.comboBoxSelectAccount.Location = new System.Drawing.Point(79, 77);
            this.comboBoxSelectAccount.Name = "comboBoxSelectAccount";
            this.comboBoxSelectAccount.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSelectAccount.TabIndex = 3;
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
            this.comboBoxSelectMonth.Location = new System.Drawing.Point(79, 37);
            this.comboBoxSelectMonth.Name = "comboBoxSelectMonth";
            this.comboBoxSelectMonth.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSelectMonth.TabIndex = 2;
            // 
            // btnInvoiceExport
            // 
            this.btnInvoiceExport.Location = new System.Drawing.Point(57, 120);
            this.btnInvoiceExport.Name = "btnInvoiceExport";
            this.btnInvoiceExport.Size = new System.Drawing.Size(103, 23);
            this.btnInvoiceExport.TabIndex = 1;
            this.btnInvoiceExport.Text = " Export";
            this.btnInvoiceExport.UseVisualStyleBackColor = true;
            this.btnInvoiceExport.Click += new System.EventHandler(this.button4_Click);
            // 
            // grpBillingExport
            // 
            this.grpBillingExport.Controls.Add(this.btnBillingExport);
            this.grpBillingExport.Controls.Add(this.dtpBillingEndDate);
            this.grpBillingExport.Controls.Add(this.dtpBillingStartDate);
            this.grpBillingExport.Location = new System.Drawing.Point(232, 135);
            this.grpBillingExport.Name = "grpBillingExport";
            this.grpBillingExport.Size = new System.Drawing.Size(216, 119);
            this.grpBillingExport.TabIndex = 3;
            this.grpBillingExport.TabStop = false;
            this.grpBillingExport.Text = "Billing Export";
            // 
            // btnBillingExport
            // 
            this.btnBillingExport.Location = new System.Drawing.Point(131, 74);
            this.btnBillingExport.Name = "btnBillingExport";
            this.btnBillingExport.Size = new System.Drawing.Size(75, 23);
            this.btnBillingExport.TabIndex = 2;
            this.btnBillingExport.Text = "Export";
            this.btnBillingExport.UseVisualStyleBackColor = true;
            this.btnBillingExport.Click += new System.EventHandler(this.button3_Click);
            // 
            // dtpBillingEndDate
            // 
            this.dtpBillingEndDate.Location = new System.Drawing.Point(7, 47);
            this.dtpBillingEndDate.Name = "dtpBillingEndDate";
            this.dtpBillingEndDate.Size = new System.Drawing.Size(200, 20);
            this.dtpBillingEndDate.TabIndex = 1;
            // 
            // dtpBillingStartDate
            // 
            this.dtpBillingStartDate.Location = new System.Drawing.Point(7, 20);
            this.dtpBillingStartDate.Name = "dtpBillingStartDate";
            this.dtpBillingStartDate.Size = new System.Drawing.Size(200, 20);
            this.dtpBillingStartDate.TabIndex = 0;
            // 
            // grpStandaloneFileExport
            // 
            this.grpStandaloneFileExport.Controls.Add(this.btnImportLogs);
            this.grpStandaloneFileExport.Controls.Add(this.btnExportStandaloneFile);
            this.grpStandaloneFileExport.Location = new System.Drawing.Point(232, 260);
            this.grpStandaloneFileExport.Name = "grpStandaloneFileExport";
            this.grpStandaloneFileExport.Size = new System.Drawing.Size(216, 100);
            this.grpStandaloneFileExport.TabIndex = 2;
            this.grpStandaloneFileExport.TabStop = false;
            this.grpStandaloneFileExport.Text = "Standalone Files";
            // 
            // btnImportLogs
            // 
            this.btnImportLogs.Location = new System.Drawing.Point(52, 59);
            this.btnImportLogs.Name = "btnImportLogs";
            this.btnImportLogs.Size = new System.Drawing.Size(103, 23);
            this.btnImportLogs.TabIndex = 1;
            this.btnImportLogs.Text = "Import Logs";
            this.btnImportLogs.UseVisualStyleBackColor = true;
            this.btnImportLogs.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnExportStandaloneFile
            // 
            this.btnExportStandaloneFile.Location = new System.Drawing.Point(52, 29);
            this.btnExportStandaloneFile.Name = "btnExportStandaloneFile";
            this.btnExportStandaloneFile.Size = new System.Drawing.Size(103, 23);
            this.btnExportStandaloneFile.TabIndex = 0;
            this.btnExportStandaloneFile.Text = "Export Standalone";
            this.btnExportStandaloneFile.UseVisualStyleBackColor = true;
            // 
            // tbpAccountAdmin
            // 
            this.tbpAccountAdmin.Controls.Add(this.btnAccountAdminNew);
            this.tbpAccountAdmin.Controls.Add(this.cboAccountAdminNew);
            this.tbpAccountAdmin.Controls.Add(this.btnAccountAdminSearch);
            this.tbpAccountAdmin.Controls.Add(this.lblAccountAdminView);
            this.tbpAccountAdmin.Controls.Add(this.cboAccountAdminView);
            this.tbpAccountAdmin.Controls.Add(this.txtAccountAdminSearch);
            this.tbpAccountAdmin.Controls.Add(this.AdminDataGridView);
            this.tbpAccountAdmin.Location = new System.Drawing.Point(4, 22);
            this.tbpAccountAdmin.Name = "tbpAccountAdmin";
            this.tbpAccountAdmin.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAccountAdmin.Size = new System.Drawing.Size(683, 589);
            this.tbpAccountAdmin.TabIndex = 1;
            this.tbpAccountAdmin.Text = "Account Admin";
            this.tbpAccountAdmin.UseVisualStyleBackColor = true;
            this.tbpAccountAdmin.Click += new System.EventHandler(this.tbpAccountAdmin_Click);
            // 
            // btnAccountAdminNew
            // 
            this.btnAccountAdminNew.Location = new System.Drawing.Point(475, 8);
            this.btnAccountAdminNew.Name = "btnAccountAdminNew";
            this.btnAccountAdminNew.Size = new System.Drawing.Size(75, 23);
            this.btnAccountAdminNew.TabIndex = 6;
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
            "Supply",
            "User",
            "Point of Contact"});
            this.cboAccountAdminNew.Location = new System.Drawing.Point(556, 9);
            this.cboAccountAdminNew.Name = "cboAccountAdminNew";
            this.cboAccountAdminNew.Size = new System.Drawing.Size(121, 21);
            this.cboAccountAdminNew.TabIndex = 5;
            // 
            // btnAccountAdminSearch
            // 
            this.btnAccountAdminSearch.Location = new System.Drawing.Point(330, 8);
            this.btnAccountAdminSearch.Name = "btnAccountAdminSearch";
            this.btnAccountAdminSearch.Size = new System.Drawing.Size(75, 23);
            this.btnAccountAdminSearch.TabIndex = 4;
            this.btnAccountAdminSearch.Text = "Search";
            this.btnAccountAdminSearch.UseVisualStyleBackColor = true;
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
            "Supplies"});
            this.cboAccountAdminView.Location = new System.Drawing.Point(42, 9);
            this.cboAccountAdminView.Name = "cboAccountAdminView";
            this.cboAccountAdminView.Size = new System.Drawing.Size(121, 21);
            this.cboAccountAdminView.TabIndex = 2;
            this.cboAccountAdminView.SelectedValueChanged += new System.EventHandler(this.adminEditViewLoad);
            // 
            // txtAccountAdminSearch
            // 
            this.txtAccountAdminSearch.Location = new System.Drawing.Point(224, 9);
            this.txtAccountAdminSearch.Name = "txtAccountAdminSearch";
            this.txtAccountAdminSearch.Size = new System.Drawing.Size(100, 20);
            this.txtAccountAdminSearch.TabIndex = 1;
            // 
            // AdminDataGridView
            // 
            this.AdminDataGridView.AllowUserToAddRows = false;
            this.AdminDataGridView.AllowUserToDeleteRows = false;
            this.AdminDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AdminDataGridView.Location = new System.Drawing.Point(6, 37);
            this.AdminDataGridView.Name = "AdminDataGridView";
            this.AdminDataGridView.ReadOnly = true;
            this.AdminDataGridView.Size = new System.Drawing.Size(671, 546);
            this.AdminDataGridView.TabIndex = 0;
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
            this.grpManualEntries.TabIndex = 11;
            this.grpManualEntries.TabStop = false;
            this.grpManualEntries.Text = "Manual Entries";
            // 
            // grpBillingSupplies
            // 
            this.grpBillingSupplies.Controls.Add(this.btnBillingSupplyAdd);
            this.grpBillingSupplies.Controls.Add(this.txtSupplyQuantity);
            this.grpBillingSupplies.Controls.Add(this.lblQuantity);
            this.grpBillingSupplies.Controls.Add(this.cboBillingSupplyFunding);
            this.grpBillingSupplies.Controls.Add(this.lblSupplyFunding);
            this.grpBillingSupplies.Controls.Add(this.cboBillingSupplyName);
            this.grpBillingSupplies.Controls.Add(this.lblSupplyName);
            this.grpBillingSupplies.Location = new System.Drawing.Point(339, 15);
            this.grpBillingSupplies.Name = "grpBillingSupplies";
            this.grpBillingSupplies.Size = new System.Drawing.Size(326, 199);
            this.grpBillingSupplies.TabIndex = 18;
            this.grpBillingSupplies.TabStop = false;
            this.grpBillingSupplies.Text = "Supplies";
            // 
            // btnBillingSupplyAdd
            // 
            this.btnBillingSupplyAdd.Location = new System.Drawing.Point(199, 88);
            this.btnBillingSupplyAdd.Name = "btnBillingSupplyAdd";
            this.btnBillingSupplyAdd.Size = new System.Drawing.Size(75, 23);
            this.btnBillingSupplyAdd.TabIndex = 11;
            this.btnBillingSupplyAdd.Text = "Add";
            this.btnBillingSupplyAdd.UseVisualStyleBackColor = true;
            // 
            // txtSupplyQuantity
            // 
            this.txtSupplyQuantity.Location = new System.Drawing.Point(126, 90);
            this.txtSupplyQuantity.Name = "txtSupplyQuantity";
            this.txtSupplyQuantity.Size = new System.Drawing.Size(67, 20);
            this.txtSupplyQuantity.TabIndex = 10;
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
            this.cboBillingSupplyFunding.TabIndex = 7;
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
            this.cboBillingSupplyName.TabIndex = 5;
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
            this.grpManualTimeLog.TabIndex = 17;
            this.grpManualTimeLog.TabStop = false;
            this.grpManualTimeLog.Text = "Time Log";
            // 
            // dtpManualLog
            // 
            this.dtpManualLog.Location = new System.Drawing.Point(34, 118);
            this.dtpManualLog.Name = "dtpManualLog";
            this.dtpManualLog.Size = new System.Drawing.Size(236, 20);
            this.dtpManualLog.TabIndex = 3;
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
            this.cboManualLogInstrument.TabIndex = 2;
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
            this.cboManualLogUser.TabIndex = 13;
            // 
            // cboManualLogFunding
            // 
            this.cboManualLogFunding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboManualLogFunding.FormattingEnabled = true;
            this.cboManualLogFunding.Location = new System.Drawing.Point(122, 62);
            this.cboManualLogFunding.Name = "cboManualLogFunding";
            this.cboManualLogFunding.Size = new System.Drawing.Size(148, 21);
            this.cboManualLogFunding.TabIndex = 1;
            // 
            // txtManualLogDuration
            // 
            this.txtManualLogDuration.Location = new System.Drawing.Point(122, 146);
            this.txtManualLogDuration.Name = "txtManualLogDuration";
            this.txtManualLogDuration.Size = new System.Drawing.Size(67, 20);
            this.txtManualLogDuration.TabIndex = 12;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(195, 144);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
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
            this.grpTimeLogExceptions.Controls.Add(this.dgvTimeLogRequests);
            this.grpTimeLogExceptions.Controls.Add(this.btnSubmit);
            this.grpTimeLogExceptions.Location = new System.Drawing.Point(6, 232);
            this.grpTimeLogExceptions.Name = "grpTimeLogExceptions";
            this.grpTimeLogExceptions.Size = new System.Drawing.Size(671, 354);
            this.grpTimeLogExceptions.TabIndex = 8;
            this.grpTimeLogExceptions.TabStop = false;
            this.grpTimeLogExceptions.Text = "Time Log Exceptions";
            // 
            // dgvTimeLogRequests
            // 
            this.dgvTimeLogRequests.AllowUserToAddRows = false;
            this.dgvTimeLogRequests.AllowUserToDeleteRows = false;
            this.dgvTimeLogRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimeLogRequests.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTimeLogRequests.Location = new System.Drawing.Point(7, 20);
            this.dgvTimeLogRequests.Name = "dgvTimeLogRequests";
            this.dgvTimeLogRequests.Size = new System.Drawing.Size(658, 299);
            this.dgvTimeLogRequests.TabIndex = 8;
            this.dgvTimeLogRequests.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTimeLogRequests_RowHeaderMouseClick);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(590, 325);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // tbpSettings
            // 
            this.tbpSettings.Controls.Add(this.chkStandalone);
            this.tbpSettings.Controls.Add(this.grpExportPath);
            this.tbpSettings.Location = new System.Drawing.Point(4, 22);
            this.tbpSettings.Name = "tbpSettings";
            this.tbpSettings.Size = new System.Drawing.Size(683, 589);
            this.tbpSettings.TabIndex = 3;
            this.tbpSettings.Text = "Settings";
            this.tbpSettings.UseVisualStyleBackColor = true;
            // 
            // chkStandalone
            // 
            this.chkStandalone.AutoSize = true;
            this.chkStandalone.Location = new System.Drawing.Point(149, 207);
            this.chkStandalone.Name = "chkStandalone";
            this.chkStandalone.Size = new System.Drawing.Size(110, 17);
            this.chkStandalone.TabIndex = 6;
            this.chkStandalone.Text = "Standalone Mode";
            this.chkStandalone.UseVisualStyleBackColor = true;
            this.chkStandalone.CheckedChanged += new System.EventHandler(this.chkStandalone_CheckedChanged);
            // 
            // grpExportPath
            // 
            this.grpExportPath.Controls.Add(this.lblExportPath);
            this.grpExportPath.Controls.Add(this.txtInvoiceExportPath);
            this.grpExportPath.Controls.Add(this.btnSetInvoiceExportPath);
            this.grpExportPath.Location = new System.Drawing.Point(130, 244);
            this.grpExportPath.Name = "grpExportPath";
            this.grpExportPath.Size = new System.Drawing.Size(423, 100);
            this.grpExportPath.TabIndex = 5;
            this.grpExportPath.TabStop = false;
            this.grpExportPath.Text = "Export Invoice";
            // 
            // lblExportPath
            // 
            this.lblExportPath.AutoSize = true;
            this.lblExportPath.Location = new System.Drawing.Point(19, 29);
            this.lblExportPath.Name = "lblExportPath";
            this.lblExportPath.Size = new System.Drawing.Size(93, 13);
            this.lblExportPath.TabIndex = 3;
            this.lblExportPath.Text = "Enter Export Path:";
            // 
            // txtInvoiceExportPath
            // 
            this.txtInvoiceExportPath.Location = new System.Drawing.Point(19, 60);
            this.txtInvoiceExportPath.Name = "txtInvoiceExportPath";
            this.txtInvoiceExportPath.Size = new System.Drawing.Size(276, 20);
            this.txtInvoiceExportPath.TabIndex = 2;
            // 
            // btnSetInvoiceExportPath
            // 
            this.btnSetInvoiceExportPath.Location = new System.Drawing.Point(301, 58);
            this.btnSetInvoiceExportPath.Name = "btnSetInvoiceExportPath";
            this.btnSetInvoiceExportPath.Size = new System.Drawing.Size(103, 23);
            this.btnSetInvoiceExportPath.TabIndex = 0;
            this.btnSetInvoiceExportPath.Text = "Browse";
            this.btnSetInvoiceExportPath.UseVisualStyleBackColor = true;
            this.btnSetInvoiceExportPath.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tbpBilling);
            this.tabControlMain.Controls.Add(this.tbpAccountAdmin);
            this.tabControlMain.Controls.Add(this.tbpExports);
            this.tabControlMain.Controls.Add(this.tbpSettings);
            this.tabControlMain.Controls.Add(this.tbpTracking);
            this.tabControlMain.Controls.Add(this.tbpManualRequests);
            this.tabControlMain.Location = new System.Drawing.Point(12, 12);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(691, 615);
            this.tabControlMain.TabIndex = 0;
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
            this.tbpManualRequests.Controls.Add(this.groupBox7);
            this.tbpManualRequests.Location = new System.Drawing.Point(4, 22);
            this.tbpManualRequests.Name = "tbpManualRequests";
            this.tbpManualRequests.Padding = new System.Windows.Forms.Padding(3);
            this.tbpManualRequests.Size = new System.Drawing.Size(683, 589);
            this.tbpManualRequests.TabIndex = 4;
            this.tbpManualRequests.Text = "Manual Requests";
            this.tbpManualRequests.UseVisualStyleBackColor = true;
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
            this.groupBox8.Controls.Add(this.label12);
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(144, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Validated";
            this.label12.Visible = false;
            // 
            // btnManualSupplyValidate
            // 
            this.btnManualSupplyValidate.Location = new System.Drawing.Point(201, 75);
            this.btnManualSupplyValidate.Name = "btnManualSupplyValidate";
            this.btnManualSupplyValidate.Size = new System.Drawing.Size(75, 23);
            this.btnManualSupplyValidate.TabIndex = 22;
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
            this.txtManualSupplyPassword.TabIndex = 21;
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
            this.txtManualSupplyUsername.TabIndex = 19;
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
            this.btnManualSupplyAdd.TabIndex = 11;
            this.btnManualSupplyAdd.Text = "Add";
            this.btnManualSupplyAdd.UseVisualStyleBackColor = true;
            this.btnManualSupplyAdd.Click += new System.EventHandler(this.btnManualSupplyAdd_Click);
            // 
            // txtManualSupplyQuantity
            // 
            this.txtManualSupplyQuantity.Location = new System.Drawing.Point(128, 157);
            this.txtManualSupplyQuantity.Name = "txtManualSupplyQuantity";
            this.txtManualSupplyQuantity.Size = new System.Drawing.Size(67, 20);
            this.txtManualSupplyQuantity.TabIndex = 10;
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
            this.cboManualSupplyAccount.TabIndex = 7;
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
            this.cboManualSupplyItem.TabIndex = 5;
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
            this.btnManualTimeValidate.TabIndex = 18;
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
            this.txtManualTimePassword.TabIndex = 17;
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
            this.txtManualTimeUsername.TabIndex = 15;
            // 
            // dtpManualTimeDate
            // 
            this.dtpManualTimeDate.CustomFormat = "Da\'t\'e: M-dd-yyyy Ti\'m\'e: hh:mm tt";
            this.dtpManualTimeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpManualTimeDate.Location = new System.Drawing.Point(32, 160);
            this.dtpManualTimeDate.Name = "dtpManualTimeDate";
            this.dtpManualTimeDate.Size = new System.Drawing.Size(236, 20);
            this.dtpManualTimeDate.TabIndex = 3;
            // 
            // lblInstrument
            // 
            this.lblInstrument.AutoSize = true;
            this.lblInstrument.Location = new System.Drawing.Point(29, 135);
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
            this.cboManualTimeInstrument.Location = new System.Drawing.Point(120, 132);
            this.cboManualTimeInstrument.Name = "cboManualTimeInstrument";
            this.cboManualTimeInstrument.Size = new System.Drawing.Size(148, 21);
            this.cboManualTimeInstrument.TabIndex = 2;
            // 
            // cboManualTimeAccount
            // 
            this.cboManualTimeAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboManualTimeAccount.FormattingEnabled = true;
            this.cboManualTimeAccount.Location = new System.Drawing.Point(120, 104);
            this.cboManualTimeAccount.Name = "cboManualTimeAccount";
            this.cboManualTimeAccount.Size = new System.Drawing.Size(148, 21);
            this.cboManualTimeAccount.TabIndex = 1;
            // 
            // txtManualTimeDuration
            // 
            this.txtManualTimeDuration.Location = new System.Drawing.Point(120, 186);
            this.txtManualTimeDuration.Name = "txtManualTimeDuration";
            this.txtManualTimeDuration.Size = new System.Drawing.Size(67, 20);
            this.txtManualTimeDuration.TabIndex = 12;
            // 
            // btnManualTimeAdd
            // 
            this.btnManualTimeAdd.Location = new System.Drawing.Point(193, 184);
            this.btnManualTimeAdd.Name = "btnManualTimeAdd";
            this.btnManualTimeAdd.Size = new System.Drawing.Size(75, 23);
            this.btnManualTimeAdd.TabIndex = 0;
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
            this.lblFundingSource.Location = new System.Drawing.Point(29, 107);
            this.lblFundingSource.Name = "lblFundingSource";
            this.lblFundingSource.Size = new System.Drawing.Size(85, 13);
            this.lblFundingSource.TabIndex = 4;
            this.lblFundingSource.Text = "Funding Source:";
            // 
            // frmCUITAdminMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(712, 639);
            this.Controls.Add(this.tabControlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmCUITAdminMain";
            this.Text = "CUITAdmin";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tbpExports.ResumeLayout(false);
            this.grpInvoiceExport.ResumeLayout(false);
            this.grpInvoiceExport.PerformLayout();
            this.grpBillingExport.ResumeLayout(false);
            this.grpStandaloneFileExport.ResumeLayout(false);
            this.tbpAccountAdmin.ResumeLayout(false);
            this.tbpAccountAdmin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AdminDataGridView)).EndInit();
            this.tbpBilling.ResumeLayout(false);
            this.grpManualEntries.ResumeLayout(false);
            this.grpBillingSupplies.ResumeLayout(false);
            this.grpBillingSupplies.PerformLayout();
            this.grpManualTimeLog.ResumeLayout(false);
            this.grpManualTimeLog.PerformLayout();
            this.grpTimeLogExceptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeLogRequests)).EndInit();
            this.tbpSettings.ResumeLayout(false);
            this.tbpSettings.PerformLayout();
            this.grpExportPath.ResumeLayout(false);
            this.grpExportPath.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tbpManualRequests.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.TabPage tbpExports;
        private System.Windows.Forms.GroupBox grpBillingExport;
        private System.Windows.Forms.Button btnBillingExport;
        private System.Windows.Forms.DateTimePicker dtpBillingEndDate;
        private System.Windows.Forms.DateTimePicker dtpBillingStartDate;
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
        private System.Windows.Forms.DataGridView AdminDataGridView;
        private System.Windows.Forms.TabPage tbpBilling;
        private System.Windows.Forms.GroupBox grpManualEntries;
        private System.Windows.Forms.GroupBox grpBillingSupplies;
        private System.Windows.Forms.Button btnBillingSupplyAdd;
        private System.Windows.Forms.TextBox txtSupplyQuantity;
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
        private System.Windows.Forms.Button btnInvoiceExport;
        private System.Windows.Forms.FolderBrowserDialog InvoiceExportPath;
        private System.Windows.Forms.TabPage tbpSettings;
        private System.Windows.Forms.GroupBox grpExportPath;
        private System.Windows.Forms.TextBox txtInvoiceExportPath;
        private System.Windows.Forms.Button btnSetInvoiceExportPath;
        private System.Windows.Forms.GroupBox grpInvoiceExport;
        private System.Windows.Forms.Label lblExportPath;
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
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxSelectMonth;
        private System.Windows.Forms.ComboBox comboBoxSelectAccount;
        private System.Windows.Forms.Label txtAccount;
        private System.Windows.Forms.Label txtMonth;
        private System.Windows.Forms.CheckBox chkStandalone;
    }
}

