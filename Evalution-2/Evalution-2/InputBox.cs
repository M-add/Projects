using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evalution_2
{
    public partial class InputBox : Form
    {
        public string Category { get; set; }

        public InputBox()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (ValueBox.Text != "")
            {
                Category = ValueBox.Text;
                Hide();
            }
        }
    }
}
