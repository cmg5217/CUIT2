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
            xmlManager = new XmlManager();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (xmlManager.EditUser(textBox1.Text, textBox2.Text)) textBox1.Text = "User Edited";
            else textBox1.Text = "User doesn't Exists";
        }
    }
}
