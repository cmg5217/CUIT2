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
            this.components = new System.ComponentModel.Container();
            this.unapprovedTimeLogTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cUIT_TRIALDataSet = new CUITAdmin.CUIT_TRIALDataSet();
            this.time_LogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.time_LogTableAdapter = new CUITAdmin.CUIT_TRIALDataSetTableAdapters.Time_LogTableAdapter();
            this.tableAdapterManager = new CUITAdmin.CUIT_TRIALDataSetTableAdapters.TableAdapterManager();
            this.unapprovedTimeLogTableTableAdapter = new CUITAdmin.CUIT_TRIALDataSetTableAdapters.UnapprovedTimeLogTableTableAdapter();
            this.tbpExports = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tbpAccountAdmin = new System.Windows.Forms.TabPage();
            this.btnAccountAdminNew = new System.Windows.Forms.Button();
            this.cboAccountAdminNew = new System.Windows.Forms.ComboBox();
            this.btnAccountAdminSearch = new System.Windows.Forms.Button();
            this.lblAccountAdminView = new System.Windows.Forms.Label();
            this.cboAccountAdminView = new System.Windows.Forms.ComboBox();
            this.txtAccountAdminSearch = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tbpBilling = new System.Windows.Forms.TabPage();
            this.grpManualEntries = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btmSupplyAdd = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.cboSupplyFunding = new System.Windows.Forms.ComboBox();
            this.lblSupplyFunding = new System.Windows.Forms.Label();
            this.cboSupplyName = new System.Windows.Forms.ComboBox();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.InvoiceExportPath = new System.Windows.Forms.FolderBrowserDialog();
            this.tbpSettings = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tbpTracking = new System.Windows.Forms.TabPage();
            this.clmApprove = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFundingSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmInstrument = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTimeLogRequests = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.unapprovedTimeLogTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cUIT_TRIALDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.time_LogBindingSource)).BeginInit();
            this.tbpExports.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tbpAccountAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tbpBilling.SuspendLayout();/////
            this.grpManualEntries.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpManualTimeLog.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeLogRequests)).BeginInit();
            this.tbpSettings.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // unapprovedTimeLogTableBindingSource
            // 
            this.unapprovedTimeLogTableBindingSource.DataMember = "UnapprovedTimeLogTable";
            this.unapprovedTimeLogTableBindingSource.DataSource = this.cUIT_TRIALDataSet;
            // 
            // cUIT_TRIALDataSet
            // 
            this.cUIT_TRIALDataSet.DataSetName = "CUIT_TRIALDataSet";
            this.cUIT_TRIALDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // time_LogBindingSource
            // 
            this.time_LogBindingSource.DataMember = "Time_Log";
            this.time_LogBindingSource.DataSource = this.cUIT_TRIALDataSet;
            // 
            // time_LogTableAdapter
            // 
            this.time_LogTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.Account_AccessTableAdapter = null;
            this.tableAdapterManager.AccountTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Instrument_RateTableAdapter = null;
            this.tableAdapterManager.InstrumentTableAdapter = null;
            this.tableAdapterManager.ManagerTableAdapter = null;
            this.tableAdapterManager.Time_LogTableAdapter = this.time_LogTableAdapter;
            this.tableAdapterManager.UpdateOrder = CUITAdmin.CUIT_TRIALDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.User_ContactsTableAdapter = null;
            this.tableAdapterManager.UserTableAdapter = null;
            // 
            // unapprovedTimeLogTableTableAdapter
            // 
            this.unapprovedTimeLogTableTableAdapter.ClearBeforeFill = true;
            // 
            // tbpExports
            // 
            this.tbpExports.Controls.Add(this.groupBox6);
            this.tbpExports.Controls.Add(this.groupBox4);
            this.tbpExports.Controls.Add(this.groupBox3);
            this.tbpExports.Location = new System.Drawing.Point(4, 22);
            this.tbpExports.Name = "tbpExports";
            this.tbpExports.Padding = new System.Windows.Forms.Padding(3);
            this.tbpExports.Size = new System.Drawing.Size(683, 589);
            this.tbpExports.TabIndex = 2;
            this.tbpExports.Text = "Exports";
            this.tbpExports.UseVisualStyleBackColor = true;
            this.tbpExports.Click += new System.EventHandler(this.tbpExports_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.dateTimePicker2);
            this.groupBox4.Controls.Add(this.dateTimePicker1);
            this.groupBox4.Location = new System.Drawing.Point(232, 135);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(216, 119);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Billing Export";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(131, 74);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Export";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(7, 47);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(7, 20);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(232, 260);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(216, 100);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Account Adminn";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(52, 59);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Import Logs";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(52, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Export User Data";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tbpAccountAdmin
            // 
            this.tbpAccountAdmin.Controls.Add(this.btnAccountAdminNew);
            this.tbpAccountAdmin.Controls.Add(this.cboAccountAdminNew);
            this.tbpAccountAdmin.Controls.Add(this.btnAccountAdminSearch);
            this.tbpAccountAdmin.Controls.Add(this.lblAccountAdminView);
            this.tbpAccountAdmin.Controls.Add(this.cboAccountAdminView);
            this.tbpAccountAdmin.Controls.Add(this.txtAccountAdminSearch);
            this.tbpAccountAdmin.Controls.Add(this.dataGridView1);
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
            "Account Manager",
            "Item",
            "User",
            "User Contact"});
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
            "Account Manager",
            "Contacts",
            "Users",
            "Items"});
            this.cboAccountAdminView.Location = new System.Drawing.Point(42, 9);
            this.cboAccountAdminView.Name = "cboAccountAdminView";
            this.cboAccountAdminView.Size = new System.Drawing.Size(121, 21);
            this.cboAccountAdminView.TabIndex = 2;
            // 
            // txtAccountAdminSearch
            // 
            this.txtAccountAdminSearch.Location = new System.Drawing.Point(224, 9);
            this.txtAccountAdminSearch.Name = "txtAccountAdminSearch";
            this.txtAccountAdminSearch.Size = new System.Drawing.Size(100, 20);
            this.txtAccountAdminSearch.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(671, 546);
            this.dataGridView1.TabIndex = 0;
            // 
            // tbpBilling
            // 
            this.tbpBilling.AutoScroll = true;
            this.tbpBilling.Controls.Add(this.grpManualEntries);
            this.tbpBilling.Controls.Add(this.groupBox1);
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
            this.grpManualEntries.Controls.Add(this.groupBox2);
            this.grpManualEntries.Controls.Add(this.grpManualTimeLog);
            this.grpManualEntries.Location = new System.Drawing.Point(6, 6);
            this.grpManualEntries.Name = "grpManualEntries";
            this.grpManualEntries.Size = new System.Drawing.Size(671, 220);
            this.grpManualEntries.TabIndex = 11;
            this.grpManualEntries.TabStop = false;
            this.grpManualEntries.Text = "Manual Entries";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btmSupplyAdd);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.lblQuantity);
            this.groupBox2.Controls.Add(this.cboSupplyFunding);
            this.groupBox2.Controls.Add(this.lblSupplyFunding);
            this.groupBox2.Controls.Add(this.cboSupplyName);
            this.groupBox2.Controls.Add(this.lblSupplyName);
            this.groupBox2.Location = new System.Drawing.Point(339, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(326, 199);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Supplies";
            // 
            // btmSupplyAdd
            // 
            this.btmSupplyAdd.Location = new System.Drawing.Point(199, 88);
            this.btmSupplyAdd.Name = "btmSupplyAdd";
            this.btmSupplyAdd.Size = new System.Drawing.Size(75, 23);
            this.btmSupplyAdd.TabIndex = 11;
            this.btmSupplyAdd.Text = "Add";
            this.btmSupplyAdd.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(126, 90);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(67, 20);
            this.textBox1.TabIndex = 10;
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
            // cboSupplyFunding
            // 
            this.cboSupplyFunding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSupplyFunding.FormattingEnabled = true;
            this.cboSupplyFunding.Location = new System.Drawing.Point(126, 63);
            this.cboSupplyFunding.Name = "cboSupplyFunding";
            this.cboSupplyFunding.Size = new System.Drawing.Size(148, 21);
            this.cboSupplyFunding.TabIndex = 7;
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
            // cboSupplyName
            // 
            this.cboSupplyName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSupplyName.FormattingEnabled = true;
            this.cboSupplyName.Location = new System.Drawing.Point(126, 37);
            this.cboSupplyName.Name = "cboSupplyName";
            this.cboSupplyName.Size = new System.Drawing.Size(148, 21);
            this.cboSupplyName.TabIndex = 5;
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
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(52, 55);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(103, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = " Export";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            
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
            this.lblManualLogDuration.Size = new System.Drawing.Size(95, 13);
            this.lblManualLogDuration.TabIndex = 9;
            this.lblManualLogDuration.Text = "Duration: (minutes)";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvTimeLogRequests);
            this.groupBox1.Controls.Add(this.btnSubmit);
            this.groupBox1.Location = new System.Drawing.Point(6, 232);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(671, 354);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Time Log Requests";
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
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tbpBilling);
            this.tabControlMain.Controls.Add(this.tbpAccountAdmin);
            this.tabControlMain.Controls.Add(this.tbpExports);
            this.tabControlMain.Controls.Add(this.tbpTracking);
            this.tabControlMain.Controls.Add(this.tbpSettings);
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
            // clmApprove
            // 
            this.clmApprove.HeaderText = "Approve?";
            this.clmApprove.Name = "clmApprove";
            this.clmApprove.Width = 60;
            // 
            // clmFundingSource
            // 
            this.clmFundingSource.HeaderText = "Funding Source";
            this.clmFundingSource.Name = "clmFundingSource";
            // 
            // clmDuration
            // 
            this.clmDuration.HeaderText = "Duration";
            this.clmDuration.Name = "clmDuration";
            this.clmDuration.Width = 60;
            // 
            // clmTime
            // 
            this.clmTime.HeaderText = "Start Time";
            this.clmTime.Name = "clmTime";
            this.clmTime.Width = 75;
            // 
            // clmDate
            // 
            this.clmDate.HeaderText = "Log Date";
            this.clmDate.Name = "clmDate";
            // 
            // clmInstrument
            // 
            this.clmInstrument.HeaderText = "Instrument";
            this.clmInstrument.Name = "clmInstrument";
            // 
            // clmName
            // 
            this.clmName.HeaderText = "Name";
            this.clmName.Name = "clmName";
            // 
            // dgvTimeLogRequests
            // 
            this.dgvTimeLogRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimeLogRequests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmName,
            this.clmInstrument,
            this.clmDate,
            this.clmTime,
            this.clmDuration,
            this.clmFundingSource,
            this.clmApprove});
            this.dgvTimeLogRequests.Location = new System.Drawing.Point(7, 20);
            this.dgvTimeLogRequests.Name = "dgvTimeLogRequests";
            this.dgvTimeLogRequests.Size = new System.Drawing.Size(658, 299);
            this.dgvTimeLogRequests.TabIndex = 8;
            //
            // tbpSettings
            // 
            this.tbpSettings.Controls.Add(this.groupBox5);
            this.tbpSettings.Location = new System.Drawing.Point(4, 22);
            this.tbpSettings.Name = "tbpSettings";
            this.tbpSettings.Size = new System.Drawing.Size(683, 589);
            this.tbpSettings.TabIndex = 3;
            this.tbpSettings.Text = "Settings";
            this.tbpSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.textBox2);
            this.groupBox5.Controls.Add(this.button5);
            this.groupBox5.Location = new System.Drawing.Point(130, 244);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(423, 100);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Export Invoice";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(19, 60);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(276, 20);
            this.textBox2.TabIndex = 2;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(301, 58);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(103, 23);
            this.button5.TabIndex = 0;
            this.button5.Text = "Browse";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter Export Path:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button4);
            this.groupBox6.Location = new System.Drawing.Point(232, 379);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(216, 114);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Export Invoice";
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
            ((System.ComponentModel.ISupportInitialize)(this.unapprovedTimeLogTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cUIT_TRIALDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.time_LogBindingSource)).EndInit();
            this.tbpExports.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tbpAccountAdmin.ResumeLayout(false);
            this.tbpAccountAdmin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tbpBilling.ResumeLayout(false);
            this.grpManualEntries.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpManualTimeLog.ResumeLayout(false);
            this.grpManualTimeLog.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeLogRequests)).EndInit();
            this.tbpSettings.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CUIT_TRIALDataSet cUIT_TRIALDataSet;
        private System.Windows.Forms.BindingSource time_LogBindingSource;
        private CUIT_TRIALDataSetTableAdapters.Time_LogTableAdapter time_LogTableAdapter;
        private CUIT_TRIALDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource unapprovedTimeLogTableBindingSource;
        private CUIT_TRIALDataSetTableAdapters.UnapprovedTimeLogTableTableAdapter unapprovedTimeLogTableTableAdapter;
        private System.Windows.Forms.TabPage tbpExports;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tbpAccountAdmin;
        private System.Windows.Forms.Button btnAccountAdminNew;
        private System.Windows.Forms.ComboBox cboAccountAdminNew;
        private System.Windows.Forms.Button btnAccountAdminSearch;
        private System.Windows.Forms.Label lblAccountAdminView;
        private System.Windows.Forms.ComboBox cboAccountAdminView;
        private System.Windows.Forms.TextBox txtAccountAdminSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tbpBilling;
        private System.Windows.Forms.GroupBox grpManualEntries;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btmSupplyAdd;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.ComboBox cboSupplyFunding;
        private System.Windows.Forms.Label lblSupplyFunding;
        private System.Windows.Forms.ComboBox cboSupplyName;
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tbpTracking;
        private System.Windows.Forms.DataGridView dgvTimeLogRequests;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmInstrument;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFundingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmApprove;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.FolderBrowserDialog InvoiceExportPath;
        private System.Windows.Forms.TabPage tbpSettings;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
    }
}

