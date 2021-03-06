﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CUITAdmin
{
    public partial class UserInstrumentsForm : Form
    {
        NewUserPanel pform;
        DBManager dbManager;

        public UserInstrumentsForm(NewUserPanel pform, string username = "")
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

            if (username != "")
            {
                DataTable userInstrumentsDataSource = dbManager.GetUserInstruments(username);
                List<DataRow> rowsToBeRemoved = new List<DataRow>(userInstrumentsDataSource.Rows.Count);
                userInstrumentsDataSource.Columns[1].SetOrdinal(0);
                for (int i = 0; i < userInstrumentsDataSource.Rows.Count; i++)
                {
                    foreach (DataRow row in allInstrumentsDataSource.Rows)
                    {
                         bool whatthefuck = userInstrumentsDataSource.Rows[i][0].ToString() == row[0].ToString();
                        if (whatthefuck)
                            rowsToBeRemoved.Add(row);
                    }
                }

                foreach (DataRow row in rowsToBeRemoved)
                    allInstrumentsDataSource.Rows.Remove(row);
                dgvUserInstruments.DataSource = userInstrumentsDataSource;
            }
            else
            {
                DataTable userInstrumentsDataSource = new DataTable();
                foreach (DataColumn col in allInstrumentsDataSource.Columns)
                {
                    userInstrumentsDataSource.Columns.Add(col.ColumnName);
                }
                
                dgvUserInstruments.DataSource = userInstrumentsDataSource;
            }

            dgvAllInstruments.DataSource = allInstrumentsDataSource;

            dgvAllInstruments.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.AllInstrumentsHeaderButton_Click);
            dgvUserInstruments.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.UserInstrumentsHeaderButton_Click);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            pform.setUserInstrumentsTable((DataTable)dgvUserInstruments.DataSource);
            this.Close();
        }

        private void AllInstrumentsHeaderButton_Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            string[] columnContents = new string[dgvUserInstruments.Columns.Count];
            for (int i = 0; i < dgvUserInstruments.Columns.Count; i++)
            {
                columnContents[i] = dgvAllInstruments.Rows[e.RowIndex].Cells[i].Value.ToString();
            }

            ((DataTable)dgvUserInstruments.DataSource).Rows.Add(columnContents);

            ((DataTable)dgvAllInstruments.DataSource).Rows.RemoveAt(e.RowIndex);
        }

        private void UserInstrumentsHeaderButton_Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            string[] columnContents = new string[dgvAllInstruments.Columns.Count];
            for (int i = 0; i < dgvAllInstruments.Columns.Count; i++)
            {
                columnContents[i] = dgvUserInstruments.Rows[e.RowIndex].Cells[i].Value.ToString();
            }

            ((DataTable)dgvAllInstruments.DataSource).Rows.Add(columnContents);

            ((DataTable)dgvUserInstruments.DataSource).Rows.RemoveAt(e.RowIndex);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvAllInstruments.SelectedCells.Count != 0)
            {
                int index = dgvAllInstruments.SelectedCells[0].RowIndex;
                string[] columnContents = new string[dgvUserInstruments.Columns.Count];
                for (int i = 0; i < dgvUserInstruments.Columns.Count; i++)
                {

                    columnContents[i] = dgvAllInstruments.Rows[index].Cells[i].Value.ToString();

                }

                ((DataTable)dgvUserInstruments.DataSource).Rows.Add(columnContents);

                ((DataTable)dgvAllInstruments.DataSource).Rows.RemoveAt(index);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvUserInstruments.SelectedCells.Count != 0)
            {
                int index = dgvUserInstruments.SelectedCells[0].RowIndex;
                string[] columnContents = new string[dgvAllInstruments.Columns.Count];
                for (int i = 0; i < dgvAllInstruments.Columns.Count; i++)
                {
                    columnContents[i] = dgvUserInstruments.Rows[index].Cells[i].Value.ToString();
                }

                ((DataTable)dgvAllInstruments.DataSource).Rows.Add(columnContents);

                ((DataTable)dgvUserInstruments.DataSource).Rows.RemoveAt(index);
            }
        }
    }
}
