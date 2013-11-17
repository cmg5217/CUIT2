﻿//////////////////////////////////////////////////////////////////////////////////////////
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

namespace CUITAdmin {
    public partial class frmCUITAdminMain : Form {

        public static string CONFIG_FILE = "";
        private bool standalone = false;
        private string accountType;
        private char userType;

        LogPanel startPanel;

        XmlManager xmlManager;
        DBManager dbManager;

        ExcelManager ExcelManager;



        public frmCUITAdminMain(char userType) {
            this.userType = userType;
            InitializeComponent();
        }


        private void Main_Load(object sender, EventArgs e)
        {

            tabControlMain.Location = new Point((this.Size.Width / 2) - (tabControlMain.Size.Width/2) - 7, 
                                                (this.Size.Height / 2) - (tabControlMain.Size.Height/2) - 19);
                                      //new Point(0, 0);
            /// manually setting standalone to true so that we can test
            /// To-DO:: Make sure to remove this to work on the server
            if (Properties.Settings.Default.StandaloneMode == "true")
            {
                standalone = true;
            }

            else standalone = false;

            chkFullScreen.Checked = Settings.Default.FullScreen;
            ToggleScreenMode();

            xmlManager = XmlManager.Instance;
            dbManager = DBManager.Instance;
            dbManager.BindForm(this);
            startPanel = new LogPanel(tbpTracking, new Point(5,5));

            cboAccountAdminNew.SelectedItem = "Account";
            cboAccountAdminView.SelectedItem = "Accounts";
            //dgvTimeLogRequests.DataSource = ds;
            //cboAccountAdminView.SelectedValue = "Accounts";
            // Resize the DataGridView columns to fit the newly loaded content.
            dgvAdmin.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            //loads the path for the invoice export from app.config
            txtInvoiceExportPath.Text = Settings.Default["InvoicePath"].ToString();
            //set the current month in the export pdf combobox
            DateTime now = DateTime.Now;
            comboBoxSelectMonth.Text = ((now.ToString("MMMMMMMMM")));
            txtInvoiceExportPath.Text = Properties.Settings.Default.InvoicePath;
            //text export path
            txtInvoiceExportPath.Text = Properties.Settings.Default.InvoicePath;
            //load setting for glsu checkbox
            InitializeGLSUCheckbox();
            // Sets up the return keys for the manual entry tab


            InitializeRequestTab();

            if (userType == 'A' && !standalone) {
                InitializeBillingTab();
                InitializeSettingsTab();
                InitializeExportTab();
            } else if(userType == 'A' && standalone){
                InitializeSettingsTab();
                tabControlMain.TabPages.Remove(tabControlMain.TabPages["tbpBilling"]);
                tabControlMain.TabPages.Remove(tabControlMain.TabPages["tbpAccountAdmin"]);
            } else {
                tabControlMain.TabPages.Remove(tabControlMain.TabPages["tbpBilling"]);
                tabControlMain.TabPages.Remove(tabControlMain.TabPages["tbpAccountAdmin"]);
                tabControlMain.TabPages.Remove(tabControlMain.TabPages["tbpExports"]);
            }

            BindReturnKeys();
        }



        #region Billing Tab

        DataTable BillingExceptions;
        private void InitializeBillingTab() {
            editedRows = new List<int>();

            if (!standalone) {
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

                cboBillingSupplyName.DataSource = dbManager.GetSupplies();
                cboBillingSupplyName.DisplayMember = "Supply_Name";
                cboBillingSupplyName.ValueMember = "Supply_Name";

                cboBillingExceptions.SelectedIndex = 0;

                InitializeExceptionDGV();
            } else {
                //TO-DO Add XML to load accounts

            }
        }

        private void InitializeExceptionDGV() {
            // reset the edited rows because we are switching between time logs and supplies
            editedRows = new List<int>();

            if (cboBillingExceptions.SelectedItem.ToString() == "Time Logs") {
                BillingExceptions = dbManager.GetTimeLogsExceptions();

                BillingExceptions.Columns.Add(new DataColumn("Duration"));

                foreach (DataRow currentRow in BillingExceptions.Rows) {
                    if (currentRow["End_Time"].ToString() == "") continue;
                    TimeSpan duration = (DateTime)currentRow["End_Time"] - (DateTime)currentRow["Start_Time"];
                    currentRow["Duration"] = duration.TotalMinutes;
                }

                BillingExceptions.Columns.Remove("End_Time");

                dgvTimeLogRequests.DataSource = BillingExceptions;

                FindAndRenameDGVColumn("Account_Name", "Account Name", dgvTimeLogRequests);
                FindAndRenameDGVColumn("Account_Number", "Account Number", dgvTimeLogRequests);

                foreach (DataGridViewColumn col in dgvTimeLogRequests.Columns) {
                    if (!(col.Name == "Duration" || col.Name == "Approved")) {
                        col.ReadOnly = true;
                    }
                }

                dgvTimeLogRequests.Columns["Duration"].DisplayIndex = 4;
                dgvTimeLogRequests.Columns["Duration"].HeaderText = "Duration (min)";


                foreach (DataGridViewRow row in dgvTimeLogRequests.Rows) {
                    if (!(row.Cells["Duration"].Value.ToString() == "")) {
                        row.Cells["Duration"].ReadOnly = true;
                    }
                    if (!(row.Cells["Approved"].Value.ToString() == "")) {
                        row.Cells["Approved"].ReadOnly = true;
                    }
                }
            } else {
                BillingExceptions = dbManager.GetSupplyUseExceptions();

                dgvTimeLogRequests.DataSource = BillingExceptions;

                foreach (DataGridViewColumn col in dgvTimeLogRequests.Columns) {
                    if (col.Name != "Approved") {
                        col.ReadOnly = true;
                    }
                }


                foreach (DataGridViewRow row in dgvTimeLogRequests.Rows) {
                    if (!(row.Cells["Approved"].Value.ToString() == "")) {
                        row.Cells["Approved"].ReadOnly = true;
                    }
                }
            }

        }

        private void btnAdd_Click(object sender, EventArgs e) {
            int duration;
            if (!(int.TryParse(txtManualLogDuration.Text, out duration))) {
                txtManualLogDuration.BackColor = Color.Red;
                return;
            }

            if (cboManualLogFunding.Items.Count == 0) {
                cboManualLogFunding.BackColor = Color.Red;
                return;
            }

            cboManualLogFunding.BackColor = Color.White;
            txtManualTimeDuration.BackColor = Color.White;

            string accountNumber = cboManualLogFunding.SelectedValue.ToString();
            int instrumentID = int.Parse(cboManualLogInstrument.SelectedValue.ToString());
            int userID = int.Parse(cboManualLogUser.SelectedValue.ToString());
            DateTime startTime = dtpManualLog.Value;
            dtpManualLog.Value = DateTime.Now;
            DateTime endTime = startTime.AddMinutes(int.Parse(txtManualLogDuration.Text));

            if (dbManager.AddTimeLog(accountNumber, userID, 'Y', instrumentID, startTime, endTime)) {
                MessageBox.Show("Time log successfully added");
            } else {
                MessageBox.Show("There was an error executing your request. \r\n" +
                                "Please check your connection or contact your server admin");
            }
        }

        private void btnBillingSupplyAdd_Click(object sender, EventArgs e) {

            int quantity;

            if (!(int.TryParse(txtBillingSupplyQuantity.Text, out quantity))) {
                txtBillingSupplyQuantity.BackColor = Color.Red;
                return;
            }
            txtBillingSupplyQuantity.BackColor = Color.White;

            string accountNumber = cboBillingSupplyFunding.SelectedValue.ToString();
            string supplyName = cboBillingSupplyName.SelectedValue.ToString();
            DateTime serverTime;
            dbManager.GetServerDateTime(out serverTime);
            if (dbManager.AddSupplyUse(accountNumber, supplyName, serverTime, quantity, true)) {
                MessageBox.Show("Supply use successfully added");
            } else {
                MessageBox.Show("There was an error executing your request. \r\n" +
                "Please check your connection or contact your server admin");
            }
        }


        List<int> editedRows;
        private void dgvTimeLogRequests_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            if (dgvTimeLogRequests.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "") {
                editedRows.Remove(e.RowIndex);
            } else {
                editedRows.Add(e.RowIndex);
            }
        }

        // TO-DO: further test and make sure the errors looks good.
        private void btnSubmit_Click(object sender, EventArgs e) {
            bool error = false;

            foreach (int rowIndex in editedRows) {
                string approved = dgvTimeLogRequests.Rows[rowIndex].Cells["Approved"].Value.ToString();

                DataRow editedRow = BillingExceptions.Rows[rowIndex];

                bool success; // used for error checking

                if (cboBillingExceptions.SelectedItem.ToString() == "Time Logs") {///////////////// Start section for time exceptions
                    int minutesToAdd;
                    success = int.TryParse(dgvTimeLogRequests.Rows[rowIndex].Cells["Duration"].Value.ToString(), out minutesToAdd);

                    DateTime endTime = ((DateTime)editedRow["Start_Time"]).AddMinutes(minutesToAdd);


                    if (approved == "Y") {

                        dbManager.AddTimeLogEndTime(
                            editedRow["Account_Number"].ToString(),
                            int.Parse(editedRow["PersonID"].ToString()),
                            int.Parse(editedRow["InstrumentID"].ToString()),
                            (DateTime)editedRow["Start_Time"],
                            endTime);

                    } else if (approved == "N") {

                        dbManager.UpdateTimeLogApproval(
                            editedRow["Account_Number"].ToString(),
                            int.Parse(editedRow["PersonID"].ToString()),
                            int.Parse(editedRow["InstrumentID"].ToString()),
                            (DateTime)editedRow["Start_Time"],
                            'N');
                    } else if (approved == "") {

                    } else {
                        success = false;
                    }

                    if (!success) error = true;
                } else {/////////////////////////////////////////////////////////////////////////// Start section for supply exceptions



                    if (approved == "Y") {

                        dbManager.UpdateSupplyApproval(editedRow["Account_Number"].ToString(),
                            editedRow["Supply_Name"].ToString(),
                            (DateTime)editedRow["Date"],
                            'Y');

                    } else if (approved == "N") {

                        dbManager.UpdateSupplyApproval(editedRow["Account_Number"].ToString(),
                            editedRow["Supply_Name"].ToString(),
                            (DateTime)editedRow["Date"],
                            'N');
                    } else if (approved == "") {

                    } else {
                        success = false;
                    }
                }
            }
            if (error) MessageBox.Show("There was an error with the input values, please make sure you enter numbers only for duration and 'Y' / 'N' for Approved");
            editedRows = new List<int>();
            InitializeExceptionDGV();
        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            InitializeExceptionDGV();
        }

        private void cboBillingExceptions_SelectedIndexChanged(object sender, EventArgs e) {
            InitializeExceptionDGV();
        }


        #endregion  Billing Tab

        #region Admin Tab

        // Called in the onload of the tab page to prevent unnecessary calls to the DB5

        public void updateAdminDGV() {
            bool inactive = chkAdminIncludeInactive.Checked;

            if (cboAccountAdminView.SelectedItem == "Accounts") {
                dgvAdmin.DataSource = dbManager.GetAccounts(inactive);
            } else if (cboAccountAdminView.SelectedItem == "Contacts") {
                dgvAdmin.DataSource = dbManager.GetContacts();
            } else if (cboAccountAdminView.SelectedItem == "Users") {
                dgvAdmin.DataSource = dbManager.GetUsers();
            } else if (cboAccountAdminView.SelectedItem == "Instruments") {
                dgvAdmin.DataSource = dbManager.GetInstruments();
            } else if (cboAccountAdminView.SelectedItem == "Rate Types") {
                dgvAdmin.DataSource = dbManager.GetRateTypes();
            } else if (cboAccountAdminView.SelectedItem == "Supplies") {
                dgvAdmin.DataSource = dbManager.GetSupplies();
            }
        }

        private void btnAccountAdminNew_Click(object sender, EventArgs e) {
            string addNewCase = cboAccountAdminNew.Text;
            Form newForm = new NewEntryForm(addNewCase, this);
            newForm.ShowDialog(); //Displays forms modally
        }

        private void AdminDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            /*
            Accounts
            Contacts
            Users
            Instruments
            Rate Types
            Supplies
             */

            string primaryKey = "";
            string addNewCase = "";
            switch (cboAccountAdminView.Text) {
                case "Users":
                    primaryKey = dgvAdmin.Rows[e.RowIndex].Cells["PersonID"].Value.ToString();
                    addNewCase = "Edit User";

                    break;
                default:
                    return;

            }


            Form newForm = new NewEntryForm(addNewCase, this, primaryKey);
            newForm.ShowDialog(); //Displays forms modally

        }


        private void InitializeGLSUCheckbox() {
            if (Properties.Settings.Default.GLSUexport == "false") {
                chkGLSU.Checked = false;
            }
        }


        private void adminEditViewLoad(object sender, EventArgs e) {

            updateAdminDGV();

        }


        #endregion Admin Tab

        #region Settings Tab

        private void InitializeSettingsTab() {
            if (standalone) {
                chkStandalone.Checked = true;
            }
        }



        #endregion Settings Tab

        #region Export Tab

        private void InitializeExportTab() {
            if (!standalone) {
                comboBoxSelectAccount.DataSource = dbManager.GetAccounts();
                comboBoxSelectAccount.DisplayMember = "Name";
                comboBoxSelectAccount.ValueMember = "Account_Number";
            }
        }

        private void genPDF(int invoiceID) {

        }


        private void btnSetInvoiceExportPath_Click(object sender, EventArgs e) {
            if (InvoiceExportPath.ShowDialog() == DialogResult.OK) {

                Properties.Settings.Default.InvoicePath = InvoiceExportPath.SelectedPath;
                Properties.Settings.Default.Save();
                txtInvoiceExportPath.Text = InvoiceExportPath.SelectedPath;
            }

        }

        private void btnExportAll_Click(object sender, EventArgs e) {

            if (Settings.Default["InvoicePath"].ToString() == "") {
                MessageBox.Show("You have not selected the export path. Please select an export path first.");

            } else {
                //parse the date in the combobox and calculate the end of the month
                string date = comboBoxSelectMonth.Text;
                DateTime datetime = DateTime.ParseExact(date, "MMMMMMMM", CultureInfo.InvariantCulture);
                DateTime endtime = datetime.AddMonths(1);
                endtime = endtime.AddSeconds(-1);


                string offset = "";
                List<int> invoiceIDs;

                dbManager.GenerateAllInvoices(datetime, endtime, out invoiceIDs);

                PDFManager pdfManager = new PDFManager();
                foreach (int currentInvoice in invoiceIDs) {
                    ExportSingleInvoice(currentInvoice);
                }
            }
        }

        private void btnExportSingle_Click(object sender, EventArgs e) {
            if (Settings.Default["InvoicePath"].ToString() == "") {
                MessageBox.Show("You have not selected the export path. Please select an export path first.");

            } else {
                //parse the date in the combobox and calculate the end of the month
                string date = comboBoxSelectMonth.Text;
                DateTime datetime = DateTime.ParseExact(date, "MMMMMMMM", CultureInfo.InvariantCulture);
                DateTime endtime = datetime.AddMonths(1);
                endtime = endtime.AddSeconds(-1);

                int invoiceID;

                dbManager.GenerateInvoice(comboBoxSelectAccount.SelectedValue.ToString(), datetime, endtime, out invoiceID);

                //invoiceID = 396;

                ExportSingleInvoice(invoiceID);
            }

        }

        private void ExportSingleInvoice(int invoiceID) {
            PDFManager pdfManager = new PDFManager();
            pdfManager.GenerateInvoicePDF(invoiceID);


            DataTable invoice = dbManager.GetInvoice(invoiceID);
            bool excelgenar = (invoice.Rows[0]["Rate_Type"].ToString() == "Industry");

            if (chkGLSU.Checked == true) {
                //ExcelManager.generateAR(excelgenar);
                //ExcelManager.generateExcel(invoice);
            }
        }


        private void chkGLSU_Click(object sender, EventArgs e) {
            if (chkGLSU.Checked) {
                Properties.Settings.Default.GLSUexport = "true";
                Properties.Settings.Default.Save();
            } else {
                Properties.Settings.Default.GLSUexport = "false";
                Properties.Settings.Default.Save();
            }
        }

        private void chkStandalone_Click_1(object sender, EventArgs e) {
            //standalone mode on
            if (chkStandalone.Checked) {
                //
                DialogResult dialogResult = MessageBox.Show("In order to enable standalone mode, the application must restart. Any logs in progress will be lost. Do you want to continue?", "Standalone mode", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes) {
                    Properties.Settings.Default.StandaloneMode = "true";
                    Properties.Settings.Default.Save();
                    System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
                    this.Close();
                } else if (dialogResult == DialogResult.No) {
                    chkStandalone.Checked = false;
                    MessageBox.Show("Settings not changed, you are not in standalone mode.");

                }


            }
                //standalone mode off
            else {
                DialogResult dialogResult = MessageBox.Show("In order to disable standalone mode, the application must restart. Any logs in progress will be lost. Do you want to continue?", "Standalone mode", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes) {
                    Properties.Settings.Default.StandaloneMode = "false";
                    Properties.Settings.Default.Save();
                    System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
                    this.Close();
                } else if (dialogResult == DialogResult.No) {
                    chkStandalone.Checked = true;
                    MessageBox.Show("Settings not changed, you are still in standalone mode.");

                }
            }
        }

        private void chkFullScreen_Click(object sender, EventArgs e) {

            if (chkFullScreen.Checked) {
                Settings.Default.FullScreen = true;
                Settings.Default.Save();

            } else {
                Settings.Default.FullScreen = false;
                Settings.Default.Save();
            }

            DialogResult dialogResult = MessageBox.Show("You must restart for these settings to take effect. Any current sessions will be lost. Would you like to restart now?", "Full Screen", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) {
                System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
                this.Close();
            }
        }

        private void ToggleScreenMode() {
            if (Settings.Default.FullScreen) {
                this.FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            } else {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }

        }



        #endregion Export Tab

        #region Request Tab

        private void InitializeRequestTab() {
            if (Settings.Default.StandaloneMode == "false") {

                cboManualTimeInstrument.DataSource = dbManager.GetInstruments();
                cboManualTimeInstrument.DisplayMember = "Name";
                cboManualTimeInstrument.ValueMember = "InstrumentID";


                cboManualSupplyItem.DataSource = dbManager.GetSupplies();
                cboManualSupplyItem.DisplayMember = "Supply_Name";
                cboManualSupplyItem.ValueMember = "Supply_Name";
            } else {
                //TO-DO Add XML to load     

            }

            List<string> states = new List<string> { "", "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Delaware", "Florida", "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana", "Maine", "Maryland", "Massachusetts", "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota", "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota", "Tennessee", "Texas", "Utah", "Vermont", "Virginia", "Washington", "West Virginia", "Wisconsin", "Wyoming" };
            foreach (string s in states) {
                cboAcctManagementState.Items.Add(s);
            }

            cboAcctManagementState.SelectedIndex = 0;
        }

        private bool timeValid = false;
        private void btnManualTimeValidate_Click(object sender, EventArgs e) {
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
            if (pwValid) {
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
                    DataTable timeAcctTable = dbManager.GetUserAccounts(txtManualTimeUsername.Text);
                    if (timeAcctTable.Rows.Count == 0) {
                        MessageBox.Show("There are no accounts tied to this username.");
                        return;
                    }
                    cboManualTimeAccount.DataSource = timeAcctTable;
                    cboManualTimeAccount.DisplayMember = "Name";
                    cboManualTimeAccount.ValueMember = "Account_Number";

                }


                lblValidate.Visible = true;



                timeValid = true;
            } else {
                MessageBox.Show("Your username or password is incorrect.");
                txtManualTimeUsername.Focus();
            }
        }

        private void btnManualTimeAdd_Click(object sender, EventArgs e) {
            //this is for adding the time log user manual request log
            txtManualTimeDuration.BackColor = System.Drawing.Color.White;

            //RegEx pattern for duration field
            string durationPattern = "^[0-9]+$";

            if (!timeValid) {
                MessageBox.Show("Your log in information is not valid.  Please log in to continue.");
                txtManualTimeUsername.Focus();
            } else if (!System.Text.RegularExpressions.Regex.IsMatch(txtManualTimeDuration.Text, durationPattern)) {
                txtManualTimeDuration.BackColor = System.Drawing.Color.Red;
                MessageBox.Show("Please input a simple integer to represent the durations in minutes.");
            } else {

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
        private void btnManualSupplyValidate_Click(object sender, EventArgs e) {
            bool pwValid = false;


            string username = txtManualSupplyUsername.Text;
            string password = txtManualSupplyPassword.Text;
            //supplies manual request log in validation

            if (standalone) {
                pwValid = xmlManager.CheckPassword(username, password);
            } else {
                pwValid = dbManager.CheckPassword(username, password);
            }



            if (pwValid) {
                if (standalone) {
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
                } else {
                    DataTable accounts = dbManager.GetUserAccounts(txtManualTimeUsername.Text);
                    if (accounts.Rows.Count == 0) {
                        MessageBox.Show("There are no accounts tied to this username.");
                        return;
                    }
                    cboManualSupplyAccount.DataSource = accounts;

                    cboManualSupplyAccount.DisplayMember = "Name";
                    cboManualSupplyAccount.ValueMember = "Account_Number";
                }



                label12.Visible = true;
                supplyValid = true;

            } else {
                MessageBox.Show("Your username or password is incorrect.");
                txtManualSupplyUsername.Focus();
            }
        }

        private void btnManualSupplyAdd_Click(object sender, EventArgs e) {
            //this is for adding the supplies user manual request log
            txtManualSupplyQuantity.BackColor = System.Drawing.Color.White;

            //RegEx pattern for the quantity field
            string quantityPattern = "^[0-9]+$";

            if (!supplyValid) {
                MessageBox.Show("Your log in information is not valid.  Please log in to continue.");
                txtManualSupplyUsername.Focus();
            } else if (!System.Text.RegularExpressions.Regex.IsMatch(txtManualSupplyQuantity.Text, quantityPattern)) {
                txtManualSupplyQuantity.BackColor = System.Drawing.Color.Red;
                MessageBox.Show("Please input a simple integer to represent the quantity in the unit of measurement appropriate.");
                txtManualSupplyQuantity.Focus();
            } else {
                string username = txtManualSupplyUsername.Text;
                string account = cboManualSupplyAccount.SelectedValue.ToString();
                if (standalone) {

                    //adds the supply use log 
                    cboManualSupplyItem.SelectedValue.ToString();
                    string quantity = txtManualSupplyQuantity.Text;
                    string item = cboManualSupplyItem.SelectedItem.ToString();
                    xmlManager.AddSupplyUse(DateTime.Now.ToString(), account, item, quantity);
                } else {
                    DateTime serverTime;
                    dbManager.GetServerDateTime(out serverTime);
                    dbManager.AddSupplyUse(account, cboManualSupplyItem.SelectedValue.ToString(), serverTime, int.Parse(txtManualSupplyQuantity.Text));
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

        // Check any fields in Account Management that are not blank
        private bool validateAccountRequest() {
            bool error = false;

            txtAcctManagementPhone.BackColor = System.Drawing.Color.White;
            txtAcctManagementZip.BackColor = System.Drawing.Color.White;
            txtAcctManagementCity.BackColor = System.Drawing.Color.White;
            txtAcctManagementStreet.BackColor = System.Drawing.Color.White;
            txtAcctManagementEmail.BackColor = System.Drawing.Color.White;
            txtAcctManagementNewPw.BackColor = System.Drawing.Color.White;
            txtAcctManagementConfirmPw.BackColor = System.Drawing.Color.White;

            // Phone
            string phonePattern = "^\\D?(\\d{3})\\D?\\D?(\\d{3})\\D?(\\d{4})$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtAcctManagementPhone.Text, phonePattern) && txtAcctManagementPhone.Text != "") {
                txtAcctManagementPhone.BackColor = System.Drawing.Color.Red;
                error = true;
            }

            // Zip
            string zipPattern = "^([0-9]{5})\\-?([0-9]{4})?$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtAcctManagementZip.Text, zipPattern) && txtAcctManagementZip.Text != "") {
                txtAcctManagementZip.BackColor = System.Drawing.Color.Red;
                error = true;
            }

            // City
            string cityPattern = "^[A-Za-z\\s-\\.]+$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtAcctManagementCity.Text, cityPattern) && txtAcctManagementCity.Text != "") {
                txtAcctManagementCity.BackColor = System.Drawing.Color.Red;
                error = true;
            }

            // Street
            string streetPattern = "^[\\w\\s-\\.]+$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtAcctManagementStreet.Text, streetPattern) && txtAcctManagementStreet.Text != "") {
                txtAcctManagementStreet.BackColor = System.Drawing.Color.Red;
                error = true;
            }

            //Email
            string emailPattern = "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtAcctManagementEmail.Text, emailPattern) && txtAcctManagementEmail.Text != "") {
                txtAcctManagementEmail.BackColor = System.Drawing.Color.Red;
                error = true;
            }

            // New Password
            string passwordPattern = "^([1-zA-Z0-1@.\\s]{5,20})$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtAcctManagementNewPw.Text, passwordPattern) && txtAcctManagementNewPw.Text != "") {
                txtAcctManagementNewPw.BackColor = System.Drawing.Color.Red;
                error = true;

            }

            // Confirm Password
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtAcctManagementConfirmPw.Text, passwordPattern) && txtAcctManagementConfirmPw.Text != "") {
                txtAcctManagementConfirmPw.BackColor = System.Drawing.Color.Red;
                error = true;
            }

            if (txtAcctManagementConfirmPw.Text != txtAcctManagementNewPw.Text) error = true;

            return error;

        }

        private void txtAcctManagementConfirmPw_TextChanged(object sender, EventArgs e) {
            if (txtAcctManagementConfirmPw.Text != txtAcctManagementNewPw.Text) {
                lblAcctManagementPwMessage.Text = "Passwords don't match";
            } else {
                lblAcctManagementPwMessage.Text = "";
            }

        }

        private void txtAcctManagementNewPw_TextChanged(object sender, EventArgs e) {
            if (txtAcctManagementNewPw.Text != txtAcctManagementConfirmPw.Text && txtAcctManagementConfirmPw.Text != "") {
                lblAcctManagementPwMessage.Text = "Passwords don't match";
            } else {
                lblAcctManagementPwMessage.Text = "";
            }
        }

        private void bnAcctManagementSubmit_Click(object sender, EventArgs e) {
            bool error = false;
            string errorMessage = "";
            if (!dbManager.CheckPassword(txtAcctManagementUserame.Text, txtAcctManagementPassword.Text)) {
                error = true;
                errorMessage += "Username or password invalid. \r\n\r\n";
            }

            if (validateAccountRequest()) {
                error = true;
                errorMessage += "There were errors on the form, please correct them and submit again.";
            }

            if (!error) {
                int userID = dbManager.GetUserID(txtAcctManagementUserame.Text);

                string state;
                if (cboAcctManagementState.SelectedItem == null) state = "";
                else state = cboAcctManagementState.SelectedItem.ToString();

                dbManager.UpdateUser(userID, "", "", txtAcctManagementStreet.Text, txtAcctManagementCity.Text, state,
                    txtAcctManagementZip.Text, txtAcctManagementPhone.Text, txtAcctManagementEmail.Text, "", txtAcctManagementNewPw.Text, "", "", "");

                ClearAcctManagementFields();
            } else {
                MessageBox.Show(errorMessage);
            }
        }

        private void ClearAcctManagementFields() {
            txtAcctManagementStreet.Clear();
            txtAcctManagementPassword.Clear();
            txtAcctManagementStreet.Clear();
            txtAcctManagementCity.Clear();
            txtAcctManagementZip.Clear();
            txtAcctManagementPhone.Clear();
            txtAcctManagementEmail.Clear();
            txtAcctManagementNewPw.Clear();
            txtAcctManagementConfirmPw.Clear();
            cboAcctManagementState.SelectedIndex = 0;
        }

        #endregion Request Tab




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


        private void frmCUITAdminMain_Resize(object sender, EventArgs e) {
            tabControlMain.Location = new Point((this.Size.Width / 2) - (tabControlMain.Size.Width / 2) - 7,
                                    (this.Size.Height / 2) - (tabControlMain.Size.Height / 2) - 19);
        }


        private void btnExportStandaloneFile_Click(object sender, EventArgs e) {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK) {
                xmlManager.CreateLogFile(dialog.SelectedPath);
            }
        }

        private void btnImportLogs_Click(object sender, EventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK) {

                // Create the 2 tables that you will send to the server
                DataTable timeLogs = new DataTable();
                DataTable supplyUses = new DataTable();

                foreach (string currentFile in dialog.FileNames) {

                    // Create the 2 tables that you will send to the server
                    DataTable currentTimeLogs = xmlManager.ImportTimeLogs(currentFile);
                    DataTable currentSupplyUses = xmlManager.ImportSupplyUse(currentFile);

                    // Get the additional information to fill in all rows
                    DataTable timeLogImportData = dbManager.GetImportDataTimeLog();
                    DataTable supplyUseImportData = dbManager.GetImportDataSupplyUse();

                    // Loop through and add the rate and time increment to each timelog
                    foreach (DataRow row in currentTimeLogs.Rows) {
                        foreach (DataRow importRow in timeLogImportData.Rows) {
                            if (importRow["Account_Number"].ToString() == row["Account_Number"].ToString() &&
                                importRow["InstrumentID"].ToString() == row["InstrumentID"].ToString()) {
                                row["Current_Rate"] = importRow["Rate"];
                                row["Time_Increment"] = importRow["Time_Increment"];
                            }
                        }
                    }

                    // Loop through and add the cost to each supply use
                    foreach (DataRow row in currentSupplyUses.Rows) {
                        foreach (DataRow importRow in supplyUseImportData.Rows) {
                            if (importRow["Supply_Name"].ToString() == row["Supply_Name"].ToString()) {
                                row["Current_Cost"] = importRow["Cost"];
                            }
                        }
                    }

                    timeLogs.Merge(currentTimeLogs);
                    supplyUses.Merge(currentSupplyUses);
                }

                // send the imports to the server
                dbManager.AddTimeLogBulk(timeLogs);
                dbManager.AddSupplyUseBulk(supplyUses);
            }
        }

        private void chkAdminIncludeInactive_CheckedChanged(object sender, EventArgs e) {
            updateAdminDGV();
        }

    }
}
