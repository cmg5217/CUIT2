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

            DBManager dbManager = DBManager.Instance;

            switch (addNewCase)
            {
                case "Account":
                    NewAccountPanel myAcctForm = new NewAccountPanel(this);
                    this.SetBounds(350, 350, 680, 340);
                    this.Text = "New Account Form";
                    break;

                case "Instrument":
                    NewInstrumentPanel myInstrumentForm = new NewInstrumentPanel(this);
                    this.SetBounds(350, 350, 340, 320);
                    this.Text = "New Instrument Form";
                    break;

                case "Rate Type":
                    NewRateTypePanel myRateForm = new NewRateTypePanel(this);
                    this.SetBounds(350, 350, 300, 300);
                    this.Text = "New Rate Type Form";
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

                case "Point of Contact":
                    NewPointOfContactPanel myContactPanel = new NewPointOfContactPanel(this);
                    this.SetBounds(350, 350, 555, 250);
                    this.Text = "New Contact Form";
                    break;
            }
            
        }
    }
}
