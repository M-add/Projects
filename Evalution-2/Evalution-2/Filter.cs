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
        private bool FiterClicked = false;

        private void FilterButtonClick(object sender, EventArgs e)
        {
            FiterClicked = !FiterClicked;
            if (FiterClicked)
            {
                FilterButton.BackColor = SystemColors.Highlight;
            }
            else
            {
                FilterButton.BackColor = Color.FromArgb(214, 201, 235);

            }
            FilterPanel.Visible = !FilterPanel.Visible;
        }

        private void SearchButtonClick(object sender, EventArgs e)
        {
            List<int> id = new List<int>();

            if (CustomSearchBoxFrom.Text != "" && CustomSearchBoxTo.Text != "")
            {
                DateTime From = DateTime.Parse(CustomSearchBoxFrom.Text);
                DateTime To = DateTime.Parse(CustomSearchBoxTo.Text);
                for (int i = 0; i < ExpenseManager.ExpenseList.Count; i++)
                {
                    Expenses expense = ExpenseManager.ExpenseList[i];
                    if (expense.Date >= From && expense.Date <= To)
                    {
                        id.Add(i);
                    }
                }
                CustomDateSearch view = new CustomDateSearch(id, From, To);
                view.Show();
                view.UpdateClick += UpdateDataTable;
            }
        }

        private void FilterSearchClick(object sender, EventArgs e)
        {
            #region DataTable
            DataTable tab = new DataTable();
            tab.Columns.Add("S.No");
            tab.Columns.Add("Title");
            tab.Columns.Add("Amount");
            tab.Columns.Add("Date");
            tab.Columns.Add("Category");
            int count = 1;

            if (FilterBox.Text != "" && FilterBox.Text != "All")
            {
                foreach (var exp in ExpenseManager.ExpenseList)
                {
                    if (exp.Category == FilterBox.Text)
                    {
                        tab.Rows.Add(count, exp.Name, exp.Amount,
                            exp.Date.ToShortDateString(), exp.Category);
                        count++;
                    }
                }
                FilterView filter = new FilterView(FilterBox.Text);
                filter.Show();
                filter.UpdateClick += UpdateDataTable;
            }
            #endregion
        }

        //Event Handler
        private void UpdateDataTable(object sender, int[] prev)
        {
            UpdateClick = true;
            string key = FilterBox.Text;
            int month = prev[2];
            int year = prev[3];
            string InnerKey = month + "," + year;
            int prevAmount = prev[0];
            int updatedAmount = prev[1];

            if (Budget.ContainsKey(key) && Budget[key].ContainsKey(InnerKey))
            {
                Budget[key][InnerKey] += prevAmount;
                Budget[key][InnerKey] -= updatedAmount;
            }
            foreach (DataRow row in BudgetTable.Rows)
            {
                string category = row[1].ToString();
                string monthYear = row[2].ToString();
                int amt = int.Parse(row[3].ToString());
                if (category == key && monthYear == InnerKey)
                {
                    row[3] = Budget[key][InnerKey];
                }
            }
            Budgets.Refresh();
            //ExpenseGridView.Rows.Clear();
            table.Rows.Clear();
            ExpenseGridView.DataSource = null;
            if (Budget.ContainsKey(key) && Budget[key].ContainsKey(InnerKey))
            {
                //Budget[key][InnerKey] -= updatedAmount;
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
            int count = 1;
            foreach (var expense in ExpenseManager.ExpenseList)
            {
                table.Rows.Add(count++, expense.Name, expense.Amount,
                expense.Date.ToShortDateString(), expense.Category);
                //ExpenseGridView.Rows.Add(expense.Name, expense.Amount,
                //expense.Date.ToShortDateString(), expense.Category);
            }
            ExpenseGridView.DataSource = table;
            ExpenseGridView.Refresh();
            UpdateClick = false;
        }
    }
}
