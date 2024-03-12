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
    public partial class DayView : Form
    {
        private Dictionary<string, Dictionary<DateTime, int>> monthExpense = new Dictionary<string, Dictionary<DateTime, int>>();
        private HashSet<string> Categories = new HashSet<string>();
        List<Expenses> ExpenseList = new List<Expenses>();
        private DataTable table = new DataTable();

        public DayView(List<Expenses> list)
        {
            InitializeComponent();

            table.Columns.Add("S.No");
            table.Columns.Add("Category");
            table.Columns.Add("Day");
            table.Columns.Add("Month");
            table.Columns.Add("Amount");

            ExpenseList = list;
            SetYear();
        }

        private void SetYear()
        {
            HashSet<int> yearSet = new HashSet<int>();
            foreach (var exp in ExpenseList)
            {
                int year = exp.Date.Year;
                if (!yearSet.Contains(year))
                {
                    yearSet.Add(year);
                    YearBox.Items.Add(year);
                }
            }
        }

        private void AddData(List<Expenses> ExpenseList)
        {

            int index = 1;

            foreach (var category in Categories)
            {
                if (monthExpense.ContainsKey(category))
                {
                    foreach (var dict in monthExpense[category])
                    {
                        table.Rows.Add(index++, category, dict.Key.Day, dict.Key.Month, dict.Value);
                    }
                }
            }

            dataGridView1.DataSource = table;
            TotalExpense();
        }

        private void SetButtonClick(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                RemoveDataGridViewRows();
                table.Clear();
                textBox1.Text = "";
                monthExpense.Clear();
            }

            if (YearBox.Text != "")
            {
                int Year = int.Parse(YearBox.Text);
                foreach (var expense in ExpenseList)
                {
                    if (expense.Date.Year == Year)
                    {
                        string key = expense.Category;
                        DateTime date = expense.Date;
                        Categories.Add(key);

                        if (monthExpense.ContainsKey(key) && monthExpense[key].ContainsKey(date))
                        {
                            monthExpense[key][date] += expense.Amount;
                        }
                        else if (monthExpense.ContainsKey(key))
                        {
                            monthExpense[key].Add(date, expense.Amount);
                        }
                        else
                        {
                            monthExpense.Add(key, new Dictionary<DateTime, int> { { date, expense.Amount } });
                        }
                    }
                }

                AddData(ExpenseList);
            }
        }

        private void RemoveDataGridViewRows()
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows.RemoveAt(0);
            }
        }

        private void TotalExpense()
        {
            int total = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                total += int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
            }
            textBox1.Text = total.ToString();
        }
    }
}
