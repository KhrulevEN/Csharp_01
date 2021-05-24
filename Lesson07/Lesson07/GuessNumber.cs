using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson07
{
    public partial class GuessNumber : UserControl
    {

        clGuessNumber m_GuessNumber;

        public GuessNumber()
        {
            InitializeComponent();
            
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            m_GuessNumber = new clGuessNumber();
            UpdateUI();
        }


        public void ResetCounter()
        {
            m_GuessNumber.ResetCounter();
            UpdateUI();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetCounter();
        }

        private void UpdateUI()
        {            
            if (m_GuessNumber.Play)
            {
                btnPlay.BackColor = Color.Red;
                btnInput.Enabled = true;
            }
            else
            {
                btnPlay.BackColor = Color.LightGray;
                btnInput.Enabled = false;
            }
            lblInput.Text = "Введите число от " + m_GuessNumber.BeginRange.ToString()
                +" до "+ m_GuessNumber.EndRange.ToString();
            btnReset.Enabled = m_GuessNumber.Play;
            btnPlay.Enabled = !m_GuessNumber.Play;
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            bool bFinish = false;
            m_GuessNumber.InputNumber(txtbInput.Text, ref bFinish);
            UpdateUI();
        }

        private void btnPlayNewWindow_Click(object sender, EventArgs e)
        {
            formInput newFormInput = new formInput();
            newFormInput.ShowDialog();
        }
    }
}
