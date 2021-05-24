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
    public partial class CounterControl : UserControl
    {
        //public event EventHandler<CounterEventArgs> CounterEvent;

        public Stack<int> numbers;// = new Stack<int>();

        public int Counter { get  ; set; }
        public int Step { get { return numbers.Count; } }
        public int ResNumber { get; set; }
        public bool Play { get; set; }

        private void UpdateUI()
        {
            lblNumber.Text = Counter.ToString();
            lblStep.Text = Step.ToString();
            lblResNumber.Text = ResNumber.ToString();
            if (Play)
            {
                btnPlay.BackColor = Color.Red;
            }
            else
            {
                btnPlay.BackColor = Color.LightGray;
            }
            btnReset.Enabled = Play;
            btnMulti2.Enabled = Play;
            btnPlus1.Enabled = Play;
            btnUndo.Enabled = Play;

        }

        public void ResetCounter()
        {
            numbers.Clear();
            Counter = 0;
            Play = false;
            UpdateUI();
        }

        public CounterControl()
        {
            InitializeComponent();
            numbers = new Stack<int>();
            ResetCounter();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetCounter();
        }

        private void btnMulti2_Click(object sender, EventArgs e)
        {
            Counter *= 2;
            numbers.Push(Counter);
            if (Play && Counter == ResNumber)
            {
                MessageBox.Show($"Вы достигли числа {ResNumber} за количество шагов = {Step}. Вы выиграли!",
                    "Игра", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Play = false;
            }
            if (Play && Counter > ResNumber)
            {
                MessageBox.Show($"Вы превысили число {ResNumber}. Вы проиграли!",
                    "Игра", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Play = false;
            }
            UpdateUI();
        }

        private void btnPlus1_Click(object sender, EventArgs e)
        {
            Counter++;
            numbers.Push(Counter);
            if (Play && Counter== ResNumber)
            {
                MessageBox.Show($"Вы достигли числа {ResNumber} за количество шагов = {Step}. Вы выиграли!",
                    "Игра", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Play = false;
            }
            if (Play && Counter > ResNumber)
            {
                MessageBox.Show($"Вы превысили число {ResNumber}. Вы проиграли!",
                    "Игра", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Play = false;
            }
            UpdateUI();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            var rand = new Random();
            ResNumber = rand.Next(50,100);
            MessageBox.Show($"Достигните числа {ResNumber} за минимальное количество шагов используя x2 и +1",
                "Игра", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Play = true;
            UpdateUI();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (Step == 0)
                return;
            numbers.Pop();
            if (Step > 0)
                Counter = numbers.Peek();
            UpdateUI();
        }

        private void играToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnPlay_Click(sender, e);
        }

        private void x2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnMulti2_Click(sender, e);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            btnPlus1_Click(sender, e);
        }

        private void сбросToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnReset_Click(sender, e);
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnUndo_Click(sender, e);
        }

        /*
                private void bCounter_Click(object sender, EventArgs e)
                {
                    i++;
                    Counter++;
                    UpdateUI();
                    if (i >= 3)
                    {
                        if (CounterEvent != null)
                        {
                            CounterEvent.Invoke(this, new CounterEventArgs() { Counter = Counter});
                        }
                        i = 0;
                    }
                }

                private void txtbCounter_TextChanged(object sender, EventArgs e)
                {
                    int number = 0;

                    if (int.TryParse(txtbCounter.Text, out number))
                    {
                        Counter = number;
                        UpdateUI();
                    }
                    else
                    {
                        Counter = 0;
                        UpdateUI();
                    }
                }
        */




    }
/*
    public class CounterEventArgs: EventArgs
    {
        public int Counter { get; set; }
    }
*/
}
