using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using CUITAdmin.Properties;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CUITAdmin
{
    class ExcelManager
    {
        /* private const int ROW_OFFSET = 8,
                                  ACCOUNT_COLUMN = 2,
                                  BALANCE_COL = 5,
                                  COST_CENTER_COL = 8,
                                  WBS_COL = 12;*/


        private static Microsoft.Office.Interop.Excel.Workbook mWorkBook;
        private static Microsoft.Office.Interop.Excel.Sheets mWorkSheets;
        private static Microsoft.Office.Interop.Excel.Worksheet mWSheet1;
        private static Microsoft.Office.Interop.Excel.Application oXL;
        private static string pathname = Settings.Default["InvoicePath"].ToString() + @"\Invoices\" + (DateTime.Now.Year);
        private static System.Data.DataTable invoiceDataTable;
        DBManager dbManager;

        static public void generateAR(bool createme)
        {

            if (createme == true)
            {
                pathname = Settings.Default["InvoicePath"].ToString() + @"\Invoices\" +(DateTime.Now.Year)+@"\Accounts Receivable";
            }

        }

        static public void generateExcel(System.Data.DataTable invoiceDataTable)
        {
            generateExcel(new System.Data.DataTable[] { invoiceDataTable });
        }
        
        static public void generateExcel(System.Data.DataTable[] invoiceArray)

        {

            //if the excel process is open, kill it. This will not close excel documents which do not have changes saved to them.
            Process[] processes = Process.GetProcessesByName("EXCEL");
            //if (processes.Length > 0) 
                //processes[0].Kill();


            string invoiceid = invoiceArray[0].Rows[0]["InvoiceID"].ToString();
            string excelfilename = @"\" + DateTime.Now.ToString("MM-dd-yyyy") + " - Invoice " + invoiceid+".xls";
            //checks if the files exists and delets it if it does exits            
            if (File.Exists(pathname + excelfilename))
            {
              File.Delete(pathname + excelfilename);                
            }
    
            //copies the template from the bin folder to a predetermined location
            System.IO.File.Copy(@"GLSU Template.xls", pathname + excelfilename);
            string path = pathname + excelfilename;
            
            //write info to newly copied excel file
            oXL = new Microsoft.Office.Interop.Excel.Application();
            oXL.Visible = false;
            oXL.DisplayAlerts = false;
            mWorkBook = oXL.Workbooks.Open(path, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
           
            //Get all the sheets in the workbook
            mWorkSheets = mWorkBook.Worksheets;
            //Get the allready exists sheet
            mWSheet1 = (Microsoft.Office.Interop.Excel.Worksheet)mWorkSheets.get_Item("Sheet1");
            Microsoft.Office.Interop.Excel.Range range = mWSheet1.UsedRange;
            int colCount = range.Columns.Count;
            int rowCount = range.Rows.Count;
            //pull information from the database
            DateTime poststart = DateTime.Parse(invoiceArray[0].Rows[0]["Posting_Start_Date"].ToString());
            //string balance = (invoiceDataTable.Rows[0]["Total_Balance"].ToString());
            
            string account = invoiceArray[0].Rows[0]["Name"].ToString();
            //DataTable invoice = dbManager.GetInvoice(invoiceID);
            string balance = (invoiceArray[0].Rows[0]["Total_Balance"].ToString());
            string wbs = invoiceArray[0].Rows[0]["WBS_Number"].ToString();
            string costcenter = invoiceArray[0].Rows[0]["Cost_Center"].ToString();

            //cost center
            mWSheet1.Cells[9, 8] = costcenter;
            
            //Document Date
            mWSheet1.Cells[4, 2] = DateTime.Now.ToString("M/d/yyyy");
            
            //Posting Date
            mWSheet1.Cells[4, 3] = poststart;

            //balance
            mWSheet1.Cells[9, 5] = balance;
            mWSheet1.Cells[8, 5] = balance;

            //wbs element
            mWSheet1.Cells[9, 12] = wbs;


            //change then business area to 25
            mWSheet1.Cells[8, 7] = "25";
            mWSheet1.Cells[9, 7] = "25";

            //change the invoice #
            mWSheet1.Cells[8, 6] = "InvoiceID:" + invoiceid + "    AccountID:" + account;
            mWSheet1.Cells[9, 6] = "InvoiceID:" + invoiceid + "    AccountID:" + account;


            //change the funding source(account)
            mWSheet1.Cells[8, 7] = "25";

            
            //for (int i = 0; i < invoiceArray.Length; i++ )
            //{
            //    addLine(invoiceArray[i], i);
            //
            //}


            mWorkBook.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
            Missing.Value, Missing.Value, Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
            Missing.Value, Missing.Value, Missing.Value,
            Missing.Value, Missing.Value);
            mWorkBook.Close(Missing.Value, Missing.Value, Missing.Value);
            mWSheet1 = null;
            mWorkBook = null;
            oXL.Quit();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            Marshal.ReleaseComObject(mWorkSheets);
            Marshal.ReleaseComObject(oXL);

            if (mWSheet1 != null)
            {
                 Marshal.ReleaseComObject(mWSheet1);
                mWSheet1 = null;
            }
            if (mWorkBook != null)
            {
                Marshal.ReleaseComObject(mWorkBook);
                mWorkBook = null;
            }
            if (oXL != null)
            {
                Marshal.ReleaseComObject(oXL);
                oXL = null;
            }

            Process excelProcess = Process.GetProcessesByName("EXCEL")[0];
            if (!excelProcess.CloseMainWindow())
            {
                excelProcess.Kill();
            }

        }

        /*private static void addLine(System.Data.DataTable invoiceDataTable, int index)
        {
            string balance = (invoiceDataTable.Rows[0]["Total_Balance"].ToString());
            string account = invoiceDataTable.Rows[0]["Account_Number"].ToString(); //maybe change to account name
            string costcenter = invoiceDataTable.Rows[0]["Cost_Center"].ToString();
            string wbs = invoiceDataTable.Rows[0]["WBS_Number"].ToString();
            //Account
            //mWSheet1.Cells[ROW_OFFSET + index, ACCOUNT_COLUMN] = account;

            //Balance
            mWSheet1.Cells[ROW_OFFSET + index, BALANCE_COL] = balance;

            //cost center
            mWSheet1.Cells[ROW_OFFSET + index, COST_CENTER_COL] = costcenter;

            //wbs
            //mWSheet1.Cells[ROW_OFFSET + index, WBS_COL] = wbs;
        }*/
    }
}
