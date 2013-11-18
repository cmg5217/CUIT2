using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace CUITAdmin {
    public partial class TestForm : Form {

        XmlManager xmlManager;

        public TestForm() {
            InitializeComponent();
            xmlManager = XmlManager.Instance;
        }

        
        private void button1_Click(object sender, EventArgs e) 
        {
            xmlManager = XmlManager.Instance; 
            int count = 0;
            DBManager dbManager = DBManager.Instance;
            Random rand = new Random();

            dbManager.UpdateAccount("1", "testAccount", 50000.00, DateTime.Now.AddMonths(6), "Internal Academic",
                17, "test edit", "cost center test edit", "wbs test edit", 500.13, "edit street", "edit city",
                "edit state", 99999, "eit tax ID", 'N');
            Debug.WriteLine("----");
            dbManager.UpdateInstrument(10, "Tazer", "Time", 2, 'Y');
            Debug.WriteLine("----");
            dbManager.UpdateSupply("Beaker", 80000, "vehicle", 'Y');
            Debug.WriteLine("----");

            /*
            xmlManager.CreateLogFile();

            xmlManager.AddPartialLog("cmg5217", "1", "10", DateTime.Now.ToString());
            xmlManager.AddSupplyUse(DateTime.Now.ToString(), "1", "Needles", 30);
            xmlManager.AddSupplyUse(DateTime.Now.AddHours(-3).ToString(), "1", "Needles", 30);
            xmlManager.AddLog("cmg5217", "1", "10", DateTime.Now.AddHours(-5).ToString(), DateTime.Now.ToString());
            xmlManager.AddLog("cmg5217", "1", "10", DateTime.Now.AddHours(-6).ToString(), DateTime.Now.ToString());

            // Create the 2 tables that you will send to the server
            DataTable timeLogs = xmlManager.ImportTimeLogs("records.xml");
            DataTable supplyUses = xmlManager.ImportSupplyUse("records.xml");

            // Get the additional information to fill in all rows
            DataTable timeLogImportData = dbManager.GetImportDataTimeLog();
            DataTable supplyUseImportData = dbManager.GetImportDataSupplyUse();

            // Loop through and add the rate and time increment to each timelog
            foreach (DataRow row in timeLogs.Rows) {
                foreach (DataRow importRow in timeLogImportData.Rows) {
                    if (importRow["Account_Number"].ToString() == row["Account_Number"].ToString() &&
                        importRow["InstrumentID"].ToString() == row["InstrumentID"].ToString()) {
                        row["Current_Rate"] = importRow["Rate"];
                        row["Time_Increment"] = importRow["Time_Increment"];
                    }
                }
            }

            // Loop through and add the cost to each supply use
            foreach (DataRow row in supplyUses.Rows) {
                foreach (DataRow importRow in supplyUseImportData.Rows) {
                    if (importRow["Supply_Name"].ToString() == row["Supply_Name"].ToString()) {
                        row["Current_Cost"] = importRow["Cost"];
                    }
                }
            }

            // send the imports to the server
            dbManager.AddTimeLogBulk(timeLogs);
            dbManager.AddSupplyUseBulk(supplyUses);
            */

            Debug.Write("");
            /*
            StreamReader reader = new StreamReader("records.xml");
            string file = reader.ReadToEnd();
            SimpleAES aes = new SimpleAES();
            file = aes.EncryptToString(file);

            StreamWriter writer = new StreamWriter("testencryption.txt");
            writer.Write(file);
            writer.Close();

            string file2 = aes.DecryptString(file);

            StreamWriter writer2 = new StreamWriter("testdecryption.txt");
            writer2.Write(file2);
            writer2.Close();
            */

            int invoiceID = 381;

            PDFManager mypdf = new PDFManager();

            mypdf.GenerateInvoicePDF(381);
            


            //DataTable testTable = mymanager.GetAccounts();
            //testTable.TableName = "root";
            //XmlWriter testWriter = XmlWriter.Create("test.xml");
           // DataSet testSet = new DataSet("testSet");
            //testSet.Tables.Add(testTable);

            //testSet.WriteXml(testWriter);

            //xmlManager.AddSupplyUse("string username", "string accountnumber", "string supply", "string quantity");

            //mymanager.SendDataTable();

            //MessageBox.Show(DateTime.Now.ToString());


            

            //DataTable testTable = mymanager.GetUserAccounts("cmg5217");
            

            ///*
            DateTime currentTime = new DateTime();
            string pointOfContactID;

            //mymanager.AddRateType("TestRate" + rand.Next());

            //Debug.WriteLine("Line" + (++count));
            
            //mymanager.AddPointOfContact("Tom", "Ato", "Heinze St", "Pittsburgh", "Pa", "15219", "8148675309", "test@test.com", "these are notes");

            //Debug.WriteLine("Line" + (++count));

            #region Add Account, User, and User_Account
            
            string testAccountNum = "TestAcct" + rand.Next();
            
            //mymanager.AddAccount("1", "testAccount", 1000000, DateTime.Now, "Internal Academic", 4, "this guy is terrible", "costCenter test", "1234", 0,
            //                        "teststreet", "testcity", "teststate", 12345);
            //Debug.WriteLine("Line" + (++count));
           
            dbManager.AddUser("test", "lastName", "street", "city", "state", "12345", "8147587606", "test@test.com", "chris1", "tHeskull0135$",
                "computer science", "U", "Terrible Student", 4);

            //mymanager.AddUserAccount(1, "1");
            //Debug.WriteLine("Line" + (++count));
            
            #endregion
            
            

            //Debug.WriteLine("Line" + (++count));
            //DateTime startTime = DateTime.Now.AddHours(-10);
            //mymanager.AddTimeLog("1", 1, 'Y', 1, startTime, DateTime.Now); 
            
            #region Add Supply & Use
            /*
            Debug.WriteLine("Line" + (++count));
            mymanager.AddSupplyUse("1", "TestSupply", DateTime.Now, 20);
            Debug.WriteLine("Line" + (++count));
            mymanager.AddSupply("testsupply" + DateTime.Now.ToString(), 100, "gm");
            */
            #endregion


            //int invoiceID;

            //TO-DO Remove these functions
            #region Generated from a different function now 
            //Debug.WriteLine("Line" + (++count));
            //mymanager.AddInvoice(DateTime.Now, DateTime.Now, DateTime.Now, "12345", 40, out invoiceID);
            //Debug.WriteLine("Line" + (++count));
            //mymanager.AddInvoiceSupplyLine("testsupply", 50, invoiceID);
            //Debug.WriteLine("Line" + (++count));
            //mymanager.AddInvoiceTimeLine("testsupply", 30, 50, invoiceID);
            #endregion

            #region Add instrument and rate
            
            //Debug.WriteLine("Line" + (++count));
            //mymanager.AddInstrument("testInstrument", "oz", 50);

            //Debug.WriteLine("Line" + (++count));
            //mymanager.AddInstrumentRate("TestRate" + rand.Next(), 10, 1);
             
            #endregion

            //mymanager.GenerateInvoice("1", DateTime.Now.AddDays(-15), DateTime.Now);
            
        }

        private void TestForm_Load(object sender, EventArgs e) {

        }
    }
}
