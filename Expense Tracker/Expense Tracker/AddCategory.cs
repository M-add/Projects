using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evalution_2
{
    public partial class AddCategory : UserControl
    {
        public event EventHandler<string> OkClick;
        public AddCategory()
        {
            InitializeComponent();
            panel1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ValueBox.Text != "")
            {
                OkClick?.Invoke(this, ValueBox.Text);
                ValueBox.Text = "";
            }
        }
    }
}
