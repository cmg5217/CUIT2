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

        private void button1_Click(object sender, EventArgs e) {
            DBManager mymanager = DBManager.Instance;
            //mymanager.AddNewManager("test", "lastName", "street", "city", "state", "12345", "8147587606", "test@test.com");
            //DateTime currentTime = new DateTime();
            //mymanager.AddNewUser("test", "lastName", "street", "city", "state", "12345", "8147587606", "test@test.com", "cmg5217", "password",
            //    "computer science", "U", "Terrible Student", "1");
            mymanager.AddAccount("123", "testAccount", "1000000", DateTime.Now.ToLongDateString(), "InternalAcademic", "12", "this guy is terrible", "costCenter test", "1234","0");
            //List<string> output = mymanager.GetUserAccountNumbers("cmg5217");
            //foreach (string theString in output) {
            //    MessageBox.Show(theString);
            //}
        
        
        
        }
    }
}
