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
    public partial class AccountInstrumentsForm : Form
    {
        NewAccountPanel pform;
        DBManager dbManager;
        DataRow currentRow;

        public AccountInstrumentsForm(NewAccountPanel pform, string accountNumber = "")
        {
            InitializeComponent();

            this.pform = pform;
            dbManager = DBManager.Instance;

            DataTable allInstrumentsDataSource = dbManager.GetInstruments();

            for (int i = 0; i < allInstrumentsDataSource.Columns.Count; i++)
            {
                if (!(allInstrumentsDataSource.Columns[i].ColumnName == "InstrumentID" || allInstrumentsDataSource.Columns[i].ColumnName == "Name"))
                {
                    allInstrumentsDataSource.Columns.RemoveAt(i);
                    --i;
                }
            }

            if (accountNumber != "")
            {
                DataTable accountsInstrumentDataSource = dbManager.GetAccountInstruments(accountNumber);
                List<DataRow> rowsToBeRemoved = new List<DataRow>(accountsInstrumentDataSource.Rows.Count);
                for (int i = 0; i < accountsInstrumentDataSource.Rows.Count; i++)
                {
                    foreach (DataRow row in allInstrumentsDataSource.Rows)
                    {
                        bool whatthefuck = accountsInstrumentDataSource.Rows[i][0].ToString() == row[0].ToString();
                        if (whatthefuck)
                            rowsToBeRemoved.Add(row);
                    }
                }

                foreach (DataRow row in rowsToBeRemoved)
                    allInstrumentsDataSource.Rows.Remove(row);

                dgvAccountInstruments.DataSource = accountsInstrumentDataSource;
            }
            else
            {
                DataTable dataSource = new DataTable();
                foreach (DataColumn col in allInstrumentsDataSource.Columns)
                {
                    dataSource.Columns.Add(col.ColumnName);
                }
                dgvAccountInstruments.DataSource = dataSource;
            }

            dgvAllInstruments.DataSource = allInstrumentsDataSource;

            dgvAllInstruments.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.AllInstrumentsHeaderButton_Click);
            dgvAccountInstruments.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.AccountInstrumentsHeaderButton_Click);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            pform.setAccountInstrumentsTable((DataTable)dgvAccountInstruments.DataSource);
            this.Close();
        }

        private void AllInstrumentsHeaderButton_Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            string[] columnContents = new string[dgvAccountInstruments.Columns.Count];
            for (int i = 0; i < dgvAccountInstruments.Columns.Count; i++)
            {
                columnContents[i] = dgvAllInstruments.Rows[e.RowIndex].Cells[i].Value.ToString();
            }

            ((DataTable)dgvAccountInstruments.DataSource).Rows.Add(columnContents);

            ((DataTable)dgvAllInstruments.DataSource).Rows.RemoveAt(e.RowIndex);

        }

        private void AccountInstrumentsHeaderButton_Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            string[] columnContents = new string[dgvAllInstruments.Columns.Count];
            for (int i = 0; i < dgvAllInstruments.Columns.Count; i++)
            {
                columnContents[i] = dgvAccountInstruments.Rows[e.RowIndex].Cells[i].Value.ToString();
            }

            ((DataTable)dgvAllInstruments.DataSource).Rows.Add(columnContents);

            ((DataTable)dgvAccountInstruments.DataSource).Rows.RemoveAt(e.RowIndex);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvAllInstruments.SelectedCells.Count != 0)
            {
                int index = dgvAllInstruments.SelectedCells[0].RowIndex;
                string[] columnContents = new string[dgvAccountInstruments.Columns.Count];
                for (int i = 0; i < dgvAccountInstruments.Columns.Count; i++)
                {

                    columnContents[i] = dgvAllInstruments.Rows[index].Cells[i].Value.ToString();
                    
                }

                ((DataTable)dgvAccountInstruments.DataSource).Rows.Add(columnContents);

                ((DataTable)dgvAllInstruments.DataSource).Rows.RemoveAt(index);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvAccountInstruments.SelectedCells.Count != 0)
            {
                int index = dgvAccountInstruments.SelectedCells[0].RowIndex;
                string[] columnContents = new string[dgvAllInstruments.Columns.Count];
                for (int i = 0; i < dgvAllInstruments.Columns.Count; i++)
                {
                    columnContents[i] = dgvAccountInstruments.Rows[index].Cells[i].Value.ToString();
                }

                ((DataTable)dgvAllInstruments.DataSource).Rows.Add(columnContents);

                ((DataTable)dgvAccountInstruments.DataSource).Rows.RemoveAt(index);
            }
        }
    }
}
