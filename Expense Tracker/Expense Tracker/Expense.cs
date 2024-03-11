using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evalution_2
{
    public class Expense
    {
        public static List<Expense> ExpenseList = new List<Expense>();

        public string Category { get; set; }
        public string Name;
        public int Amount;
        public DateTime Date;
        private int Budget { get; set; }

        public Expense(string category, string name, string amt, string date)
        {
            Category = category;
            Name = name == "" ? category : name;
            Amount = int.Parse(amt);
            Date = DateTime.Parse(date);
        }
    }
}
