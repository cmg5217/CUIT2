﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;


namespace CUITAdmin
{
    class NewUserPanel : Panel
    {
        Button btnSubmit = new Button();
        Button btnNewContact = new Button();
        ComboBox cboContacts = new ComboBox();
        RichTextBox rtbNotes = new RichTextBox();
        TextBox txtPhone = new TextBox();
        TextBox txtZipCode = new TextBox();
        TextBox txtState = new TextBox();
        TextBox txtCity = new TextBox();
        TextBox txtStreet = new TextBox();
        TextBox txtEmail = new TextBox();
        TextBox txtDepartment = new TextBox();
        TextBox txtLastName = new TextBox();
        TextBox txtFirstName = new TextBox();
        TextBox txtPassword = new TextBox();
        TextBox txtUsername = new TextBox();
        Label lblContact = new Label();
        Label lblNotes = new Label();
        Label lblPhone = new Label();
        Label lblZipCode = new Label();
        Label lblState = new Label();
        Label lblCity = new Label();
        Label lblStreet = new Label();
        Label lblEmail = new Label();
        Label lblDepartment = new Label();
        Label lblLastName = new Label();
        Label lblFirstName = new Label();
        Label lblPassword = new Label();
        Label lblUsername = new Label();
        NewEntryForm containingForm;
        
        public NewUserPanel(NewEntryForm pForm)
        {
            containingForm = pForm;
            pForm.Controls.Add(this);
            this.Location = new Point(10, 10);
            this.Size = new Size(650, 400);

            addControls();
        }

        private void addControls()
        {
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnNewContact);
            this.Controls.Add(this.cboContacts);
            this.Controls.Add(this.rtbNotes);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtZipCode);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtStreet);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblZipCode);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblStreet);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Location = new System.Drawing.Point(3, 2);
            this.Name = "pnlNewUser";
            this.Size = new System.Drawing.Size(526, 250);
            this.TabIndex = 0;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(430, 218);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 27;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new EventHandler(this.btnSubmit_Click);
            // 
            // btnNewContact
            // 
            this.btnNewContact.Location = new System.Drawing.Point(248, 219);
            this.btnNewContact.Name = "btnNewContact";
            this.btnNewContact.Size = new System.Drawing.Size(24, 21);
            this.btnNewContact.TabIndex = 26;
            this.btnNewContact.Text = "...";
            System.Windows.Forms.ToolTip tip = new ToolTip();
            tip.SetToolTip(this.btnNewContact, "Add New Contact");
            this.btnNewContact.UseVisualStyleBackColor = true;
            this.btnNewContact.Click += new EventHandler(this.btnNewContact_Click);
            // 
            // cboContacts
            // 
            this.cboContacts.FormattingEnabled = true;
            this.cboContacts.Location = new System.Drawing.Point(108, 219);
            this.cboContacts.Name = "cboContacts";
            this.cboContacts.Size = new System.Drawing.Size(134, 21);
            this.cboContacts.TabIndex = 25;
            // 
            // rtbNotes
            // 
            this.rtbNotes.Location = new System.Drawing.Point(303, 85);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(202, 130);
            this.rtbNotes.TabIndex = 24;
            this.rtbNotes.Text = "";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(358, 58);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(147, 20);
            this.txtPhone.TabIndex = 23;
            // 
            // txtZipCode
            // 
            this.txtZipCode.Location = new System.Drawing.Point(108, 193);
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(134, 20);
            this.txtZipCode.TabIndex = 22;
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(108, 166);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(134, 20);
            this.txtState.TabIndex = 21;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(108, 139);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(134, 20);
            this.txtCity.TabIndex = 20;
            // 
            // txtStreet
            // 
            this.txtStreet.Location = new System.Drawing.Point(108, 112);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(134, 20);
            this.txtStreet.TabIndex = 19;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(358, 31);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(147, 20);
            this.txtEmail.TabIndex = 18;
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(358, 4);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(147, 20);
            this.txtDepartment.TabIndex = 17;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(108, 85);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(134, 20);
            this.txtLastName.TabIndex = 16;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(108, 58);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(134, 20);
            this.txtFirstName.TabIndex = 15;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(108, 31);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(134, 20);
            this.txtPassword.TabIndex = 14;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(108, 4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(134, 20);
            this.txtUsername.TabIndex = 13;
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Location = new System.Drawing.Point(9, 222);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(47, 13);
            this.lblContact.TabIndex = 12;
            this.lblContact.Text = "Contact:";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(259, 88);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(38, 13);
            this.lblNotes.TabIndex = 11;
            this.lblNotes.Text = "Notes:";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(259, 61);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(81, 13);
            this.lblPhone.TabIndex = 10;
            this.lblPhone.Text = "Phone Number:";
            // 
            // lblZipCode
            // 
            this.lblZipCode.AutoSize = true;
            this.lblZipCode.Location = new System.Drawing.Point(9, 196);
            this.lblZipCode.Name = "lblZipCode";
            this.lblZipCode.Size = new System.Drawing.Size(53, 13);
            this.lblZipCode.TabIndex = 9;
            this.lblZipCode.Text = "Zip Code:";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(9, 169);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(35, 13);
            this.lblState.TabIndex = 8;
            this.lblState.Text = "State:";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(9, 142);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(27, 13);
            this.lblCity.TabIndex = 7;
            this.lblCity.Text = "City:";
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Location = new System.Drawing.Point(9, 115);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(38, 13);
            this.lblStreet.TabIndex = 6;
            this.lblStreet.Text = "Street:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(259, 34);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "Email:";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(259, 7);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(65, 13);
            this.lblDepartment.TabIndex = 4;
            this.lblDepartment.Text = "Department:";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(9, 88);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(61, 13);
            this.lblLastName.TabIndex = 3;
            this.lblLastName.Text = "Last Name:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(9, 61);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(60, 13);
            this.lblFirstName.TabIndex = 2;
            this.lblFirstName.Text = "First Name:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(9, 34);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(9, 7);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username:";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a test");
            containingForm.Close();
        }

        private void btnNewContact_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a test");
        }
    }
}