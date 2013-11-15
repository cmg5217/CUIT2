using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
            DBManager mymanager = DBManager.Instance;
            Random rand = new Random();

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
           
            mymanager.AddUser("test", "lastName", "street", "city", "state", "12345", "8147587606", "test@test.com", "chris1", "tHeskull0135$",
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
