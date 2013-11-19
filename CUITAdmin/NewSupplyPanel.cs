using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace CUITAdmin
{
    class NewSupplyPanel : Panel
    {
        Button btnSubmit = new Button();
        CheckBox ckbActive = new CheckBox();
        TextBox txtIndustryRate = new TextBox();
        TextBox txtExternalRate = new TextBox();
        TextBox txtInternalRate = new TextBox();
        TextBox txtUnit = new TextBox();
        TextBox txtSupplyCost = new TextBox();
        TextBox txtSupplyName = new TextBox();
        Label lblIndustryRate = new Label();
        Label lblExternalRate = new Label();
        Label lblInternalRate = new Label();
        Label lblSupplyCost = new Label();
        Label lblUnit = new Label();
        Label lblSupplyName = new Label();
        NewEntryForm containingForm;
        DBManager dbManager;
        string primaryKey;
        string mode = "add";

        public NewSupplyPanel(NewEntryForm pForm, string primaryKey)
            : this(pForm) {
            ckbActive.Text = "Active";
            ckbActive.Location = new Point(550, 310);
            this.Controls.Add(ckbActive);
            this.primaryKey = primaryKey;
            populateControls();
            mode = "edit";
        }

        public NewSupplyPanel(NewEntryForm pForm) {
            dbManager = DBManager.Instance;
            containingForm = pForm;
            pForm.Controls.Add(this);
            this.Location = new Point(10, 10);
            this.Size = new Size(650, 400);

            addControls();
            containingForm.AcceptButton = btnSubmit;

            //this should just go into the constructor for edit mode but it doesnt exist yet.
            //CheckBox ckbActive = new CheckBox();


            //this should go into populate controls, but that also doesnt exist yet.
            //char active = char.Parse(user["Active"].ToString());


        }

        private void populateControls() {
            DataTable supply = dbManager.GetSupply(primaryKey);
            this.txtUnit.Text = supply.Rows[0]["Unit"].ToString();
            this.txtSupplyCost.Text = supply.Rows[0]["Cost"].ToString();
            this.txtSupplyName.Text = supply.Rows[0]["Supply_Name"].ToString();
            txtSupplyName.Enabled = false;

            char active = Convert.ToChar(supply.Rows[0]["Active"]);


            if (active == 'Y')
                ckbActive.Checked = true;
            else
                ckbActive.Checked = false;
        }

        private void addControls()
        {
            // 
            // pnlNewSupply
            // 
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtIndustryRate);
            this.Controls.Add(this.txtExternalRate);
            this.Controls.Add(this.txtInternalRate);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.txtSupplyCost);
            this.Controls.Add(this.txtSupplyName);
            this.Controls.Add(this.lblIndustryRate);
            this.Controls.Add(this.lblExternalRate);
            this.Controls.Add(this.lblInternalRate);
            this.Controls.Add(this.lblSupplyCost);
            this.Controls.Add(this.lblUnit);
            this.Controls.Add(this.lblSupplyName);
            this.Location = new System.Drawing.Point(1, 2);
            this.Name = "pnlNewSupply";
            this.Size = new System.Drawing.Size(249, 214);
            this.TabIndex = 0;
            // 
            // lblInternalRate
            // 
            this.lblInternalRate.AutoSize = true;
            this.lblInternalRate.Location = new System.Drawing.Point(11, 94);
            this.lblInternalRate.Name = "lblInternalRate";
            this.lblInternalRate.Size = new System.Drawing.Size(95, 13);
            this.lblInternalRate.TabIndex = 3;
            this.lblInternalRate.Text = "Internal Rate/Unit:";
            // 
            // lblSupplyCost
            // 
            this.lblSupplyCost.AutoSize = true;
            this.lblSupplyCost.Location = new System.Drawing.Point(11, 40);
            this.lblSupplyCost.Name = "lblSupplyCost";
            this.lblSupplyCost.Size = new System.Drawing.Size(66, 13);
            this.lblSupplyCost.TabIndex = 2;
            this.lblSupplyCost.Text = "Supply Cost:";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(11, 67);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(108, 13);
            this.lblUnit.TabIndex = 1;
            this.lblUnit.Text = "Unit of Measurement:";
            // 
            // lblSupplyName
            // 
            this.lblSupplyName.AutoSize = true;
            this.lblSupplyName.Location = new System.Drawing.Point(11, 13);
            this.lblSupplyName.Name = "lblSupplyName";
            this.lblSupplyName.Size = new System.Drawing.Size(73, 13);
            this.lblSupplyName.TabIndex = 0;
            this.lblSupplyName.Text = "Supply Name:";
            // 
            // lblExternalRate
            // 
            this.lblExternalRate.AutoSize = true;
            this.lblExternalRate.Location = new System.Drawing.Point(11, 121);
            this.lblExternalRate.Name = "lblExternalRate";
            this.lblExternalRate.Size = new System.Drawing.Size(98, 13);
            this.lblExternalRate.TabIndex = 4;
            this.lblExternalRate.Text = "External Rate/Unit:";
            // 
            // lblIndustryRate
            // 
            this.lblIndustryRate.AutoSize = true;
            this.lblIndustryRate.Location = new System.Drawing.Point(11, 148);
            this.lblIndustryRate.Name = "lblIndustryRate";
            this.lblIndustryRate.Size = new System.Drawing.Size(97, 13);
            this.lblIndustryRate.TabIndex = 5;
            this.lblIndustryRate.Text = "Industry Rate/Unit:";
            // 
            // txtSupplyName
            // 
            this.txtSupplyName.Location = new System.Drawing.Point(129, 10);
            this.txtSupplyName.Name = "txtSupplyName";
            this.txtSupplyName.Size = new System.Drawing.Size(100, 20);
            this.txtSupplyName.TabIndex = 6;
            // 
            // txtSupplyCost
            // 
            this.txtSupplyCost.Location = new System.Drawing.Point(129, 37);
            this.txtSupplyCost.Name = "txtSupplyCost";
            this.txtSupplyCost.Size = new System.Drawing.Size(100, 20);
            this.txtSupplyCost.TabIndex = 7;
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(129, 64);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(100, 20);
            this.txtUnit.TabIndex = 8;
            // 
            // txtInternalRate
            // 
            this.txtInternalRate.Location = new System.Drawing.Point(129, 91);
            this.txtInternalRate.Name = "txtInternalRate";
            this.txtInternalRate.Size = new System.Drawing.Size(100, 20);
            this.txtInternalRate.TabIndex = 9;
            // 
            // txtExternalRate
            // 
            this.txtExternalRate.Location = new System.Drawing.Point(129, 118);
            this.txtExternalRate.Name = "txtExternalRate";
            this.txtExternalRate.Size = new System.Drawing.Size(100, 20);
            this.txtExternalRate.TabIndex = 10;
            // 
            // txtIndustryRate
            // 
            this.txtIndustryRate.Location = new System.Drawing.Point(129, 145);
            this.txtIndustryRate.Name = "txtIndustryRate";
            this.txtIndustryRate.Size = new System.Drawing.Size(100, 20);
            this.txtIndustryRate.TabIndex = 11;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(153, 172);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 12;
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
                    dbManager.AddSupply(txtSupplyName.Text, Double.Parse(txtSupplyCost.Text), txtUnit.Text);

                } else {
                    
                    dbManager.UpdateSupply(txtSupplyName.Text, Convert.ToDouble(txtSupplyCost.Text), txtUnit.Text, (ckbActive.Checked) ? 'Y' : 'N');
                }
                containingForm.updateAdminDGV();
                containingForm.Close();
            }
        }

        private Boolean errorChecked()
        {
            txtIndustryRate.BackColor = System.Drawing.Color.White;
            txtExternalRate.BackColor = System.Drawing.Color.White;
            txtInternalRate.BackColor = System.Drawing.Color.White;
            txtUnit.BackColor = System.Drawing.Color.White;
            txtSupplyCost.BackColor = System.Drawing.Color.White;
            txtSupplyName.BackColor = System.Drawing.Color.White;

            bool error = false;

            string industryPattern = "^\\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtIndustryRate.Text, industryPattern))
            {
                txtIndustryRate.BackColor = System.Drawing.Color.Red;
                error = true;
            }

            string externalPattern = "^\\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtExternalRate.Text, externalPattern))
            {
                txtExternalRate.BackColor = System.Drawing.Color.Red;
                error = true;
            }

            string internalPattern = "^\\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtInternalRate.Text, internalPattern))
            {
                txtInternalRate.BackColor = System.Drawing.Color.Red;
                error = true;
            }

            string unitPattern = "^[\\w]+$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtUnit.Text, unitPattern))
            {
                txtUnit.BackColor = System.Drawing.Color.Red;
                error = true;
            }

            string costPattern = "^\\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtSupplyCost.Text, costPattern))
            {
                txtSupplyCost.BackColor = System.Drawing.Color.Red;
                error = true;
            }

            string namePattern = "^[A-Za-z\\s-\\.]+$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtSupplyName.Text, namePattern))
            {
                txtSupplyName.BackColor = System.Drawing.Color.Red;
                error = true;
            }

            return error;
        }
    }
}
