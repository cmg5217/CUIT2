using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        PDFManager pdfManager;

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
            standalone = true;



            startPanel = new LogPanel(tbpTracking, new Point(5,5));      
  

            cboAccountAdminNew.SelectedItem = "Account";
            cboAccountAdminView.SelectedItem = "Accounts";
            DataGridViewCell editCell = dgvTimeLogRequests.Rows[0].Cells[6];
            editCell.Value = "test";

            //loads the path for the invoice export from app.config
            textBox2.Text = Settings.Default["InvoicePath"].ToString();

            
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
                textBox2.Text = InvoiceExportPath.SelectedPath;
                Settings.Default["InvoicePath"] = button5.Text;
                Settings.Default.Save();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pdfManager = new PDFManager();
            pdfManager.AddAddress("David Stephens", "1856 Us 62", "Oil City", "PA", "16301");
            pdfManager.AddService("Atomic Force", "Aug. 2013", "12", "27", "hour");
            pdfManager.AddDate("January 2014");
            pdfManager.AddInvoiceID("Invoice 234");
            pdfManager.AddBalance("529");
            pdfManager.AddCharge("529");
            pdfManager.QueryDatabase("January");
            pdfManager.PDFClose();  
         
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
                textBox2.Text = InvoiceExportPath.SelectedPath;
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

        private void btnPreview_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}

