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
        string primaryKey;
        
        frmCUITAdminMain containingForm;
        public NewEntryForm(string addNewCase, frmCUITAdminMain containingForm, string primaryKey = "")
        {
            this.containingForm = containingForm;
            DBManager dbManager = DBManager.Instance;

            switch (addNewCase)
            {
                case "Account":
                    NewAccountPanel myAcctForm = new NewAccountPanel(this);
                    this.SetBounds(350, 350, 680, 410);
                    this.Text = "New Account";
                    break;

                // TO-DO: actually set up the panel to edit accounts
                case "Edit Account":
                    NewAccountPanel myAcctEditForm = new NewAccountPanel(this, primaryKey);
                    this.SetBounds(350, 350, 680, 410);
                    this.Text = "New Account";
                    break;

                case "Instrument":
                    NewInstrumentPanel myInstrumentForm = new NewInstrumentPanel(this);
                    this.SetBounds(350, 350, 340, 320);
                    this.Text = "New Instrument";
                    break;

                case "Edit Instrument":
                    NewInstrumentPanel myInstrumentEditForm = new NewInstrumentPanel(this, int.Parse(primaryKey));
                    this.SetBounds(350, 350, 340, 320);
                    this.Text = "New Instrument";
                    break;

                case "Rate Type":
                    NewRateTypePanel myRateForm = new NewRateTypePanel(this);
                    this.SetBounds(350, 350, 300, 300);
                    this.Text = "New Rate Type";
                    break;

                case "Supply":
                    NewSupplyPanel mySupplyForm = new NewSupplyPanel(this);
                    this.SetBounds(350, 350, 270, 250);
                    this.Text = "New Supply";
                    break;

                case "Edit Supply":
                    NewSupplyPanel myEditSupplyForm = new NewSupplyPanel(this, primaryKey);
                    this.SetBounds(350, 350, 270, 250);
                    this.Text = "New Supply";
                    break;

                case "User":
                    NewUserPanel myUserPanel = new NewUserPanel(this);
                    this.SetBounds(350, 350, 545, 330);
                    this.Text = "New User Form";
                    break;

                case "Edit User":
                    NewUserPanel myUserEditPanel = new NewUserPanel(this, int.Parse(primaryKey));
                    this.SetBounds(350, 350, 545, 330);
                    this.Text = "Edit User";
                    break;

                case "Point of Contact":
                    NewPointOfContactPanel myContactPanel = new NewPointOfContactPanel(this);
                    this.SetBounds(350, 350, 555, 250);
                    this.Text = "New Contact";
                    break;

                case "Edit Point of Contact":
                    NewPointOfContactPanel myContactEditPanel = new NewPointOfContactPanel(this, int.Parse(primaryKey));
                    this.SetBounds(350, 350, 555, 250);
                    this.Text = "New Contact";
                    break;
            }
        }
        
        public void updateAdminDGV()
            {
                containingForm.updateAdminDGV();
            }
    }
}
