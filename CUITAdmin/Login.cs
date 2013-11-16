using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CUITAdmin.Properties;

namespace CUITAdmin {
    public partial class Login : Form {

        DBManager dbManager;


        public Login() {
            InitializeComponent();
        }


        private void Login_Load(object sender, EventArgs e) {
            dbManager = DBManager.Instance;
            this.AcceptButton = btnLogin;
            txtPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            if (Settings.Default.StandaloneMode == "true") {

            } else {
                if (dbManager.CheckPassword(txtUsername.Text, txtPassword.Text)) {
                    Program.userType = dbManager.GetUserType(txtUsername.Text);
                    this.Close();
                } else {
                    MessageBox.Show("Username or password did not match, please try again.");
                }
            }
        }
    }
}
