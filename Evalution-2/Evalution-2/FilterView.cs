using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evalution_2
{
    public partial class FilterView : Form
    {
        private string category;
        public event EventHandler<int[]> UpdateClick;
        private int[] BudgetUpdate;

        public FilterView(string data)
        {
            InitializeComponent();
            category = data;

            dataGridView1.Columns.Add("Name" ,  "Name");
            dataGridView1.Columns.Add("Amount" , "Amount");
            dataGridView1.Columns.Add("Date" ,  "Date");
            dataGridView1.Columns.Add("Category" , "Category");
           
            SetValue();
            Total();

            dataGridView1.CellClick += DataGridViewCellClick;
        }

        private void DataGridViewCellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            BudgetUpdate = new int[4];
            BudgetUpdate[0] = int.Parse(row.Cells[1].Value.ToString());
            BudgetUpdate[2] = DateTime.Parse(DateTime.Parse(row.Cells[2].Value.ToString()).ToString()).Month;
            BudgetUpdate[3] = DateTime.Parse(DateTime.Parse(row.Cells[2].Value.ToString()).ToString()).Year;
        }

        private void SetValue()
        {
            dataGridView1.Rows.Clear();
            foreach (var exp in ExpenseManager.ExpenseList)
            {
                if (exp.Category == category)
                {
                    dataGridView1.Rows.Add(exp.Name, exp.Amount, exp.Date.ToShortDateString(), exp.Category);
                }
            }
        }

        private void Total()
        {
            int total = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                total += int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
            }
            textBox1.Text = total.ToString();
        }
        private void dataGridView1CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateButton.Visible = true;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            BudgetUpdate[1] = int.Parse(row.Cells[1].Value.ToString());

            Total();
        }
        
        private void UpdateButtonClick(object sender, EventArgs e)
        {
            int count = 0;
            foreach(var exp in ExpenseManager.ExpenseList)
            {
                if(exp.Category == category)
                {
                    if(dataGridView1.RowCount == 0)
                    {
                        ExpenseManager.ExpenseList.Remove(exp);
                    }
                    else if (dataGridView1.RowCount > 0)
                    {
                        exp.Category = dataGridView1.Rows[count].Cells[3].Value.ToString();
                        exp.Name = dataGridView1.Rows[count].Cells[0].Value.ToString();
                        exp.Amount = int.Parse(dataGridView1.Rows[count].Cells[1].Value.ToString());
                        string s = dataGridView1.Rows[count].Cells[2].Value.ToString();
                        exp.Date = DateTime.Parse(DateTime.Parse(s).ToShortDateString());
                        count++; 
                    }
                }
            }
            SetValue();
            UpdateClick?.Invoke(this, BudgetUpdate);
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            UpdateButton.Visible = true;
        }
    }
}
