using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            DBManager mymanager = DBManager.Instance;
            Random rand = new Random();
            //mymanager.AddPerson("test", "lastName", "street", "city", "state", "12345", "8147587606", "test@test.com");
            //mymanager.AddNewManager("test", "lastName", "street", "city", "state", "12345", "8147587606", "test@test.com");
            //DateTime currentTime = new DateTime();
            //mymanager.AddUser("test", "lastName", "street", "city", "state", "12345", "8147587606", "test@test.com", "cmg5217", "password",
            //    "computer science", "U", "Terrible Student", "1");
            //string pointOfContactID;
            //mymanager.AddPointOfContact("ted", "bundy", "murder street", "murder town", "Pa", "16301", "8147777777", "test@test.com", "crazy");
            //mymanager.AddAccount("1", "testAccount", "1000000", DateTime.Now, "InternalAcademic", "14", "this guy is terrible", "costCenter test", "1234","0");
            //List<string> output = mymanager.GetUserAccountNumbers("cmg5217");
            //foreach (string theString in output) {
            //    MessageBox.Show(theString);
            //}
            //mymanager.AddTimeLog("1", "12", 'Y', DateTime.Now, DateTime.Now, 50, "1");
            //mymanager.AddSupplyUse("12345", "TestSupply", DateTime.Now, 30);
            //mymanager.AddUserAccount(12, "54321");
            //mymanager.AddSupply("testsupply 3", 100, "gm");

            //int invoiceID;
            //mymanager.AddInvoice(DateTime.Now, DateTime.Now, DateTime.Now, "12345", 40, out invoiceID);
            //mymanager.AddInvoiceSupplyLine("testsupply", 50, invoiceID);
            //mymanager.AddInvoiceTimeLine("testsupply", 30, 50, invoiceID);

            //mymanager.AddInstrument("testInstrument" + rand.Next(), "oz", 50);

            //mymanager.AddInstrumentRate("Internal Academic", 10, 1);
        }
    }
}
