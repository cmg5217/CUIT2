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

            string passwordPattern = "^([1-zA-Z0-1@.\\s\\$\\%\\(\\)\\!\\^\\+\\~\\@\\#]{5,20})$";

            if (txtConfirmPassword.Text != txtPassword.Text) {
                lblMessage.Text = "Passwords do not match...";
            } 
            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtPassword.Text, passwordPattern))
            {
                lblMessage.Text = "Password is not valid. Please enter a valid password.";
                txtPassword.Focus();
            }
            else {
                DBManager dbManager = DBManager.Instance;
                dbManager.UpdateUser(dbManager.GetUserID(username), "", "", "", "", "", "", "", "", "", txtPassword.Text,  "", "", "", 'Y');
                this.Close();
            }
        }
    }
}
