namespace CUITAdmin
{
    partial class UserAccountsForm
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
            this.dgvAllAccounts = new System.Windows.Forms.DataGridView();
            this.dgvUserAccounts = new System.Windows.Forms.DataGridView();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblAllAccounts = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserAccounts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAllAccounts
            // 
            this.dgvAllAccounts.AllowUserToAddRows = false;
            this.dgvAllAccounts.AllowUserToDeleteRows = false;
            this.dgvAllAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllAccounts.Location = new System.Drawing.Point(12, 54);
            this.dgvAllAccounts.Name = "dgvAllAccounts";
            this.dgvAllAccounts.ReadOnly = true;
            this.dgvAllAccounts.Size = new System.Drawing.Size(240, 150);
            this.dgvAllAccounts.TabIndex = 0;
            // 
            // dgvUserAccounts
            // 
            this.dgvUserAccounts.AllowUserToAddRows = false;
            this.dgvUserAccounts.AllowUserToDeleteRows = false;
            this.dgvUserAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserAccounts.Location = new System.Drawing.Point(301, 54);
            this.dgvUserAccounts.Name = "dgvUserAccounts";
            this.dgvUserAccounts.ReadOnly = true;
            this.dgvUserAccounts.Size = new System.Drawing.Size(240, 150);
            this.dgvUserAccounts.TabIndex = 3;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(466, 210);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblAllAccounts
            // 
            this.lblAllAccounts.AutoSize = true;
            this.lblAllAccounts.Location = new System.Drawing.Point(13, 35);
            this.lblAllAccounts.Name = "lblAllAccounts";
            this.lblAllAccounts.Size = new System.Drawing.Size(66, 13);
            this.lblAllAccounts.TabIndex = 5;
            this.lblAllAccounts.Text = "All Accounts";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Accounts with User Access";
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Location = new System.Drawing.Point(9, 9);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(487, 13);
            this.lblInstructions.TabIndex = 9;
            this.lblInstructions.Text = "Click on the button to the left of the Account Number to move the account from on" +
    "e table to the other.";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(259, 91);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(36, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "-->";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(258, 139);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(36, 23);
            this.btnRemove.TabIndex = 11;
            this.btnRemove.Text = "<--";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // UserAccountsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 241);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAllAccounts);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.dgvUserAccounts);
            this.Controls.Add(this.dgvAllAccounts);
            this.Name = "UserAccountsForm";
            this.Text = "User Accounts";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllAccounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserAccounts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAllAccounts;
        private System.Windows.Forms.DataGridView dgvUserAccounts;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblAllAccounts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
    }
}