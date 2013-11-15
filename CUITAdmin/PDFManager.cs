using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using CUITAdmin.Properties;
using System.Data.SqlClient;

namespace CUITAdmin
{
    public sealed class PDFManager
    {

        private static readonly object padlock = new object();
        //template pdf file in same directory as executable
        private static string PDF_TEMPLATE = @"invoicetemplate.pdf";
        PdfReader pdfReader;
        PdfStamper pdfStamper;
        AcroFields pdfFormFields;
        private static string filename = @"default.pdf";
        private static string pathname = Settings.Default["InvoicePath"].ToString() + @"\Invoices\" + (DateTime.Now.Year);
        private static string fullpath = pathname + filename;
        private static bool path = true;

        public PDFManager()

            //filename of exported invoiceis stored in app.config. 
            //If the program has not been used on the user's
            //computer before, the path will default to the user's desktop.
            //TODO: make filename set to invoiceID
            : this(filename, path)
        {
        }

        //change the pdf tempalte to instrument use
        public void ChangeTemplateInst(bool useInstTemplate)
        {

            if (useInstTemplate == true)
            {

                PDF_TEMPLATE = @"servicetemplate.pdf";
            }

        }

        public PDFManager(string newFile, bool path, string fileType = "")
        {

            switch (fileType)
            {
                case "timelog":
                    PDF_TEMPLATE = @"servicetemplate.pdf";
                    break;
                case "invoice":
                    PDF_TEMPLATE = @"invoicetemplate.pdf";
                    break;
            }

            changeDirectoryRate(path);

            CreateFolderifDoesNotExist();
            // open the invoice template using PdfReader
            pdfReader = new PdfReader(PDF_TEMPLATE);

            pdfStamper = new PdfStamper(pdfReader, new FileStream(
                          pathname + "\\" + newFile, FileMode.Create));
            pdfFormFields = pdfStamper.AcroFields;

        }



        // crete the directory if it does not exist (/Invoices/[currentyear])
        public void CreateFolderifDoesNotExist()
        {
            if (!Directory.Exists(pathname))
            {
                Directory.CreateDirectory(pathname);
            }
        }

        public void PDFClose()
        {
            //makes the pdf file uneditable
            pdfStamper.FormFlattening = true;
            //close the file stream
            pdfStamper.Close();
            //Display success message with the file path in the message
            MessageBox.Show("Export Complete! \n" + "File has been exported to:\n" + pathname);

        }

        //if the rate is external, place the invoice in the accounts receivable folder
        public void changeDirectoryRate(bool exists)
        {
            if (exists == true)
            {

                if (!Directory.Exists(pathname + @"\Accounts Receivable"))
                {
                    Directory.CreateDirectory(pathname + @"\Accounts Receivable");
                }
            }



        }
        //////// Add instrument info instrument use pdf////////////
        public void AddInstrument(string instrumentName, string usedDate, string usedDuration, string usedRate)
        {
            string fieldInst = pdfFormFields.GetField("instrument");
            string fieldDate = pdfFormFields.GetField("date");
            string fieldDuration = pdfFormFields.GetField("duration");
            string fieldRate = pdfFormFields.GetField("rate");

            pdfFormFields.SetField("instrument", fieldInst + instrumentName + "\r\n\r\n\r\n");
            pdfFormFields.SetField("date", fieldDate + usedDate + "\r\n\r\n");
            pdfFormFields.SetField("duration", fieldDuration + usedDuration + "\r\n\r\n\r\n");
            pdfFormFields.SetField("rate", fieldRate + usedRate + "\r\n\r\n\r\n");
        }

        // Add Page Number //////////////
        public void InsertPageNumber(string CurrentPage, string TotalPages)
        {

            pdfFormFields.SetField("PageNumber", CurrentPage + " of " + TotalPages);
        }

        // Add Address //////////////
        public void AddAddress(string name, string street, string city, string state, string zip)
        {

            pdfFormFields.SetField("Address", name + Environment.NewLine
               + street + Environment.NewLine + city + ", " + state + " " + zip);
        }

        //Add postdate/////////////
        public void AddPostDate(string postStartDate, string postEndDate)
        {

            pdfFormFields.SetField("services", "Post Start Date: " + postStartDate + Environment.NewLine + "Post End Date: " + postEndDate + Environment.NewLine + Environment.NewLine);


        }

        public int ServiceLines()
        {
            return pdfFormFields.GetField("services").Split('\n').Length;
        }

        //Add Service//////////////
        public void AddService(string service, string unitquantity, string rate, string unit)
        {

            string field = pdfFormFields.GetField("services");
            //old code
            //pdfFormFields.SetField("services", service +
            //Environment.NewLine + "(" + postStartDate + ", " 
            //+ unitquantity + " " + unit + "s" + " @ $" + rate + "/" + unit + "" + ")" +
            //Environment.NewLine + Environment.NewLine); 
            ///
            pdfFormFields.SetField("services", field + service
             + Environment.NewLine + "(" + unitquantity + " " + unit + "s" + " @ $" + rate
             + "/" + unit + "" + ")" + Environment.NewLine + Environment.NewLine);



        }
        //add charge////////////////////
        public void AddCharge(string chargeamount)
        {
            string field = pdfFormFields.GetField("charges");

            pdfFormFields.SetField("charges", "\n\r\n\n" + field + "$" + chargeamount + "\r\n\r\n\r");
        }
        //add balance/////////////////////
        public void AddBalance(string balance)
        {


            // pdfFormFields.SetField("balance", Environment.NewLine + Environment.NewLine + Environment.NewLine +
            //     Environment.NewLine + balance);
            pdfFormFields.SetField("balance", "\n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \r" + balance);

        }
        //add date/////////////////////////
        public void AddDate(string Date)
        {

            pdfFormFields.SetField("Date", Date);
        }
        //add invoiceID/////////////////////////
        public void AddInvoiceID(string invoiceID)
        {

            pdfFormFields.SetField("FillText1", invoiceID);
        }

        public void GenerateOldInvoice(int invoiceNumber)
        {
            DBManager dbManager = DBManager.Instance;
            //MessageBox.Show(endtime.ToString());
            //the offset 
            string offset = "";
            //int invoiceID;
            //dbManager.GenerateInvoice("1", DateTime.Now.AddDays(-5), DateTime.Now, out invoiceID);

            DataTable invoice = dbManager.GetInvoice(invoiceNumber);
            DataTable invoiceTime = dbManager.GetInvoiceTimeLine(invoiceNumber);
            DataTable invoiceSupply = dbManager.GetInvoiceSupplyLine(invoiceNumber);
            DataTable getacc = dbManager.GetAccountsForExport();
            //convert date time to invoice friendly format
            DateTime poststart = DateTime.Parse(invoice.Rows[0]["Posting_Start_Date"].ToString());
            DateTime postend = DateTime.Parse(invoice.Rows[0]["Posting_End_Date"].ToString());
            //MessageBox.Show(test.ToShortDateString().ToString());

            // try
            // {


            //pdfManager.AddAddress("Name", "Street", "City", "State", "Zip");
            AddAddress(getacc.Rows[0]["Name"].ToString(),
                getacc.Rows[0]["Street"].ToString(), //add street to invocie
                getacc.Rows[0]["City"].ToString(), // add city to invoice
                getacc.Rows[0]["State"].ToString(), //add state to invoice
                getacc.Rows[0]["Zip"].ToString()); //add zip to invoice

            //pdfManager.AddService("Instrument", "StartPostDate", "EndPostDate","hours", "rate ($/hr)", "unit(hours days ects)");
            foreach (DataRow currentRow in invoiceTime.Rows)
            {

                AddService(
                    currentRow["Name"].ToString(), //insert time into the invoice
                    currentRow["Hours"].ToString(), //insert hours into invoice
                    currentRow["Rate"].ToString(), //insert dollars per hour into invoice
                    "day");// unit of biling displayed on invoice
                AddCharge(currentRow["Line_Amount"].ToString()); //add charge to invoice
                offset += "\r\n\r\n";
            }

            AddDate(DateTime.Now.ToString()); //Add todays date to the invoice
            AddInvoiceID(invoice.Rows[0]["InvoiceID"].ToString()); // add invoice id to invoice
            //AddBalance(offset + "$" + invoice.Rows[0]["Total_Balance"].ToString()); // add balance to invoice
            AddBalance("$" + invoice.Rows[0]["Total_Balance"].ToString()); // add balance to invoice


        }

        public void GenerateInvoicePDF(int invoiceID)
        {
            DBManager mymanager = DBManager.Instance;
            DataTable invoice = mymanager.GetInvoice(invoiceID);
            if (invoice.Rows.Count == 0)
            {

                MessageBox.Show("No invoices");
                return;
            }

            DataTable invoiceTime = mymanager.GetInvoiceTimeLine(invoiceID);
            DataTable invoiceSupply = mymanager.GetInvoiceSupplyLine(invoiceID);
            //convert date time to invoice friendly format

            string accounttype = (invoice.Rows[0]["Rate_Type"].ToString());
            //string timeIncriment = (invoice.Rows[0]["Time_Increment"].ToString());
            //MessageBox.Show(timeIncriment);
            //MessageBox.Show(accounttype);
            string exportpath = "Invoice - " + invoiceID + ".pdf";
            bool path = false;
            bool excelgenar = false;

            // try
            // {
            //if the rate is industry, then add an accounts receivable folder
            if (accounttype == "Industry")
            {
                //pdfManager.changeDirectoryRate(true);
                exportpath = @"Accounts Receivable\Invoice - " + invoiceID + ".pdf";
                path = true;
                excelgenar = true;
            }

            GeneratePDF(invoice, invoiceTime, exportpath, path);
        }

        public void GenerateInstrumentUsePDF()
        {

        }

        public void GenerateSupplyUsePDF()
        {

        }

        public string GeneratePDF(DataTable invoice, DataTable invoiceTime, string exportpath, bool path)
        {
            string offset = "";
            DateTime poststart = DateTime.Parse(invoice.Rows[0]["Posting_Start_Date"].ToString());
            DateTime postend = DateTime.Parse(invoice.Rows[0]["Posting_End_Date"].ToString());
            PDFManager pdfManager = new PDFManager(exportpath, path, "invoice");

            //pdfManager.AddAddress("Name", "Street", "City", "State", "Zip");
            pdfManager.AddAddress(invoice.Rows[0]["Name"].ToString(),
                invoice.Rows[0]["Street"].ToString(), //add street to invocie
                invoice.Rows[0]["City"].ToString(), // add city to invoice
                invoice.Rows[0]["State"].ToString(), //add state to invoice
                invoice.Rows[0]["Zip"].ToString()); //add zip to invoice

            pdfManager.InsertPageNumber("4", "5");



            //pdfManager.AddService("Instrument", "StartPostDate", "EndPostDate","hours", "rate ($/hr)", "unit(hours days ects)");

            pdfManager.AddPostDate(poststart.ToShortDateString().ToString(), postend.ToShortDateString().ToString());

            while (invoiceTime.Rows.Count > 0)
            {
                DataRow currentRow = invoiceTime.Rows[0];
                double computedRate = Convert.ToDouble(currentRow["Line_Amount"]) / Convert.ToDouble(currentRow["Hours"]);


                pdfManager.AddService(
                    currentRow["Name"].ToString(), //insert time into the invoice
                    currentRow["Hours"].ToString(), //insert hours into invoice
                    computedRate.ToString(), //insert dollars per hour into invoice
                    "hour");// unit of biling displayed on invoice
                pdfManager.AddCharge(currentRow["Line_Amount"].ToString()); //add charge to invoice
                offset += "\r\n\r\n";
                invoiceTime.Rows.RemoveAt(0);
            }

            string services = pdfManager.GetFieldByName("services");
            string services2 = pdfManager.GetFieldByName("charge");

            string[] serviceLines = services.Split('\n');

            for (int i = 0; i < services.Length; i++) { }

                pdfManager.AddDate(DateTime.Now.ToString()); //Add todays date to the invoice
            pdfManager.AddInvoiceID(invoice.Rows[0]["InvoiceID"].ToString()); // add invoice id to invoice
            pdfManager.AddBalance(offset + "$" + invoice.Rows[0]["Total_Balance"].ToString()); // add balance to invoice

            pdfManager.PDFClose();
            return offset;
        }


        internal string GetFieldByName(string fieldName)
        {
            return pdfFormFields.GetField(fieldName);
        }
    }
}

