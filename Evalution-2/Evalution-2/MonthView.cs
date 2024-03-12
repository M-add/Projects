using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
namespace Evalution_2
{
    public partial class MonthView : Form
    {
        private Dictionary<string, Dictionary<int, int>> monthExpense = new Dictionary<string, Dictionary<int, int>>();
        private HashSet<string> Categories = new HashSet<string>();
        private DataTable table = new DataTable();

        public MonthView()
        {
            InitializeComponent();

            table.Columns.Add("S.No");
            table.Columns.Add("Category");
            table.Columns.Add("Month");
            table.Columns.Add("Amount");

            SetYear();
        }

        private void SetYear()
        {
            HashSet<int> yearSet = new HashSet<int>();
            foreach (var exp in ExpenseManager.ExpenseList)
            {
                int year = exp.Date.Year;
                if (!yearSet.Contains(year))
                {
                    yearSet.Add(year);
                    YearBox.Items.Add(year);
                }
            }
        }

        private void AddData()
        {

            int index = 1;

            foreach (var category in Categories)
            {
                if (monthExpense.ContainsKey(category))
                {
                    foreach (var dict in monthExpense[category])
                    {
                        table.Rows.Add(index++, category, dict.Key, dict.Value);
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
                foreach (var expense in ExpenseManager.ExpenseList)
                {
                    if (expense.Date.Year == Year)
                    {
                        string key = expense.Category;
                        int month = expense.Date.Month;
                        Categories.Add(key);

                        if (monthExpense.ContainsKey(key) && monthExpense[key].ContainsKey(month))
                        {
                            monthExpense[key][month] += expense.Amount;
                        }
                        else if (monthExpense.ContainsKey(key))
                        {
                            monthExpense[key].Add(month, expense.Amount);
                        }
                        else
                        {
                            monthExpense.Add(key, new Dictionary<int, int> { { month, expense.Amount } });
                        }
                    }
                }

                AddData();
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
                total += int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
            }
            textBox1.Text = total.ToString();
        }

    }
}
