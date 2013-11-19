using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CUITAdmin.Properties;
using System.Globalization;

namespace CUITAdmin {
    public partial class UserControl1 : UserControl {

        frmCUITAdminMain mainForm;

        public UserControl1(frmCUITAdminMain mainForm) {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        bool standalone;
        XmlManager xmlManager;
        DBManager dbManager;
        private System.Windows.Forms.FolderBrowserDialog InvoiceExportPath;

        private void UserControl1_Load(object sender, EventArgs e) {
            standalone = Settings.Default.StandaloneMode;
            dbManager = DBManager.Instance;
            xmlManager = XmlManager.Instance;
            this.InvoiceExportPath = new System.Windows.Forms.FolderBrowserDialog();
        }



        private void InitializeExportTab() {
            if (!standalone) {
                comboBoxSelectAccount.DataSource = dbManager.GetAccounts();
                comboBoxSelectAccount.DisplayMember = "Name";
                comboBoxSelectAccount.ValueMember = "Account_Number";
            }
        }

        private void InitializeSettingsTab() {
            if (standalone) {
                chkStandalone.Checked = true;
                btnExportSingle.Enabled = false;
                btnExportAll.Enabled = false;
                btnExportStandaloneFile.Enabled = false;
                btnImportLogs.Enabled = false;
                comboBoxSelectAccount.Enabled = false;
                comboBoxSelectMonth.Enabled = false;
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

            if (standalone) {

            } else {
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

                    //invoiceID = 405;

                    ExportSingleInvoice(invoiceID);
                }
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

        private void chkStandalone_Click(object sender, EventArgs e) {
            //standalone mode on
            if (chkStandalone.Checked) {
                //
                DialogResult dialogResult = MessageBox.Show("In order to enable standalone mode, the application must restart. Any logs in progress will be lost. Do you want to continue?", "Standalone mode", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes) {
                    Properties.Settings.Default.StandaloneMode = true;
                    Properties.Settings.Default.Save();
                    System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
                    Application.Exit();
                } else if (dialogResult == DialogResult.No) {
                    chkStandalone.Checked = false;
                    MessageBox.Show("Settings not changed, you are not in standalone mode.");

                }


            }
                //standalone mode off
            else {
                DialogResult dialogResult = MessageBox.Show("In order to disable standalone mode, the application must restart. Any logs in progress will be lost. Do you want to continue?", "Standalone mode", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes) {
                    Properties.Settings.Default.StandaloneMode = false;
                    Properties.Settings.Default.Save();
                    System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
                    Application.Exit();
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
                Application.Exit();
            }
        }

        private void ToggleScreenMode() {
            mainForm.ToggleScreenMode();

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

        private void btnExportStandaloneFile_Click(object sender, EventArgs e) {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK) {
                xmlManager.CreateLogFile(dialog.SelectedPath);
            }
        }

    }
}
