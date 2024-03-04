using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evalution2._2
{
    public partial class Calender : UserControl
    {
        List<TextBox> list = new List<TextBox>();
        //List<TextBox> WeekList = new List<TextBox>();
        DateTime cal = new DateTime(2024, 2, 1);
        DateTime date = DateTime.Now;

        public Calender()
        {
            InitializeComponent();
            cal = DateTime.Today;
            foreach (Control c in DatePanel.Controls)
            {
                if (c is TextBox)
                {
                    TextBox textBox = c as TextBox;
                    textBox.TextAlign = HorizontalAlignment.Center;
                    textBox.BackColor = Color.DimGray;
                    textBox.BorderStyle = BorderStyle.None;
                    textBox.Font = new Font("Microsoft Sans Serif", 15, FontStyle.Regular);
                    list.Add(c as TextBox);
                }
            }
            list.Reverse();

            foreach (Control c in WeekPanel.Controls)
            {
                if (c is TextBox)
                {
                    TextBox textBox = c as TextBox;
                    textBox.TextAlign = HorizontalAlignment.Center;
                    textBox.BackColor = Color.DimGray;
                    textBox.BorderStyle = BorderStyle.None;
                    textBox.Font = new Font("Microsoft YaHei UI", 10, FontStyle.Bold);
                    //WeekList.Add(c as TextBox);
                }
            }

            Timer time = new Timer
            {
                Interval = 100
            };
            time.Tick += TimeUpdate;
            time.Start();
        }

        private void TimeUpdate(object sender, EventArgs e)
        {
            TimeLabel.Text = DateTime.Now.ToLongTimeString();
        }

        private void CalenderLoad(object sender, EventArgs e)
        {
            MonthLabel.Text = cal.Month.ToString();
            YearLabel.Text = cal.Year.ToString();
            int day = (int)cal.DayOfWeek;

            SetDay(day);
            DayLabel.Text = date.ToLongDateString();
            DayLabel.ForeColor = Color.LightSkyBlue;
        }

        private void SetDay(int day)
        {
            int count = 1;
            int n = DateTime.DaysInMonth(cal.Year, cal.Month);

            for (int i = day; count <= n && i < 35; i++)
            {
                HighLight(list[i], count);
                list[i].Text = count.ToString();
                count++;
            }

            if (count <= n)
            {
                for (int i = 0; i < day; i++)
                {
                    HighLight(list[i], count);
                    list[i].Text = count.ToString();
                    count++;
                    if (count > n)
                    {
                        break;
                    }
                }
            }
        }

        private void HighLight(TextBox textbox, int day)
        {
            DateTime Today = DateTime.Today;
            int today = Today.Day;
            int searchDay = 0;
            if (SearchBox.Text != "")
            {
                DateTime SearchDate = DateTime.Parse(SearchBox.Text);
                searchDay = SearchDate.Day;
            }
            if (day == today && cal.Month == Today.Month && cal.Year == Today.Year 
                ||(SearchBox.Text != "" && searchDay == day))
            {
                textbox.BorderStyle = BorderStyle.Fixed3D;
                textbox.BackColor = Color.Blue;
                textbox.ForeColor = Color.White;
                SearchBox.Text = "";
            }
            else
            {
                textbox.ForeColor = Color.Black;
                textbox.BorderStyle = BorderStyle.None;
                textbox.BackColor = Color.DimGray;
            }
        }

        private void MonthNextButton_Click(object sender, EventArgs e)
        {
            int month = int.Parse(MonthLabel.Text);

            if (month < 12)
            {
                month++;
            }
            else
            {
                month = 1;
                int year = int.Parse(YearLabel.Text);
                year++;
                YearLabel.Text = (year).ToString();
            }
            MonthLabel.Text = month.ToString();
            ClearList();
            cal = new DateTime(int.Parse(YearLabel.Text), month, 1);
            int day = (int)cal.DayOfWeek;
            SetDay(day);
        }

        private void MonthBackButton_Click(object sender, EventArgs e)
        {
            int month = int.Parse(MonthLabel.Text);

            if (month > 1)
            {
                month--;
            }
            else
            {
                month = 12;
                int year = int.Parse(YearLabel.Text);
                year--;
                YearLabel.Text = (year).ToString();
            }
            ClearList();
            MonthLabel.Text = month.ToString();
            cal = new DateTime(int.Parse(YearLabel.Text), month, 1);
            int day = (int)cal.DayOfWeek;
            SetDay(day);
        }
        private void ClearList()
        {
            foreach (var t in list)
            {
                t.Text = "";
            }
        }
        private void YearNextButton_Click(object sender, EventArgs e)
        {
            int year = int.Parse(YearLabel.Text);
            year++;
            YearLabel.Text = year.ToString();
            ClearList();
            cal = new DateTime(year, int.Parse(MonthLabel.Text), 1);
            int day = (int)cal.DayOfWeek;
            SetDay(day);
        }

        private void YearBackButton_Click(object sender, EventArgs e)
        {
            int year = int.Parse(YearLabel.Text);
            year--;
            YearLabel.Text = year.ToString();
            ClearList();
            cal = new DateTime(year, int.Parse(MonthLabel.Text), 1);
            int day = (int)cal.DayOfWeek;
            SetDay(day);
        }

        private void SearchButtonClick(object sender, EventArgs e)
        {
            if (SearchBox.Text != "")
            {
                DateTime SearchDate = DateTime.Parse(SearchBox.Text);
                cal = new DateTime(SearchDate.Year , SearchDate.Month , 1);
                MonthLabel.Text = cal.Month.ToString();
                YearLabel.Text = cal.Year.ToString();
                ClearList();
                SetDay((int)cal.DayOfWeek);
            }
        }
    }
}
