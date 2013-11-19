using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CUITAdmin {
    public partial class ChangePassword : Form {

        string username;
        public ChangePassword(string username) {
            InitializeComponent();
            this.username = username;
            this.CenterToScreen();
        }

        private void btnSubmit_Click(object sender, EventArgs e) {
            if (txtConfirmPassword.Text != txtPassword.Text) {
                lblMessage.Text = "Passwords do not match...";
            } else {
                DBManager dbManager = DBManager.Instance;
                dbManager.UpdateUser(dbManager.GetUserID(username), "", "", "", "", "", "", "", "", "", txtPassword.Text,  "", "", "");
                this.Close();
            }
            // TO-DO match against regex
        }
    }
}
