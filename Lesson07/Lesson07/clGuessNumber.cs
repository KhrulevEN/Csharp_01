using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson07
{
    class clGuessNumber
    {
        private int ResNumber { get; set; }
        private int CurNumber { get; set; }
        public bool Play { get; set; }
        public int BeginRange { get; set; }
        public int EndRange { get; set; }

        public clGuessNumber()
        {
            var rand = new Random();
            CurNumber = 0;
            BeginRange = 1;
            EndRange = 100;
            ResNumber = rand.Next(BeginRange, EndRange+1);
            Play = true;
        }

        public void ResetCounter()
        {
            CurNumber = 0;
            Play = false;
            BeginRange = 0;
            EndRange = 100;
        }

        public bool InputNumber (string strText, ref bool bFinish )
        {
            int nNumber = CurNumber;

            bool bRes = int.TryParse(strText, out nNumber);
            if (bRes)
            {

                if (nNumber < 1 || nNumber > 100)
                {
                    MessageBox.Show("Вывели число не из диапазона [1;100]!",
                        "Игра", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                CurNumber = nNumber;
                if (CurNumber == ResNumber)
                {
                    MessageBox.Show($"Победа! Вы угадали число {ResNumber}",
                        "Игра", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetCounter();
                    bFinish = true;
                }
                else
                {
                    if (CurNumber > ResNumber)
                    {
                        MessageBox.Show($"У вас число больше нужного! Введите меньше!",
                            "Игра", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EndRange = CurNumber-1;
                    }
                    else
                    {
                        MessageBox.Show($"У вас число меньше нужного! Введите больше!",
                            "Игра", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BeginRange = CurNumber+1;
                    }
                }
            }
            else
            {
                MessageBox.Show($"Неверный формат числа!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bRes;
        }

    }
}
