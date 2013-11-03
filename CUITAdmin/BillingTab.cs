using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CUITAdmin {
    class BillingTab : TabPage {

        private void InitializeComponents() {

            this.grpTimeLogExceptions = new System.Windows.Forms.GroupBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.dgvTimeLogRequests = new System.Windows.Forms.DataGridView();
            this.clmApprove = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFundingSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmInstrument = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpManualEntries = new System.Windows.Forms.GroupBox();
            this.grpManualTimeLog = new System.Windows.Forms.GroupBox();
            this.lblManualLogFunding = new System.Windows.Forms.Label();
            this.lblManualLogDuration = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtManualLogDuration = new System.Windows.Forms.TextBox();
            this.cboManualLogFunding = new System.Windows.Forms.ComboBox();
            this.cboManualLogUser = new System.Windows.Forms.ComboBox();
            this.cboManualLogInstrument = new System.Windows.Forms.ComboBox();
            this.lblManualLogUser = new System.Windows.Forms.Label();
            this.lblManualLogInstrument = new System.Windows.Forms.Label();
            this.dtpManualLog = new System.Windows.Forms.DateTimePicker();
            this.grpManualSupplies = new System.Windows.Forms.GroupBox();
            this.lblSupplyName = new System.Windows.Forms.Label();
            this.cboSupplyName = new System.Windows.Forms.ComboBox();
            this.lblSupplyFunding = new System.Windows.Forms.Label();
            this.cboSupplyFunding = new System.Windows.Forms.ComboBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtSupplyQuantity = new System.Windows.Forms.TextBox();
            this.btnSupplyAdd = new System.Windows.Forms.Button();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tbpBilling.SuspendLayout();
            this.grpTimeLogExceptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeLogRequests)).BeginInit();
            this.grpManualEntries.SuspendLayout();
            this.grpManualTimeLog.SuspendLayout();
            this.grpManualSupplies.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.SuspendLayout();

            #region Set TablePage Properties
            this.AutoScroll = true;
            this.Controls.Add(this.grpManualEntries);
            this.Controls.Add(this.grpTimeLogExceptions);
            this.Location = new System.Drawing.Point(4, 22);
            this.Name = "tbpBilling";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(683, 589);
            this.TabIndex = 0;
            this.Text = "Billing";
            this.UseVisualStyleBackColor = true;
            #endregion

            #region
            this.grpTimeLogExceptions.Controls.Add(this.dgvTimeLogRequests);
            this.grpTimeLogExceptions.Controls.Add(this.btnSubmit);
            this.grpTimeLogExceptions.Location = new System.Drawing.Point(6, 232);
            this.grpTimeLogExceptions.Name = "grpTimeLogExceptions";
            this.grpTimeLogExceptions.Size = new System.Drawing.Size(671, 354);
            this.grpTimeLogExceptions.TabIndex = 8;
            this.grpTimeLogExceptions.TabStop = false;
            this.grpTimeLogExceptions.Text = "Time Log Requests";
            #endregion
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
            // grpManualEntries
            // 
            this.grpManualEntries.Controls.Add(this.grpManualSupplies);
            this.grpManualEntries.Controls.Add(this.grpManualTimeLog);
            this.grpManualEntries.Location = new System.Drawing.Point(6, 6);
            this.grpManualEntries.Name = "grpManualEntries";
            this.grpManualEntries.Size = new System.Drawing.Size(671, 220);
            this.grpManualEntries.TabIndex = 11;
            this.grpManualEntries.TabStop = false;
            this.grpManualEntries.Text = "Manual Entries";
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
            // lblManualLogFunding
            // 
            this.lblManualLogFunding.AutoSize = true;
            this.lblManualLogFunding.Location = new System.Drawing.Point(31, 65);
            this.lblManualLogFunding.Name = "lblManualLogFunding";
            this.lblManualLogFunding.Size = new System.Drawing.Size(85, 13);
            this.lblManualLogFunding.TabIndex = 4;
            this.lblManualLogFunding.Text = "Funding Source:";
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
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(195, 144);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // txtManualLogDuration
            // 
            this.txtManualLogDuration.Location = new System.Drawing.Point(122, 146);
            this.txtManualLogDuration.Name = "txtManualLogDuration";
            this.txtManualLogDuration.Size = new System.Drawing.Size(67, 20);
            this.txtManualLogDuration.TabIndex = 12;
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
            // cboManualLogInstrument
            // 
            this.cboManualLogInstrument.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboManualLogInstrument.FormattingEnabled = true;
            this.cboManualLogInstrument.Location = new System.Drawing.Point(122, 90);
            this.cboManualLogInstrument.Name = "cboManualLogInstrument";
            this.cboManualLogInstrument.Size = new System.Drawing.Size(148, 21);
            this.cboManualLogInstrument.TabIndex = 2;
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
            // lblManualLogInstrument
            // 
            this.lblManualLogInstrument.AutoSize = true;
            this.lblManualLogInstrument.Location = new System.Drawing.Point(31, 93);
            this.lblManualLogInstrument.Name = "lblManualLogInstrument";
            this.lblManualLogInstrument.Size = new System.Drawing.Size(59, 13);
            this.lblManualLogInstrument.TabIndex = 5;
            this.lblManualLogInstrument.Text = "Instrument:";
            // 
            // dtpManualLog
            // 
            this.dtpManualLog.Location = new System.Drawing.Point(34, 118);
            this.dtpManualLog.Name = "dtpManualLog";
            this.dtpManualLog.Size = new System.Drawing.Size(236, 20);
            this.dtpManualLog.TabIndex = 3;
            // 
            // grpManualSupplies
            // 
            this.grpManualSupplies.Controls.Add(this.btnSupplyAdd);
            this.grpManualSupplies.Controls.Add(this.txtSupplyQuantity);
            this.grpManualSupplies.Controls.Add(this.lblQuantity);
            this.grpManualSupplies.Controls.Add(this.cboSupplyFunding);
            this.grpManualSupplies.Controls.Add(this.lblSupplyFunding);
            this.grpManualSupplies.Controls.Add(this.cboSupplyName);
            this.grpManualSupplies.Controls.Add(this.lblSupplyName);
            this.grpManualSupplies.Location = new System.Drawing.Point(339, 15);
            this.grpManualSupplies.Name = "grpManualSupplies";
            this.grpManualSupplies.Size = new System.Drawing.Size(326, 199);
            this.grpManualSupplies.TabIndex = 18;
            this.grpManualSupplies.TabStop = false;
            this.grpManualSupplies.Text = "Supplies";
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
            // cboSupplyName
            // 
            this.cboSupplyName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSupplyName.FormattingEnabled = true;
            this.cboSupplyName.Location = new System.Drawing.Point(126, 37);
            this.cboSupplyName.Name = "cboSupplyName";
            this.cboSupplyName.Size = new System.Drawing.Size(148, 21);
            this.cboSupplyName.TabIndex = 5;
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
            // cboSupplyFunding
            // 
            this.cboSupplyFunding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSupplyFunding.FormattingEnabled = true;
            this.cboSupplyFunding.Location = new System.Drawing.Point(126, 63);
            this.cboSupplyFunding.Name = "cboSupplyFunding";
            this.cboSupplyFunding.Size = new System.Drawing.Size(148, 21);
            this.cboSupplyFunding.TabIndex = 7;
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
            // txtSupplyQuantity
            // 
            this.txtSupplyQuantity.Location = new System.Drawing.Point(126, 90);
            this.txtSupplyQuantity.Name = "txtSupplyQuantity";
            this.txtSupplyQuantity.Size = new System.Drawing.Size(67, 20);
            this.txtSupplyQuantity.TabIndex = 10;
            // 
            // btnSupplyAdd
            // 
            this.btnSupplyAdd.Location = new System.Drawing.Point(199, 88);
            this.btnSupplyAdd.Name = "btnSupplyAdd";
            this.btnSupplyAdd.Size = new System.Drawing.Size(75, 23);
            this.btnSupplyAdd.TabIndex = 11;
            this.btnSupplyAdd.Text = "Add";
            this.btnSupplyAdd.UseVisualStyleBackColor = true;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tbpBilling);
            this.tabControlMain.Location = new System.Drawing.Point(70, 29);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(691, 615);
            this.tabControlMain.TabIndex = 1;
        }

        #region Control Declarations
        
        private System.Windows.Forms.TabPage tbpBilling;
        private System.Windows.Forms.GroupBox grpManualEntries;
        private System.Windows.Forms.GroupBox grpManualSupplies;
        private System.Windows.Forms.Button btnSupplyAdd;
        private System.Windows.Forms.TextBox txtSupplyQuantity;
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
        private System.Windows.Forms.GroupBox grpTimeLogExceptions;
        private System.Windows.Forms.DataGridView dgvTimeLogRequests;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmInstrument;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFundingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmApprove;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TabControl tabControlMain;

        #endregion

    } // End of class
}
