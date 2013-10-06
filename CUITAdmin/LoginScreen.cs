using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CUITAdmin
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string UserName = txtUser.Text;
            string Password = txtPassword.Text;

            if (UserName == "" || Password == "")
            {
                MessageBox.Show("Password or username is empty.");
            }

            else //if the username is not blank, do this
            {

               //CHECK DATABASE FOR LOGIN INFO



                using (SqlCommand cmd = new SqlCommand("select count(*) from Users where [UserName]=@UserName and [Password]=@Password", new SqlConnection(@"Data Source=CUITS\CUITS;Initial Catalog=CUITS;User ID=DataAdmin;Password=noforyoureyes67")))
                {
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    cmd.Connection.Open();
                    if ((int)cmd.ExecuteScalar() > 0)
                    {
                        MessageBox.Show("You have successfully Logged In");
                        //SelectGrant SelectGrant = new SelectGrant(UserName);
                        //SelectGrant.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Login Failed");
                    }
                }

                //END CHECK DATABASE FOR LOGIN INFO
              
            }
             
        }

        

       

    }
}
