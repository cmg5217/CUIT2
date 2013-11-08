//////////////////////////////////////////////////////////////////////////////////////////
/* 
 * TO-DO - Reorder tab stop on manual request, check tabstop for all pages
 * 
 * 
 */ 
//////////////////////////////////////////////////////////////////////////////////////////

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
using System.Globalization;

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
        ExcelManager ExcelManager;


        public frmCUITAdminMain()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
            /// manually setting standalone to true so that we can test
            /// To-DO:: Make sure to remove this to work on the server
            if (Properties.Settings.Default.StandaloneMode == "true")
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
            //get the moth from user input
            DateTime now = DateTime.Now;
            comboBoxSelectMonth.Text = ((now.ToString("MMMMMMMMM")));
            txtInvoiceExportPath.Text = Properties.Settings.Default.InvoicePath;
            //text export path
            txtInvoiceExportPath.Text = Properties.Settings.Default.InvoicePath;
            // Sets up the return keys for the manual entry tab
            BindReturnKeys();
            InitializeBillingTab();
            InitializeRequestTab();
            InitializeSettingsTab();
            InitializeExportTab();
        }

        private void InitializeBillingTab() {
            if (Settings.Default.StandaloneMode == "false") {
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
            } else {
                //TO-DO Add XML to load accounts

            }
        }

        private void InitializeRequestTab() {
            if (Settings.Default.StandaloneMode == "false") {

            cboManualTimeInstrument.DataSource = dbManager.GetInstruments();
            cboManualTimeInstrument.DisplayMember = "Name";
            cboManualTimeInstrument.ValueMember = "InstrumentID";            
            
            
            cboManualSupplyItem.DataSource = dbManager.GetInstruments();
            cboManualSupplyItem.DisplayMember = "Name";
            cboManualSupplyItem.ValueMember = "InstrumentID";
            } else {
                //TO-DO Add XML to load     

            }
        }

        private void InitializeSettingsTab() {
            if (Properties.Settings.Default.StandaloneMode == "true") {
                chkStandalone.Checked = true;
            }
        }

        private void InitializeExportTab()
        {
            comboBoxSelectAccount.DataSource = dbManager.GetAccounts();
            comboBoxSelectAccount.DisplayMember = "Name";
            comboBoxSelectAccount.ValueMember = "Account_Number";
        }

        // Called in the onload of the tab page to prevent unnecessary calls to the DB5
        private void InitializeAdminTab()
        {

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
            ;
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

            InitializeAdminTab();

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
            newForm.ShowDialog(); //Displays forms modally
        }

        private void tbpExports_Click(object sender, EventArgs e)
        {
            
        }

        private void genPDF(int invoiceID) {
            
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
                //parse the date in the combobox and calculate the end of the month
                string date = comboBoxSelectMonth.Text;
                DateTime datetime = DateTime.ParseExact(date, "MMMMMMMM", CultureInfo.InvariantCulture);
                DateTime endtime = datetime.AddMonths(1);
                endtime = endtime.AddSeconds(-1);
                //MessageBox.Show(endtime.ToString());
                //the offset 
                string offset = "";
                int invoiceID;
                //dbManager.GenerateInvoice("1", DateTime.Now.AddDays(-5), DateTime.Now, out invoiceID);
                dbManager.GenerateInvoice(comboBoxSelectAccount.SelectedValue.ToString(), datetime, endtime, out invoiceID);

                DataTable invoice = dbManager.GetInvoice(invoiceID);
                DataTable invoiceTime = dbManager.GetInvoiceTimeLine(invoiceID);
                DataTable invoiceSupply = dbManager.GetInvoiceSupplyLine(invoiceID);
                DataTable getacc = dbManager.GetAccounts();
                //convert date time to invoice friendly format
                DateTime poststart = DateTime.Parse(invoice.Rows[0]["Posting_Start_Date"].ToString());
                DateTime postend = DateTime.Parse(invoice.Rows[0]["Posting_End_Date"].ToString());
                //MessageBox.Show(test.ToShortDateString().ToString());
               
               // try
               // {

                pdfManager = new PDFManager();
                //pdfManager.AddAddress("Name", "Street", "City", "State", "Zip");
                pdfManager.AddAddress(getacc.Rows[0]["Name"].ToString(),
                    getacc.Rows[0]["Street"].ToString(), //add street to invocie
                    getacc.Rows[0]["City"].ToString(), // add city to invoice
                    getacc.Rows[0]["State"].ToString(), //add state to invoice
                    getacc.Rows[0]["Zip"].ToString()); //add zip to invoice

                //pdfManager.AddService("Instrument", "StartPostDate", "EndPostDate","hours", "rate ($/hr)", "unit(hours days ects)");

                pdfManager.AddPostDate(poststart.ToShortDateString().ToString(), postend.ToShortDateString().ToString());
                
                foreach (DataRow currentRow in invoiceTime.Rows)
                {

                    pdfManager.AddService(
                        currentRow["Name"].ToString(), //insert time into the invoice
                        poststart.ToShortDateString().ToString(), //insert start date into invoice
                        postend.ToShortDateString().ToString(),  //insert end date into invoice
                        currentRow["Hours"].ToString(), //insert hours into invoice
                        currentRow["Rate"].ToString(), //insert dollars per hour into invoice
                        "hour");// unit of biling displayed on invoice
                        pdfManager.AddCharge(currentRow["Line_Amount"].ToString()); //add charge to invoice
                        offset += "\r\n\r\n";
                }

                pdfManager.AddDate(DateTime.Now.ToString()); //Add todays date to the invoice
                pdfManager.AddInvoiceID(invoice.Rows[0]["InvoiceID"].ToString()); // add invoice id to invoice
                pdfManager.AddBalance(offset+"$"+invoice.Rows[0]["Total_Balance"].ToString()); // add balance to invoice

                pdfManager.PDFClose();
              //  }
              //  catch (Exception)
              //  {
               //     MessageBox.Show("Error writing file. Check that this file is not currently\n" 
              //                   +"open in a PDF reader such as Adobe Reader.");
               // }

                ExcelManager.generateExcel(invoice);
               
                
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
            bool pwValid = false;

            string username = txtManualTimeUsername.Text;
            string password = txtManualTimePassword.Text;

            txtManualTimeDuration.Clear();
            lblValidate.Visible = false;
            timeValid = false;
            cboManualTimeAccount.DataSource = null;
            cboManualTimeAccount.Items.Clear();
            dtpManualTimeDate.Value = DateTime.Now;

            if (standalone) {
                pwValid = xmlManager.CheckPassword(username, password);
            } else {
                pwValid = dbManager.CheckPassword(username, password);
            }

            //time log manual request log in validation
            if (pwValid)
            {
                if (standalone) {
                    //code for populating the funding source combobox
                    BindingList<Data> comboItems = new BindingList<Data>();
                    if (!xmlManager.GetUserAccounts(txtManualTimeUsername.Text, out comboItems)) {
                        MessageBox.Show("There are no accounts tied to this username.");
                        return;
                    }
                    cboManualTimeAccount.DataSource = comboItems;
                    cboManualTimeAccount.DisplayMember = "Name";
                    cboManualTimeAccount.ValueMember = "Value";
                } else {
                    DataTable timeAcctTable = dbManager.GetAccounts();
                    if (timeAcctTable.Rows.Count == 0) MessageBox.Show("There are no accounts tied to this username.");
                    cboManualTimeAccount.DataSource = timeAcctTable;
                    cboManualTimeAccount.DisplayMember = "Name";
                    cboManualTimeAccount.ValueMember = "Account_Number";

                }
            

                lblValidate.Visible = true;
                


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
                string instrument = cboManualTimeInstrument.SelectedValue.ToString();


                if (standalone) {
                    string startTime = dtpManualTimeDate.Value.ToString();
                    string endTime = (dtpManualTimeDate.Value.AddMinutes(int.Parse(txtManualTimeDuration.Text))).ToString();
                    xmlManager.AddLog(username, account, instrument, startTime, endTime);
                } else {
                    int instrumentId = int.Parse(instrument);
                    DateTime startTime = dtpManualTimeDate.Value;
                    DateTime endTime = dtpManualTimeDate.Value.AddMinutes(int.Parse(txtManualTimeDuration.Text));
                    dbManager.AddTimeLog(account, dbManager.GetUserID(username), ' ', instrumentId, startTime, endTime);
                }
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
            string username = txtManualSupplyUsername.Text;
            string password = txtManualSupplyPassword.Text;
            //supplies manual request log in validation



            if (xmlManager.CheckPassword(username, password))
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
                    string username = txtManualSupplyUsername.Text;
                    string account = cboManualSupplyAccount.SelectedValue.ToString();
                if (standalone) {

                    //adds the supply use log 
                    string item = "item";// cboManualSupplyItem.SelectedValue.ToString();
                    string quantity = txtManualSupplyQuantity.Text;
                    xmlManager.AddSupplyUse(username, account, item, quantity);
                }
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

        private void chkStandalone_CheckedChanged(object sender, EventArgs e) {

           
        }

        private void btnExportAll_Click(object sender, EventArgs e)
        {
            if (Settings.Default["InvoicePath"].ToString() == "") {
                MessageBox.Show("You have not selected the export path. Please go to the Settings tab and select an export path.");

            } else {
                //parse the date in the combobox and calculate the end of the month
                string date = comboBoxSelectMonth.Text;
                DateTime datetime = DateTime.ParseExact(date, "MMMMMMMM", CultureInfo.InvariantCulture);
                DateTime endtime = datetime.AddMonths(1);
                endtime = endtime.AddSeconds(-1);
                //MessageBox.Show(endtime.ToString());
                //the offset 

                int invoiceID;
                //dbManager.GenerateInvoice("1", DateTime.Now.AddDays(-5), DateTime.Now, out invoiceID);
                //dbManager.GenerateInvoice(comboBoxSelectAccount.SelectedValue.ToString(), datetime, endtime, out invoiceID);

                List<int> invoiceIDs = new List<int>();

                dbManager.GenerateAllInvoices(datetime, endtime, out invoiceIDs);

                List<DataTable> invoices = new List<DataTable>();
                PDFManager pdfManager;
                foreach (int currentInvoice in invoiceIDs) {
                    pdfManager = new PDFManager("Invoice - " + currentInvoice + ".pdf");
                    pdfManager.GeneratePDF(currentInvoice);
                    invoices.Add(dbManager.GetInvoice(currentInvoice));

                }

                //  }
                //  catch (Exception)
                //  {
                //     MessageBox.Show("Error writing file. Check that this file is not currently\n" 
                //                   +"open in a PDF reader such as Adobe Reader.");
                // }

                ExcelManager.generateExcel(invoices.ToArray());


            }
        }

        private void chkStandalone_Click(object sender, EventArgs e)
        {

            //standalone mode on
            if (chkStandalone.Checked)
            {
                //
                DialogResult dialogResult = MessageBox.Show("In order to enable standalone mode, the application must restart. Any logs in progress will be lost. Do you want to continue?", "Standaloen mode", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Properties.Settings.Default.StandaloneMode = "true";
                    Properties.Settings.Default.Save();
                    System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
                    this.Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("Settings not changed, you are not in standalone mode.");
                    chkStandalone.Checked = false;
                }

                                
            }
            //standalone mode off
            else
            {
                DialogResult dialogResult = MessageBox.Show("In order to disable standalone mode, the application must restart. Any logs in progress will be lost. Do you want to continue?", "Standalone mode", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Properties.Settings.Default.StandaloneMode = "false";
                    Properties.Settings.Default.Save();
                    System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
                    this.Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("Settings not changed, you are still in standalone mode.");
                    chkStandalone.Checked = true;
                }
            }
        }
    }
}

