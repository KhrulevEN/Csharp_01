using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
а) Добавить в программу «Удвоитель» подсчёт количества отданных команд удвоителю.
б) Добавить меню и команду «Играть». При нажатии появляется сообщение, какое число должен получить игрок. 
Игрок должен получить это число за минимальное количество ходов.
в) *Добавить кнопку «Отменить», которая отменяет последние ходы. Используйте обобщенный класс Stack.
Вся логика игры должна быть реализована в классе с удвоителем.


Используя Windows Forms, разработать игру «Угадай число». Компьютер загадывает число от 1 до 100, 
а человек пытается его угадать за минимальное число попыток. Компьютер говорит, 
больше или меньше загаданное число введенного.  
a) Для ввода данных от человека используется элемент TextBox;
б) **Реализовать отдельную форму c TextBox для ввода числа.
*/

namespace Lesson07
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


/*

        private void counterControl3_CounterEvent(object sender, CounterEventArgs e)
        {
            MessageBox.Show($"Вы 3 раза нажали на кнопку. Счетчик={e.Counter}",
                "Счетчик", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
*/

    }
}
