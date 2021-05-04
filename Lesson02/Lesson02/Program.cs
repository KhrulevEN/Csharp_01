using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Хрулев Е. Н.
namespace Lesson02
{
    class Program
    {

        static void PrintXYColor(string msg, bool bWriteLine = true, int x = -1, int y = -1, ConsoleColor foregroundcolor = ConsoleColor.White)
        {
            if (x != -1 || y != -1)
            {
                Console.SetCursorPosition(x, y);
            }
            Console.ForegroundColor = foregroundcolor;
            if (bWriteLine)
            {
                Console.WriteLine(msg);
            }
            else
            {
                Console.Write(msg);
            }
        }

        static void Pause()
        {
            Console.ReadKey();
        }

        static double Min_from3(double dA, double dB, double dC)
        {
            double dMin = dA <= dB ? (dA <= dC ? dA : dC) : (dB <= dC ? dB : dC);
            return dMin;
        }

        static void Task01()
        {      
            //1. Написать метод, возвращающий минимальное из трёх чисел.
            Console.Clear();
            PrintXYColor("a: ", false);
            double dA = Convert.ToDouble(Console.ReadLine());
            PrintXYColor("b: ", false);
            double dB = Convert.ToDouble(Console.ReadLine());
            PrintXYColor("c: ", false);
            double dC = Convert.ToDouble(Console.ReadLine());
            double dMin = Min_from3(dA, dB, dC);
            Console.WriteLine($"Min = {dMin}");
        }

        static int SumDigitNumber(int nNumber)
        {
            int nSum = 0;
            while (nNumber > 0)
            {
                nSum += nNumber % 10;
                nNumber /= 10;
            }
            return nSum;
        }

        static void Task02()
        {      
            //2. Написать метод подсчета количества цифр числа.
            Console.Clear();
            PrintXYColor("Введите целое число: ",false);
            int nNumber = Convert.ToInt32(Console.ReadLine());
            int nSum = SumDigitNumber(nNumber);
            Console.WriteLine($"Сумма цифр = {nSum}");
        }

        static bool IsPositiveOdd(int nNumber)
        {
            return nNumber > 0 && nNumber % 2==1;
        }

        static void Task03()
        {
            //3. С клавиатуры вводятся числа, пока не будет введен 0. 
            //Подсчитать сумму всех нечетных положительных чисел.
            Console.Clear();
            PrintXYColor("Введите целые числа (0 - окончание ввода)");
            int nSumPositOdd = 0;
            int nNumber = 0;
            do
            {
                nNumber = Convert.ToInt32(Console.ReadLine());
                if (IsPositiveOdd(nNumber))
                {
                    nSumPositOdd += nNumber;
                }
            } while (nNumber != 0);
            Console.WriteLine($"Сумма всех нечетных положительных чисел = {nSumPositOdd}");
        }

        static bool IsCorrectLoginPassword(string sLogin, string sPassword)
        {
            return sLogin == "root" && sPassword == "GeekBrains";
        }

        static void Task04()
        {
            /*
             4. Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. 
             На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). 
             Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, 
             программа пропускает его дальше или не пропускает. 
             С помощью цикла do while ограничить ввод пароля тремя попытками. 
            */
            Console.Clear();
            bool bSuccessInput = false;
            int nCntInput = 0;
            do
            {
                PrintXYColor("Введите логин: ", false);               
                string sLogin = Console.ReadLine();
                PrintXYColor("Введите пароль: ", false);
                string sPassword = Console.ReadLine();
                bSuccessInput = IsCorrectLoginPassword(sLogin, sPassword);
                nCntInput++;
            } while (!bSuccessInput && nCntInput<3);
            if (bSuccessInput)
            {
                Console.WriteLine("Логин и пароль введены правильно!");
            }
            else
            {
                Console.WriteLine("Вы 3 раза ввели неверные логин и пароль!");
            }
            
        }

        static void Task05()
        {
            /*
            5.  а) Написать программу, которая запрашивает массу и рост человека, 
                вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.
                б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
            */
            Console.Clear();
            PrintXYColor("Введите массу в кг: ", false);
            double dWeight  = double.Parse(Console.ReadLine());
            PrintXYColor("Введите рост в м: ", false);
            double dHeight = double.Parse(Console.ReadLine());
            double dI = dWeight / (dHeight * dHeight);
            Console.WriteLine($"Индекс массы = {dI}");
            //PrintXYColor("а) Сообщает, нужно ли человеку похудеть, набрать вес или всё в норме");
            /*
                16 и менее	Выраженный дефицит массы тела
                16—18,5	Недостаточная (дефицит) масса тела
                18,5—25	Норма
                25—30	Избыточная масса тела (предожирение)
                30—35	Ожирение
                35—40	Ожирение резкое
                40 и более	Очень резкое ожирение 
            */
            double dWeightNormaDown = 18.5 * dHeight * dHeight;
            double dWeightNormaUp = 25 * dHeight * dHeight;
            double dDeltaWeightDown = dWeightNormaDown - dWeight;
            double dDeltaWeightUp = dWeight - dWeightNormaUp;

            if (dI < 16)
            {
                PrintXYColor("a) Выраженный дефицит массы тела");
            }
            else if (dI>=16 && dI<18.5)
            {
                PrintXYColor("a) Недостаточная (дефицит) масса тела");                
            }
            else if (dI >= 18.5 && dI <= 25)
            {
                PrintXYColor("a) Норма");
            }
            else if (dI > 25 && dI < 30)
            {
                PrintXYColor("a) Избыточная масса тела (предожирение)");
            }
            else if (dI >= 30 && dI < 35)
            {
                PrintXYColor("a) Ожирение");
            }
            else if (dI >= 35 && dI < 40)
            {
                PrintXYColor("a) Ожирение резкое");                
            }
            else
            {
                PrintXYColor("Очень резкое ожирение");
            }

            if (dI<18.5)
            {
                PrintXYColor($"б) Необходимо набрать {dDeltaWeightDown} кг!");
            }
            else if(dI > 25)
            {
                PrintXYColor($"б) Необходимо сбросить {dDeltaWeightUp} кг!");
            }
            else
            {
                PrintXYColor("У вас все хорошо. Ничего набирать и сбрасывать не надо!");
            }           
        }

        static void Task06()
        {
            /*
            6. *Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000. 
            «Хорошим» называется число, которое делится на сумму своих цифр. 
            Реализовать подсчёт времени выполнения программы, используя структуру DateTime.
            */
            Console.Clear();
            DateTime dt1 = DateTime.Now;
            PrintXYColor("Считается количество «хороших» чисел в диапазоне от 1 до 1 000 000 000");
            int nCntGoodNumber = 0;
            for (int i=1; i<=1000000000; i++)
            {
                int nSum = SumDigitNumber(i);
                if (i % nSum==0)
                {
                    nCntGoodNumber++;
                }
            }
            DateTime dt2 = DateTime.Now;
            PrintXYColor($"Количество «хороших» чисел в диапазоне от 1 до 1 000 000 000 = {nCntGoodNumber}");
            PrintXYColor((dt2-dt1).ToString());
        }

        static void OutputNumber(int a, int b)
        {
            if (a <= b)
            {
                PrintXYColor($"{a}");
                OutputNumber(a+1, b);
            }            
        }

        static int SumNumber(int a, int b)
        {
            if (a <= b)
            {
                return (a == b ? b : a + SumNumber(a + 1, b));
            }
            else
            {
                return 0;
            }

        }

        static void Task07()
        {
            /*
            7.
                a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
                б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.
            */
            Console.Clear();
            PrintXYColor("Введите число a: ", false);
            int nA = int.Parse(Console.ReadLine());
            PrintXYColor("Введите число b: ", false);
            int nB = int.Parse(Console.ReadLine());
            PrintXYColor("а) Рекурсивный метод, который выводит на экран числа от a до b (a < b).");
            OutputNumber(nA, nB);

            PrintXYColor("б) *Рекурсивный метод, который считает сумму чисел от a до b.");
            int nSum = SumNumber(nA, nB);
            PrintXYColor($"сумму чисел от a до b = {nSum}");
        }


        static void Main(string[] args)
        {
            int nNumTask = 0;
            do
            {
                Console.Clear();
                PrintXYColor("Введите номер домашнего задания от 1 - до 7 (0 - Выход): ", false, 0, 0, ConsoleColor.Red);
                nNumTask = int.Parse(Console.ReadLine());
                switch (nNumTask)
                {
                    case 0:
                        return;
                    case 1:
                        Task01();
                        break;
                    case 2:
                        Task02();
                        break;
                    case 3:
                        Task03();
                        break;
                    case 4:
                        Task04();
                        break;
                    case 5:
                        Task05();
                        break;
                    case 6:
                        Task06();
                        break;
                    case 7:
                        Task07();
                        break;
                    default:
                        PrintXYColor("Вы ввели неверный номер!");
                        break;
                }
                Pause();
            }
            while (nNumTask != 0);
        }
    }
}
