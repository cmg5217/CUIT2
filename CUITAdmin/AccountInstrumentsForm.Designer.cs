﻿namespace CUITAdmin
{
    partial class AccountInstrumentsForm
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
            this.lblLeftArrow = new System.Windows.Forms.Label();
            this.lblRightArrow = new System.Windows.Forms.Label();
            this.lblAccountInstruments = new System.Windows.Forms.Label();
            this.lblAllInstruments = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.dgvAccountInstruments = new System.Windows.Forms.DataGridView();
            this.dgvAllInstruments = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountInstruments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllInstruments)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Location = new System.Drawing.Point(9, 9);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(485, 13);
            this.lblInstructions.TabIndex = 17;
            this.lblInstructions.Text = "Click on the button to the left of the Instrument row to move the instrument from" +
    " one table to the other.";
            // 
            // lblLeftArrow
            // 
            this.lblLeftArrow.AutoSize = true;
            this.lblLeftArrow.Location = new System.Drawing.Point(267, 138);
            this.lblLeftArrow.Name = "lblLeftArrow";
            this.lblLeftArrow.Size = new System.Drawing.Size(19, 13);
            this.lblLeftArrow.TabIndex = 16;
            this.lblLeftArrow.Text = "<--";
            // 
            // lblRightArrow
            // 
            this.lblRightArrow.AutoSize = true;
            this.lblRightArrow.Location = new System.Drawing.Point(267, 93);
            this.lblRightArrow.Name = "lblRightArrow";
            this.lblRightArrow.Size = new System.Drawing.Size(19, 13);
            this.lblRightArrow.TabIndex = 15;
            this.lblRightArrow.Text = "-->";
            // 
            // lblAccountInstruments
            // 
            this.lblAccountInstruments.AutoSize = true;
            this.lblAccountInstruments.Location = new System.Drawing.Point(298, 35);
            this.lblAccountInstruments.Name = "lblAccountInstruments";
            this.lblAccountInstruments.Size = new System.Drawing.Size(164, 13);
            this.lblAccountInstruments.TabIndex = 14;
            this.lblAccountInstruments.Text = "Instruments with Account Access";
            // 
            // lblAllInstruments
            // 
            this.lblAllInstruments.AutoSize = true;
            this.lblAllInstruments.Location = new System.Drawing.Point(13, 35);
            this.lblAllInstruments.Name = "lblAllInstruments";
            this.lblAllInstruments.Size = new System.Drawing.Size(75, 13);
            this.lblAllInstruments.TabIndex = 13;
            this.lblAllInstruments.Text = "All Instruments";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(466, 210);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 12;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // dgvAccountInstruments
            // 
            this.dgvAccountInstruments.AllowUserToAddRows = false;
            this.dgvAccountInstruments.AllowUserToDeleteRows = false;
            this.dgvAccountInstruments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccountInstruments.Location = new System.Drawing.Point(301, 54);
            this.dgvAccountInstruments.Name = "dgvAccountInstruments";
            this.dgvAccountInstruments.ReadOnly = true;
            this.dgvAccountInstruments.Size = new System.Drawing.Size(240, 150);
            this.dgvAccountInstruments.TabIndex = 11;
            // 
            // dgvAllInstruments
            // 
            this.dgvAllInstruments.AllowUserToAddRows = false;
            this.dgvAllInstruments.AllowUserToDeleteRows = false;
            this.dgvAllInstruments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllInstruments.Location = new System.Drawing.Point(12, 54);
            this.dgvAllInstruments.Name = "dgvAllInstruments";
            this.dgvAllInstruments.ReadOnly = true;
            this.dgvAllInstruments.Size = new System.Drawing.Size(240, 150);
            this.dgvAllInstruments.TabIndex = 10;
            // 
            // InstrumentAccessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 241);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.lblLeftArrow);
            this.Controls.Add(this.lblRightArrow);
            this.Controls.Add(this.lblAccountInstruments);
            this.Controls.Add(this.lblAllInstruments);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.dgvAccountInstruments);
            this.Controls.Add(this.dgvAllInstruments);
            this.Name = "InstrumentAccessForm";
            this.Text = "Account Instruments";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountInstruments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllInstruments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Label lblLeftArrow;
        private System.Windows.Forms.Label lblRightArrow;
        private System.Windows.Forms.Label lblAccountInstruments;
        private System.Windows.Forms.Label lblAllInstruments;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DataGridView dgvAccountInstruments;
        private System.Windows.Forms.DataGridView dgvAllInstruments;
    }
}