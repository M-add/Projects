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
        private void AddExpenseButton_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && textBox3.Text != "" && textBox2.Text != "")
            {
                expense = new Expenses(comboBox1.Text, textBox1.Text, textBox2.Text,
                        textBox3.Text);

                //ExpenseGridView.Rows.Add(expense.Name, expense.Amount,
                //    expense.Date.ToShortDateString(), expense.Category);

                string query = "INSERT INTO expense (Id ,Name, Amount ,Date, Category) VALUES " +
               "('" + id++ + "', '" + expense.Name + "', '" + expense.Amount + "', '" +
                expense.Date.ToString("yyyy-MM-dd") + "', '" + expense.Category + "');";

                ExpenseManager.ExpenseList.Add(expense);

                DataBaseConnection(query);

                CheckBudget(expense.Category, expense.Date.Month, expense.Date.Year, expense.Amount);
            }
        }

        //Category Filter
        private void AddOkButtonClick(object sender, EventArgs e)
        {
            if (valueBox.Text != "")
            {
                comboBox1.Items.Add(valueBox.Text);
                FilterBox.Items.Add(valueBox.Text);
                BudgetComboBox.Items.Add(valueBox.Text);
                AddNewPanel.Visible = false;
                valueBox.Text = "";
            }
        }

        private void AddCategoryClick(object sender, EventArgs e)
        {
            AddNewPanel.Visible = !AddNewPanel.Visible;
        }

        private void RemoveCategoryClick(object sender, EventArgs e)
        {
            string category = comboBox1.Text != "" ? comboBox1.Text : "";
            if (category != "")
            {
                comboBox1.Items.Remove(category);
                FilterBox.Items.Remove(category);
                BudgetComboBox.Items.Remove(category);
            }
        }
    }
}
