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
using System.Diagnostics;

namespace CUITAdmin
{
    public sealed class PDFManager
    {

        private static readonly object padlock = new object();
        //template pdf file in same directory as executable
        private const string INVOICE_TEMPLATE = @"invoicetemplate.pdf";

        private static string filename = @"default.pdf";
        private static string pathname = Settings.Default["InvoicePath"].ToString() + @"\Invoices\" + (DateTime.Now.Year) + @"\";
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

        }

        public PDFManager(string newFile, bool path, string fileType = "")
        {

        }



        // crete the directory if it does not exist (/Invoices/[currentyear])
        public void CreateFolderifDoesNotExist()
        {
            if (!Directory.Exists(pathname))
            {
                Directory.CreateDirectory(pathname + @"Accounts Receivable\");
            }
        }

        public void PDFClose()
        {
            //makes the pdf file uneditable
            //pdfStamper.FormFlattening = true;
            //close the file stream
           // pdfStamper.Close();
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

        public void AddInstrument(AcroFields acroFields, string instrumentName, string usedDate, string usedDuration, string usedRate)
        {
            // get the previous values so that we can append vs override
            string fieldInst = acroFields.GetField("instrument");
            string fieldDate = acroFields.GetField("date");
            string fieldDuration = acroFields.GetField("duration");
            string fieldRate = acroFields.GetField("rate");

            acroFields.SetField("instrument", fieldInst + instrumentName + "\r\n\r\n\r\n");
            acroFields.SetField("date", fieldDate + usedDate + "\r\n\r\n");
            acroFields.SetField("duration", fieldDuration + usedDuration + "\r\n\r\n\r\n");
            acroFields.SetField("rate", fieldRate + usedRate + "\r\n\r\n\r\n");
        }

        // Add Page Number //////////////
        public void InsertPageNumber(AcroFields field, int CurrentPage, int TotalPages)
        {
            field.SetField("PageNumber", CurrentPage.ToString() + " of " + TotalPages.ToString());
        }

        // Add Address //////////////
        public void AddAddress(AcroFields pdfFormFields, string name, string street, string city, string state, string zip)
        {

            pdfFormFields.SetField("Address", name + Environment.NewLine
               + street + Environment.NewLine + city + ", " + state + " " + zip);
        }

        //Add postdate/////////////
        public void AddPostDate(AcroFields acroFields, string postStartDate, string postEndDate)
        {

            acroFields.SetField("services", "Post Start Date: " + postStartDate + Environment.NewLine + "Post End Date: " + postEndDate + Environment.NewLine + Environment.NewLine);
            acroFields.SetField("charges", "\r\n\r\n\r\n");

        }

        //Add Service//////////////
        public void AddService(AcroFields acroFields, string service, string unitquantity, string rate, string unit)
        {
            string field = acroFields.GetField("services");
            acroFields.SetField("services", field + service
             + Environment.NewLine + "(" + unitquantity + " " + unit + "s" + " @ $" + rate
             + "/" + unit + "" + ")" + Environment.NewLine + Environment.NewLine);
        }
        
        //add charge////////////////////
        public void AddCharge(AcroFields acroFields, string chargeamount)
        {
            string field = acroFields.GetField("charges");

            acroFields.SetField("charges", field + "$" + chargeamount + "\r\n\r\n\r\n");
        }
       
        //add balance/////////////////////
        public void AddBalance(AcroFields acroFields, string balance)
        {


            // pdfFormFields.SetField("balance", Environment.NewLine + Environment.NewLine + Environment.NewLine +
            //     Environment.NewLine + balance);
            acroFields.SetField("balance", "\n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \r" + balance);

        }
        
        //add date/////////////////////////
        public void AddDate(AcroFields acroFields, string Date)
        {
            acroFields.SetField("Date", Date);
        }
        
        //add invoiceID/////////////////////////
        public void AddInvoiceID(AcroFields acroFields, string invoiceID)
        {

            acroFields.SetField("FillText1", "CARIPD-" + invoiceID + "-" + DateTime.Now.ToString("yy"));
        }

        private static void AppendToDocument(string sourcePdfPath, string outputPdfPath, List<int> neededPages) {

            var sourceDocumentStream = new FileStream(sourcePdfPath, FileMode.Open);
            var destinationDocumentStream = new FileStream(outputPdfPath, FileMode.Create);
            var pdfConcat = new PdfConcatenate(destinationDocumentStream);

            var pdfReader = new PdfReader(sourceDocumentStream);
            pdfReader.SelectPages(neededPages);
            pdfConcat.AddPages(pdfReader);

            pdfReader.Close();
            pdfConcat.Close();
        }

        public void GenerateInvoicePDF(int invoiceID)
        {
            //Get the invoice from the database, we can extract this later
            DBManager dbManager = DBManager.Instance;
            DataTable invoice = dbManager.GetInvoice(invoiceID);

            //Make a folder to save the file in
            CreateFolderifDoesNotExist();

            // get the account type so we know where to place the file
            string accounttype = (invoice.Rows[0]["Rate_Type"].ToString());

            // make a name for the file
            string exportFileName = "CARIPD-" + invoiceID + "-" + DateTime.Now.ToString("yy") + " " + invoice.Rows[0]["Name"] +  ".pdf";
            
            bool path = false;

            if (accounttype == "Industry") {
                exportFileName = @"Accounts Receivable\" + exportFileName;
            }


            // open the invoice template using PdfReader

            if (invoice.Rows.Count == 0)
            {
                MessageBox.Show("The invoice you are trying to export does not exist");
                return;
            }

            DataTable invoiceTime = dbManager.GetInvoiceTimeLine(invoiceID);
            DataTable invoiceSupply = dbManager.GetInvoiceSupplyLine(invoiceID);
            //convert date time to invoice friendly format

            List<string> filesToMerge = new List<string>();
            int page = 1;
            CreateInvoicePage(invoice, invoiceTime, invoiceSupply, page, filesToMerge);

            //We will be using this file and if it already exists the program will crash
            if(File.Exists("merge.pdf")) File.Delete("merge.pdf"); 

            if (filesToMerge.Count > 1) {
                MergeFiles("merge.pdf", filesToMerge.ToArray());
            } else {
                File.Move(filesToMerge[0], "merge.pdf");
            }

            if (File.Exists(pathname + exportFileName))
                File.Delete(pathname + exportFileName);

            File.Move("merge.pdf", pathname + exportFileName);

            File.Delete("merge.pdf");
            foreach (string currentPath in filesToMerge) {
                //File.Delete(currentPath);
            }
        }
        
        private void CreateInvoicePage(DataTable invoice, DataTable invoiceTime, DataTable invoiceSupply, int page, List<string> filesToMerge) {
            string filePath = page + "temp.pdf";
            filesToMerge.Add(filePath);


            PdfReader pdfReader = new PdfReader(@"invoicetemplate.pdf");
            FileStream fileStream = new FileStream(filePath, FileMode.Create);
            PdfStamper pdfStamper = new PdfStamper(pdfReader, fileStream);
            AcroFields acroFields = pdfStamper.AcroFields;

            string offset = "";
            DateTime poststart = DateTime.Parse(invoice.Rows[0]["Posting_Start_Date"].ToString());
            DateTime postend = DateTime.Parse(invoice.Rows[0]["Posting_End_Date"].ToString());



            AddAddress(
                acroFields,
                invoice.Rows[0]["Name"].ToString(),
                invoice.Rows[0]["Street"].ToString(), //add street to invocie
                invoice.Rows[0]["City"].ToString(), // add city to invoice
                invoice.Rows[0]["State"].ToString(), //add state to invoice
                invoice.Rows[0]["Zip"].ToString()); //add zip to invoice

            AddPostDate(acroFields, poststart.ToShortDateString().ToString(), postend.ToShortDateString().ToString());

            int fieldLines = 3;

            while (invoiceTime.Rows.Count > 0 && fieldLines < 40) {
                DataRow currentRow = invoiceTime.Rows[0];
                double computedRate = Convert.ToDouble(currentRow["Line_Amount"]) / Convert.ToDouble(currentRow["Hours"]);

                // Add the instrument row
                AddService(
                    acroFields,
                    currentRow["Name"].ToString(), //insert time into the invoice
                    Convert.ToDouble(currentRow["Hours"]).ToString("#.00"), //insert hours into invoice
                    computedRate.ToString("#.00"), //insert dollars per hour into invoice
                    ((currentRow["Billing_Unit"].ToString() == "Time") ? "hour" : "use"));// unit of biling displayed on invoice

                // Add the charge for the corresponding instrument
                AddCharge(acroFields, currentRow["Line_Amount"].ToString()); //add charge to invoice

                offset += "\r\n\r\n";
                invoiceTime.Rows.RemoveAt(0);
                fieldLines += 3;
            }

            while (invoiceSupply.Rows.Count > 0 && fieldLines < 40) {
                DataRow currentRow = invoiceSupply.Rows[0];

                AddService(acroFields,
                    currentRow["Supply_Name"].ToString(),
                    currentRow["Quantity"].ToString(),
                    (Convert.ToDouble(currentRow["Line_Amount"]) / Convert.ToInt32(currentRow["Quantity"])).ToString(),
                    currentRow["Unit"].ToString()
                    );

                AddCharge(acroFields, currentRow["Line_Amount"].ToString());

                invoiceSupply.Rows.RemoveAt(0);
                fieldLines += 3;

            }

            //Calls this function recursively to add additional pages
            if (invoiceSupply.Rows.Count > 0 || invoiceTime.Rows.Count > 0) {
                CreateInvoicePage(invoice, invoiceTime, invoiceSupply, page + 1, filesToMerge);
            }

            InsertPageNumber(acroFields, page, filesToMerge.Count());

            AddDate(acroFields, DateTime.Now.ToString()); //Add todays date to the invoice
            AddInvoiceID(acroFields, invoice.Rows[0]["InvoiceID"].ToString()); // add invoice id to invoice
            
            
            AddBalance(acroFields, "$" + invoice.Rows[0]["Total_Balance"].ToString()); // add balance to invoice

            pdfStamper.FormFlattening = true;

            //close the file stream
            pdfStamper.Close();
        }

        public void GenerateInstrumentUsePDF(List<string[]> logs)
        {


            foreach (string[] currentLine in logs) {

                /*AddInstrument(
                    acroFields, 
                    currentLine[0],
                    currentLine[1],
                    currentLine[2]
                    );*/
            }
        }

        public void GenerateInstrumentPage(){
        
        }

        public void GenerateSupplyUsePDF()
        {

        }

        public void MergeFiles(string destinationFile, string[] sourceFiles) {
            if (System.IO.File.Exists(destinationFile))
                System.IO.File.Delete(destinationFile);

            string[] sSrcFile;
            sSrcFile = new string[2];

            string[] arr = new string[2];
            for (int i = 0; i <= sourceFiles.Length - 1; i++) {
                if (sourceFiles[i] != null) {
                    if (sourceFiles[i].Trim() != "")
                        arr[i] = sourceFiles[i].ToString();
                }
            }

            if (arr != null) {
                sSrcFile = new string[2];

                for (int ic = 0; ic <= arr.Length - 1; ic++) {
                    sSrcFile[ic] = arr[ic].ToString();
                }
            }

            {
                int f = 0;

                PdfReader reader = new PdfReader(sSrcFile[f]);
                int n = reader.NumberOfPages;

                Document document = new Document(PageSize.A4);

                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(destinationFile, FileMode.Create));

                document.Open();
                PdfContentByte cb = writer.DirectContent;
                PdfImportedPage page;

                int rotation;
                while (f < sSrcFile.Length) {
                    int i = 0;
                    while (i < n) {
                        i++;

                        document.SetPageSize(PageSize.A4);
                        document.NewPage();
                        page = writer.GetImportedPage(reader, i);

                        rotation = reader.GetPageRotation(i);
                        if (rotation == 90 || rotation == 270) {
                            cb.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(i).Height);
                        } else {
                            cb.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
                        }

                    }

                    f++;
                    if (f < sSrcFile.Length) {
                        reader = new PdfReader(sSrcFile[f]);
                        n = reader.NumberOfPages;

                    }
                }
                document.Close();
            }
        }


       // internal string GetFieldByName(string fieldName)
     //   {
        //    return pdfFormFields.GetField(fieldName);
      //  }
    }
}

