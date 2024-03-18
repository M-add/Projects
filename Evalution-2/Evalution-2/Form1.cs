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
        #region Variables
        private DataTable data = new DataTable();
        Dictionary<string, Dictionary<string, int>> Budget = new Dictionary<string, Dictionary<string, int>>();
        private int index;
        private bool UpdateClick = false;
        private bool EditMode = false;
        Expenses expense;
        private int id = 1;
        #endregion

        #region DataBase Variables
        DataTable table = new DataTable();
        MySqlConnection connect;
        #endregion

        public Form1()
        {
            InitializeComponent();
            EditPanel.Controls.Add(ExpensePanel);
            ExpensePanel.Dock = DockStyle.Fill;
            ExpensePanel.SendToBack();
            FilterBox.Items.Add("All");
            DoubleBuffered = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region DataBase
            string localhost = "server=localhost;port=3306;uid=root;pwd=12345;database=mathan";
            connect = new MySqlConnection(localhost);
            connect.Open();
            string queryShow = "SELECT * FROM expense;";
            using (MySqlCommand commandShow = new MySqlCommand(queryShow, connect))
            {
                using (MySqlDataReader read = commandShow.ExecuteReader())
                {
                    table.Load(read);
                }
            }
            ExpenseGridView.DataSource = table;
            ExpenseGridView.Columns["Id"].Visible = false;
            SetId();
            InitializeBudget();
            #endregion

            textBox1.Font = textBox2.Font = textBox3.Font =
                new Font("Microsoft Sans Serif", 16, FontStyle.Regular);
            comboBox1.Font = new Font("Microsoft Tai Le", 12, FontStyle.Regular);

            //if(Budget.Count > 0)
            //{
            //    foreach(var exp in ExpenseManager.ExpenseList)
            //    {
            //        int month = exp.Date.Month;
            //        int year = exp.Date.Year;
            //        string category = exp.Category;
            //        string key = month + "," + year;
            //        if (Budget.ContainsKey(category) && Budget[category].ContainsKey(key))
            //        {
            //            Budget[category][key] -= exp.Amount;
            //        }
            //        Budgets.Refresh();
            //    }
            //}
            //ExpenseGridView.Columns.Add("Name", "Name");
            //ExpenseGridView.Columns.Add("Amount", "Amount");
            //ExpenseGridView.Columns.Add("Date", "Date");
            //ExpenseGridView.Columns.Add("Category", "Category");
        }

        private void SetId()
        {
            int i = 0;
            foreach (DataGridViewRow row in ExpenseGridView.Rows)
            {
                i = int.Parse(row.Cells[0].Value.ToString());
                string name = row.Cells[1].Value.ToString();
                string amount = row.Cells[2].Value.ToString();
                string date = row.Cells[3].Value.ToString();
                string category = row.Cells[4].Value.ToString();
                Expenses exp = new Expenses(category, name, amount, date);
                ExpenseManager.ExpenseList.Add(exp);
            }
            id = i + 1;
        }

        private void DataBaseConnection(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connect);
            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                string queryShow = "SELECT * FROM expense;";
                using (MySqlCommand commandShow = new MySqlCommand(queryShow, connect))
                {
                    using (MySqlDataReader read = commandShow.ExecuteReader())
                    {
                        table.Load(read);
                    }
                }
                ExpenseGridView.DataSource = table;
            }

        }

        private void ExpenseGridViewCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ExpenseGridView.Refresh();
            int count = 0;

            string key = ExpenseManager.ExpenseList[e.RowIndex].Category;
            int month = ExpenseManager.ExpenseList[e.RowIndex].Date.Month;
            int Year = ExpenseManager.ExpenseList[e.RowIndex].Date.Year;
            int amount = ExpenseManager.ExpenseList[e.RowIndex].Amount;
            string InnerKey = "" + month + "," + Year;
            if (Budget.ContainsKey(key) && Budget[key].ContainsKey(InnerKey))
            {
                Budget[key][InnerKey] += amount;
            }
            foreach (var exp in ExpenseManager.ExpenseList)
            {
                exp.Name = ExpenseGridView.Rows[count].Cells[1].Value.ToString();
                exp.Amount = int.Parse(ExpenseGridView.Rows[count].Cells[2].Value.ToString());
                exp.Date = DateTime.Parse(ExpenseGridView.Rows[count].Cells[3].Value.ToString());
                exp.Category = ExpenseGridView.Rows[count].Cells[4].Value.ToString();
                count++;
            }

            if (Budget.ContainsKey(key) && Budget[key].ContainsKey(InnerKey))
            {
                Budget[key][InnerKey] -= ExpenseManager.ExpenseList[e.RowIndex].Amount;
                if (Budget[key][InnerKey] <= 0)
                {
                    MessageBox.Show("The Limit of " + key + " Exceeded for month :- " + month, "",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
        }

        private void ExpenseGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index = e.RowIndex;
                DataGridViewRow row = ExpenseGridView.Rows[index];
                if (index >= 0)
                {
                    if (EditMode)
                    {
                        comboBox1.Text = row.Cells[4].Value.ToString();
                        textBox1.Text = row.Cells[1].Value.ToString();
                        textBox2.Text = row.Cells[2].Value.ToString();
                        textBox3.Text = (DateTime.Parse(row.Cells[3].Value.ToString())).ToShortDateString();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void TitlePanelPaint(object sender, PaintEventArgs e)
        {
        }

        private void SidePanelButtonClick(object sender, EventArgs e)
        {
            SidePanel.Visible = !SidePanel.Visible;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        private void TitlePanelResize(object sender, EventArgs e)
        {
            BudgetBox.Location = new Point(TitlePanel.Width - BudgetBox.Width - SetButton.Width - 10,
                BudgetBox.Location.Y);
            BudgetComboBox.Location = new Point(TitlePanel.Width - BudgetBox.Width - SetButton.Width - 10,
                BudgetComboBox.Location.Y);
            SetButton.Location = new Point(TitlePanel.Width - SetButton.Width, SetButton.Location.Y);
        }



        private void ExpenseGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (e.RowIndex < ExpenseManager.ExpenseList.Count)
            {
                string key = ExpenseManager.ExpenseList[e.RowIndex].Category;
                int amount = ExpenseManager.ExpenseList[e.RowIndex].Amount;
                int month = ExpenseManager.ExpenseList[e.RowIndex].Date.Month;
                int Year = ExpenseManager.ExpenseList[e.RowIndex].Date.Year;
                string InnerKey = "" + month + "," + Year;
                if (Budget.ContainsKey(key) && Budget[key].ContainsKey(InnerKey))
                {
                    Budget[key][InnerKey] += amount;
                }
                foreach (DataRow row in BudgetTable.Rows)
                {
                    string category = row[1].ToString();
                    string monthYear = row[2].ToString();
                    int amt = int.Parse(row[3].ToString());
                    if (category == key && monthYear == InnerKey)
                    {
                        row[3] = amt + amount;
                    }
                }
                Budgets.Refresh();

                //    if (!UpdateClick)
                //    {
                //ExpenseManager.ExpenseList.RemoveAt(e.RowIndex);
                //if (e.RowIndex == 0)
                //{
                //    ExpenseManager.ExpenseList.RemoveAt(e.RowIndex);
                //}
                //else
                //{
                //    ExpenseManager.ExpenseList.RemoveAt(e.RowIndex - 1);
                //}
                //    }
                //}

                //if (!UpdateClick)
                //{
                //    if (ExpenseGridView.RowCount < 1)
                //    {
                //        ExpenseManager.ExpenseList.Clear();
                //    }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            //Expense Table Update
            string query = "Delete from expense";
            MySqlCommand cmd = new MySqlCommand(query, connect);
            cmd.ExecuteNonQuery();
            int count = 1;
            int d = ExpenseGridView.Rows.Count;
            ExpenseManager.ExpenseList.ForEach((ex) =>
            {
                cmd = new MySqlCommand($"Insert into expense values({count++},@Name , @Amount ,@Date,@Category )", connect);
                cmd.Parameters.AddWithValue("@Name", ex.Name);
                cmd.Parameters.AddWithValue("@Amount", ex.Amount);
                cmd.Parameters.AddWithValue("@Date", ex.Date);
                cmd.Parameters.AddWithValue("@Category", ex.Category);
                cmd.ExecuteNonQuery();
            });

            //Budget Table Update
            query = "Delete from budget";
            cmd = new MySqlCommand(query, connect);
            cmd.ExecuteNonQuery();
            count = 1;
            foreach (var budget in Budget)
            {
                string category = budget.Key;
                string MonthYear = "";
                int amount = 0;
                foreach (var dict in Budget[category])
                {
                    MonthYear = dict.Key;
                    amount = dict.Value;
                    cmd = new MySqlCommand($"Insert into budget values({count++},@Category , @MonthYear , @Budget)", connect);
                    cmd.Parameters.AddWithValue("@Category", category);
                    cmd.Parameters.AddWithValue("@MonthYear", MonthYear);
                    cmd.Parameters.AddWithValue("@Budget", amount);
                    cmd.ExecuteNonQuery();
                }
            }
            connect.Close();
            base.OnFormClosing(e);
        }

    }
}
