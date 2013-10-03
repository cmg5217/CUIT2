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
    public partial class NewAccountAdminForm : Form
    {

        public NewAccountAdminForm()
        {
            InitializeComponent();
            this.SetBounds(350, 350, 680, 300);
        }

        private void NewAccountAdminForm_Load(object sender, EventArgs e)
        {
            NewAccountAdminPanel myAcctAdminForm = new NewAccountAdminPanel(this);
        }
    }
}

