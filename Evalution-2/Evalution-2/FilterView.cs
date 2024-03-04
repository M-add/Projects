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
        public event EventHandler UpdateClick;

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
        }

        private void SetValue()
        {
            dataGridView1.Rows.Clear();
            foreach (var exp in Expense.ExpenseList)
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
            Total();
        }

        private void UpdateButtonClick(object sender, EventArgs e)
        {
            int count = 0;
            foreach(var exp in Expense.ExpenseList)
            {
                if(exp.Category == category)
                {
                    if(dataGridView1.RowCount == 0)
                    {
                        Expense.ExpenseList.Remove(exp);
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
            UpdateClick?.Invoke(this, EventArgs.Empty);
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            UpdateButton.Visible = true;
        }
    }
}
