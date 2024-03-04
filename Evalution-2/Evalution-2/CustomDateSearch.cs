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
        public event EventHandler UpdateClick;
        private List<int> Id = new List<int>();
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
        }
        private void SetValue()
        {
            dataGridView1.Rows.Clear();
            foreach (var id in Id)
            {
                Expense exp = Expense.ExpenseList[id];
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
                DataGridViewRow row = dataGridView1.Rows[count];
                Expense.ExpenseList[i].Category = row.Cells[3].Value.ToString();
                Expense.ExpenseList[i].Name = row.Cells[0].Value.ToString();
                Expense.ExpenseList[i].Amount = int.Parse(row.Cells[1].Value.ToString());
                string s = dataGridView1.Rows[count].Cells[2].Value.ToString();
                Expense.ExpenseList[i].Date = DateTime.Parse(DateTime.Parse(s).ToShortDateString());
                count++;
            }
            SetValue();
            UpdateClick?.Invoke(this, EventArgs.Empty);
        }

        private void dataGridView1CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateButton.Visible = true;
        }
    }
}
