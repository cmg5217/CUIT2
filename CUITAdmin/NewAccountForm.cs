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
    public partial class NewAccountForm : Form
    {

        public NewAccountForm()
        {
            InitializeComponent();
            this.SetBounds(350, 350, 680, 400);
        }

        private void NewAccountForm_Load(object sender, EventArgs e)
        {
            NewAccountPanel myAcctForm = new NewAccountPanel(this, 0);
        }
    }
}
