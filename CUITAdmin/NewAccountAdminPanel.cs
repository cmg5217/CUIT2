using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CUITAdmin
{
    class NewAccountAdminPanel : Panel
    {
        NewEntryForm containingForm;
        Label lblFirstName = new Label();
        TextBox txtFirstName = new TextBox();
        Label lblLastName = new Label();
        TextBox txtLastName = new TextBox();
        Label lblEmail = new Label();
        TextBox txtEmail = new TextBox();
        Label lblPhone = new Label();
        TextBox txtPhone = new TextBox();
        Label lblStreet = new Label();
        TextBox txtStreet = new TextBox();
        Label lblCity = new Label();
        TextBox txtCity = new TextBox();
        Label lblState = new Label();
        ComboBox cboState = new ComboBox();
        Label lblZipCode = new Label();
        TextBox txtZipCode = new TextBox();
        Button btnSubmit = new Button();

        public NewAccountAdminPanel(NewEntryForm pForm)
        {
            containingForm = pForm;
            pForm.Controls.Add(this);
            this.Location = new Point(10, 10);
            this.Size = new Size(650, 400);

            //Label lblFirstName = new Label();
            lblFirstName.Text = "First Name:";
            lblFirstName.Location = new Point(10, 10);
            this.Controls.Add(lblFirstName);

            //TextBox txtFirstName = new TextBox();
            txtFirstName.SetBounds(110, 10, 200, 20);
            this.Controls.Add(txtFirstName);

            //Label lblLastName = new Label();
            lblLastName.Text = "Last Name:";
            lblLastName.Location = new Point(10, 40);
            this.Controls.Add(lblLastName);

            //TextBox txtLastName = new TextBox();
            txtLastName.SetBounds(110, 40, 200, 20);
            this.Controls.Add(txtLastName);

            //Label lblEmail = new Label();
            lblEmail.Text = "Email:";
            lblEmail.Location = new Point(10, 70);
            this.Controls.Add(lblEmail);

            //TextBox txtEmail = new TextBox();
            txtEmail.SetBounds(110, 70, 200, 20);
            this.Controls.Add(txtEmail);

            //Label lblPhone = new Label();
            lblPhone.Text = "Phone Number:";
            lblPhone.Location = new Point(10, 100);
            this.Controls.Add(lblPhone);

            //TextBox txtPhone = new TextBox();
            txtPhone.SetBounds(110, 100, 200, 20);
            this.Controls.Add(txtPhone);

            //Label lblStreet = new Label();
            lblStreet.Text = "Street:";
            lblStreet.Location = new Point(10, 130);
            this.Controls.Add(lblStreet);

            //TextBox txtStreet = new TextBox();
            txtStreet.SetBounds(110, 130, 200, 20);
            this.Controls.Add(txtStreet);

            //Label lblCity = new Label();
            lblCity.Text = "City:";
            lblCity.Location = new Point(10, 160);
            this.Controls.Add(lblCity);

            //TextBox txtCity = new TextBox();
            txtCity.SetBounds(110, 160, 200, 20);
            this.Controls.Add(txtCity);

            //Label lblState = new Label();
            lblState.Text = "State:";
            lblState.Location = new Point(10, 190);
            this.Controls.Add(lblState);

            //TextBox txtState = new TextBox();
            cboState.SetBounds(110, 190, 200, 20);
            this.Controls.Add(cboState);
            List<string> states = new List<string> { "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Delaware", "Florida", "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana", "Maine", "Maryland", "Massachusetts", "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New", "Hampshire", "New", "Jersey", "New", "Mexico", "New", "York", "North", "Carolina", "North", "Dakota", "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Rhode", "Island", "South", "Carolina", "South", "Dakota", "Tennessee", "Texas", "Utah", "Vermont", "Virginia", "Washington", "West", "Virginia", "Wisconsin", "Wyoming" };
            foreach (string s in states)
            {
                cboState.Items.Add(s);
            }
            cboState.SelectedItem = "Pennsylvania";

            //Label lblZipCode = new Label();
            lblZipCode.Text = "Zip Code:";
            lblZipCode.Location = new Point(10, 220);
            this.Controls.Add(lblZipCode);

            //TextBox txtZipCode = new TextBox();
            txtZipCode.SetBounds(110, 220, 200, 20);
            this.Controls.Add(txtZipCode);

            //Button btnSubmit = new Button();
            btnSubmit.Text = "Submit";
            btnSubmit.Location = new Point(230, 250);
            this.Controls.Add(btnSubmit);
            btnSubmit.Click += new EventHandler(this.btnSubmit_Click);

            containingForm.AcceptButton = btnSubmit;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            txtFirstName.BackColor = System.Drawing.Color.White;
            txtLastName.BackColor = System.Drawing.Color.White;
            txtEmail.BackColor = System.Drawing.Color.White;
            txtPhone.BackColor = System.Drawing.Color.White;
            txtStreet.BackColor = System.Drawing.Color.White;
            txtCity.BackColor = System.Drawing.Color.White;
            cboState.BackColor = System.Drawing.Color.White;
            txtZipCode.BackColor = System.Drawing.Color.White;

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

            if (error == true)
                MessageBox.Show("There were errors on the form.  Please correct them and submit again.");
            else
            {
                //this is for testing and will be deleted and changed
                MessageBox.Show("There were no errors. Form submitted.");
                containingForm.Close();
            }
        }
    }
}
