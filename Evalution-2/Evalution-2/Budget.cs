using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;

namespace Evalution_2
{
    public partial class Form1 : Form
    {
        public void SetButtonClick(object sender, EventArgs e)
        {
            if (BudgetBox.Text != "" && BudgetComboBox.Text != "")
            {
                string[] split = BudgetBox.Text.Split(' ');

                int value = int.Parse(split[0]);
                int month = int.Parse(split[1]);
                string key = BudgetComboBox.Text;
                if (Budget.ContainsKey(key) && Budget[key].ContainsKey(month))
                {
                    Budget[key][month] = value;
                }
                else if (Budget.ContainsKey(key))
                {
                    Budget[key].Add(month, value);
                }
                else
                {
                    Budget.Add(BudgetComboBox.Text, new Dictionary<int, int> { { month, value } });
                }
                BudgetBox.Text = "";
                BudgetComboBox.Text = "";
            }
            CheckPreviousBudget();
        }

        private void CheckPreviousBudget()
        {
            if (ExpenseGridView.RowCount > 0)
            {
                for (int i = 0; i < ExpenseGridView.RowCount; i++)
                {
                    DataGridViewRow row = ExpenseGridView.Rows[i];
                    string key = row.Cells[4].Value.ToString();
                    int amount = int.Parse(row.Cells[2].Value.ToString());
                    int month = (DateTime.Parse(row.Cells[3].Value.ToString())).Month;
                    if (Budget.ContainsKey(key) && Budget[key].ContainsKey(month))
                    {
                        Budget[key][month] -= amount;
                    }
                }
            }
        }

        private void CheckBudget(string key, int month, int amount)
        {
            if (Budget.ContainsKey(key) && Budget[key].ContainsKey(month))
            {
                Budget[key][month] -= amount;
                if (Budget[key][month] < 0)
                {
                    MessageBox.Show("The Limit of " + key + " Exceeded for month : " + month,
                        "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (Budget[key][month] == 0)
                {
                    MessageBox.Show("The Limit of " + key + " Reached for month : " + month,
                        "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
