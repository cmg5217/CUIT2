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
        static PDFManager globalManager = null;
        private static readonly object padlock = new object();
        //template pdf file in same directory as executable
        private const string PDF_TEMPLATE = @"invoicetemplate.pdf";
        PdfReader pdfReader;
        PdfStamper pdfStamper;
        AcroFields pdfFormFields;
                             

        public PDFManager()
            
            //filename of exported invoiceis stored in app.config. 
            //If the program has not been used on the user's
            //computer before, the path will default to the user's desktop.
            //TODO: make filename set to invoiceID
            : this(Settings.Default["InvoicePath"].ToString() + @"\CARIPD-002-17.pdf")
        {
        }

        
       public PDFManager(string newFile){
            // open the invoice template using PdfReader
            pdfReader = new PdfReader(PDF_TEMPLATE);
            pdfStamper = new PdfStamper(pdfReader, new FileStream(
                        newFile, FileMode.Create));
            pdfFormFields = pdfStamper.AcroFields;


        }

         //~PDFManager(){
             /*   try
                {
                   //pdfStamper.Close();              
                }
                catch (Exception e)
                {

               } */
         //}

       
        public void PDFClose()
        {
            //makes the pdf file uneditable
            pdfStamper.FormFlattening = true;
            //close the file stream
            pdfStamper.Close();
            //Display success message with the file path in the message
            MessageBox.Show("Export Complete! \n" + "File has been exported to:\n" + Settings.Default["InvoicePath"].ToString());
            
        }
        // Add Address //////////////
        public void AddAddress(string name, string street, string city, string state, string zip )
        {
            
            pdfFormFields.SetField("Address", name + Environment.NewLine
               + street + Environment.NewLine + city +","+ state +" "+ zip);
        }

        //Add Service//////////////
        public void AddService(string service, string date, string unitquantity, string rate, string unit)
        {
            
            string field = pdfFormFields.GetField("services");
            pdfFormFields.SetField("services", field + service +
                 Environment.NewLine + "(" + date + ", " + unitquantity + " " + unit +"s" + " @ $" + rate + "/" + unit + "" +")"+
                 Environment.NewLine + Environment.NewLine); 
        }
        //add charge////////////////////
        public void AddCharge(string chargeamount)
        {
          

            pdfFormFields.SetField("charges", "$" + chargeamount);                   
        }
        //add balance/////////////////////
        public void AddBalance(string balance)
        {
           

            pdfFormFields.SetField("balance", Environment.NewLine + Environment.NewLine + Environment.NewLine +
                Environment.NewLine + "$"+balance);
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
        //pull information from the database
        public void QueryDatabase(string month)
        {

            //SqlConnection myConnection = new SqlConnection("Data Source=CUITS\\CUITS;Initial Catalog=CUIT;User ID=DataAdmin;Password=JazBarne$411");

           // SqlDataReader myReader = null;
           // SqlCommand myCommand = new SqlCommand("select * from Invoice",
           //                                          myConnection);
           // myReader = myCommand.ExecuteReader();
           // while (myReader.Read())
           // {
           //     MessageBox.Show((myReader["Column1"].ToString()));
           //     Console.WriteLine(myReader["Column1"].ToString());
           //     //Console.WriteLine(myReader["Column2"].ToString());
           // }
            
        }
       }
}

