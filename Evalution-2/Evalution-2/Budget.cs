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
        private DataTable BudgetTable = new DataTable();
        private bool budgetShow = false;
        private DataGridView Budgets = new DataGridView();

        private void InitializeBudget()
        {
            string queryShow = "SELECT * FROM budget;";
            using (MySqlCommand commandShow = new MySqlCommand(queryShow, connect))
            {
                using (MySqlDataReader read = commandShow.ExecuteReader())
                {
                    BudgetTable.Load(read);
                }
            }
            Budgets.DataSource = BudgetTable;
            Budgets.Dock = DockStyle.Fill;
            Budgets.BackgroundColor = SystemColors.Control;
            Budgets.AllowUserToAddRows = false;
            Budgets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Budgets.Hide();
            GridViewPanel.Controls.Add(Budgets);

            foreach(DataRow budget in BudgetTable.Rows)
            {
                int amount = int.Parse(budget[3].ToString());
                string monthYear = budget[2].ToString();
                string category = budget[1].ToString();

                Budget.Add(category, new Dictionary<string, int> { { monthYear, amount } });
            }
        }

        private void BudgetTableShowClick(object sender, EventArgs e)
        {
            budgetShow = !budgetShow;
            if (budgetShow)
            {
                ExpenseGridView.Hide();
                Budgets.Show();
            }
            else
            {
                Budgets.Hide();
                ExpenseGridView.Show();
            }
        }

        private void BudgetButtonClick(object sender, EventArgs e)
        {
            BudgetPanel.Visible = true;
            BudgetButton.Visible = false;
        }

        public void SetButtonClick(object sender, EventArgs e)
        {
            if (BudgetBox.Text != "" && BudgetComboBox.Text != "")
            {
                string[] split = BudgetBox.Text.Split(' ');

                int value = int.Parse(split[0]);
                int month = int.Parse(split[1]);
                int year = int.Parse(split[2]);
                string InnerKey = month + "," + year;
                string key = BudgetComboBox.Text;
                if (Budget.ContainsKey(key) && Budget[key].ContainsKey(InnerKey))
                {
                    Budget[key][InnerKey] = value;
                }
                else if (Budget.ContainsKey(key))
                {
                    Budget[key].Add(InnerKey, value);
                }
                else
                {
                    Budget.Add(BudgetComboBox.Text,
                        new Dictionary<string, int> { { InnerKey, value } });
                }
                BudgetBox.Text = "";
                BudgetComboBox.Text = "";
                BudgetButton.Visible = true;
                BudgetPanel.Visible = false;
                AddBudgetToDataBase();
            }
            CheckPreviousBudget();
        }

        private void AddBudgetToDataBase()
        {
            foreach (var budget in Budget)
            {
                string category = budget.Key;
                string MonthYear ="";
                int amount = 0;
                foreach (var dict in Budget[category])
                {
                    MonthYear = dict.Key;
                    amount = dict.Value;
                }
                string query = "INSERT INTO budget (Category, MonthYear ,Budget) VALUES " +
               "('" + category + "', '" + MonthYear + "', '" + amount + "');";
                MySqlCommand command = new MySqlCommand(query, connect);
                command.ExecuteNonQuery();
                string queryShow = "SELECT * FROM budget;";
                using (MySqlCommand commandShow = new MySqlCommand(queryShow, connect))
                {
                    using (MySqlDataReader read = commandShow.ExecuteReader())
                    {
                        BudgetTable.Load(read);
                    }
                }
                Budgets.DataSource = BudgetTable;
            }
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
                    int year = (DateTime.Parse(row.Cells[3].Value.ToString())).Year;
                    string InnerKey = month + "," + year;
                    if (Budget.ContainsKey(key) && Budget[key].ContainsKey(InnerKey))
                    {
                        Budget[key][InnerKey] -= amount;
                    }
                }
            }
        }

        private void CheckBudget(string key, int month, int year, int amount)
        {
            string InnerKey = month + "," + year;

            if (Budget.ContainsKey(key) && Budget[key].ContainsKey(InnerKey))
            {
                Budget[key][InnerKey] -= amount;
                if (Budget[key][InnerKey] < 0)
                {
                    MessageBox.Show("The Limit of " + key + " Exceeded for month : " + month,
                        "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (Budget[key][InnerKey] == 0)
                {
                    MessageBox.Show("The Limit of " + key + " Reached for month : " + month,
                        "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
