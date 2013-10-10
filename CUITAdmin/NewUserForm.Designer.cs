namespace CUITAdmin
{
    partial class NewUserForm
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
            this.btnAddUser = new System.Windows.Forms.Button();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.lblZip = new System.Windows.Forms.Label();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.lblStreet = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.txtmail = new System.Windows.Forms.TextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblContactID = new System.Windows.Forms.Label();
            this.pnlAddUser = new System.Windows.Forms.Panel();
            this.txtContactID = new System.Windows.Forms.TextBox();
            this.lblContsactID = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.pnlAddUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(211, 302);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(163, 23);
            this.btnAddUser.TabIndex = 18;
            this.btnAddUser.Text = "Add and Close";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddContact_Click);
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(82, 226);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(208, 20);
            this.txtPhone.TabIndex = 17;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(16, 229);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(41, 13);
            this.lblPhone.TabIndex = 16;
            this.lblPhone.Text = "Phone:";
            // 
            // txtZip
            // 
            this.txtZip.Location = new System.Drawing.Point(82, 200);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(208, 20);
            this.txtZip.TabIndex = 15;
            // 
            // lblZip
            // 
            this.lblZip.AutoSize = true;
            this.lblZip.Location = new System.Drawing.Point(16, 203);
            this.lblZip.Name = "lblZip";
            this.lblZip.Size = new System.Drawing.Size(25, 13);
            this.lblZip.TabIndex = 14;
            this.lblZip.Text = "Zip:";
            // 
            // txtStreet
            // 
            this.txtStreet.Location = new System.Drawing.Point(82, 174);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(208, 20);
            this.txtStreet.TabIndex = 13;
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Location = new System.Drawing.Point(16, 177);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(38, 13);
            this.lblStreet.TabIndex = 12;
            this.lblStreet.Text = "Street:";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(82, 148);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(208, 20);
            this.txtType.TabIndex = 11;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(16, 151);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 10;
            this.lblType.Text = "Type:";
            // 
            // txtmail
            // 
            this.txtmail.Location = new System.Drawing.Point(82, 122);
            this.txtmail.Name = "txtmail";
            this.txtmail.Size = new System.Drawing.Size(208, 20);
            this.txtmail.TabIndex = 9;
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(16, 125);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(35, 13);
            this.lblMail.TabIndex = 8;
            this.lblMail.Text = "Email:";
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(82, 96);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(208, 20);
            this.txtDepartment.TabIndex = 7;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(16, 99);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(65, 13);
            this.lblDepartment.TabIndex = 6;
            this.lblDepartment.Text = "Department:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(82, 70);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(208, 20);
            this.txtFirstName.TabIndex = 5;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(16, 73);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(57, 13);
            this.lblFirstName.TabIndex = 4;
            this.lblFirstName.Text = "FirstName:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(82, 44);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(208, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(16, 47);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(82, 18);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(208, 20);
            this.txtUsername.TabIndex = 1;
            // 
            // lblContactID
            // 
            this.lblContactID.AutoSize = true;
            this.lblContactID.Location = new System.Drawing.Point(16, 21);
            this.lblContactID.Name = "lblContactID";
            this.lblContactID.Size = new System.Drawing.Size(58, 13);
            this.lblContactID.TabIndex = 0;
            this.lblContactID.Text = "Username:";
            // 
            // pnlAddUser
            // 
            this.pnlAddUser.Controls.Add(this.lblNotes);
            this.pnlAddUser.Controls.Add(this.txtNotes);
            this.pnlAddUser.Controls.Add(this.txtContactID);
            this.pnlAddUser.Controls.Add(this.lblContsactID);
            this.pnlAddUser.Controls.Add(this.btnAddUser);
            this.pnlAddUser.Controls.Add(this.txtPhone);
            this.pnlAddUser.Controls.Add(this.lblPhone);
            this.pnlAddUser.Controls.Add(this.txtZip);
            this.pnlAddUser.Controls.Add(this.lblZip);
            this.pnlAddUser.Controls.Add(this.txtStreet);
            this.pnlAddUser.Controls.Add(this.lblStreet);
            this.pnlAddUser.Controls.Add(this.txtType);
            this.pnlAddUser.Controls.Add(this.lblType);
            this.pnlAddUser.Controls.Add(this.txtmail);
            this.pnlAddUser.Controls.Add(this.lblMail);
            this.pnlAddUser.Controls.Add(this.txtDepartment);
            this.pnlAddUser.Controls.Add(this.lblDepartment);
            this.pnlAddUser.Controls.Add(this.txtFirstName);
            this.pnlAddUser.Controls.Add(this.lblFirstName);
            this.pnlAddUser.Controls.Add(this.txtPassword);
            this.pnlAddUser.Controls.Add(this.lblPassword);
            this.pnlAddUser.Controls.Add(this.txtUsername);
            this.pnlAddUser.Controls.Add(this.lblContactID);
            this.pnlAddUser.Location = new System.Drawing.Point(12, 12);
            this.pnlAddUser.Name = "pnlAddUser";
            this.pnlAddUser.Size = new System.Drawing.Size(572, 354);
            this.pnlAddUser.TabIndex = 1;
            // 
            // txtContactID
            // 
            this.txtContactID.Location = new System.Drawing.Point(82, 252);
            this.txtContactID.Name = "txtContactID";
            this.txtContactID.Size = new System.Drawing.Size(208, 20);
            this.txtContactID.TabIndex = 20;
            // 
            // lblContsactID
            // 
            this.lblContsactID.AutoSize = true;
            this.lblContsactID.Location = new System.Drawing.Point(16, 255);
            this.lblContsactID.Name = "lblContsactID";
            this.lblContsactID.Size = new System.Drawing.Size(58, 13);
            this.lblContsactID.TabIndex = 19;
            this.lblContsactID.Text = "ContactID:";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(309, 47);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(248, 225);
            this.txtNotes.TabIndex = 21;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(306, 21);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(38, 13);
            this.lblNotes.TabIndex = 22;
            this.lblNotes.Text = "Notes:";
            // 
            // NewUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 380);
            this.Controls.Add(this.pnlAddUser);
            this.Name = "NewUserForm";
            this.Text = "Add User";
            this.pnlAddUser.ResumeLayout(false);
            this.pnlAddUser.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtZip;
        private System.Windows.Forms.Label lblZip;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.Label lblStreet;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox txtmail;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblContactID;
        private System.Windows.Forms.Panel pnlAddUser;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.TextBox txtContactID;
        private System.Windows.Forms.Label lblContsactID;
    }
}