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
