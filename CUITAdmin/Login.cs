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




        public Login() {
            InitializeComponent();
            this.CenterToScreen();
        }


        private void Login_Load(object sender, EventArgs e) {
            ToggleScreenMode();
            this.AcceptButton = btnLogin;
            txtPassword.PasswordChar = '*';

            if (Settings.Default.FullScreen)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Fixed3D;
                this.WindowState = FormWindowState.Normal;
            }
        }

        public void ToggleScreenMode() {
            if (Settings.Default.FullScreen) {
                this.FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            } else {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }

        }

        private void btnLogin_Click(object sender, EventArgs e) {
            if (Settings.Default.StandaloneMode) {
                XmlManager xmlManager = XmlManager.Instance;

                if (xmlManager.CheckPassword(txtUsername.Text, txtPassword.Text)){
                    Program.userType = xmlManager.GetUserType(txtUsername.Text);
                    this.Close();
                } else {
                    MessageBox.Show("Username or password did not match, please try again.");
                }

            } else {
                DBManager dbManager = DBManager.Instance;

                if (dbManager.CheckPassword(txtUsername.Text, txtPassword.Text)) {
                    if (txtPassword.Text == "CARIPD") {
                        ChangePassword cp = new ChangePassword(txtUsername.Text);
                        cp.ShowDialog();
                    }
                    Program.userType = dbManager.GetUserType(txtUsername.Text);
                    this.Close();
                } else {
                    MessageBox.Show("Username or password did not match, please try again.");
                }
            }
        }

        private void Login_SizeChanged(object sender, EventArgs e)
        {
            pnlControls.Location = new Point(this.Width / 2 - pnlControls.Width / 2, this.Height / 2 - pnlControls.Height / 2);
        }
    }
}
