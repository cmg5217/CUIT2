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
            //mymanager.AddUser("test", "lastName", "street", "city", "state", "12345", "8147587606", "test@test.com");
            DateTime currentTime = new DateTime();

            //mymanager.AddAccount("123", "testAccount", "1000000", DateTime.Now.ToLongDateString(), "InternalAcademic", "1", "this guy is a bitch", "costCenter test", "1234", "0");
        }
    }
}
