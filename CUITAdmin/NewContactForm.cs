using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CUITAdmin
{
    public partial class NewContactForm : Form
    {
        public NewContactForm()
        {
            InitializeComponent();
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
