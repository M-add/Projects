using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evalution_2
{
    public class Expenses
    {
        //public static List<Expenses> ExpenseList = new List<Expenses>();

        public string Category { get; set; }
        public string Name;
        public int Amount;
        public DateTime Date;
        private int Budget { get; set; }

        public Expenses(string category, string name, string amt, string date)
        {
            Category = category;
            Name = name == "" ? category : name;
            Amount = int.Parse(amt);
            Date = DateTime.Parse(date);
        }
    }
}
