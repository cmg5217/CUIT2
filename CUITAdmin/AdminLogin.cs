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
    public partial class AdminLogin : Form {

        frmCUITAdminMain mainForm;

        public AdminLogin(frmCUITAdminMain mainForm) {
            this.mainForm = mainForm;
            InitializeComponent();

            this.AcceptButton = btnSubmit;
        }

        private void btnSubmit_Click(object sender, EventArgs e) {
            if (Settings.Default.StandaloneMode) {
                XmlManager xmlManager = XmlManager.Instance;
                if (xmlManager.CheckPassword(txtUsername.Text, txtPassword.Text)) {
                    char usertype = xmlManager.GetUserType(txtUsername.Text);
                    if (usertype != 'A') {
                        MessageBox.Show("The username entered is not an admin.");
                        this.Close();
                    } else {
                        mainForm.Exit();
                    }
                } else {
                    MessageBox.Show("Username and password did not match");
                    this.Close();
                }
            } else {
                DBManager dbManager = DBManager.Instance;
                if (dbManager.CheckPassword(txtUsername.Text, txtPassword.Text)) {
                    char usertype = dbManager.GetUserType(txtUsername.Text);
                    if (usertype != 'A') {
                        MessageBox.Show("This username entered is not an admin");
                        this.Close();
                    } else {
                        mainForm.Exit();
                    }
                } else {
                    MessageBox.Show("Username and password did not match");
                    this.Close();
                }
            }
        }
    }
}
