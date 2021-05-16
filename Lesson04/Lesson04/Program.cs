using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // Обязательно еще одно пространство имен.
using Library_MyArray;
using Library_MyArray2;

namespace Lesson04
{
    static class ArrayIntRandom
    {
        
        static int SumDigitNumber(int a_nNumber)
        {
            int nSum = 0;
            int nNumber = Math.Abs(a_nNumber);
            while (nNumber > 0)
            {
                nSum += nNumber % 10;
                nNumber /= 10;
            }
            return nSum;
        }
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

        public static int[] InputRandomArray(int nCntArr, int nBeginRange, int nEndRange)
        {
            Random rnd = new Random();
            int[] a = new int[nCntArr];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = rnd.Next(nBeginRange, nEndRange);
                PrintXYColor($"{a[i]} ", false);
            }
            return a;
        }

        public static int FindCntPairFromTask01(int[] a)
        {
            int nCntPair = 0;
            PrintXYColor("");
            PrintXYColor("Пары чисел:");
            for (int i = 0; i < a.Length - 1; i++)
            {
                int nSum1 = SumDigitNumber(a[i]);
                int nSum2 = SumDigitNumber(a[i + 1]);
                if ((nSum1 % 3 == 0) ^ (nSum2 % 3 == 0))
                {
                    PrintXYColor($"{a[i]}, {a[i + 1]}");
                    nCntPair++;
                }
            }     
            return nCntPair;
        }

        public static int[] InputArrayFromFile(string filename)
        {

            // Создаем объект sr и связываем его с файлом data.txt.
            try
            {
                StreamReader sr = new StreamReader(filename);// "..\\..\\data.txt");               
                int n = int.Parse(sr.ReadLine());
                int[] a = new int[n];
                for (int i = 0; i < n; i++)
                {
                    a[i] = int.Parse(sr.ReadLine());
                    PrintXYColor($"{a[i]} ", false);
                }
                // Освобождаем файл data.txt для использования другими программами.
                sr.Close();
                return a;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                int[] a = new int[0];
                return a;
            }            
        }

    }
    class Program
    {
        const int NUMBER_ARRAY = 20;
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

/*
1. Дан целочисленный массив из 20 элементов.Элементы массива могут принимать целые значения от –10 000 до 10 000 
включительно.Заполнить случайными числами.Написать программу, позволяющую найти и вывести количество пар элементов массива, 
в которых только одно число делится на 3. В данной задаче под парой подразумевается два подряд идущих элемента массива.
Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2.
*/
        static int SumDigitNumber(int a_nNumber)
        {
            int nSum = 0;
            int nNumber = Math.Abs(a_nNumber);
            while (nNumber > 0)
            {
                nSum += nNumber % 10;
                nNumber /= 10;
            }
            return nSum;
        }
        static void Task01()
        {                        
            Console.Clear();
            Random rnd = new Random();
            int[] a = new int[NUMBER_ARRAY];
            for (int i = 0; i < NUMBER_ARRAY; i++)
            {
                a[i] = rnd.Next(-10001, 10001);
                PrintXYColor($"{a[i]} ", false);
            }
            Console.WriteLine();
            PrintXYColor("Пары чисел:");
            int nCnt = 0;
            for (int i = 0; i < NUMBER_ARRAY-1; i++)
            {
                int nSum1 = SumDigitNumber(a[i]);
                int nSum2 = SumDigitNumber(a[i+1]);
                if ((nSum1 % 3 == 0) ^ (nSum2 % 3 == 0))
                {
                    PrintXYColor($"{a[i]}, {a[i+1]}");
                    nCnt++;
                }
            }
            PrintXYColor($"Количество пар = {nCnt}");
        }

/*
2. Реализуйте задачу 1 в виде статического класса StaticClass;
а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
б) Добавьте статический метод для считывания массива из текстового файла. Метод должен возвращать массив целых чисел;
в)*Добавьте обработку ситуации отсутствия файла на диске.
*/
        static void Task02()
        {
            //int[] a = new int[NUMBER_ARRAY];
            int[] a = ArrayIntRandom.InputRandomArray(NUMBER_ARRAY, -10001, 10001);
            int nCnt = ArrayIntRandom.FindCntPairFromTask01(a);
            PrintXYColor($"Количество пар = {nCnt}");
            PrintXYColor("б) Считывание массива из файла:");
            int[] b = ArrayIntRandom.InputArrayFromFile("..\\..\\data.txt");
        }
/*
3.
а) Дописать класс для работы с одномерным массивом.Реализовать конструктор, создающий массив определенного размера
и заполняющий массив числами от начального значения с заданным шагом.Создать свойство Sum, которое возвращает сумму элементов массива, 
метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива(старый массив, остается без изменений), 
метод Multi, умножающий каждый элемент массива на определённое число, свойство MaxCount, возвращающее количество максимальных элементов.
б)** Создать библиотеку содержащую класс для работы с массивом.Продемонстрировать работу библиотеки
*/
        static void Task03()
        {
            MyArray a = new MyArray(10, 0, 100);
            PrintXYColor(a.ToString());
            Console.WriteLine(a.Max);
            Console.WriteLine(a.Min);
            Console.WriteLine(a.CountPositiv);

            PrintXYColor("");
            MyArray b = new MyArray(10, 3, 5, 0);
            PrintXYColor(b.ToString());
            PrintXYColor($"Сумма = {b.Sum}");
            PrintXYColor("Меняем знаки у элементов массива:");
            int[] c = b.Inverse();
            for (int i=0; i<c.Length; i++)
            {
                PrintXYColor($"{c[i]} ", false);
            }
            PrintXYColor("");
            PrintXYColor("Пример на использование метода Multi и свойства MaxCount");
            MyArray d = new MyArray(5, 3, 0, 0);
            PrintXYColor(d.ToString());
            int nMaxCount = d.MaxCount;
            PrintXYColor($"Количество максимальных чисел = {nMaxCount}");
            d.Multi();
            PrintXYColor(d.ToString());



        }

 //4. Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив. Создайте структуру Account, содержащую Login и Password

        public static bool InputLoginPasswordFromFile(string filename)
        {

            // Создаем объект sr и связываем его с файлом data.txt.
            try
            {
                StreamReader sr = new StreamReader(filename);// "..\\..\\data.txt");
                bool bFind = false;
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    string[] str_arr = str.Split(' ');
                    if (str_arr.Length==2)
                    {
                        if (str_arr[0] == "root" && str_arr[1] == "GeekBrains")
                        {

                            bFind = true;
                            break;
                        }
                    }                   
                }
                if (bFind)
                {
                    PrintXYColor("Логин и пароль верны вы можете проходить!");
                }
                else
                {
                    PrintXYColor("Нарушитель - логин и пароль не верны!");
                }
                // Освобождаем файл data.txt для использования другими программами.
                sr.Close();
                return true;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);                
                return false;
            }
        }
        static void Task04()
        {
            InputLoginPasswordFromFile("..\\..\\LoginPassword.txt");            
        }

/*
5.
а) Реализовать библиотеку с классом для работы с двумерным массивом. Реализовать конструктор, заполняющий массив случайными числами. 
Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, свойство, 
возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива, метод, 
возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out).
*б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
**в) Обработать возможные исключительные ситуации при работе с файлами. 
*/
        static void Task05()
        {
            MyArray2 a = new MyArray2(5, 5, 0, 100);
            PrintXYColor("Двумерный массив 5 на 5, заполненный случайными числами от 0 до 100");
            PrintXYColor(a.ToString());
            PrintXYColor($"Сумма = {a.Sum()}");
            int nNumber = 45;
            PrintXYColor($"Сумма >{nNumber} = {a.SumAbove(nNumber)}");
            PrintXYColor("");
            MyArray2 b = new MyArray2("..\\..\\Array.txt");
            PrintXYColor("Двумерный массив, заполненный из файла Array.txt");
            PrintXYColor(b.ToString());
            b.SaveArrayToFile("..\\..\\Array_copy.txt");

        }

        static void Main(string[] args)
        {
            int nNumTask = 0;
            do
            {
                Console.Clear();
                PrintXYColor("Введите номер домашнего задания от 1 - до 5 (0 - Выход): ", false, 0, 0, ConsoleColor.Red);
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




