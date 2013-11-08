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
        private const string PDF_TEMPLATE = @"invoicetemplate.pdf";
        PdfReader pdfReader;
        PdfStamper pdfStamper;
        AcroFields pdfFormFields;
        private static string filename = @"default.pdf";
        private static string pathname = Settings.Default["InvoicePath"].ToString() + @"\Invoices\" + (DateTime.Now.Year);
        private static string fullpath = pathname + filename;
       
        public PDFManager()
            
            //filename of exported invoiceis stored in app.config. 
            //If the program has not been used on the user's
            //computer before, the path will default to the user's desktop.
            //TODO: make filename set to invoiceID
            : this(filename)
        {
        }

       
       public PDFManager(string newFile){

           CreateFolderifDoesNotExist();
            // open the invoice template using PdfReader
            pdfReader = new PdfReader(PDF_TEMPLATE);

            pdfStamper = new PdfStamper(pdfReader, new FileStream(
                          pathname + "\\" + newFile, FileMode.Create));
            pdfFormFields = pdfStamper.AcroFields;

        }


       public bool GeneratePDF(int invoiceID){
           DBManager dbManager = DBManager.Instance;

           string offset = "";
           DataTable invoice = dbManager.GetInvoice(invoiceID);
           if (invoice.Rows.Count == 0) return false;
           DataTable invoiceTime = dbManager.GetInvoiceTimeLine(invoiceID);
           DataTable invoiceSupply = dbManager.GetInvoiceSupplyLine(invoiceID);
           DataTable getacc = dbManager.GetAccounts();
           //convert date time to invoice friendly format
           DateTime poststart = DateTime.Parse(invoice.Rows[0]["Posting_Start_Date"].ToString());
           DateTime postend = DateTime.Parse(invoice.Rows[0]["Posting_End_Date"].ToString());
           //MessageBox.Show(test.ToShortDateString().ToString());


           //AddAddress("Name", "Street", "City", "State", "Zip");
           AddAddress(getacc.Rows[0]["Name"].ToString(),
               getacc.Rows[0]["Street"].ToString(), //add street to invocie
               getacc.Rows[0]["City"].ToString(), // add city to invoice
               getacc.Rows[0]["State"].ToString(), //add state to invoice
               getacc.Rows[0]["Zip"].ToString()); //add zip to invoice

           //AddService("Instrument", "StartPostDate", "EndPostDate","hours", "rate ($/hr)", "unit(hours days ects)");

           AddPostDate(poststart.ToShortDateString().ToString(), postend.ToShortDateString().ToString());

           foreach (DataRow currentRow in invoiceTime.Rows)
           {

               AddService(
                   currentRow["Name"].ToString(), //insert time into the invoice
                   poststart.ToShortDateString().ToString(), //insert start date into invoice
                   postend.ToShortDateString().ToString(),  //insert end date into invoice
                   currentRow["Hours"].ToString(), //insert hours into invoice
                   currentRow["Rate"].ToString(), //insert dollars per hour into invoice
                   "hour");// unit of biling displayed on invoice
               AddCharge(currentRow["Line_Amount"].ToString()); //add charge to invoice
               offset += "\r\n\r\n";
           }

           AddDate(DateTime.Now.ToString()); //Add todays date to the invoice
           AddInvoiceID(invoice.Rows[0]["InvoiceID"].ToString()); // add invoice id to invoice
           AddBalance(offset + "$" + invoice.Rows[0]["Total_Balance"].ToString()); // add balance to invoice

           PDFClose();
           return true;
       }



       // crete the directory if it does not exist (/Invoices/[currentyear])
       public void CreateFolderifDoesNotExist()
       {
          if (!Directory.Exists(pathname))
           {             
               Directory.CreateDirectory(pathname );
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
        // Add Address //////////////
        public void AddAddress(string name, string street, string city, string state, string zip )
        {
            
            pdfFormFields.SetField("Address", name + Environment.NewLine
               + street + Environment.NewLine + city +", "+ state +" "+ zip);
        }

        //Add postdate/////////////
        public void AddPostDate(string postStartDate, string postEndDate) {

            pdfFormFields.SetField("services", "Post Start Date: " + postStartDate + Environment.NewLine + "Post End Date: " + postEndDate + Environment.NewLine + Environment.NewLine);
             
        
        }


        //Add Service//////////////
        public void AddService(string service, string postStartDate, string postEndDate, string unitquantity, string rate, string unit)
        {
            
            string field = pdfFormFields.GetField("services");
            //old code
            //pdfFormFields.SetField("services", service +
            //Environment.NewLine + "(" + postStartDate + ", " 
            //+ unitquantity + " " + unit + "s" + " @ $" + rate + "/" + unit + "" + ")" +
            //Environment.NewLine + Environment.NewLine); 
            ///
            pdfFormFields.SetField("services", field + service 
             + Environment.NewLine+ "("+ unitquantity +" "  + unit + "s" + " @ $" + rate 
             + "/" + unit + "" + ")" + Environment.NewLine + Environment.NewLine);



        }
        //add charge////////////////////
        public void AddCharge(string chargeamount)
        {
            string field = pdfFormFields.GetField("charges");

            pdfFormFields.SetField("charges", "\n\r\n" +field + "$" + chargeamount + "\r\n\r\n\r");                   
        }
        //add balance/////////////////////
        public void AddBalance(string balance)
        {
           

            pdfFormFields.SetField("balance", Environment.NewLine + Environment.NewLine + Environment.NewLine +
                Environment.NewLine + balance);
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

        public void GenerateOldInvoice(int invoiceNumber) {
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
                    poststart.ToShortDateString().ToString(), //insert start date into invoice
                    postend.ToShortDateString().ToString(),  //insert end date into invoice
                    currentRow["Hours"].ToString(), //insert hours into invoice
                    currentRow["Rate"].ToString(), //insert dollars per hour into invoice
                    "day");// unit of biling displayed on invoice
                AddCharge(currentRow["Line_Amount"].ToString()); //add charge to invoice
                offset += "\r\n\r\n";
            }

            AddDate(DateTime.Now.ToString()); //Add todays date to the invoice
            AddInvoiceID(invoice.Rows[0]["InvoiceID"].ToString()); // add invoice id to invoice
            AddBalance(offset + "$" + invoice.Rows[0]["Total_Balance"].ToString()); // add balance to invoice

        }

              
       }
}

