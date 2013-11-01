using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CUITAdmin {
    public partial class TestForm : Form {

        XmlManager xmlManager;

        public TestForm() {
            InitializeComponent();
            xmlManager = XmlManager.Instance;
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            
            int count = 0;
            DBManager mymanager = DBManager.Instance;
            Random rand = new Random();


            DataTable testTabel = mymanager.GetUserAccounts("cmg5217");
            testTabel.Columns

            /*
            DateTime currentTime = new DateTime();
            string pointOfContactID;

            Debug.WriteLine("Line" + (++count));
            mymanager.AddPointOfContact("ted", "bundy", "murder street", "murder town", "Pa", "16301", "8147777777", "test@test.com", "crazy");
*/
            /*string testAccountNum = "TestAcct" + rand.Next();

            Debug.WriteLine("Line" + (++count));
            
            mymanager.AddAccount(testAccountNum, "testAccount", 1000000, DateTime.Now, "InternalAcademic", 14, "this guy is terrible", "costCenter test", "1234", 0);
            Debug.WriteLine("Line" + (++count));
           
            
            mymanager.AddUser("test", "lastName", "street", "city", "state", "12345", "8147587606", "test@test.com", "cmg" + rand.Next(), "password",
                "computer science", "U", "Terrible Student", 1);
            Debug.WriteLine("Line" + (++count));

            
            mymanager.AddUserAccount(73, testAccountNum);
            /*
            string message = "Accounts: \r\n";

            List<string> output = mymanager.GetUserAccountNumbers("cmg5217");
            foreach (string theString in output) {
                message += "\r\n " + theString;
            }

            MessageBox.Show(message);

            Debug.WriteLine("Line" + (++count));
            mymanager.AddTimeLog("1", "63", 'Y', DateTime.Now, DateTime.Now, 50, "1");
            Debug.WriteLine("Line" + (++count));
            mymanager.AddSupplyUse("12345", "TestSupply", DateTime.Now, 30);
            Debug.WriteLine("Line" + (++count));
            mymanager.AddSupply("testsupply" + DateTime.Now.ToString(), 100, "gm");

            int invoiceID;
             
            Debug.WriteLine("Line" + (++count));
            mymanager.AddInvoice(DateTime.Now, DateTime.Now, DateTime.Now, "12345", 40, out invoiceID);
            Debug.WriteLine("Line" + (++count));
            mymanager.AddInvoiceSupplyLine("testsupply", 50, invoiceID);
            Debug.WriteLine("Line" + (++count));
            mymanager.AddInvoiceTimeLine("testsupply", 30, 50, invoiceID);
            
            Debug.WriteLine("Line" + (++count));
            mymanager.AddInstrument("testInstrument", "oz", 50);

            Debug.WriteLine("Line" + (++count));
            mymanager.AddInstrumentRate("TestRate" + rand.Next(), 10, 1);
            
            */
        }
    }
}
