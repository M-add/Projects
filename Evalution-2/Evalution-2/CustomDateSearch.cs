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
    public partial class CustomDateSearch : Form
    {
        public event EventHandler<int[]> UpdateClick;
        private List<int> Id = new List<int>();
        private int[] BudgetUpdate;
        DateTime From;
        DateTime To;

        public CustomDateSearch(List<int> id, DateTime FromDate, DateTime ToDate)
        {
            InitializeComponent();
            Id.AddRange(id);
            From = FromDate;
            To = ToDate;
            label2.Text = From.ToShortDateString();
            label4.Text = To.ToShortDateString();

            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Amount", "Amount");
            dataGridView1.Columns.Add("Date", "Date");
            dataGridView1.Columns.Add("Category", "Category");

            SetValue();
            Total();

            dataGridView1.CellClick += DataGridViewCellClick;
        }

        private void DataGridViewCellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            BudgetUpdate = new int[3];
            BudgetUpdate[0] = int.Parse(row.Cells[1].Value.ToString());
            BudgetUpdate[2] = DateTime.Parse(DateTime.Parse(row.Cells[2].Value.ToString()).ToString()).Month;
            BudgetUpdate[3] = DateTime.Parse(DateTime.Parse(row.Cells[2].Value.ToString()).ToString()).Year;
        }

        private void SetValue()
        {
            dataGridView1.Rows.Clear();
            foreach (var id in Id)
            {
                Expenses exp = ExpenseManager.ExpenseList[id];
                if (exp.Date >= From && exp.Date <= To)
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

        private void UpdateButtonClick(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i < Id.Count; i++)
            {
                try
                {
                    DataGridViewRow row = dataGridView1.Rows[count];
                    ExpenseManager.ExpenseList[i].Category = row.Cells[3].Value.ToString();
                    ExpenseManager.ExpenseList[i].Name = row.Cells[0].Value.ToString();
                    ExpenseManager.ExpenseList[i].Amount = int.Parse(row.Cells[1].Value.ToString());
                    string s = dataGridView1.Rows[count].Cells[2].Value.ToString();
                    ExpenseManager.ExpenseList[i].Date = DateTime.Parse(DateTime.Parse(s).ToShortDateString());
                    count++;
                }
                catch(Exception)
                {
                }
            }
            SetValue();
            UpdateClick?.Invoke(this, BudgetUpdate);
        }

        private void dataGridView1CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateButton.Visible = true;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            BudgetUpdate[1] = int.Parse(row.Cells[1].Value.ToString());

            Total();
        }
    }
}
