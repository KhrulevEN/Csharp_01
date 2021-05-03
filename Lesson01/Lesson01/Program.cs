using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lesson01
{
    class MyFirstClass
    {
        public static void PrintXYColor(string msg, bool bWriteLine = true, int x = -1, int y = -1, ConsoleColor foregroundcolor = ConsoleColor.White)
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

        public static void Pause()
        {
            Console.ReadKey();
        }

    }

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

        static void Task01()
        {
            #region Task01
            /*
                Написать программу «Анкета». Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). 
                В результате вся информация выводится в одну строчку:   
                    а) используя  склеивание;
	                б) используя форматированный вывод;
	                в) используя вывод со знаком $.
            */
            Console.Clear();
            PrintXYColor("Task01", true, 40, 0, ConsoleColor.Red);
            PrintXYColor("Анкета", true, 40, 1, ConsoleColor.Red);
            //имя, фамилия, возраст, рост, веc
            PrintXYColor("Имя: ", false);
            string sName = Console.ReadLine();
            PrintXYColor("Фамилия: ", false);
            string sSurName = Console.ReadLine();
            PrintXYColor("Возраст: ", false);
            int nAge = Convert.ToInt32(Console.ReadLine());
            PrintXYColor("Рост: ", false);
            double dHeight = Convert.ToDouble(Console.ReadLine());
            PrintXYColor("Вес: ", false);
            double dWeight = double.Parse(Console.ReadLine());
            PrintXYColor("а) используя  склеивание");
            Console.WriteLine("Имя: " + sName + ", Фамилия: " + sSurName + ", Возраст: " + nAge + ", Рост: " + dHeight + ", Вес: " + dWeight);
            PrintXYColor("б) используя форматированный вывод");
            Console.WriteLine("Имя: {0}, Фамилия: {1}, Возраст: {2}, Рост: {3}, Вес: {4}", sName, sSurName, nAge, dHeight, dWeight);
            PrintXYColor("в) используя вывод со знаком $");
            Console.WriteLine($"Имя: {sName}, Фамилия: {sSurName}, Возраст: {nAge}, Рост: {dHeight}, Вес: {dWeight}");
            #endregion
        }

        static void Task02()
        {
            #region Task02
            /*
                Ввести вес и рост человека. Рассчитать и вывести индекс массы тела (ИМТ) по формуле I=m/(h*h); 
                где m — масса тела в килограммах, h — рост в метрах.
            */
            Console.Clear();
            PrintXYColor("Task02", true, 40, 0, ConsoleColor.Red);
            PrintXYColor("Вес в кг: ", false);
            double dWeight = double.Parse(Console.ReadLine());
            PrintXYColor("Рост в м: ", false);
            double dHeight = Convert.ToDouble(Console.ReadLine());
            double dI = dWeight / (dHeight * dHeight);
            Console.WriteLine($"Индекс массы тела (ИМТ): {dI}");
            #endregion
        }

        static void Task03()
        {
            #region Task03
            /*
                а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 
                    по формуле r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2). 
                    Вывести результат, используя спецификатор формата .2f (с двумя знаками после запятой);
                б) *Выполнить предыдущее задание, оформив вычисления расстояния между точками в виде метода.
            */
            Console.Clear();
            PrintXYColor("Task03", true, 40, 0, ConsoleColor.Red);
            PrintXYColor("X1: ", false);
            double dX1 = double.Parse(Console.ReadLine());
            PrintXYColor("Y1: ", false);
            double dY1 = Convert.ToDouble(Console.ReadLine());
            PrintXYColor("X2: ", false);
            double dX2 = double.Parse(Console.ReadLine());
            PrintXYColor("Y2: ", false);
            double dY2 = Convert.ToDouble(Console.ReadLine());
            double dR = Math.Sqrt(Math.Pow(dX2 - dX1, 2) + Math.Pow(dY2 - dY1, 2));
            Console.WriteLine($"R = {dR:F2}");
            #endregion
        }


        static void Task04()
        {
            #region Task04
            /*
                Написать программу обмена значениями двух переменных:
                    а) с использованием третьей переменной;
	                б) *без использования третьей переменной.
            */
            Console.Clear();
            PrintXYColor("Task04", true, 40, 0, ConsoleColor.Red);
            PrintXYColor("a: ", false);
            double dA = double.Parse(Console.ReadLine());
            PrintXYColor("b: ", false);
            double dB = Convert.ToDouble(Console.ReadLine());
            PrintXYColor($"a={dA}, b={dB}", true);
            PrintXYColor("а) с использованием третьей переменной", true);
            double dC = dA;
            dA = dB;
            dB = dC;
            PrintXYColor($"a={dA}, b={dB}", true);            
            PrintXYColor("б) *без использования третьей переменной (вернем в исходное:))", true);
            dA = dA + dB;
            dB = dA - dB;
            dA = dA - dB;
            PrintXYColor($"a={dA}, b={dB}", true);
            #endregion
        }


        static void Task05()
        {
            #region Task05
            /*
                а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
                б) *Сделать задание, только вывод организовать в центре экрана.
                в) **Сделать задание б с использованием собственных методов (например, Print(string ms, int x,int y). 
            */
            Console.Clear();
            PrintXYColor("Task05", true, 40, 0, ConsoleColor.Red);
            PrintXYColor("Имя: ", false);
            string sName = Console.ReadLine();
            PrintXYColor("Фамилия: ", false);
            string sSurName = Console.ReadLine();
            PrintXYColor("Город проживания: ", false);
            string sCity = Console.ReadLine();
            PrintXYColor("а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.");
            Console.WriteLine($"Имя: {sName}, Фамилия: {sSurName}, Город проживания: {sCity}");
            PrintXYColor("Нажмите любую клавишу...");
            Pause();

            Console.Clear();
            PrintXYColor("б) *Сделать задание, только вывод организовать в центре экрана..");
            Console.SetCursorPosition(Console.WindowWidth/2, Console.WindowHeight/2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Имя: {sName}, Фамилия: {sSurName}, Город проживания: {sCity}");
            PrintXYColor("Нажмите любую клавишу...");
            Pause();

            Console.Clear();
            PrintXYColor("**Сделать задание б с использованием собственных методов (например, Print(string ms, int x,int y)");
            string sMsg = $"Имя: { sName}, Фамилия: { sSurName}, Город проживания: { sCity}";
            PrintXYColor(sMsg, true, 20, 20, ConsoleColor.Red);
            #endregion
        }


        static void Task06()
        {
            #region Task06
            /*
                *Создать класс с методами, которые могут пригодиться в вашей учебе (Print, Pause).
            */
            MyFirstClass.PrintXYColor("Нажмите любую клавишу...");
            MyFirstClass.Pause();
            MyFirstClass.PrintXYColor("Пример MyFirstClass.PrintXYColor", true, 20, 20, ConsoleColor.Blue);
            #endregion
        }

        static void Main(string[] args)
        {
            #region Lesson01
            int nNumTask = 0;
            do
            {
                Console.Clear();
                PrintXYColor("Введите номер домашнего задания от 1 - до 6 (0 - Выход):", false, 0, 0, ConsoleColor.Red);
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
                    default:
                        PrintXYColor("Вы ввели неверный номер!");
                        break;
                }
                Pause();
            }
            while (nNumTask != 0);
            #endregion         

        }
    }
}
