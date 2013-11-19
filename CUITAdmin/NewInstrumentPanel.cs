using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace CUITAdmin
{
    class NewInstrumentPanel : Panel
    {
        Button btnSubmit = new Button();
        TextBox txtTimeIncrement = new TextBox();
        ComboBox cboBillingType = new ComboBox();
        TextBox txtInstrumentName = new TextBox();
        DataGridView dgvInstrumentRates = new DataGridView();
        Label lblInstrumentRates = new Label();
        Label lblTimeIncrement = new Label();
        Label lblBillingType = new Label();
        Label lblInstrumentName = new Label();
        NewEntryForm containingForm;
        DBManager dbManager;
        int primaryKey;
        string mode = "add";


        public NewInstrumentPanel(NewEntryForm pForm, int primaryKey) 
        :this(pForm){
            
            this.primaryKey = primaryKey;
            mode = "edit";
            populateControls();
        }

        public NewInstrumentPanel(NewEntryForm pForm)
        {
            dbManager = DBManager.Instance;
            containingForm = pForm;
            pForm.Controls.Add(this);
            this.Location = new Point(10, 10);
            this.Size = new Size(650, 400);

            addControls();
            containingForm.AcceptButton = btnSubmit;
        }

        public void populateControls(){
            dbManager = DBManager.Instance;
            DataTable instrument = dbManager.GetInstrument(primaryKey);
            DataTable instrumentRates = dbManager.GetInstrumentRates(primaryKey);
            if (instrument.Rows[0]["Billing_Unit"].ToString() == "Per Use") cboBillingType.SelectedIndex = 1;
            this.txtInstrumentName.Text = instrument.Rows[0]["Name"].ToString();
            this.txtTimeIncrement.Text = instrument.Rows[0]["Time_Increment"].ToString();
            foreach (DataGridViewRow row in dgvInstrumentRates.Rows) {
                foreach (DataRow tableRow in instrumentRates.Rows) {
                    if (row.Cells[0].Value.ToString() == tableRow["Rate_Type"].ToString())
                        row.Cells[1].Value = tableRow["Rate"].ToString();
                }
            }
        }

        private void addControls()
        {
            // 
            // pnlNewInstrument
            // 
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtTimeIncrement);
            this.Controls.Add(this.cboBillingType);
            this.Controls.Add(this.txtInstrumentName);
            this.Controls.Add(this.lblTimeIncrement);
            this.Controls.Add(this.lblBillingType);
            this.Controls.Add(this.lblInstrumentName);
            this.Controls.Add(this.lblInstrumentRates);
            this.Controls.Add(this.dgvInstrumentRates);
            this.Location = new System.Drawing.Point(12, 12);
            this.Name = "pnlNewInstrument";
            this.Size = new System.Drawing.Size(285, 328);
            this.TabIndex = 0;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(190, 229);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 12;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new EventHandler(this.btnSubmit_Click);
            //
            // dgvInstrumentRates
            //
            this.dgvInstrumentRates.Location = new System.Drawing.Point(21, 120);
            this.dgvInstrumentRates.Name = "dgvInstrumentRates";
            this.dgvInstrumentRates.Size = new System.Drawing.Size(245, 100);
            this.dgvInstrumentRates.TabIndex = 9;
            this.dgvInstrumentRates.RowHeadersVisible = false;
            DataTable sourceTable = dbManager.GetRateTypes();

            sourceTable.Columns.Add(new DataColumn("Rate"));

            this.dgvInstrumentRates.DataSource = sourceTable;
            this.dgvInstrumentRates.Columns["Name"].ReadOnly = true;
            this.dgvInstrumentRates.AllowUserToAddRows = false;
            // 
            // txtTimeIncrement
            // 
            this.txtTimeIncrement.Location = new System.Drawing.Point(166, 71);
            this.txtTimeIncrement.Name = "txtTimeIncrement";
            this.txtTimeIncrement.Size = new System.Drawing.Size(100, 20);
            this.txtTimeIncrement.TabIndex = 8;
            // 
            // cboBillingType
            // 
            this.cboBillingType.Location = new System.Drawing.Point(166, 44);
            this.cboBillingType.Name = "cboBillingType";
            this.cboBillingType.Size = new System.Drawing.Size(100, 20);
            this.cboBillingType.TabIndex = 7;
            cboBillingType.Items.Add("Time");
            cboBillingType.Items.Add("Per Use");
            cboBillingType.SelectedItem = "Time";
            this.cboBillingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBillingType.SelectedIndexChanged += new EventHandler(this.timeIncrementEnabled);
            // 
            // txtInstrumentName
            // 
            this.txtInstrumentName.Location = new System.Drawing.Point(166, 17);
            this.txtInstrumentName.Name = "txtInstrumentName";
            this.txtInstrumentName.Size = new System.Drawing.Size(100, 20);
            this.txtInstrumentName.TabIndex = 6;
            //
            // lblInstrumentRates
            //
            this.lblInstrumentRates.AutoSize = true;
            this.lblInstrumentRates.Location = new System.Drawing.Point(18, 101);
            this.lblInstrumentRates.Name = "lblInstrumentRates";
            this.lblInstrumentRates.Size = new System.Drawing.Size(83, 13);
            this.lblInstrumentRates.TabIndex = 10;
            this.lblInstrumentRates.Text = "Instrument Rates:";
            // 
            // lblTimeIncrement
            // 
            this.lblTimeIncrement.AutoSize = true;
            this.lblTimeIncrement.Location = new System.Drawing.Point(18, 74);
            this.lblTimeIncrement.Name = "lblTimeIncrement";
            this.lblTimeIncrement.Size = new System.Drawing.Size(83, 13);
            this.lblTimeIncrement.TabIndex = 2;
            this.lblTimeIncrement.Text = "Time Increment:";
            // 
            // lblBillingType
            // 
            this.lblBillingType.AutoSize = true;
            this.lblBillingType.Location = new System.Drawing.Point(18, 47);
            this.lblBillingType.Name = "lblBillingType";
            this.lblBillingType.Size = new System.Drawing.Size(64, 13);
            this.lblBillingType.TabIndex = 1;
            this.lblBillingType.Text = "Billing Type:";
            // 
            // lblInstrumentName
            // 
            this.lblInstrumentName.AutoSize = true;
            this.lblInstrumentName.Location = new System.Drawing.Point(18, 20);
            this.lblInstrumentName.Name = "lblInstrumentName";
            this.lblInstrumentName.Size = new System.Drawing.Size(90, 13);
            this.lblInstrumentName.TabIndex = 0;
            this.lblInstrumentName.Text = "Instrument Name:";
        }

        private void timeIncrementEnabled(object sender, EventArgs e)
        {
            if (cboBillingType.SelectedItem == "Time")
                txtTimeIncrement.Enabled = true;
            else
                txtTimeIncrement.Enabled = false;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (errorChecked())
                MessageBox.Show("There were errors on the form.  Please correct them and submit again.");
            else
            {
                if (mode == "add") {
                    int instrumentID;

                    dbManager.AddInstrument(txtInstrumentName.Text, cboBillingType.SelectedItem.ToString(),
                        (txtTimeIncrement.Text == "") ? 0 : int.Parse(txtTimeIncrement.Text), out instrumentID);
                    //I hate you chris ^^^
                    DataTable ratesTable = (DataTable)dgvInstrumentRates.DataSource;
                    foreach (DataRow row in ratesTable.Rows) {
                        dbManager.AddInstrumentRate(row["Name"].ToString(), int.Parse(row["Rate"].ToString()), instrumentID);
                    }

                } else {
                    //TO-DO: add chkbox for approved
                    dbManager.UpdateInstrument(primaryKey, txtInstrumentName.Text, cboBillingType.SelectedItem.ToString(),
                        (txtTimeIncrement.Text == "") ? 0 : int.Parse(txtTimeIncrement.Text), 'Y');

                    DataTable ratesTable = (DataTable)dgvInstrumentRates.DataSource;
                    dbManager.UpdateInstrumentRates(ratesTable, primaryKey);
                }

                containingForm.updateAdminDGV();
                containingForm.Close();
            }
        }

        private Boolean errorChecked()
        {
            txtTimeIncrement.BackColor = System.Drawing.Color.White;
            cboBillingType.BackColor = System.Drawing.Color.White;
            txtInstrumentName.BackColor = System.Drawing.Color.White;

            bool error = false;

            string ratePattern = "^\\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$";
            DataTable ratesTable = (DataTable)dgvInstrumentRates.DataSource;
            foreach (DataRow row in ratesTable.Rows)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(row["Rate"].ToString(), ratePattern) || Double.Parse(row["Rate"].ToString()) < 0)
                {
                    lblInstrumentRates.BackColor = System.Drawing.Color.Red;
                    error = true;
                }
            }

            if (cboBillingType.SelectedItem == "Time")
            { 
                string timePattern = "^[0-9]+$";
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtTimeIncrement.Text, timePattern) || int.Parse(txtTimeIncrement.Text) <= 0)
                {
                    txtTimeIncrement.BackColor = System.Drawing.Color.Red;
                    error = true;
                }
            }
            
            string namePattern = "^[A-Za-z\\s-\\.]+$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtInstrumentName.Text, namePattern))
            {
                txtInstrumentName.BackColor = System.Drawing.Color.Red;
                error = true;
            }

            return error;
        }
    }
}
