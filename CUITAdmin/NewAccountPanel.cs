using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Data;

namespace CUITAdmin
{
    class NewAccountPanel : Panel
    {
        NewEntryForm containingForm;
        TextBox txtAccountName = new TextBox();
        TextBox txtAccountNumber = new TextBox();
        TextBox txtMaxCharge = new TextBox();
        ComboBox cboRateType = new ComboBox();
        ComboBox cboContacts = new ComboBox();
        TextBox txtBalance = new TextBox();
        TextBox txtCostCenter = new TextBox();
        TextBox txtWBSNumber = new TextBox();
        TextBox txtZipCode = new TextBox();
        ComboBox cboState = new ComboBox();
        TextBox txtCity = new TextBox();
        TextBox txtStreet = new TextBox();
        TextBox txtTaxID = new TextBox();
        Label lblAccountName = new Label();
        Label lblAccountNumber = new Label();
        Label lblMaxCharge = new Label();
        Label lblZipCode = new Label();
        Label lblState = new Label();
        Label lblCity = new Label();
        Label lblStreet = new Label();
        Label lblAccountExpiration = new Label();
        Label lblContacts = new Label();
        DateTimePicker dtpAccountExpiration = new DateTimePicker();
        Label lblRateType = new Label();
        Label lblBalance = new Label();
        Label lblNotes = new Label();
        Label lblCostCenter = new Label();
        Label lblWBSNumber = new Label();
        Label lblTaxID = new Label();
        RichTextBox rtbNotes = new RichTextBox();
        Button btnSubmit = new Button();
        Button btnNewContact = new Button();
        DBManager dbManager;

        public NewAccountPanel(NewEntryForm pForm)
        {
            dbManager = DBManager.Instance;
            containingForm = pForm;
            pForm.Controls.Add(this);
            this.SetBounds(10, 10, 680, 380);

            //Label lblAccountName = new Label();
            lblAccountName.Text = "Account Name:";
            lblAccountName.Location = new Point(10, 10);
            this.Controls.Add(lblAccountName);

            //TextBox txtAccountName = new TextBox();
            txtAccountName.SetBounds(110, 10, 200, 20);
            this.Controls.Add(txtAccountName);
            txtAccountName.TabIndex = 0;
            //Label lblAccountNumber = new Label();
            lblAccountNumber.Text = "Account Number:";
            lblAccountNumber.Location = new Point(10, 40);
            this.Controls.Add(lblAccountNumber);

            //TextBox txtAccountNumber = new TextBox();
            txtAccountNumber.SetBounds(110, 40, 200, 20);
            this.Controls.Add(txtAccountNumber);

            //Label lblMaxCharge = new Label();
            lblMaxCharge.Text = "Max Charge Limit:";
            lblMaxCharge.Location = new Point(10, 70);
            this.Controls.Add(lblMaxCharge);

            //TextBox txtMaxCharge = new TextBox();
            txtMaxCharge.SetBounds(110, 70, 200, 20);
            this.Controls.Add(txtMaxCharge);

            //Label lblAccountExpiration = new Label();
            lblAccountExpiration.Text = "Account Expiration:";
            lblAccountExpiration.Location = new Point(10, 130);
            this.Controls.Add(lblAccountExpiration);

            //DateTimePicker dtpAccountExpiration = new DateTimePicker();
            dtpAccountExpiration.Location = new Point(110, 130);
            this.Controls.Add(dtpAccountExpiration);

            //Label lblZipCode = new Label();
            this.Controls.Add(this.lblZipCode);
            lblZipCode.Text = "Zip Code:";
            lblZipCode.Location = new Point(10, 250);

            //TextBox txtZipCode = new TextBox();
            this.Controls.Add(this.txtZipCode);
            txtZipCode.SetBounds(110, 250, 200, 20);

            //Label lblState = new Label();
            this.Controls.Add(this.lblState);
            lblState.Text = "State:";
            lblState.Location = new Point(10, 220);

            //ComboBox cboState = new ComboBox();
            this.Controls.Add(this.cboState);
            this.cboState.Location = new Point(110, 220);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(200, 20);
            List<string> states = new List<string> { "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Delaware", "Florida", "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana", "Maine", "Maryland", "Massachusetts", "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota", "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota", "Tennessee", "Texas", "Utah", "Vermont", "Virginia", "Washington", "West Virginia", "Wisconsin", "Wyoming" };
            foreach (string s in states)
            {
                cboState.Items.Add(s);
            }
            this.cboState.SelectedItem = "Pennsylvania";
            this.cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            //Label lblCity = new Label();
            this.Controls.Add(this.lblCity);
            lblCity.Text = "City:";
            lblCity.Location = new Point(10, 190);

            //TextBox txtCity = new TextBox();
            this.Controls.Add(this.txtCity);
            txtCity.SetBounds(110, 190, 200, 20);

            //Label lblStreet = new Label();
            this.Controls.Add(this.lblStreet);
            lblStreet.Text = "Street:";
            lblStreet.Location = new Point(10, 160);

            //TextBox txtStreet = new TextBox();
            this.Controls.Add(this.txtStreet);
            txtStreet.SetBounds(110, 160, 200, 20);

            //Label lblRateType = new Label();
            lblRateType.Text = "Rate Type:";
            lblRateType.Location = new Point(325, 70);
            this.Controls.Add(lblRateType);

            //ComboBox cboRateType = new ComboBox();
            cboRateType.SetBounds(425, 70, 200, 20);
            this.Controls.Add(cboRateType);
            cboRateType.DataSource = dbManager.GetRateTypes();
            cboRateType.DisplayMember = "Name";
            cboRateType.SelectedIndex = 0;
            this.cboRateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            //Label lblBalance = new Label();
            lblBalance.Text = "Balance:";
            lblBalance.Location = new Point(10, 100);
            this.Controls.Add(lblBalance);

            //TextBox txtBalance = new TextBox();
            txtBalance.SetBounds(110, 100, 200, 20);
            txtBalance.Text = "0.00";
            this.Controls.Add(txtBalance);

            //Label lblContacts = new Label();
            lblContacts.Text = "Contacts:";
            lblContacts.Location = new Point(10, 280);
            this.Controls.Add(lblContacts);
            
            //ComboBox cboContacts = new ComboBox();
            cboContacts.SetBounds(110, 280, 200, 20);
            this.Controls.Add(cboContacts);
            this.cboContacts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboContacts.Click += new EventHandler(cboContact_Click);
            updateContactList();

            //Label lblCostCenter = new Label();
            lblCostCenter.Text = "Cost Center:";
            lblCostCenter.Location = new Point(325, 10);
            this.Controls.Add(lblCostCenter);

            //TextBox txtCostCenter = new TextBox();
            txtCostCenter.SetBounds(425, 10, 200, 20);
            this.Controls.Add(txtCostCenter);

            //Label lblWBSNumber = new Label();
            lblWBSNumber.Text = "WBSNumber:";
            lblWBSNumber.Location = new Point(325, 40);
            this.Controls.Add(lblWBSNumber);

            //TextBox txtWBSNumber = new TextBox();
            txtWBSNumber.SetBounds(425, 40, 200, 20);
            this.Controls.Add(txtWBSNumber);

            //Label lblTaxID = new Label();
            lblTaxID.Text = "Tax ID:";
            lblTaxID.Location = new Point(325, 100);
            this.Controls.Add(lblTaxID);

            //TextBox txtTaxID = new TextBox();
            txtTaxID.SetBounds(425, 100, 200, 20);
            this.Controls.Add(txtTaxID);

            //Label lblNotes = new Label();
            lblNotes.Text = "Notes:";
            lblNotes.Location = new Point(325, 130);
            this.Controls.Add(lblNotes);

            //RichTextBox rtbNotes = new RichTextBox();
            rtbNotes.SetBounds(425, 130, 200, 142);
            this.Controls.Add(rtbNotes);

            //Button btnSubmit = new Button();
            btnSubmit.Text = "Submit";
            btnSubmit.Location = new Point(550, 280);
            this.Controls.Add(btnSubmit);
            btnSubmit.Click += new EventHandler(this.btnSubmit_Click);

            //Button btnNewContact = new Button();
            btnNewContact.Location = new Point(315,280);
            btnNewContact.Name = "btnNewContact";
            btnNewContact.Size = new System.Drawing.Size(24, 21);
            btnNewContact.Text = "...";
            System.Windows.Forms.ToolTip tip = new ToolTip();
            tip.SetToolTip(this.btnNewContact, "Add New Contact");
            this.Controls.Add(btnNewContact);
            btnNewContact.Click += new EventHandler(this.btnNewContact_Click);

            //sets all of the tab indexes
            txtAccountName.TabIndex = 0;
            txtAccountNumber.TabIndex = 1;
            txtMaxCharge.TabIndex = 2;
            txtBalance.TabIndex = 3;
            dtpAccountExpiration.TabIndex = 4;
            txtStreet.TabIndex = 5;
            txtCity.TabIndex = 6;
            cboState.TabIndex = 7;
            txtZipCode.TabIndex = 8;
            cboContacts.TabIndex = 9;
            btnNewContact.TabIndex = 10;
            txtCostCenter.TabIndex = 11;
            txtWBSNumber.TabIndex = 12;
            cboRateType.TabIndex = 13;
            txtTaxID.TabIndex = 14;
            rtbNotes.TabIndex = 15;
            btnSubmit.TabIndex = 16;

            containingForm.AcceptButton = btnSubmit;
        }

        private void updateContactList()
        {
            BindingList<Data> comboItems = new BindingList<Data>();
            DataTable table = dbManager.GetContacts();
            DataTableReader myReader = table.CreateDataReader();
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
            {
                MessageBox.Show("There were errors on the form.  Please correct them and submit again.");
            }

            else
            {
                dbManager.AddAccount(txtAccountNumber.Text, txtAccountName.Text, int.Parse(txtMaxCharge.Text), dtpAccountExpiration.Value, 
                    cboRateType.SelectedItem.ToString(), int.Parse(cboContacts.SelectedValue.ToString()), rtbNotes.Text, txtCostCenter.Text, txtWBSNumber.Text, int.Parse(txtBalance.Text),
                    txtStreet.Text, txtCity.Text, cboState.SelectedItem.ToString(), int.Parse(txtZipCode.Text));

                containingForm.Close();
            }
        }

        private bool errorCheck()
        {
            txtAccountName.BackColor = System.Drawing.Color.White;
            txtAccountNumber.BackColor = System.Drawing.Color.White;
            txtMaxCharge.BackColor = System.Drawing.Color.White;
            cboRateType.BackColor = System.Drawing.Color.White;
            txtZipCode.BackColor = System.Drawing.Color.White;
            txtCity.BackColor = System.Drawing.Color.White;
            txtStreet.BackColor = System.Drawing.Color.White;
            txtBalance.BackColor = System.Drawing.Color.White;
            txtWBSNumber.BackColor = System.Drawing.Color.White;
            txtCostCenter.BackColor = System.Drawing.Color.White;

            bool error = false;
            string namePattern = "^[A-Za-z0-9\\s-\\.]+$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtAccountName.Text, namePattern))
            {
                txtAccountName.BackColor = System.Drawing.Color.Red;
                error = true;
            }

            string numberPattern = "^[\\w\\W]+$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtAccountNumber.Text, numberPattern))
            {
                txtAccountNumber.BackColor = System.Drawing.Color.Red;
                error = true;
            }

            string chargePattern = "^\\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtMaxCharge.Text, chargePattern))
            {
                txtMaxCharge.BackColor = System.Drawing.Color.Red;
                error = true;
            }

            if (cboRateType.SelectedIndex == 0)
            {
                lblRateType.BackColor = System.Drawing.Color.Red;
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

            string balancePattern = "^\\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtBalance.Text, balancePattern))
            {
                txtBalance.BackColor = System.Drawing.Color.Red;
                error = true;
            }

            return error;
        }

        private void btnNewContact_Click(object sender, EventArgs e)
        {
            NewEntryForm newContact = new NewEntryForm("Point of Contact");
            newContact.ShowDialog();
        }
    }
}
