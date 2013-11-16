using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Data;


namespace CUITAdmin
{
    public class NewUserPanel : Panel
    {
        string mode;
        int userID;
        Button btnSubmit = new Button();
        Button btnNewContact = new Button();
        Button btnUserAccounts = new Button();
        ComboBox cboContacts = new ComboBox();
        RichTextBox rtbNotes = new RichTextBox();
        TextBox txtPhone = new TextBox();
        TextBox txtZipCode = new TextBox();
        ComboBox cboState = new ComboBox();
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
        DataTable userAccounts = new DataTable();
        NewEntryForm containingForm;
        DBManager dbManager;
<<<<<<< HEAD
        DataRow user;
        bool[] userAccountAllowed;
        string acctNum;
=======

        bool userAccountsAdded = false;
>>>>>>> shane
        
        public NewUserPanel(NewEntryForm pForm)
            :this(pForm, "add") { }

        public NewUserPanel(NewEntryForm pForm, int userID)
            : this(pForm, "edit") {
            this.userID = userID;
            populateControls();
        }

        private NewUserPanel(NewEntryForm pForm, string mode) {
            dbManager = DBManager.Instance;
            containingForm = pForm;
            pForm.Controls.Add(this);
            this.Location = new Point(10, 10);
            this.Size = new Size(650, 400);

            addControls();
            containingForm.AcceptButton = btnSubmit;
            this.mode = mode;
        }

        private void populateControls() {
            user = dbManager.GetUser(userID).Rows[0];

            txtFirstName.Text = user["First_Name"].ToString();
            txtLastName.Text = user["Last_Name"].ToString();
            txtUsername.Text = user["Username"].ToString();

            for (int i = 0; i < cboContacts.Items.Count; i++ ) {
                cboContacts.SelectedIndex = i;
                if (cboContacts.SelectedValue.ToString() == user["ContactID"].ToString()) {
                    break;
                }
            }

            rtbNotes.Text = user["Notes"].ToString();
            txtPhone.Text = user["Phone_Number"].ToString();
            txtZipCode.Text = user["Zip"].ToString();
            cboState.Text = user["State"].ToString();
            txtCity.Text = user["City"].ToString();
            txtStreet.Text = user["Street"].ToString();
            txtEmail.Text = user["Email"].ToString();
            txtDepartment.Text = user["Department"].ToString();

        }

        public void setUserAccountsTable(DataTable table)
        {
            userAccounts = table;
            if (userAccounts.Rows.Count >= 1)
                userAccountsAdded = true;
            else
                userAccountsAdded = false;
        }

        private void addControls()
        {
            this.Controls.Add(this.btnUserAccounts);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnNewContact);
            this.Controls.Add(this.cboContacts);
            this.Controls.Add(this.rtbNotes);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtZipCode);
            this.Controls.Add(this.cboState);
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
            this.Size = new System.Drawing.Size(526, 750);
            this.TabIndex = 0;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(420, 250);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(85, 23);
            this.btnSubmit.TabIndex = 27;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new EventHandler(this.btnSubmit_Click);
            //
            // btnUserAccounts
            //
            this.btnUserAccounts.Location = new System.Drawing.Point(310, 250);
            this.btnUserAccounts.Name = "btnUserAccounts";
            this.btnUserAccounts.Size = new System.Drawing.Size(100, 23);
            this.btnUserAccounts.TabIndex = 26;
            this.btnUserAccounts.Text = "Account Access";
            this.btnUserAccounts.UseVisualStyleBackColor = true;
            this.btnUserAccounts.Click += new EventHandler(this.btnUserAccounts_Click);
            // 
            // btnNewContact
            // 
            this.btnNewContact.Location = new System.Drawing.Point(248, 219);
            this.btnNewContact.Name = "btnNewContact";
            this.btnNewContact.Size = new System.Drawing.Size(24, 21);
            this.btnNewContact.TabIndex = 22;
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
            this.cboContacts.TabIndex = 21;
            this.cboContacts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboContacts.Click += new EventHandler(cboContact_Click);
            updateContactList();
            // 
            // rtbNotes
            // 
            this.rtbNotes.Location = new System.Drawing.Point(285, 113);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(220, 128);
            this.rtbNotes.TabIndex = 26;
            this.rtbNotes.Text = "";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(358, 58);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(147, 20);
            this.txtPhone.TabIndex = 25;
            // 
            // txtZipCode
            // 
            this.txtZipCode.Location = new System.Drawing.Point(108, 193);
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(134, 20);
            this.txtZipCode.TabIndex = 20;
            // 
            // cboState
            // 
            this.cboState.Location = new System.Drawing.Point(108, 166);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(134, 20);
            this.cboState.TabIndex = 19;
            List<string> states = new List<string>{"Alabama",  "Alaska",  "Arizona",  "Arkansas",  "California",  "Colorado",  "Connecticut",  "Delaware",  "Florida",  "Georgia",  "Hawaii",  "Idaho",  "Illinois",  "Indiana",  "Iowa",  "Kansas",  "Kentucky",  "Louisiana",  "Maine",  "Maryland",  "Massachusetts",  "Michigan",  "Minnesota",  "Mississippi",  "Missouri",  "Montana",  "Nebraska",  "Nevada",  "New Hampshire",  "New Jersey",  "New Mexico",  "New York",  "North Carolina",  "North Dakota",  "Ohio",  "Oklahoma",  "Oregon",  "Pennsylvania",  "Rhode Island",  "South Carolina",  "South Dakota",  "Tennessee",  "Texas",  "Utah",  "Vermont",  "Virginia",  "Washington",  "West Virginia",  "Wisconsin",  "Wyoming"};
            foreach (string s in states)
            {
                cboState.Items.Add(s);
            }
            this.cboState.SelectedItem = "Pennsylvania";
            this.cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(108, 139);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(134, 20);
            this.txtCity.TabIndex = 18;
            // 
            // txtStreet
            // 
            this.txtStreet.Location = new System.Drawing.Point(108, 112);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(134, 20);
            this.txtStreet.TabIndex = 17;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(358, 31);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(147, 20);
            this.txtEmail.TabIndex = 24;
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(358, 4);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(147, 20);
            this.txtDepartment.TabIndex = 23;
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
            Random rand = new Random();
            this.txtPassword.Text = "tp" + rand.Next(1000000, 9999999);
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
            this.lblContact.TabIndex = 8;
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
            this.lblZipCode.TabIndex = 7;
            this.lblZipCode.Text = "Zip Code:";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(9, 169);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(35, 13);
            this.lblState.TabIndex = 6;
            this.lblState.Text = "State:";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(9, 142);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(27, 13);
            this.lblCity.TabIndex = 5;
            this.lblCity.Text = "City:";
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Location = new System.Drawing.Point(9, 115);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(38, 13);
            this.lblStreet.TabIndex = 4;
            this.lblStreet.Text = "Street:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(259, 34);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 8;
            this.lblEmail.Text = "Email:";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(259, 7);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(65, 13);
            this.lblDepartment.TabIndex = 7;
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

        private void updateContactList()
        {
            BindingList<Data> comboItems = new BindingList<Data>();
            DataTable table = dbManager.GetContacts();
            DataTableReader myReader = table.CreateDataReader();
            table.Rows.Add("", "");
            DataRow tempRow = table.Rows[table.Rows.Count - 1];
            table.Rows.RemoveAt(table.Rows.Count - 1);
            table.Rows.InsertAt(tempRow, 0);
            while (myReader.Read())
            {
                comboItems.Add(new Data
                {
                    Name = myReader["First_Name"] + " " + myReader["Last_Name"],
                    Value = myReader["PersonID"].ToString()
                });
            }
            cboContacts.DataSource = comboItems;
            cboContacts.DisplayMember = "Name";
            cboContacts.ValueMember = "Value";
        }

        private void cboContact_Click(object sender, EventArgs e)
        {
            updateContactList();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (errorCheck())
                MessageBox.Show("There were errors on the form or the user does not have access to any accounts.  Please correct errors and submit again.");
            else
            {
                if (mode == "add") {

                    int contactID = 0;
                    if (cboContacts.SelectedValue.ToString() != "") contactID = int.Parse(cboContacts.SelectedValue.ToString());
                    
                    int personID;

<<<<<<< HEAD
                    dbManager.AddUser(txtFirstName.Text, txtLastName.Text, txtStreet.Text, txtCity.Text, 
                        cboState.SelectedItem.ToString(), txtZipCode.Text, txtPhone.Text, txtEmail.Text, txtUsername.Text, 
                        txtPassword.Text, txtDepartment.Text, "U", rtbNotes.Text, contactID, out personID);

                    for(int i = 0; i < userAccountAllowed.Length; i++)
                    {
                        if (userAccountAllowed[i])
                        {
                            dbManager.AddUserAccount(personID, dgvAccounts.Rows[i].Cells["Account_Number"].Value.ToString());
                        }
=======
                for (int i = 0; i < userAccounts.Columns.Count; i++)
                {
                    if (userAccounts.Columns[i].ColumnName != "Account_Number")
                    {
                        userAccounts.Columns.RemoveAt(i);
>>>>>>> shane
                    }

                } else if (mode == "edit") {
                    dbManager.UpdateUser(int.Parse(user["PersonID"].ToString()), txtFirstName.Text, txtLastName.Text, txtStreet.Text, txtCity.Text,
                        cboState.Text, txtZipCode.Text, txtPhone.Text, txtEmail.Text, "", txtPassword.Text, txtDepartment.Text,
                        "", rtbNotes.Text, int.Parse(cboContacts.SelectedValue.ToString()));
                }

<<<<<<< HEAD
=======
                userAccounts.Columns.Add("PersonID", System.Type.GetType("System.Int32"));
                userAccounts.Columns[1].SetOrdinal(0);

                foreach (DataRow row in userAccounts.Rows)
                {
                    row["PersonID"] = personID;
                }

                dbManager.AddUserAccounts(userAccounts);

>>>>>>> shane
                containingForm.updateAdminDGV();
                containingForm.Close();
            }
        }

        private bool errorCheck()
        {
            txtPhone.BackColor = System.Drawing.Color.White;
            txtZipCode.BackColor = System.Drawing.Color.White;
            txtCity.BackColor = System.Drawing.Color.White;
            txtStreet.BackColor = System.Drawing.Color.White;
            txtEmail.BackColor = System.Drawing.Color.White;
            txtDepartment.BackColor = System.Drawing.Color.White;
            txtLastName.BackColor = System.Drawing.Color.White;
            txtFirstName.BackColor = System.Drawing.Color.White;
            txtPassword.BackColor = System.Drawing.Color.White;
            txtUsername.BackColor = System.Drawing.Color.White;

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

            string cityPattern = "^[A-Za-z\\s-\\.]+$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtCity.Text, cityPattern))
            {
                txtCity.BackColor = System.Drawing.Color.Red;
                error = true;
            }

            string streetPattern = "^[\\w\\s-\\.]+$";
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

            string departmentPattern = "^[\\w\\s-\\.]+$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtDepartment.Text, departmentPattern))
            {
                txtDepartment.BackColor = System.Drawing.Color.Red;
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

            string passwordPattern = "^([1-zA-Z0-1@.\\s]{5,20})$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtPassword.Text, passwordPattern))
            {
                txtPassword.BackColor = System.Drawing.Color.Red;
                error = true;
            }

            string usernamePattern = "^([1-zA-Z0-1@.]{5,20})$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtUsername.Text, usernamePattern))
            {
                txtUsername.BackColor = System.Drawing.Color.Red;
                
                error = true;
            }

            if (!dbManager.CheckUsername(txtUsername.Text))
            {
                error = true;
                MessageBox.Show("The Username you entered was already taken.  Please enter a unique Username.");
                txtUsername.Focus();
            }

            if (!userAccountsAdded)
                error = true;

            return error;
        }

        private void btnNewContact_Click(object sender, EventArgs e)
        {
            NewEntryForm newContact = new NewEntryForm("Point of Contact", null);
            newContact.ShowDialog();
        }

        private void btnUserAccounts_Click(object sender, EventArgs e)
        {
            UserAccountsForm userAccounts = new UserAccountsForm(this, txtUsername.Text);
            userAccounts.ShowDialog();
        }
    }
}
