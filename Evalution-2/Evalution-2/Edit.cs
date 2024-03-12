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
        private void EditButtonClick(object sender, EventArgs e)
        {
            if (!EditMode)
            {
                EditButton.BackColor = SystemColors.Highlight;
                ExpenseGridView.ReadOnly = false;
            }
            else
            {
                EditButton.BackColor = Color.FromArgb(214, 201, 235);
                ExpenseGridView.ReadOnly = true;
            }
            EditMode = !EditMode;
            EditModePanel.Visible = !EditModePanel.Visible;
        }

        private void UpdateButtonClick(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && textBox1.Text != "" && textBox1.Text != "" && textBox3.Text != "")
            {
                ExpenseGridView.Rows[index].Cells[1].Value = textBox1.Text;
                ExpenseGridView.Rows[index].Cells[2].Value = textBox2.Text;
                ExpenseGridView.Rows[index].Cells[3].Value = textBox3.Text;
                ExpenseGridView.Rows[index].Cells[4].Value = comboBox1.Text;
            }
        }

        private void RemoveButtonClick(object sender, EventArgs e)
        {
            if (index >= 0)
            {
                ExpenseGridView.Rows.RemoveAt(index);
                ExpenseManager.ExpenseList.RemoveAt(index);
            }
        }

        private void RemoveAlluttonClick(object sender, EventArgs e)
        {
            Budget.Clear();
            ExpenseGridView.Rows.Clear();
            ExpenseManager.ExpenseList.Clear();
        }
    }
}
