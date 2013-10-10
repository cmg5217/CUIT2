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

namespace CUITAdmin
{
    public partial class frmCUITAdminMain : Form
    {
        
        public static string CONFIG_FILE = "";
        private bool standalone = false;
        private string accountType;
        LogPanel startPanel;

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

            textBox2.Text = Properties.Settings.Default.InvoicePath;
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
    }
}

