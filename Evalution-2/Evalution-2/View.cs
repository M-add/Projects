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
        private void ViewButtonClick(object sender, EventArgs e)
        {
            if (ViewButton.BackColor == Color.FromArgb(174, 148, 216))
            {
                ViewButton.BackColor = SystemColors.Highlight;
            }
            else
            {
                ViewButton.BackColor = Color.FromArgb(174, 148, 216);
            }
            ViewPanel.Visible = !ViewPanel.Visible;
        }

        private void MonthViewButton_Click(object sender, EventArgs e)
        {
            MonthView view = new MonthView();
            view.Show();
        }

        private void DayViewButtonClick(object sender, EventArgs e)
        {
            DayView view = new DayView(ExpenseManager.ExpenseList);
            view.Show();
        }

        private void TotalButtonClick(object sender, EventArgs e)
        {
            if (ExpenseGridView.RowCount > 0)
            {
                int total = 0;
                for (int i = 0; i < ExpenseGridView.RowCount; i++)
                {
                    total += int.Parse(ExpenseGridView.Rows[i].Cells[2].Value.ToString());
                }

                MessageBox.Show(total.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
