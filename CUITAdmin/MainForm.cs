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
using CUITAdmin.Properties;

namespace CUITAdmin
{
    public partial class frmCUITAdminMain : Form
    {
        
        public static string CONFIG_FILE = "";
        private bool standalone = false;
        private string accountType;
        LogPanel startPanel;

        XmlManager xmlManager;
        DBManager dbManager;
        PDFManager pdfManager;


        public frmCUITAdminMain()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
            /// manually setting standalone to true so that we can test
            /// To-DO:: Make sure to remove this to work on the server
            if (ConfigurationManager.AppSettings["StandaloneMode"] == "true")
            {
                standalone = true;
            }
            else standalone = false;

            xmlManager = XmlManager.Instance;
            dbManager = DBManager.Instance;
            startPanel = new LogPanel(tbpTracking, new Point(5,5));

            cboAccountAdminNew.SelectedItem = "Account";
            cboAccountAdminView.SelectedItem = "Accounts";
            //dgvTimeLogRequests.DataSource = ds;
            //cboAccountAdminView.SelectedValue = "Accounts";
            
            // Resize the DataGridView columns to fit the newly loaded content.
            AdminDataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);

            //loads the path for the invoice export from app.config
            txtInvoiceExportPath.Text = Settings.Default["InvoicePath"].ToString();


            DateTime now = DateTime.Now;
            comboBoxSelectMonth.Text = ((now.ToString("MMMMMMMMM")));
            txtInvoiceExportPath.Text = Properties.Settings.Default.InvoicePath;



            txtInvoiceExportPath.Text = Properties.Settings.Default.InvoicePath;

            // Sets up the return keys for the manual entry tab

            BindReturnKeys();
            InitializeBillingTab();
            InitializeRequestTab();
        }

        private void InitializeBillingTab() {

            cboManualLogUser.DataSource = dbManager.GetUsers();
            cboManualLogUser.DisplayMember = "Username";
            cboManualLogUser.ValueMember = "PersonID";
            cboManualLogUser.Refresh();

            cboManualLogInstrument.DataSource = dbManager.GetInstruments();
            cboManualLogInstrument.DisplayMember = "Name";
            cboManualLogInstrument.ValueMember = "InstrumentID";

            cboManualLogFunding.DataSource = dbManager.GetAccounts();
            cboManualLogFunding.DisplayMember = "Name";
            cboManualLogFunding.ValueMember = "Account_Number";

            cboBillingSupplyFunding.DataSource = dbManager.GetAccounts();
            cboBillingSupplyFunding.DisplayMember = "Name";
            cboBillingSupplyFunding.ValueMember = "Account_Number";

            cboBillingSupplyName.DataSource = dbManager.GetInstruments();
            cboBillingSupplyName.DisplayMember = "Name";
            cboBillingSupplyName.ValueMember = "InstrumentID";

            dgvTimeLogRequests.DataSource = dbManager.GetTimeLogsExceptions();
            FindAndRenameDGVColumn("Account_Name", "Account Name", dgvTimeLogRequests);
            FindAndRenameDGVColumn("Account_Number", "Account Number", dgvTimeLogRequests);
        }

        private void InitializeRequestTab() {

            cboManualSupplyAccount.DataSource = dbManager.GetAccounts();
            cboManualSupplyAccount.DisplayMember = "Name";
            cboManualSupplyAccount.ValueMember = "Account_Number";

            cboManualTimeAccount.DataSource = dbManager.GetAccounts();
            cboManualTimeAccount.DisplayMember = "Name";
            cboManualTimeAccount.ValueMember = "Account_Number";

            cboManualTimeInstrument.DataSource = dbManager.GetInstruments();
            cboManualTimeInstrument.DisplayMember = "Name";
            cboManualTimeInstrument.ValueMember = "InstrumentID";            
            
            
            cboManualSupplyItem.DataSource = dbManager.GetInstruments();
            cboManualSupplyItem.DisplayMember = "Name";
            cboManualSupplyItem.ValueMember = "InstrumentID";

        }

        private void FindAndRenameDGVColumn(string searchName, string newHeader, DataGridView dgv) {
            foreach (DataGridViewColumn col in dgv.Columns) {
                if (col.Name == searchName) {
                    col.HeaderText = newHeader;
                    return;
                }
            }

        }


        private void BindReturnKeys() {
            //Time Log manual request username field clicks validate on enter key pressed
            txtManualTimeUsername.KeyDown += (sender1, args) => {
                if (args.KeyCode == Keys.Return) {
                    btnManualTimeValidate.PerformClick();
                }
            };

            

            //Time Log manual request password field clicks validate on enter key pressed
            txtManualTimePassword.KeyDown += (sender1, args) => {
                if (args.KeyCode == Keys.Return) {
                    btnManualTimeValidate.PerformClick();
                }
            };

            //Time Log manual request duration field clicks add on enter key pressed
            txtManualTimeDuration.KeyDown += (sender1, args) => {
                if (args.KeyCode == Keys.Return) {
                    btnManualTimeAdd.PerformClick();
                }
            };

            //Supplies manual request username field clicks validate on enter key pressed
            txtManualSupplyUsername.KeyDown += (sender1, args) => {
                if (args.KeyCode == Keys.Return) {
                    btnManualSupplyValidate.PerformClick();
                }
            };

            //Supplies manual request password field clicks validate on enter key pressed
            txtManualSupplyPassword.KeyDown += (sender1, args) => {
                if (args.KeyCode == Keys.Return) {
                    btnManualSupplyValidate.PerformClick();
                }
            };

            //Supplies manual request quantity field clicks add on enter key pressed
            txtManualSupplyQuantity.KeyDown += (sender1, args) => {
                if (args.KeyCode == Keys.Return) {
                    btnManualSupplyAdd.PerformClick();
                }
            };
        }

        private void adminEditViewLoad(object sender, EventArgs e)
        {

            PopulateExportAccounts();

        }

        private void PopulateExportAccounts()
        {
            BindingList<Data> comboItems = new BindingList<Data>();

            comboItems.Add(new Data{Name = "TestName", Value = "TestValue"});

            comboBoxSelectAccount.DataSource = comboItems;
            comboBoxSelectAccount.DisplayMember = "Name";
            comboBoxSelectAccount.ValueMember = "Value";

            /*Accounts
            Contacts
            Users
            Instruments
            Supplies*/
            if (cboAccountAdminView.SelectedItem == "Accounts")
            {
                AdminDataGridView.DataSource = dbManager.GetAccounts();
            }
            else if (cboAccountAdminView.SelectedItem == "Contacts")
            {
                AdminDataGridView.DataSource = dbManager.GetContacts();
            }
            else if (cboAccountAdminView.SelectedItem == "Users")
            {
                AdminDataGridView.DataSource = dbManager.GetUsers();
            }
            else if (cboAccountAdminView.SelectedItem == "Instruments")
            {
                AdminDataGridView.DataSource = dbManager.GetInstruments();
            }
            else if (cboAccountAdminView.SelectedItem == "Supplies")
            {
                AdminDataGridView.DataSource = dbManager.GetSupplies();
            }
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
            if (InvoiceExportPath.ShowDialog() == DialogResult.OK)
            {                
                txtInvoiceExportPath.Text = InvoiceExportPath.SelectedPath;
                Settings.Default["InvoicePath"] = btnSetInvoiceExportPath.Text;
                Settings.Default.Save();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Settings.Default["InvoicePath"].ToString() == "")
            {

                MessageBox.Show("You have not selected the export path. Please go to the Settings tab and select an export path.");

            }

            else
            {
                pdfManager = new PDFManager();
                pdfManager.AddAddress("David Stephens", "1856 Us 62", "Oil City", "PA", "16301");
                pdfManager.AddService("Atomic Force", "Aug. 2013", "12", "27", "hour");
                pdfManager.AddDate("January 2014");
                pdfManager.AddInvoiceID("Invoice 234");
                pdfManager.AddBalance("529");
                pdfManager.AddCharge("529");
                pdfManager.PDFClose();

            }
         
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (InvoiceExportPath.ShowDialog() == DialogResult.OK)
            {

                Properties.Settings.Default.InvoicePath = InvoiceExportPath.SelectedPath;
                Properties.Settings.Default.Save();
                txtInvoiceExportPath.Text = InvoiceExportPath.SelectedPath;
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
            lblValidate.Visible = false;
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
                    MessageBox.Show("There are no accounts tied to this username.");
                    return;
                }
                cboManualTimeAccount.DataSource = comboItems;
                cboManualTimeAccount.DisplayMember = "Name";
                cboManualTimeAccount.ValueMember = "Value";

                lblValidate.Visible = true;

                BindingList<Data> comboInstruments = dbManager.GetInstrumentsData();
                cboManualTimeInstrument.DataSource = comboInstruments;
                cboManualTimeInstrument.DisplayMember = "Name";
                cboManualTimeInstrument.ValueMember = "Value";


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
                lblValidate.Visible = false;
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
                    MessageBox.Show("There are no accounts tied to this username.");
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

        private void btnPreview_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dgvTimeLogRequests_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            MessageBox.Show("Header " + e + " Clicked");
        }
    }
}

