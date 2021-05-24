using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson07
{
    public partial class formInput : Form
    {
        clGuessNumber m_GuessNumber;
        public formInput()
        {
            InitializeComponent();
            m_GuessNumber = new clGuessNumber();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            bool bFinish = false;
            m_GuessNumber.InputNumber(txtbInput.Text, ref bFinish);
            lblInput.Text = "Введите число от " + m_GuessNumber.BeginRange.ToString()
                + " до " + m_GuessNumber.EndRange.ToString();
            if (bFinish)
            {
                Close();
            }
        }
    }
}
