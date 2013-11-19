using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace CUITAdmin
{
    class NewPointOfContactPanel : Panel
    {
        Button btnSubmit = new Button();
        RichTextBox rtbNotes = new RichTextBox();
        TextBox txtPhone = new TextBox();
        TextBox txtZipCode = new TextBox();
        ComboBox cboState = new ComboBox();
        TextBox txtCity = new TextBox();
        TextBox txtStreet = new TextBox();
        TextBox txtEmail = new TextBox();
        TextBox txtLastName = new TextBox();
        TextBox txtFirstName = new TextBox();
        Label lblNotes = new Label();
        Label lblPhone = new Label();
        Label lblZipCode = new Label();
        Label lblState = new Label();
        Label lblCity = new Label();
        Label lblStreet = new Label();
        Label lblEmail = new Label();
        Label lblLastName = new Label();
        Label lblFirstName = new Label();
        NewEntryForm containingForm;
        string mode = "add";
        int primaryKey;

        DBManager dbManager;

        public NewPointOfContactPanel(NewEntryForm pForm, int primaryKey)
        :this (pForm){
            this.primaryKey = primaryKey;
            mode = "edit";
            populateControls();
        }

        public NewPointOfContactPanel(NewEntryForm pForm)
        {
            dbManager = DBManager.Instance;
            containingForm = pForm;
            pForm.Controls.Add(this);
            this.Location = new Point(10, 10);
            this.Size = new Size(650, 400);

            addControls();
            containingForm.AcceptButton = btnSubmit;
        }

        private void populateControls() {
            DataTable pointOfContact = dbManager.GetPointOfContact(primaryKey);

            this.rtbNotes.Text = pointOfContact.Rows[0]["Notes"].ToString();
            this.txtPhone.Text = pointOfContact.Rows[0]["Phone_Number"].ToString();
            this.txtZipCode.Text = pointOfContact.Rows[0]["Zip"].ToString();
            this.cboState.Text = pointOfContact.Rows[0]["State"].ToString();
            this.txtCity.Text = pointOfContact.Rows[0]["City"].ToString();
            this.txtStreet.Text = pointOfContact.Rows[0]["Street"].ToString();
            this.txtEmail.Text = pointOfContact.Rows[0]["Email"].ToString();
            this.txtLastName.Text = pointOfContact.Rows[0]["Last_Name"].ToString();
            this.txtFirstName.Text = pointOfContact.Rows[0]["First_Name"].ToString();
        }

        private void addControls()
        {   
            // 
            // panel1
            // 
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.rtbNotes);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtZipCode);
            this.Controls.Add(this.cboState);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtStreet);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblZipCode);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.lblStreet);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.Location = new System.Drawing.Point(3, 2);
            this.Name = "newUserContactPanel";
            this.Size = new System.Drawing.Size(526, 209);
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(9, 16);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(60, 13);
            this.lblFirstName.TabIndex = 2;
            this.lblFirstName.Text = "First Name:";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(9, 43);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(61, 13);
            this.lblLastName.TabIndex = 3;
            this.lblLastName.Text = "Last Name:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(262, 16);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "Email:";
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Location = new System.Drawing.Point(9, 70);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(38, 13);
            this.lblStreet.TabIndex = 6;
            this.lblStreet.Text = "Street:";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(9, 97);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(27, 13);
            this.lblCity.TabIndex = 7;
            this.lblCity.Text = "City:";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(9, 124);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(35, 13);
            this.lblState.TabIndex = 8;
            this.lblState.Text = "State:";
            // 
            // lblZipCode
            // 
            this.lblZipCode.AutoSize = true;
            this.lblZipCode.Location = new System.Drawing.Point(9, 151);
            this.lblZipCode.Name = "lblZipCode";
            this.lblZipCode.Size = new System.Drawing.Size(53, 13);
            this.lblZipCode.TabIndex = 9;
            this.lblZipCode.Text = "Zip Code:";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(262, 43);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(81, 13);
            this.lblPhone.TabIndex = 10;
            this.lblPhone.Text = "Phone Number:";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(262, 70);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(38, 13);
            this.lblNotes.TabIndex = 11;
            this.lblNotes.Text = "Notes:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(108, 13);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(134, 20);
            this.txtFirstName.TabIndex = 0;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(108, 40);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(134, 20);
            this.txtLastName.TabIndex = 16;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(361, 13);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(147, 20);
            this.txtEmail.TabIndex = 23;
            // 
            // txtStreet
            // 
            this.txtStreet.Location = new System.Drawing.Point(108, 67);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(134, 20);
            this.txtStreet.TabIndex = 19;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(108, 94);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(134, 20);
            this.txtCity.TabIndex = 20;
            // 
            // txtState
            // 
            this.cboState.Location = new System.Drawing.Point(108, 121);
            this.cboState.Name = "txtState";
            this.cboState.Size = new System.Drawing.Size(134, 20);
            this.cboState.TabIndex = 21;
            List<string> states = new List<string> { "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Delaware", "Florida", "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana", "Maine", "Maryland", "Massachusetts", "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New", "Hampshire", "New", "Jersey", "New", "Mexico", "New", "York", "North", "Carolina", "North", "Dakota", "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Rhode", "Island", "South", "Carolina", "South", "Dakota", "Tennessee", "Texas", "Utah", "Vermont", "Virginia", "Washington", "West", "Virginia", "Wisconsin", "Wyoming" };
            foreach (string s in states)
            {
                cboState.Items.Add(s);
            }
            cboState.SelectedItem = "Pennsylvania";
            this.cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // 
            // txtZipCode
            // 
            this.txtZipCode.Location = new System.Drawing.Point(108, 148);
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(134, 20);
            this.txtZipCode.TabIndex = 22;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(361, 40);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(147, 20);
            this.txtPhone.TabIndex = 24;
            // 
            // rtbNotes
            // 
            this.rtbNotes.Location = new System.Drawing.Point(306, 67);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(202, 101);
            this.rtbNotes.TabIndex = 25;
            this.rtbNotes.Text = "";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(433, 174);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 27;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new EventHandler(this.btnSubmit_Click);
            
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (errorChecked())
                MessageBox.Show("There were errors on the form.  Please correct them and submit again.");
            else
            {
                if (mode == "add") {
                    dbManager.AddPointOfContact(txtFirstName.Text, txtLastName.Text, txtStreet.Text, txtCity.Text,
                        cboState.SelectedItem.ToString(), txtZipCode.Text, txtPhone.Text, txtEmail.Text, rtbNotes.Text);
                } else {
                    dbManager.UpdatePointOfContact(primaryKey, txtFirstName.Text, txtLastName.Text, txtStreet.Text, txtCity.Text,
                        cboState.SelectedItem.ToString(), txtZipCode.Text, txtPhone.Text, txtEmail.Text, rtbNotes.Text);
                }


                containingForm.updateAdminDGV();
                containingForm.Close();
            }
        }

        private Boolean errorChecked()
        {
            txtPhone.BackColor = System.Drawing.Color.White;
            txtZipCode.BackColor = System.Drawing.Color.White;
            txtCity.BackColor = System.Drawing.Color.White;
            txtStreet.BackColor = System.Drawing.Color.White;
            txtEmail.BackColor = System.Drawing.Color.White;
            txtLastName.BackColor = System.Drawing.Color.White;
            txtFirstName.BackColor = System.Drawing.Color.White;

            bool error = false;

            string phonePattern = "^\\D?(\\d{3})\\D?\\D?(\\d{3})\\D?(\\d{4})$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text, phonePattern))
            {
                txtPhone.BackColor = System.Drawing.Color.Red;
                error = true;
            }

            string zipPattern = "^([0-9]{5})\\-?([0-9]{4})?$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtZipCode.Text, zipPattern))
            {
                txtZipCode.BackColor = System.Drawing.Color.Red;
                error = true;
            }

            string cityPattern = "^[\\w\\W]+$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtCity.Text, cityPattern))
            {
                txtCity.BackColor = System.Drawing.Color.Red;
                error = true;
            }

            string streetPattern = "^[\\w\\W]+$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtStreet.Text, streetPattern))
            {
                txtStreet.BackColor = System.Drawing.Color.Red;
                error = true;
            }

            string emailPattern = "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, emailPattern))
            {
                txtEmail.BackColor = System.Drawing.Color.Red;
                error = true;
            }

            string lastnamePattern = "^[A-Za-z\\s-\\.]+$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtLastName.Text, lastnamePattern))
            {
                txtLastName.BackColor = System.Drawing.Color.Red;
                error = true;
            }

            string firstnamePattern = "^[A-Za-z\\s-\\.]+$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtFirstName.Text, firstnamePattern))
            {
                txtFirstName.BackColor = System.Drawing.Color.Red;
                error = true;
            }

            return error;
        }
    }
}
