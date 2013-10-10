using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CUITAdmin
{
    public partial class NewEntryForm : Form
    {

        public NewEntryForm(string addNewCase)
        {
            InitializeComponent();
 
            switch (addNewCase)
            {
                case "Account":
                    NewAccountPanel myAcctForm = new NewAccountPanel(this);
                    this.SetBounds(350, 350, 680, 300);
                    this.Text = "New Account Form";
                    break;

                case "Account Manager":
                    NewAccountAdminPanel myAcctAdminForm = new NewAccountAdminPanel(this);
                    this.SetBounds(350, 350, 360, 340);
                    this.Text = "New Manager Form";
                    break;

                case "Instrument":
                    NewInstrumentPanel myInstrumentForm = new NewInstrumentPanel(this);
                    this.SetBounds(350, 350, 340, 300);
                    this.Text = "New Instrument Form";
                    break;

                case "Supply":
                    NewSupplyPanel mySupplyForm = new NewSupplyPanel(this);
                    this.SetBounds(350, 350, 270, 250);
                    this.Text = "New Supply Form";
                    break;

                case "User":
                    NewUserPanel myUserPanel = new NewUserPanel(this);
                    this.SetBounds(350, 350, 555, 300);
                    this.Text = "New User Form";
                    break;

                case "User Contact":
                    NewUserContactPanel myUserContactPanel = new NewUserContactPanel(this);
                    this.SetBounds(350, 350, 555, 250);
                    this.Text = "New User Contact Form";
                    break;
            }
            
        }

        private void NewEntryForm_Load(object sender, EventArgs e)
        {

        }
    }
}
