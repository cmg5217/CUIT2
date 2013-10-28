using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using System.IO;

namespace CUITAdmin
{
    public partial class frmCUITAdminMain : Form
    {
        
        public static string CONFIG_FILE = "";
        private bool standalone = false;
        private string accountType;
        LogPanel startPanel;
        XmlManager xmlManager;

        public frmCUITAdminMain()
        {
            InitializeComponent();
        }

        private void time_LogBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.time_LogBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cUIT_TRIALDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cUIT_TRIALDataSet.UnapprovedTimeLogTable' table. You can move, or remove it, as needed.
            //this.unapprovedTimeLogTableTableAdapter.FillDeniedTimeLog(this.cUIT_TRIALDataSet.UnapprovedTimeLogTable);
            // TODO: This line of code loads data into the 'cUIT_TRIALDataSet.Time_Log' table. You can move, or remove it, as needed.
            //this.time_LogTableAdapter.Fill(this.cUIT_TRIALDataSet.Time_Log);
            
            /// manually setting standalone to true so that we can test
            /// To-DO:: Make sure to remove this to work on the server
            if (ConfigurationManager.AppSettings["StandaloneMode"] == "true")
            {
                standalone = true;
            }
            else standalone = false;

            xmlManager = XmlManager.Instance; 

            startPanel = new LogPanel(tbpTracking, new Point(5,5));

            cboAccountAdminNew.SelectedItem = "Account";
            cboAccountAdminView.SelectedItem = "Accounts";
            DataGridViewCell editCell = dgvTimeLogRequests.Rows[0].Cells[6];
            editCell.Value = "test";
            //loads the path for the invoice export from app.config

            textBox2.Text = Properties.Settings.Default.InvoicePath;

            //Time Log manual request username field clicks validate on enter key pressed
            txtManualTimeUsername.KeyDown += (sender1, args) =>
            {
                if (args.KeyCode == Keys.Return)
                {
                    btnManualTimeValidate.PerformClick();
                }
            };

            //Time Log manual request password field clicks validate on enter key pressed
            txtManualTimePassword.KeyDown += (sender1, args) =>
            {
                if (args.KeyCode == Keys.Return)
                {
                    btnManualTimeValidate.PerformClick();
                }
            };

            //Time Log manual request duration field clicks add on enter key pressed
            txtManualTimeDuration.KeyDown += (sender1, args) =>
            {
                if (args.KeyCode == Keys.Return)
                {
                    btnManualTimeAdd.PerformClick();
                }
            };

            //Supplies manual request username field clicks validate on enter key pressed
            txtManualSupplyUsername.KeyDown += (sender1, args) =>
            {
                if (args.KeyCode == Keys.Return)
                {
                    btnManualSupplyValidate.PerformClick();
                }
            };

            //Supplies manual request password field clicks validate on enter key pressed
            txtManualSupplyPassword.KeyDown += (sender1, args) =>
            {
                if (args.KeyCode == Keys.Return)
                {
                    btnManualSupplyValidate.PerformClick();
                }
            };

            //Supplies manual request quantity field clicks add on enter key pressed
            txtManualSupplyQuantity.KeyDown += (sender1, args) =>
            {
                if (args.KeyCode == Keys.Return)
                {
                    btnManualSupplyAdd.PerformClick();
                }
            };
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void tbpAccountAdmin_Click(object sender, EventArgs e)
        {

        }

        private void btnAccountAdminNew_Click(object sender, EventArgs e)
        {
            string addNewCase = cboAccountAdminNew.Text;
            Form newForm = new NewEntryForm(addNewCase);
            newForm.Show();
        }

        private void tbpExports_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog logDialog = new OpenFileDialog();
            logDialog.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string pdfTemplate = @"invoicetemplate.pdf";
            string newFile = textBox2.Text + @"\CARIPD-002-13.pdf";


            

            PdfReader pdfReader = new PdfReader(pdfTemplate);
            PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(
                        newFile, FileMode.Create));

            AcroFields pdfFormFields = pdfStamper.AcroFields;

            // set form pdfFormFields

            // Address
            pdfFormFields.SetField("Address", "David Stephens" + Environment.NewLine
                + "1856 US 62" + Environment.NewLine + "Oil City, PA 16301");
            //Services
            pdfFormFields.SetField("services", "Atomic Force Microscopy" +
                Environment.NewLine + "(April 2013, 16 hours @ $27/hr)" +
                Environment.NewLine + Environment.NewLine +
                "Optical/Fluorescent Microscopy" + Environment.NewLine + 
                "(April 2013, 8 hours @ $18/hr)");


            //Charges
            pdfFormFields.SetField("charges", "$432" + Environment.NewLine
                + Environment.NewLine + Environment.NewLine+
                "$144");
            //Credits
            pdfFormFields.SetField("credits", "");
            //Balance
            pdfFormFields.SetField("balance", Environment.NewLine + Environment.NewLine + Environment.NewLine +
                Environment.NewLine + "$576.00");
            //Date
            pdfFormFields.SetField("Date", "10/9/2013");
            //Invoice/ID
            pdfFormFields.SetField("FillText1", "CARIPD-002-13");

            // report by reading values from completed PDF

            MessageBox.Show("Export Complete! \n" + "File has been exported to:\n" + newFile);

            // flatten the form to remove editting options, set it to false
            // to leave the form open to subsequent manual edits
            pdfStamper.FormFlattening = true;

            // close the pdf
            pdfStamper.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {

          


        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (InvoiceExportPath.ShowDialog() == DialogResult.OK)
            {

                Properties.Settings.Default.InvoicePath = InvoiceExportPath.SelectedPath;
                Properties.Settings.Default.Save();


                textBox2.Text = InvoiceExportPath.SelectedPath;// = Properties.Settings.Default.InvoicePath;
            }
        }

        private void InitializeTabs(string accountType)
        {
            switch (accountType)
            {
                case "admin":
                    break;
            }
        }

        private bool timeValid = false;
        private void btnManualTimeValidate_Click(object sender, EventArgs e)
        {
            txtManualTimeDuration.Clear();
            label11.Visible = false;
            timeValid = false;
            cboManualTimeAccount.DataSource = null;
            cboManualTimeAccount.Items.Clear();
            dtpManualTimeDate.Value = DateTime.Now;

            //time log manual request log in validation
            if (xmlManager.CheckPassword(txtManualTimeUsername.Text, txtManualTimePassword.Text))
            {
                //code for populating the funding source combobox
                BindingList<Data> comboItems = new BindingList<Data>();
                if (!xmlManager.GetUserAccounts(txtManualTimeUsername.Text, out comboItems)) {
                    MessageBox.Show("Eat a sack of Dicks, you have no accounts");
                    return;
                }
                cboManualTimeAccount.DataSource = comboItems;
                cboManualTimeAccount.DisplayMember = "Name";
                cboManualTimeAccount.ValueMember = "Value";

                label11.Visible = true;
                timeValid = true;
            }
            else
            {
                MessageBox.Show("Your username or password is incorrect.");
                txtManualTimeUsername.Focus();
            }
        }

        private void btnManualTimeAdd_Click(object sender, EventArgs e)
        {
            //this is for adding the time log user manual request log
            txtManualTimeDuration.BackColor = System.Drawing.Color.White;
            
            //RegEx pattern for duration field
            string durationPattern = "^[0-9]+$";

            if (!timeValid)
            {
                MessageBox.Show("Your log in information is not valid.  Please log in to continue.");
                txtManualTimeUsername.Focus();
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtManualTimeDuration.Text, durationPattern))
            {
                txtManualTimeDuration.BackColor = System.Drawing.Color.Red;
                MessageBox.Show("Please input a simple integer to represent the durations in minutes.");
            }
            else
            {
                //adds the time log
                string username = txtManualTimeUsername.Text;
                string account = cboManualTimeAccount.SelectedValue.ToString();
                string instrument = "test";//cboManualTimeInstrument.SelectedValue.ToString();
                string startTime = dtpManualTimeDate.Value.ToString();
                string endTime = (dtpManualTimeDate.Value.AddMinutes(int.Parse(txtManualTimeDuration.Text))).ToString();
                xmlManager.AddLog(username, account, instrument, startTime, endTime);

                //confirms the add to the user and resets the time log form.
                MessageBox.Show("Time Log Manual Request Added");
                txtManualTimeUsername.Clear();
                txtManualTimePassword.Clear();
                txtManualTimeDuration.Clear();
                label11.Visible = false;
                timeValid = false;
                cboManualTimeAccount.DataSource = null;
                cboManualTimeAccount.Items.Clear();
                dtpManualTimeDate.Value = DateTime.Now;
                txtManualTimeUsername.Focus();
            }
        }

        private bool supplyValid = false;
        private void btnManualSupplyValidate_Click(object sender, EventArgs e)
        {
            //supplies manual request log in validation
            if (xmlManager.CheckPassword(txtManualSupplyUsername.Text, txtManualSupplyPassword.Text))
            {
                txtManualSupplyQuantity.Clear();
                label12.Visible = false;
                supplyValid = false;
                cboManualSupplyAccount.DataSource = null;
                cboManualSupplyAccount.Items.Clear();
                
                //code for populating the funding source combobox
                BindingList<Data> comboItems = new BindingList<Data>();
                if (!xmlManager.GetUserAccounts(txtManualSupplyUsername.Text, out comboItems)) {
                    MessageBox.Show("Eat a sack of Dicks, you have no accounts");
                    return;
                }
                cboManualSupplyAccount.DataSource = comboItems;
                cboManualSupplyAccount.DisplayMember = "Name";
                cboManualSupplyAccount.ValueMember = "Value";

                label12.Visible = true;
                supplyValid = true;
            }
            else
            {
                MessageBox.Show("Your username or password is incorrect.");
                txtManualSupplyUsername.Focus();
            }
        }

        private void btnManualSupplyAdd_Click(object sender, EventArgs e)
        {
            //this is for adding the supplies user manual request log
            txtManualSupplyQuantity.BackColor = System.Drawing.Color.White;
            
            //RegEx pattern for the quantity field
            string quantityPattern = "^[0-9]+$";

            if (!supplyValid)
            {
                MessageBox.Show("Your log in information is not valid.  Please log in to continue.");
                txtManualSupplyUsername.Focus();
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtManualSupplyQuantity.Text, quantityPattern))
            {
                txtManualSupplyQuantity.BackColor = System.Drawing.Color.Red;
                MessageBox.Show("Please input a simple integer to represent the quantity in the unit of measurement appropriate.");
                txtManualSupplyQuantity.Focus();
            }
            else
            {
                //adds the supply use log 
                string username = txtManualSupplyUsername.Text;
                string account = cboManualSupplyAccount.SelectedValue.ToString();
                string item = "item";// cboManualSupplyItem.SelectedValue.ToString();
                string quantity = txtManualSupplyQuantity.Text;
                xmlManager.AddSupplyUse(username, account, item, quantity);
                
                //confirms the add with the user then resets the supply form
                MessageBox.Show("Supply Manual Request Added");
                txtManualSupplyUsername.Clear();
                txtManualSupplyPassword.Clear();
                txtManualSupplyQuantity.Clear();
                label12.Visible = false;
                supplyValid = false;
                cboManualSupplyAccount.DataSource = null;
                cboManualSupplyAccount.Items.Clear();
                txtManualSupplyUsername.Focus();
            }
        }
    }
}

