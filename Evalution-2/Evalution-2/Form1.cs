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
        Dictionary<string, Dictionary<int, int>> Budget = new Dictionary<string, Dictionary<int, int>>();
        private int index;
        private bool UpdateClick = false;
        private bool EditMode = false;
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
            ExpenseGridView.Columns["id"].Visible = false;
            #endregion

            textBox1.Font = textBox2.Font = textBox3.Font =
                new Font("Microsoft Sans Serif", 16, FontStyle.Regular);
            comboBox1.Font = new Font("Microsoft Tai Le", 12, FontStyle.Regular);

            //ExpenseGridView.Columns.Add("Name", "Name");
            //ExpenseGridView.Columns.Add("Amount", "Amount");
            //ExpenseGridView.Columns.Add("Date", "Date");
            //ExpenseGridView.Columns.Add("Category", "Category");
        }

        private void DataBaseConnection(string query)
        {
            //try
            //{

            //}
            //catch (Exception)
            //{
            //}
            //finally
            //{
            //    connect.Close();
            //}
            //connect.Open();

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


        private void AddExpenseButton_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && textBox3.Text != "" && textBox2.Text != "")
            {
                Expense expense = new Expense(comboBox1.Text, textBox1.Text, textBox2.Text,
                        textBox3.Text);
                Expense.ExpenseList.Add(expense);

                //ExpenseGridView.Rows.Add(expense.Name, expense.Amount,
                //    expense.Date.ToShortDateString(), expense.Category);

                string query = "INSERT INTO expense (Name, Amount ,Date, Category) VALUES " +
               "('"+ expense.Name + "', '" + expense.Amount + "', '" +
                expense.Date.ToString("yyyy-MM-dd") + "', '" + expense.Category + "');";

                DataBaseConnection(query);

                CheckBudget(expense.Category, expense.Date.Month, expense.Amount);
            }
        }

        private void CheckBudget(string key, int month, int amount)
        {
            if (Budget.ContainsKey(key) && Budget[key].ContainsKey(month))
            {
                Budget[key][month] -= amount;
                if (Budget[key][month] <= 0)
                {
                    MessageBox.Show("The Limit of " + key + " Exceeded for month :- " + month, "",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void MonthViewButton_Click(object sender, EventArgs e)
        {
            MonthView view = new MonthView();
            view.Show();
        }

        private void AddCategoryClick(object sender, EventArgs e)
        {
            AddNewPanel.Visible = !AddNewPanel.Visible;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DayView view = new DayView(Expense.ExpenseList);
            view.Show();
        }

        private void SearchButtonClick(object sender, EventArgs e)
        {
            List<int> id = new List<int>();

            if (CustomSearchBoxFrom.Text != "" && CustomSearchBoxTo.Text != "")
            {
                DateTime From = DateTime.Parse(CustomSearchBoxFrom.Text);
                DateTime To = DateTime.Parse(CustomSearchBoxTo.Text);
                for (int i = 0; i < Expense.ExpenseList.Count; i++)
                {
                    Expense expense = Expense.ExpenseList[i];
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

        private void ExpenseGridViewCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ExpenseGridView.Refresh();
            int count = 0;

            string key = Expense.ExpenseList[e.RowIndex].Category;
            int month = Expense.ExpenseList[e.RowIndex].Date.Month;
            if (Budget.ContainsKey(key) && Budget[key].ContainsKey(month))
            {
                Budget[key][month] += Expense.ExpenseList[e.RowIndex].Amount;
            }
            foreach (var exp in Expense.ExpenseList)
            {
                exp.Name = ExpenseGridView.Rows[count].Cells[0].Value.ToString();
                exp.Amount = int.Parse(ExpenseGridView.Rows[count].Cells[1].Value.ToString());
                exp.Date = DateTime.Parse(ExpenseGridView.Rows[count].Cells[2].Value.ToString());
                exp.Category = ExpenseGridView.Rows[count].Cells[3].Value.ToString();
                count++;
            }

            if (Budget.ContainsKey(key) && Budget[key].ContainsKey(month))
            {
                Budget[key][month] -= Expense.ExpenseList[e.RowIndex].Amount;
                if (Budget[key][month] <= 0)
                {
                    MessageBox.Show("The Limit of " + key + " Exceeded for month :- " + month, "",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
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
                foreach (var exp in Expense.ExpenseList)
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

        private void UpdateDataTable(object sender, int[] prev)
        {
            UpdateClick = true;
            string key = FilterBox.Text;
            int month = prev[2];
            int prevAmount = prev[0];
            int updatedAmount = prev[1];

            if (Budget.ContainsKey(key) && Budget[key].ContainsKey(month))
            {
                Budget[key][month] += prevAmount;
                Budget[key][month] -= updatedAmount;
            }
            ExpenseGridView.Rows.Clear();
            if (Budget.ContainsKey(key) && Budget[key].ContainsKey(month))
            {
                Budget[key][month] -= updatedAmount;
                if (Budget[key][month] <= 0)
                {
                    MessageBox.Show("The Limit of " + key + " Exceeded for month :- " + month, "",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            foreach (var expense in Expense.ExpenseList)
            {
                ExpenseGridView.Rows.Add(expense.Name, expense.Amount,
                expense.Date.ToShortDateString(), expense.Category);
            }
            ExpenseGridView.Refresh();
            UpdateClick = false;
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
                        comboBox1.Text = row.Cells[3].Value.ToString();
                        textBox1.Text = row.Cells[0].Value.ToString();
                        textBox2.Text = row.Cells[1].Value.ToString();
                        textBox3.Text = (DateTime.Parse(row.Cells[2].Value.ToString())).ToShortDateString();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void TitlePanelPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Brush brush = new SolidBrush(Color.WhiteSmoke);
            Font font = new Font("Microsoft Sans Serif", 28, FontStyle.Regular);
            Point point = new Point(TitlePanel.Width / 4, 0);
            e.Graphics.DrawString("Expense Tracker", font, brush, point);
        }

        private void SidePanelButtonClick(object sender, EventArgs e)
        {
            SidePanel.Visible = !SidePanel.Visible;
        }

        private void FilterButtonClick(object sender, EventArgs e)
        {
            FilterPanel.Visible = !FilterPanel.Visible;
        }

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

        private void SetButtonClick(object sender, EventArgs e)
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
            if (ExpenseGridView.RowCount > 0)
            {
                for (int i = 0; i < ExpenseGridView.RowCount - 1; i++)
                {
                    DataGridViewRow row = ExpenseGridView.Rows[i];
                    string key = row.Cells[3].Value.ToString();
                    int amount = int.Parse(row.Cells[1].Value.ToString());
                    int month = (DateTime.Parse(row.Cells[2].Value.ToString())).Month;
                    if (Budget.ContainsKey(key) && Budget[key].ContainsKey(month))
                    {
                        Budget[key][month] -= amount;
                    }
                }
            }
        }

        private void ExpenseGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (e.RowIndex < Expense.ExpenseList.Count)
            {
                string key = Expense.ExpenseList[e.RowIndex].Category;
                int month = Expense.ExpenseList[e.RowIndex].Date.Month;
                int amount = Expense.ExpenseList[e.RowIndex].Amount;
                if (Budget.ContainsKey(key) && Budget[key].ContainsKey(month))
                {
                    Budget[key][month] += amount;
                }

                if (!UpdateClick)
                {
                    Expense.ExpenseList.RemoveAt(e.RowIndex);
                    //if (e.RowIndex == 0)
                    //{
                    //    Expense.ExpenseList.RemoveAt(e.RowIndex);
                    //}
                    //else
                    //{
                    //    Expense.ExpenseList.RemoveAt(e.RowIndex - 1);
                    //}
                }
            }

            if (!UpdateClick)
            {
                if (ExpenseGridView.RowCount < 1)
                {
                    Expense.ExpenseList.Clear();
                }
            }
        }

        private void TotalButtonClick(object sender, EventArgs e)
        {
            if (ExpenseGridView.RowCount > 1)
            {
                int total = 0;
                for (int i = 0; i < ExpenseGridView.RowCount - 1; i++)
                {
                    total += int.Parse(ExpenseGridView.Rows[i].Cells[1].Value.ToString());
                }

                MessageBox.Show(total.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RemoveAlluttonClick(object sender, EventArgs e)
        {
            Budget.Clear();
            ExpenseGridView.Rows.Clear();
        }

        private void EditButtonClick(object sender, EventArgs e)
        {
            if (!EditMode)
            {
                EditButton.BackColor = SystemColors.Highlight;
            }
            else
            {
                EditButton.BackColor = Color.FromArgb(214, 201, 235);
            }
            EditMode = !EditMode;
            EditModePanel.Visible = !EditModePanel.Visible;
        }

        private void UpdateButtonClick(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && textBox1.Text != "" && textBox1.Text != "" && textBox3.Text != "")
            {
                ExpenseGridView.Rows[index].Cells[0].Value = textBox1.Text;
                ExpenseGridView.Rows[index].Cells[1].Value = textBox2.Text;
                ExpenseGridView.Rows[index].Cells[2].Value = textBox3.Text;
                ExpenseGridView.Rows[index].Cells[3].Value = comboBox1.Text;
            }
        }

        private void ViewButtonClick(object sender, EventArgs e)
        {
            if (ViewButton.BackColor == Color.FromArgb(214, 201, 235))
            {
                ViewButton.BackColor = SystemColors.Highlight;
            }
            else
            {
                ViewButton.BackColor = Color.FromArgb(214, 201, 235);
            }
            ViewPanel.Visible = !ViewPanel.Visible;
        }

        private void RemoveButtonClick(object sender, EventArgs e)
        {
            if (index >= 0)
            {
                ExpenseGridView.Rows.RemoveAt(index);
            }
        }
    }
}
