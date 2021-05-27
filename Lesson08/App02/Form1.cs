using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void numudNumber_ValueChanged(object sender, EventArgs e)
        {
            txtbNumber.Text = numudNumber.Value.ToString();
        }
    }
}
