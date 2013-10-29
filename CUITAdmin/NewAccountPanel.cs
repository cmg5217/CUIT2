using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

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
        Label lblAccountName = new Label();
        Label lblAccountNumber = new Label();
        Label lblMaxCharge = new Label();
        Label lblAccountExpiration = new Label();
        Label lblContacts = new Label();
        DateTimePicker dtpAccountExpiration = new DateTimePicker();
        Label lblRateType = new Label();
        Label lblBalance = new Label();
        Label lblNotes = new Label();
        RichTextBox txtNotes = new RichTextBox();
        Button btnSubmit = new Button();
        Button btnNewContact = new Button();

        public NewAccountPanel(NewEntryForm pForm)
        {
            containingForm = pForm;
            pForm.Controls.Add(this);
            this.Location = new Point(10, 10);
            this.Size = new Size(650, 400);

            //Label lblAccountName = new Label();
            lblAccountName.Text = "Account Name:";
            lblAccountName.Location = new Point(10, 10);
            this.Controls.Add(lblAccountName);

            //TextBox txtAccountName = new TextBox();
            txtAccountName.SetBounds(110, 10, 200, 20);
            this.Controls.Add(txtAccountName);

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
            lblAccountExpiration.Location = new Point(10, 100);
            this.Controls.Add(lblAccountExpiration);

            //DateTimePicker dtpAccountExpiration = new DateTimePicker();
            dtpAccountExpiration.Location = new Point(110, 100);
            this.Controls.Add(dtpAccountExpiration);

            //Label lblRateType = new Label();
            lblRateType.Text = "Rate Type:";
            lblRateType.Location = new Point(10, 130);
            this.Controls.Add(lblRateType);

            //ComboBox cboRateType = new ComboBox();
            cboRateType.SetBounds(110, 130, 200, 20);
            this.Controls.Add(cboRateType);
            cboRateType.Items.Add("");
            cboRateType.Items.Add("Internal Academic");
            cboRateType.Items.Add("External Academic");
            cboRateType.Items.Add("Industry");
            cboRateType.SelectedIndex = 0;

            //Label lblBalance = new Label();
            lblBalance.Text = "Balance:";
            lblBalance.Location = new Point(10, 160);
            this.Controls.Add(lblBalance);

            //TextBox txtBalance = new TextBox();
            txtBalance.SetBounds(110, 160, 200, 20);
            this.Controls.Add(txtBalance);

            //Label lblContacts = new Label();
            lblContacts.Text = "Contacts:";
            lblContacts.Location = new Point(10, 190);
            this.Controls.Add(lblContacts);
            
            //ComboBox cboContacts = new ComboBox();
            cboContacts.SetBounds(110, 190, 200, 20);
            this.Controls.Add(cboContacts);

            //Label lblNotes = new Label();
            lblNotes.Text = "Notes:";
            lblNotes.Location = new Point(325, 10);
            this.Controls.Add(lblNotes);

            //RichTextBox txtNotes = new RichTextBox();
            txtNotes.SetBounds(325, 40, 280, 142);
            this.Controls.Add(txtNotes);

            //Button btnSubmit = new Button();
            btnSubmit.Text = "Submit";
            btnSubmit.Location = new Point(525, 190);
            this.Controls.Add(btnSubmit);
            btnSubmit.Click += new EventHandler(this.btnSubmit_Click);

            //Button btnNewContact = new Button();
            btnNewContact.Location = new Point(315,190);
            btnNewContact.Name = "btnNewContact";
            btnNewContact.Size = new System.Drawing.Size(24, 21);
            btnNewContact.Text = "...";
            System.Windows.Forms.ToolTip tip = new ToolTip();
            tip.SetToolTip(this.btnNewContact, "Add New Contact");
            this.Controls.Add(btnNewContact);
            btnNewContact.Click += new EventHandler(this.btnNewContact_Click);

            containingForm.AcceptButton = btnSubmit;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            txtAccountName.BackColor = System.Drawing.Color.White;
            txtAccountNumber.BackColor = System.Drawing.Color.White;
            txtMaxCharge.BackColor = System.Drawing.Color.White;
            cboRateType.BackColor = System.Drawing.Color.White;
            txtBalance.BackColor = System.Drawing.Color.White;

            bool error = false;
            string namePattern = "^[A-Za-z\\s-\\.]+$";
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

            if(cboRateType.SelectedIndex == 0)
            {
                cboRateType.BackColor = System.Drawing.Color.Red;
                error = true;
            }
            
            string balancePattern = "^\\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtBalance.Text, balancePattern))
            {
                txtBalance.BackColor = System.Drawing.Color.Red;
                error = true;
            }

            if (error)
            {
                MessageBox.Show("There were errors on the form.  Please correct them and submit again.");
            }

            else
            {
                MessageBox.Show("There were no errors. Form submitted.");
                containingForm.Close();
            }
            // regular expressions example
            /* ^\s*\+?\s*([0-9][\s-]*){9,}$
              ^         # Start of the string
              \s*       # Ignore leading whitespace
              \+?       # An optional plus
              \s*       # followed by an optional space or multiple spaces
              (
                 [0-9]  # A digit
                 [\s-]* # followed by an optional space or dash or more than one of those
              )
               {9,}     # That appears nine or more times
            $           # End of the string*/

            
        }

        private void btnNewContact_Click(object sender, EventArgs e)
        {
            NewEntryForm newContact = new NewEntryForm("Point of Contact");
            newContact.Show();
        }
    }
}
