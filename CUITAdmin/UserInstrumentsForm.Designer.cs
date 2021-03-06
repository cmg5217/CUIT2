﻿namespace CUITAdmin
{
    partial class UserInstrumentsForm
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
            this.lblInstructions = new System.Windows.Forms.Label();
            this.lblUserInstruments = new System.Windows.Forms.Label();
            this.lblAllInstruments = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.dgvUserInstruments = new System.Windows.Forms.DataGridView();
            this.dgvAllInstruments = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserInstruments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllInstruments)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Location = new System.Drawing.Point(12, 9);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(485, 13);
            this.lblInstructions.TabIndex = 25;
            this.lblInstructions.Text = "Click on the button to the left of the Instrument row to move the instrument from" +
    " one table to the other.";
            // 
            // lblUserInstruments
            // 
            this.lblUserInstruments.AutoSize = true;
            this.lblUserInstruments.Location = new System.Drawing.Point(301, 35);
            this.lblUserInstruments.Name = "lblUserInstruments";
            this.lblUserInstruments.Size = new System.Drawing.Size(146, 13);
            this.lblUserInstruments.TabIndex = 22;
            this.lblUserInstruments.Text = "Instruments with User Access";
            // 
            // lblAllInstruments
            // 
            this.lblAllInstruments.AutoSize = true;
            this.lblAllInstruments.Location = new System.Drawing.Point(16, 35);
            this.lblAllInstruments.Name = "lblAllInstruments";
            this.lblAllInstruments.Size = new System.Drawing.Size(75, 13);
            this.lblAllInstruments.TabIndex = 21;
            this.lblAllInstruments.Text = "All Instruments";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(469, 210);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 20;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // dgvUserInstruments
            // 
            this.dgvUserInstruments.AllowUserToAddRows = false;
            this.dgvUserInstruments.AllowUserToDeleteRows = false;
            this.dgvUserInstruments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserInstruments.Location = new System.Drawing.Point(304, 54);
            this.dgvUserInstruments.Name = "dgvUserInstruments";
            this.dgvUserInstruments.ReadOnly = true;
            this.dgvUserInstruments.Size = new System.Drawing.Size(240, 150);
            this.dgvUserInstruments.TabIndex = 19;
            // 
            // dgvAllInstruments
            // 
            this.dgvAllInstruments.AllowUserToAddRows = false;
            this.dgvAllInstruments.AllowUserToDeleteRows = false;
            this.dgvAllInstruments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllInstruments.Location = new System.Drawing.Point(15, 54);
            this.dgvAllInstruments.Name = "dgvAllInstruments";
            this.dgvAllInstruments.ReadOnly = true;
            this.dgvAllInstruments.Size = new System.Drawing.Size(240, 150);
            this.dgvAllInstruments.TabIndex = 18;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(262, 95);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(36, 23);
            this.btnAdd.TabIndex = 26;
            this.btnAdd.Text = "-->";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(262, 140);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(36, 23);
            this.btnRemove.TabIndex = 27;
            this.btnRemove.Text = "<--";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // UserInstrumentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 242);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.lblUserInstruments);
            this.Controls.Add(this.lblAllInstruments);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.dgvUserInstruments);
            this.Controls.Add(this.dgvAllInstruments);
            this.Name = "UserInstrumentsForm";
            this.Text = "User Instruments";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserInstruments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllInstruments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Label lblUserInstruments;
        private System.Windows.Forms.Label lblAllInstruments;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DataGridView dgvUserInstruments;
        private System.Windows.Forms.DataGridView dgvAllInstruments;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
    }
}