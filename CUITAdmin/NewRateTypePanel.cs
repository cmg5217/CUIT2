// TO-DO: make an edit mode for this


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace CUITAdmin
{
    class NewRateTypePanel : Panel
    {
        Button btnSubmit = new Button();
        CheckBox ckbActive = new CheckBox();
        Label lblRateName = new Label();
        Label lblInstruments = new Label();
        TextBox txtRateName = new TextBox();
        DataGridView dgvInstrumentRates = new DataGridView();
        NewEntryForm containingForm;
        DBManager dbManager;

        public NewRateTypePanel(NewEntryForm pForm)
        {
            dbManager = DBManager.Instance;
            containingForm = pForm;
            pForm.Controls.Add(this);
            this.Location = new Point(10, 10);
            this.Size = new Size(650, 400);

            addControls();
            containingForm.AcceptButton = btnSubmit;

            //this should just go into the constructor for edit mode but it doesnt exist yet.
            //CheckBox ckbActive = new CheckBox();
            ckbActive.Text = "Active";
            ckbActive.Location = new Point(550, 310);
            this.Controls.Add(ckbActive);


            //this should go into populate controls, but that also doesnt exist yet.
            //char active = char.Parse(user["Active"].ToString());

            //if (active == 'Y')
            //    ckbActive.Checked = true;
            //else
            //    ckbActive.Checked = false;
        }

        private void addControls()
        {
            // 
            // pnlRateType
            // 
            this.Controls.Add(this.lblRateName);
            this.Controls.Add(this.dgvInstrumentRates);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtRateName);
            this.Controls.Add(this.lblInstruments);
            this.Location = new System.Drawing.Point(12, 12);
            this.Name = "pnlRateType";
            this.Size = new System.Drawing.Size(272, 240);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(179, 210);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new EventHandler(this.btnSubmit_Click);
            // 
            // lblRateName
            // 
            this.lblRateName.AutoSize = true;
            this.lblRateName.Location = new System.Drawing.Point(11, 15);
            this.lblRateName.Name = "lblRateName";
            this.lblRateName.Size = new System.Drawing.Size(64, 13);
            this.lblRateName.TabIndex = 1;
            this.lblRateName.Text = "Rate Name:";
            // 
            // lblInstruments
            // 
            this.lblInstruments.AutoSize = true;
            this.lblInstruments.Location = new System.Drawing.Point(11, 37);
            this.lblInstruments.Name = "lblInstruments";
            this.lblInstruments.Size = new System.Drawing.Size(64, 13);
            this.lblInstruments.TabIndex = 2;
            this.lblInstruments.Text = "Instruments:";
            // 
            // txtRateName
            // 
            this.txtRateName.Location = new System.Drawing.Point(81, 12);
            this.txtRateName.Name = "txtRateName";
            this.txtRateName.Size = new System.Drawing.Size(173, 20);
            this.txtRateName.TabIndex = 0;
            // 
            // dgvInstrumentRates
            // 
            this.dgvInstrumentRates.Location = new System.Drawing.Point(14, 54);
            this.dgvInstrumentRates.Name = "dgvInstrumentRates";
            this.dgvInstrumentRates.Size = new System.Drawing.Size(240, 150);
            this.dgvInstrumentRates.TabIndex = 3;
            this.dgvInstrumentRates.RowHeadersVisible = false;
            DataTable sourceTable = dbManager.GetInstruments();
            sourceTable.Columns.Add(new DataColumn("Rate"));
            this.dgvInstrumentRates.DataSource = sourceTable;
            this.dgvInstrumentRates.Columns["Name"].ReadOnly = true;
            this.dgvInstrumentRates.Columns["Billing_Unit"].Visible = false;
            this.dgvInstrumentRates.Columns["Time_Increment"].Visible = false;
            this.dgvInstrumentRates.Columns["InstrumentID"].Visible = false;
            this.dgvInstrumentRates.AllowUserToAddRows = false;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (errorChecked())
                MessageBox.Show("There were errors on the form.  Please correct them and submit again.");
            else
            {
                dbManager.AddRateType(txtRateName.Text);
                DataTable ratesTable = (DataTable)dgvInstrumentRates.DataSource;
                foreach (DataRow row in ratesTable.Rows)
                {
                    dbManager.AddInstrumentRate(txtRateName.Text, int.Parse(row["Rate"].ToString()), int.Parse(row["InstrumentID"].ToString()));
                }

                containingForm.updateAdminDGV();
                containingForm.Close();
            }
        }

        private bool errorChecked()
        {
            txtRateName.BackColor = System.Drawing.Color.White;

            bool error = false;

            string namePattern = "^[A-Za-z\\s-\\.]+$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtRateName.Text, namePattern))
            {
                txtRateName.BackColor = System.Drawing.Color.Red;
                error = true;
            }

            string ratePattern = "^\\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$";
            DataTable ratesTable = (DataTable)dgvInstrumentRates.DataSource;
            foreach (DataRow row in ratesTable.Rows)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(row["Rate"].ToString(), ratePattern))
                {
                    lblInstruments.BackColor = System.Drawing.Color.Red;
                    error = true;
                }
            }

            return error;
        }
    }
}
