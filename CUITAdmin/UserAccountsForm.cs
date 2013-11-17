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
    public partial class UserAccountsForm : Form
    {
        NewUserPanel pform;
        DBManager dbManager;
        public UserAccountsForm(NewUserPanel pform, string username = "")
        {
            InitializeComponent();
            this.pform = pform;
            dbManager = DBManager.Instance;

            DataTable allAccountsDataSource = dbManager.GetAccounts();

            for (int i = 0; i < allAccountsDataSource.Columns.Count; i++)
            {
                if (!(allAccountsDataSource.Columns[i].ColumnName == "Account_Number" || allAccountsDataSource.Columns[i].ColumnName == "Name"))
                {
                    allAccountsDataSource.Columns.RemoveAt(i);
                    --i;
                }
            }

            if (username != "")
            {
                DataTable userAccountsDataSource = dbManager.GetUserAccounts(username);
                List<DataRow> rowsToBeRemoved = new List<DataRow>(userAccountsDataSource.Rows.Count);
                for (int i = 0; i < userAccountsDataSource.Rows.Count; i++)
                {
                    foreach (DataRow row in allAccountsDataSource.Rows)
                    {
                        bool whatthefuck = userAccountsDataSource.Rows[i][0].ToString() == row[0].ToString();
                        if (whatthefuck)
                            rowsToBeRemoved.Add(row);
                    }
                }

                foreach (DataRow row in rowsToBeRemoved)
                    allAccountsDataSource.Rows.Remove(row);

                dgvUserAccounts.DataSource = userAccountsDataSource;
            }   
            else
            {
                DataTable dataSource = new DataTable();
                foreach (DataColumn col in allAccountsDataSource.Columns)
                {
                    dataSource.Columns.Add(col.ColumnName);
                }
                dgvUserAccounts.DataSource = dataSource;
            }

            dgvAllAccounts.DataSource = allAccountsDataSource;

            dgvAllAccounts.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.AllAccountsHeaderButton_Click);
            dgvUserAccounts.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.UserAccountsHeaderButton_Click);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            pform.setUserAccountsTable((DataTable)dgvUserAccounts.DataSource);
            this.Close();
        }

        private void AllAccountsHeaderButton_Click(object sender, DataGridViewCellMouseEventArgs e)
        {
           // DataRow rowToAdd = ((DataTable)dgvAllAccounts.DataSource).Rows[e.RowIndex];
            //((DataTable) dgvAllAccounts.DataSource).Rows.Remove(rowToAdd);

            //((DataTable)dgvUserAccounts.DataSource).Rows.Add(rowToAdd);
            string[] columnContents = new string[dgvUserAccounts.Columns.Count];
            for(int i = 0; i < dgvUserAccounts.Columns.Count; i++)
            {
                columnContents[i] = dgvAllAccounts.Rows[e.RowIndex].Cells[i].Value.ToString();
            }

            ((DataTable)dgvUserAccounts.DataSource).Rows.Add(columnContents);

            ((DataTable)dgvAllAccounts.DataSource).Rows.RemoveAt(e.RowIndex);

        }

        private void UserAccountsHeaderButton_Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            string[] columnContents = new string[dgvAllAccounts.Columns.Count];
            for (int i = 0; i < dgvAllAccounts.Columns.Count; i++)
            {
                columnContents[i] = dgvUserAccounts.Rows[e.RowIndex].Cells[i].Value.ToString();
            }

            ((DataTable)dgvAllAccounts.DataSource).Rows.Add(columnContents);

            ((DataTable)dgvUserAccounts.DataSource).Rows.RemoveAt(e.RowIndex);
        }
    }
}
