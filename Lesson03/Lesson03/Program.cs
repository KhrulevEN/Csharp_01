using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 1.
а) Дописать структуру Complex, добавив метод вычитания комплексных чисел. Продемонстрировать работу структуры.
б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса.
в) Добавить диалог с использованием switch демонстрирующий работу класса.

2.
а) С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке). 
Требуется подсчитать сумму всех нечётных положительных чисел. Сами числа и сумму вывести на экран, используя tryParse.

3. *Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. 
Предусмотреть методы сложения, вычитания, умножения и деления дробей. Написать программу, демонстрирующую все разработанные элементы класса.
Добавить свойства типа int для доступа к числителю и знаменателю;
Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа; 
** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0"); *** Добавить упрощение дробей. 
*/

struct Complex
{
    public int im;
    public int re;
    //  в C# в структурах могут храниться также действия над данными
    //  Пример сложения двух комплексных чисел
    public Complex Plus(Complex x)
    {
        Complex y;
        y.im = im + x.im;
        y.re = re + x.re;
        return y;
    }
    //  Пример вычитания двух комплексных чисел
    public Complex Minus(Complex x)
    {
        Complex y;
        y.im = im - x.im;
        y.re = re - x.re;
        return y;
    }

    //  Пример произведения двух комплексных чисел
    public Complex Multi(Complex x)
    {
        Complex y;
        y.im = re * x.im + im * x.re;
        y.re = re * x.re - im * x.im;
        return y;
    }
    public override string ToString()
    {
        if (im>=0)
        {
            return re + "+" + im + "i";
        }
        else
        {
            return re + "" + im + "i";
        }
        
    }
}


class RatioClass
{
    private int x;
    private int y;

    public int X {
        get { return x; }
        set { X = value; }
    }

    public int Y
    {
        get { return y; }
        set { Y = value; }
    }
    public double XdY
    {
        get { double dX = x; double dY = y;  return dX / dY; }
    }

    public RatioClass() { }
    public RatioClass (int x, int y)
    {
        this.x = x;
        if (y!=0)
        {
            this.y = y;
        }
        else
        {
            //ArgumentException("Знаменатель не должен быть = 0");
        }
    }

    public int Nod(int a, int b)
    {
        int t = 0;
        if (a < b) 
        { 
            t = a; 
            a = b; 
            b = t; 
        }
        while (b != 0)
        {
            t = b;
            b = a % b;
            a = t;
        }
        return a;
    }

    public RatioClass Plus(RatioClass a) 
    {
        RatioClass c = new RatioClass();
        c.x = x*a.y + a.x*y;
        c.y = y*a.y;
        int nod = Nod(c.x, c.y);
        c.x /= nod;
        c.y /= nod;
        return c;
    }

    public RatioClass Minus(RatioClass a)
    {
        RatioClass c = new RatioClass();
        c.x = x * a.y - a.x * y;
        c.y = y*a.y;
        int nod = Nod(c.x, c.y);
        c.x /= nod;
        c.y /= nod;
        return c;
    }

    public RatioClass Multi(RatioClass a)
    {
        RatioClass c = new RatioClass();
        c.x = x * a.x;
        c.y = y * a.y;
        int nod = Nod(c.x, c.y);
        c.x /= nod;
        c.y /= nod;
        return c;
    }

    public RatioClass Divide(RatioClass a)
    {
        RatioClass c = new RatioClass();
        c.x = x * a.y;
        c.y = y * a.x;
        int nod = Nod(c.x, c.y);
        c.x /= nod;
        c.y /= nod;
        return c;
    }

    public override string ToString()
    {
        return x + "/" + y;
    }

};

class ComplexClass
{
    private int im;
    private int re;

    public int IM
    {
        get { return im; }
        set { im = value; }
    }

    public int RE
    {
        get { return re; }
        set { re = value; }
    }
    public ComplexClass() { }
    public ComplexClass(int re, int im)
    {
        this.re = re;
        this.im = im;
    }
    //  
    //  Пример сложения двух комплексных чисел
    public ComplexClass Plus(ComplexClass x)
    {
        ComplexClass c = new ComplexClass();
        c.re = re + x.re;
        c.im = im + x.im;
        return c;
    }

    //  Пример вычитания двух комплексных чисел
    public ComplexClass Minus(ComplexClass x)
    {
        ComplexClass c = new ComplexClass();
        c.re = re - x.re;
        c.im = im - x.im;
        return c;
    }

    //  Пример произведения двух комплексных чисел
    public ComplexClass Multi(ComplexClass x)
    {
        ComplexClass c = new ComplexClass();
        c.im = re * x.im + im * x.re;
        c.re = re * x.re - im * x.im;
        return c;
    }

    public static ComplexClass operator +(ComplexClass complex1, ComplexClass complex2)
    {
        return new ComplexClass { re = complex1.re + complex2.re, im = complex1.im + complex2.im };
    }

    public static ComplexClass operator -(ComplexClass complex1, ComplexClass complex2)
    {
        return new ComplexClass { re = complex1.re - complex2.re, im = complex1.im - complex2.im };
    }

    public static ComplexClass operator *(ComplexClass complex1, ComplexClass complex2)
    {
        return new ComplexClass
        {
            im = complex1.re * complex2.im + complex1.im * complex2.re,
            re = complex1.re * complex2.re - complex1.im * complex2.im
        };
    }

    public override string ToString()
    {
        if (im >= 0)
        {
            return re + "+" + im + "i";
        }
        else
        {
            return re + "" + im + "i";
        }
    }
}

namespace Lesson03
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

        static void Task01()
        {
            Console.Clear();
            Complex x;
            Complex y;
            PrintXYColor("Введите действительную часть 1-го комплексного сисла:", false);
            x.re = int.Parse(Console.ReadLine());
            PrintXYColor("Введите мнимую часть 1-го комплексного сисла:", false);
            x.im = int.Parse(Console.ReadLine());
            PrintXYColor("Введите действительную часть 2-го комплексного сисла:", false);
            y.re = int.Parse(Console.ReadLine());
            PrintXYColor("Введите мнимую часть 2-го комплексного сисла:", false);
            y.im = int.Parse(Console.ReadLine());
;
            PrintXYColor("Структуры:");
            PrintXYColor("X = "+x.ToString());
            PrintXYColor("Y = " + y.ToString());
            PrintXYColor($"Сумма = {x.Plus(y)}");
            PrintXYColor($"Разность = {x.Minus(y)}");
            PrintXYColor($"Произведение = {x.Multi(y)}");

            ComplexClass a = new ComplexClass(x.re, x.im);
            ComplexClass b = new ComplexClass(y.re, y.im);
            PrintXYColor("Классы:");
            PrintXYColor("A = " + a.ToString());
            PrintXYColor("B = " + b.ToString());
            PrintXYColor("Методы:");
            PrintXYColor($"Сумма = {a.Plus(b)}");
            PrintXYColor($"Разность = {a.Minus(b)}");
            PrintXYColor($"Произведение = {a.Multi(b)}");
            PrintXYColor("Операторы:");
            PrintXYColor($"Сумма = {a + b}");
            PrintXYColor($"Разность = {a - b}");
            PrintXYColor($"Произведение = {a * b}");                       
        }

        static void Task02()
        {
            Console.Clear();
            PrintXYColor("Введите числа:");
            int nNumber=-1;
            int nSum = 0;
            bool bRes = false;
            do
            {                
                bRes = int.TryParse(Console.ReadLine(), out nNumber);
                if (bRes)
                {
                    if (nNumber>0 && nNumber%2==1)
                    {
                        nSum += nNumber;
                    }                    
                }
                else
                {
                    PrintXYColor("Введено не число!");
                }             

            } while (nNumber != 0 || !bRes);
            Console.WriteLine($"Сумма положительных нечётных чисел = {nSum}");
        }

        static void Task03()
        {
            Console.Clear();
            PrintXYColor("Введите делимое 1-го рационального сисла:", false);
            int X1 = int.Parse(Console.ReadLine());
            PrintXYColor("Введите делитель 1-го рационального сисла:", false);
            int Y1 = int.Parse(Console.ReadLine());
            PrintXYColor("Введите делимое 2-го рационального сисла:", false);
            int X2 = int.Parse(Console.ReadLine());
            PrintXYColor("Введите делитель 2-го рационального сисла:", false);
            int Y2 = int.Parse(Console.ReadLine());

            try
            {
                RatioClass x = new RatioClass(X1, Y1);
                RatioClass y = new RatioClass(X2, Y2);

                PrintXYColor("X = " + x.ToString());
                PrintXYColor("Y = " + y.ToString());
                PrintXYColor($"x1/y1 = {x.XdY}");
                PrintXYColor($"x2/y2 = {y.XdY}");
                PrintXYColor("Методы:");
                PrintXYColor($"Сумма = {x.Plus(y)}");
                PrintXYColor($"Разность = {x.Minus(y)}");
                PrintXYColor($"Произведение = {x.Multi(y)}");
                PrintXYColor($"Деление = {x.Divide(y)}");
            }
            catch (DivideByZeroException e)//DivideByZeroException ArgumentException
            {
                // Код в catch будет выполнен.
                Console.WriteLine("Error: " + e.Message);

            }
        }

        static void Main(string[] args)
        {

            int nNumTask = 0;
            do
            {
                Console.Clear();
                PrintXYColor("Введите номер домашнего задания от 1 - до 3 (0 - Выход):", false, 0, 0, ConsoleColor.Red);
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
