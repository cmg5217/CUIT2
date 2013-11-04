namespace CUITAdmin {
    partial class Form1 {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 673);
            this.Controls.Add(this.tabControlMain);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tbpBilling.ResumeLayout(false);
            this.grpTimeLogExceptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeLogRequests)).EndInit();
            this.grpManualEntries.ResumeLayout(false);
            this.grpManualTimeLog.ResumeLayout(false);
            this.grpManualTimeLog.PerformLayout();
            this.grpManualSupplies.ResumeLayout(false);
            this.grpManualSupplies.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

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

    }
}