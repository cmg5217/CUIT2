namespace CUITAdmin
{
    partial class SelectGrant
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
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblGrant = new System.Windows.Forms.Label();
            this.txtTest = new System.Windows.Forms.ComboBox();
            this.grantsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.secondaryLoginDataSet = new CUITAdmin.SecondaryLoginDataSet();
            this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usersTableAdapter = new CUITAdmin.SecondaryLoginDataSetTableAdapters.UsersTableAdapter();
            this.grantsTableAdapter = new CUITAdmin.SecondaryLoginDataSetTableAdapters.GrantsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.grantsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondaryLoginDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSubmit.Location = new System.Drawing.Point(308, 290);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblGrant
            // 
            this.lblGrant.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGrant.AutoSize = true;
            this.lblGrant.Location = new System.Drawing.Point(286, 205);
            this.lblGrant.Name = "lblGrant";
            this.lblGrant.Size = new System.Drawing.Size(127, 13);
            this.lblGrant.TabIndex = 1;
            this.lblGrant.Text = "Please Select your Grant:";
            
            // 
            // txtTest
            // 
            this.txtTest.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTest.DataSource = this.grantsBindingSource;
            this.txtTest.DisplayMember = "GrantName";
            this.txtTest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtTest.FormattingEnabled = true;
            this.txtTest.Location = new System.Drawing.Point(289, 238);
            this.txtTest.Name = "txtTest";
            this.txtTest.Size = new System.Drawing.Size(121, 21);
            this.txtTest.TabIndex = 3;
            // 
            // grantsBindingSource
            // 
            this.grantsBindingSource.DataMember = "Grants";
            this.grantsBindingSource.DataSource = this.secondaryLoginDataSet;
            // 
            // secondaryLoginDataSet
            // 
            this.secondaryLoginDataSet.DataSetName = "SecondaryLoginDataSet";
            this.secondaryLoginDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // usersBindingSource
            // 
            this.usersBindingSource.DataMember = "Users";
            this.usersBindingSource.DataSource = this.secondaryLoginDataSet;
            // 
            // usersTableAdapter
            // 
            this.usersTableAdapter.ClearBeforeFill = true;
            // 
            // grantsTableAdapter
            // 
            this.grantsTableAdapter.ClearBeforeFill = true;
            // 
            // SelectGrant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 543);
            this.Controls.Add(this.txtTest);
            this.Controls.Add(this.lblGrant);
            this.Controls.Add(this.btnSubmit);
            this.Name = "SelectGrant";
            this.Text = "SelectGrant";
            this.Load += new System.EventHandler(this.SelectGrant_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grantsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondaryLoginDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblGrant;
        private System.Windows.Forms.ComboBox txtTest;
        private SecondaryLoginDataSet secondaryLoginDataSet;
        private System.Windows.Forms.BindingSource usersBindingSource;
        private SecondaryLoginDataSetTableAdapters.UsersTableAdapter usersTableAdapter;
        private System.Windows.Forms.BindingSource grantsBindingSource;
        private SecondaryLoginDataSetTableAdapters.GrantsTableAdapter grantsTableAdapter;









    }
}