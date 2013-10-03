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
    public partial class SelectGrant : Form
    {

        string Username;

        public SelectGrant(string userpass)
        {
            InitializeComponent();
            Username = userpass;

        }

        

        private void grantsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
          //  this.grantsBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.secondaryLoginDataSet);

        }

        private void grantsBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
           // this.grantsBindingSource.EndEdit();
           // this.tableAdapterManager.UpdateAll(this.secondaryLoginDataSet);

        }

        private void grantsBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate();
           // this.grantsBindingSource.EndEdit();
           // this.tableAdapterManager.UpdateAll(this.secondaryLoginDataSet);

        }

        private void grantsBindingNavigatorSaveItem_Click_3(object sender, EventArgs e)
        {
            this.Validate();
          //  this.grantsBindingSource.EndEdit();
          //  this.tableAdapterManager.UpdateAll(this.secondaryLoginDataSet);

        }

        private void grantsBindingNavigatorSaveItem_Click_4(object sender, EventArgs e)
        {
            this.Validate();
          //  this.grantsBindingSource.EndEdit();
          //  this.tableAdapterManager.UpdateAll(this.secondaryLoginDataSet);

        }

        private void grantsBindingNavigatorSaveItem_Click_5(object sender, EventArgs e)
        {
            this.Validate();
         //   this.grantsBindingSource.EndEdit();
         //   this.tableAdapterManager.UpdateAll(this.secondaryLoginDataSet);

        }

        private void grants1BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
       //     this.grants1BindingSource.EndEdit();
       //     this.tableAdapterManager.UpdateAll(this.secondaryLoginDataSet);

        }

        private void grants1BindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
       //     this.grants1BindingSource.EndEdit();
        //    this.tableAdapterManager.UpdateAll(this.secondaryLoginDataSet);

        }

        private void grants1BindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate();
         //   this.grants1BindingSource.EndEdit();
         //   this.tableAdapterManager.UpdateAll(this.secondaryLoginDataSet);

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
          /////


            String connectionString = "Data Source=CUITS\\CUITS;Initial Catalog=SecondaryLogin;User ID=DataAdmin;Password=noforyoureyes67";

            SqlConnection connection = new SqlConnection(connectionString);

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            //Username = "dstephens";
            //SQL statment that updates the database
            String updateStatement = "UPDATE UserTime SET GrantID=@ptxtTest WHERE Username=@pUsername";
            

            SqlCommand UpdateCmd = new SqlCommand(updateStatement, connection);

            //use the AddWithValue to pull the values from the textbox
            UpdateCmd.Parameters.AddWithValue("@ptxtTest", txtTest.Text);
            UpdateCmd.Parameters.AddWithValue("@pUsername", Username);
            //execute non query

            UpdateCmd.ExecuteNonQuery();

            //clost the dialog box 

            this.Close();

                        
            ////
            
            
            TimerWindow TimerWindow = new TimerWindow();
            TimerWindow.Show();
            this.Close();
        }

        private void SelectGrant_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'secondaryLoginDataSet.Grants' table. You can move, or remove it, as needed.
            this.grantsTableAdapter.Fill(this.secondaryLoginDataSet.Grants);
            // TODO: This line of code loads data into the 'secondaryLoginDataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.secondaryLoginDataSet.Users);
            // TODO: This line of code loads data into the 'secondaryLoginDataSet.Grants' table. You can move, or remove it, as needed.
           // this.grantsTableAdapter.Fill(this.secondaryLoginDataSet.Grants);
            this.TopMost = true;
        }

        private void grantsBindingNavigatorSaveItem_Click_6(object sender, EventArgs e)
        {
            this.Validate();
           // this.grantsBindingSource.EndEdit();
           // this.tableAdapterManager.UpdateAll(this.secondaryLoginDataSet);

        }

        

       
    }
}
