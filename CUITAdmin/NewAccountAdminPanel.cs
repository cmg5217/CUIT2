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
        public NewAccountAdminPanel(NewEntryForm pForm)
        {
            pForm.Controls.Add(this);
            this.Location = new Point(10, 10);
            this.Size = new Size(650, 400);

            Label lblFirstName = new Label();
            lblFirstName.Text = "First Name:";
            lblFirstName.Location = new Point(10, 10);
            this.Controls.Add(lblFirstName);

            TextBox txtFirstName = new TextBox();
            txtFirstName.SetBounds(110, 10, 200, 20);
            this.Controls.Add(txtFirstName);

            Label lblLastName = new Label();
            lblLastName.Text = "Last Name:";
            lblLastName.Location = new Point(10, 40);
            this.Controls.Add(lblLastName);

            TextBox txtLastName = new TextBox();
            txtLastName.SetBounds(110, 40, 200, 20);
            this.Controls.Add(txtLastName);

            Label lblEmail = new Label();
            lblEmail.Text = "Email:";
            lblEmail.Location = new Point(10, 70);
            this.Controls.Add(lblEmail);

            TextBox txtEmail = new TextBox();
            txtEmail.SetBounds(110, 70, 200, 20);
            this.Controls.Add(txtEmail);

            Label lblPhone = new Label();
            lblPhone.Text = "Phone Number:";
            lblPhone.Location = new Point(10, 100);
            this.Controls.Add(lblPhone);

            TextBox txtPhone = new TextBox();
            txtPhone.SetBounds(110, 100, 200, 20);
            this.Controls.Add(txtPhone);

            Label lblStreet = new Label();
            lblStreet.Text = "Street:";
            lblStreet.Location = new Point(10, 130);
            this.Controls.Add(lblStreet);

            TextBox txtStreet = new TextBox();
            txtStreet.SetBounds(110, 130, 200, 20);
            this.Controls.Add(txtStreet);

            Label lblCity = new Label();
            lblCity.Text = "City:";
            lblCity.Location = new Point(10, 160);
            this.Controls.Add(lblCity);

            TextBox txtCity = new TextBox();
            txtCity.SetBounds(110, 160, 200, 20);
            this.Controls.Add(txtCity);

            Label lblState = new Label();
            lblState.Text = "State:";
            lblState.Location = new Point(10, 190);
            this.Controls.Add(lblState);

            TextBox txtState = new TextBox();
            txtState.SetBounds(110, 190, 200, 20);
            this.Controls.Add(txtState);

            Label lblZipCode = new Label();
            lblZipCode.Text = "Zip Code:";
            lblZipCode.Location = new Point(10, 220);
            this.Controls.Add(lblZipCode);

            TextBox txtZipCode = new TextBox();
            txtZipCode.SetBounds(110, 220, 200, 20);
            this.Controls.Add(txtZipCode);

            Button btnSubmit = new Button();
            btnSubmit.Text = "Submit";
            btnSubmit.Location = new Point(230, 250);
            this.Controls.Add(btnSubmit);
        }
    }
}
