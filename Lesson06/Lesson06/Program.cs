using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Output;
using System.IO;
using System.Collections;

namespace Lesson06
{
    // Описываем делегат. В делегате описывается сигнатура методов, на
    // которые он сможет ссылаться в дальнейшем (хранить в себе)
    public delegate double Fun(double x);
    public delegate double Fun2(double a, double x);

    public delegate double doFunc(double x);

    class Program
    {
        /*
        1. Изменить программу вывода таблицы функции так, чтобы можно было передавать функции типа double (double, double). 
        Продемонстрировать работу на функции с функцией a* x^2 и функцией a* sin(x).
        */
        public static void Table(Fun F, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }
        public static void Table(Fun2 F, double a, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(a, x));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }
        // Создаем метод для передачи его в качестве параметра в Table
        public static double MyFunc(double x)
        {
            return x * x * x;
        }
        public static double MyFunc2(double a, double x)
        {
            return a * x * x * x;
        }
        static void Task01()
        {
            // Создаем новый делегат и передаем ссылку на него в метод Table
            Output.PrintXYColor("Таблица функции MyFunc:");
            // Параметры метода и тип возвращаемого значения, должны совпадать с делегатом
            Table(new Fun(MyFunc), -2, 2);
            Output.PrintXYColor("Еще раз та же таблица, но вызов организован по новому");
            // Упрощение(c C# 2.0).Делегат создается автоматически.            
            Table(MyFunc, -2, 2);
            Output.PrintXYColor("Таблица функции Sin:");
            Table(Math.Sin, -2, 2);      // Можно передавать уже созданные методы
            Output.PrintXYColor("Таблица функции x^2:");
            // Упрощение(с C# 2.0). Использование анонимного метода
            Table(delegate (double x) { return x * x; }, 0, 3);
            Output.Pause();

            Console.Clear();
            Output.PrintXYColor("Таблица функции MyFunc2 [-2;2]:");
            Output.PrintXYColor("Введите коэффициент a:", false);
            double a = double.Parse(Console.ReadLine());
            Table(new Fun2(MyFunc2), a, -2, 2);
            Output.PrintXYColor("Еще раз та же таблица, но вызов организован по новому");
            Table(MyFunc2, a, -2, 2);
            Output.PrintXYColor("Таблица функции a*Sin [-2;2]:");
            Table(delegate (double a0, double x) { return a0 * Math.Sin(x); }, a, -2, 2);
            Output.PrintXYColor("Таблица функции a*x^2 [0;3]:");
            Table(delegate (double a0, double x) { return a0 * x * x; }, a, 0, 3);

        }

        /*
        2. Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата. 
        а) Сделать меню с различными функциями и представить пользователю выбор, для какой функции и на каком отрезке находить минимум. 
        Использовать массив (или список) делегатов, в котором хранятся различные функции.
        б) *Переделать функцию Load, чтобы она возвращала массив считанных значений. 
        Пусть она возвращает минимум через параметр (с использованием модификатора out). 
        */
        public static double F(double x)
        {
            return x * x - 50 * x + 10;
        }
        public static double F1(double x)
        {
            return 2*x * x - 10 * x + 20;
        }
        public static double F2(double x)
        {
            return 3 * x * x - 10 ;
        }
        public static void SaveFunc(doFunc a_Func, string fileName, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {                
                bw.Write(a_Func(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }
        public static double[] Load(string fileName, out double a_min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double min = double.MaxValue;
            //double d;
            long nCnt = fs.Length / sizeof(double);
            double[] arrDouble = new double[nCnt];
            for (long i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                arrDouble[i] = bw.ReadDouble();
                if (arrDouble[i] < min) min = arrDouble[i];
            }
            bw.Close();
            fs.Close();
            a_min = min;
            return arrDouble;
        }
        static void Task02()
        {
            List<doFunc> listDoFunc = new List<doFunc>();
            listDoFunc.Add(F);
            listDoFunc.Add(F1);
            listDoFunc.Add(F2);

            int nNumFunc = 0;
            do
            {
                Console.Clear();
                Output.PrintXYColor("1 - y = x^2 - 50x + 10");
                Output.PrintXYColor("2 - y = 2x^2 - 10x + 20");
                Output.PrintXYColor("3 - y = 3x^2 - 10");
                Output.PrintXYColor("Введите номер функции от 1 - до 3 (0 - Выход): ", false);
                bool bRes = int.TryParse(Console.ReadLine(), out nNumFunc);
                if (!bRes)
                {
                    Output.PrintXYColor("Неверный формат числа номера функции!");
                    nNumFunc = -1;
                    Output.Pause();
                    continue;
                }
                if (nNumFunc == 0)
                    return;
                Output.PrintXYColor("Введите начало отрезка a: ", false);
                double dA = -100;
                bRes = double.TryParse(Console.ReadLine(), out dA);
                if (!bRes)
                {
                    Output.PrintXYColor("Неверный формат числа начала отрезка a!");
                    Output.Pause();
                    continue;
                }
                Output.PrintXYColor("Введите конец отрезка b: ", false);
                double dB = 100;
                bRes = double.TryParse(Console.ReadLine(), out dB);
                if (!bRes)
                {
                    Output.PrintXYColor("Неверный формат числа конца отрезка b!");
                    Output.Pause();
                    continue;
                }
                Output.PrintXYColor("Введите конец отрезка h: ", false);
                double dH = 0.5;
                bRes = double.TryParse(Console.ReadLine(), out dH);
                if (!bRes)
                {
                    Output.PrintXYColor("Неверный формат шага h!");
                    Output.Pause();
                    continue;
                }

                switch (nNumFunc)
                {
                    case 0:
                        return;
                    case 1:
                        SaveFunc(listDoFunc[0], AppDomain.CurrentDomain.BaseDirectory + "data.bin", dA, dB, dH);
                        break;
                    case 2:
                        SaveFunc(listDoFunc[1], AppDomain.CurrentDomain.BaseDirectory + "data.bin", dA, dB, dH);
                        break;
                    case 3:
                        SaveFunc(listDoFunc[2], AppDomain.CurrentDomain.BaseDirectory + "data.bin", dA, dB, dH);
                        break;
                    default:
                        Output.PrintXYColor("Вы ввели неверный номер!");
                        break;
                }
                double dMin = 0;
                double[] arrDouble = Load(AppDomain.CurrentDomain.BaseDirectory + "data.bin", out dMin);
                for (int i=0; i< arrDouble.Length; i++)
                {
                    if (i % 10 == 9)
                        Output.PrintXYColor($"{arrDouble[i]}");
                    else
                        Output.PrintXYColor($"{arrDouble[i]} ", false);
                }
                Output.PrintXYColor("");
                Output.PrintXYColor($"Min = {dMin}");
                Output.Pause();
                //Console.ReadLine();
            }
            while (nNumFunc != 0);           
            
        }

        /*
        3. Переделать программу Пример использования коллекций для решения следующих задач:
        а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
        б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся (*частотный массив);
        в) отсортировать список по возрасту студента;
        г) *отсортировать список по курсу и возрасту студента;
        */

        class Student
        {
            public string lastName;
            public string firstName;
            public string university;
            public string faculty;
            public int course;
            public string department;
            public int group;
            public string city;
            public int age;
            // Создаем конструктор
            public Student(string firstName, string lastName, string university, string faculty, string department, int age, int course, int group, string city)
            {
                this.lastName = lastName;
                this.firstName = firstName;
                this.university = university;
                this.faculty = faculty;
                this.department = department;
                this.age = age;
                this.course = course;
                this.group = group;
                this.city = city;
            }
        }
        static int MyDelegat(Student st1, Student st2)          // Создаем метод для сравнения для экземпляров
        {
            return String.Compare(st1.firstName, st2.firstName);          // Сравниваем две строки
        }
        static int MyDelegatLastName(Student st1, Student st2)          // Создаем метод для сравнения для экземпляров
        {
            return String.Compare(st1.lastName, st2.lastName);          // Сравниваем две строки
        }
        static int MyDelegatAge(Student st1, Student st2)          // Создаем метод для сравнения для экземпляров
        {
            if (st1.age == st2.age)            
                return 0;            
            else
            {
                if (st1.age < st2.age)
                    return -1;
                else
                    return 1;
            }
        }
        static int MyDelegatAgeCourse(Student st1, Student st2)          // Создаем метод для сравнения для экземпляров
        {
            if (st1.age == st2.age)
            {
                if (st1.course == st2.course)
                    return 0;
                else
                {
                    if (st1.course < st2.course)
                        return -1;
                    else
                        return 1;
                }
            }
            else
            {
                if (st1.age < st2.age)
                    return -1;
                else
                    return 1;
            }
        }
        static void Task03()
        {
            Console.ForegroundColor = ConsoleColor.White;

            int bakalavr = 0;
            int magistr = 0;
            int stud_5 = 0;
            int stud_6 = 0;
            List<Student> list = new List<Student>();                             // Создаем список студентов
            DateTime dt = DateTime.Now;
            StreamReader sr = new StreamReader("..\\..\\students.csv");
            Console.WriteLine("а) Подсчитать количество студентов учащихся на 5 и 6 курсах:");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    // Добавляем в список новый экземпляр класса Student
                    var student = new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]);
                    list.Add(student);
                    // Одновременно подсчитываем количество бакалавров и магистров
                    if (student.course < 5) bakalavr++;
                    else
                    {
                        magistr++;
                        if (student.course == 5)
                            stud_5++;
                        if (student.course == 6)
                            stud_6++;                       
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                    // Выход из Main
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                        return;
                }
            }
            sr.Close();
            foreach (var v in list)
                Console.WriteLine($"{v.age} {v.firstName} {v.lastName} {v.university} {v.faculty} {v.department} {v.course} {v.group} {v.city}");
            //Console.WriteLine(v.firstName);
            list.Sort(new Comparison<Student>(MyDelegat));
            Console.WriteLine("Всего студентов:" + list.Count);
            Console.WriteLine("Магистров:{0}", magistr);
            Console.WriteLine("Бакалавров:{0}", bakalavr);
            Console.WriteLine("Студентов 5 курса:{0}", stud_5);
            Console.WriteLine("Студентов 6 курса:{0}", stud_6);
            foreach (var v in list)
                Console.WriteLine($"{v.age} {v.firstName} {v.lastName} {v.university} {v.faculty} {v.department} {v.course} {v.group} {v.city}");
            Console.WriteLine(DateTime.Now - dt);


            Console.WriteLine("б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(*частотный массив):");
            int[] count = new int[6]; //1-6 курс
            int nStartCourse = 1;
            foreach (var v in list)
            {
                if (v.age>=18 && v.age<=20 && v.course >= 1 && v.course <= 6)
                {
                    count[v.course - nStartCourse]++;
                }
            }
            for (int i = 0; i < 6; i++)
                if (count[i] > 0)
                    Console.WriteLine("{0} курс = {1}", i+1, count[i]);

            Console.WriteLine("в) отсортировать список по возрасту студента:");
            list.Sort(new Comparison<Student>(MyDelegatAge));
            foreach (var v in list)
                Console.WriteLine($"{v.age} {v.course} {v.group} {v.firstName} {v.lastName} {v.university} {v.faculty} {v.department} {v.city}");

            Console.WriteLine("г) *отсортировать список по курсу и возрасту студента:");
            list.Sort(new Comparison<Student>(MyDelegatAgeCourse));
            foreach (var v in list)
                Console.WriteLine($"{v.age} {v.course} {v.group} {v.firstName} {v.lastName} {v.university} {v.faculty} {v.department} {v.city}");

        }

        /*
        4. **Считайте файл различными способами.Смотрите “Пример записи файла различными способами”. 
        Создайте методы, которые возвращают массив byte (FileStream, BufferedStream), 
        строку для StreamReader и массив int для BinaryReader.
        */
        
        static byte[] LoadFileStream(string filename, out int nReadCnt)
        {
            FileStream fileIn = new FileStream(filename, FileMode.Open, FileAccess.Read);
            long lCnt = fileIn.Length;
            byte[] arrByte = new byte[lCnt];
            nReadCnt = fileIn.Read(arrByte, 0, (int)lCnt);
            fileIn.Close();
            return arrByte;
        }
        static void SaveFileStream(string filename, byte[] arrByte)
        {
            FileStream fileOut = new FileStream(filename, FileMode.Create, FileAccess.Write);
            fileOut.Write(arrByte, 0, arrByte.Length);
            fileOut.Close();
        }
        // преобразуем строку в байты
        //byte[] array = System.Text.Encoding.Default.GetBytes(text);
        // декодируем байты в строку
        //string textFromFile = System.Text.Encoding.Default.GetString(array);
        static string LoadStreamReader(string filename)
        {
            StreamReader fileIn = new StreamReader(filename, Encoding.GetEncoding(1251));
            string text = fileIn.ReadToEnd();
            fileIn.Close();
            return text;
        }
        static void SaveStreamReader(string filename, string text)
        {
            StreamWriter fileOut = new StreamWriter(filename, false);
            fileOut.Write(filename);
            fileOut.Close();
        }
        static int[] LoadBinaryReader(string filename)
        { 
            FileStream fileIn = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BinaryReader fIn = new BinaryReader(fileIn);
            long n = fileIn.Length / 4;
            int[] arrInt32 = new int[n];
            for (int i = 0; i < n; i++)
            {
                arrInt32[i] = fIn.ReadInt32();
                //Console.Write(arrInt32[i] + " ");
            }
            fIn.Close();
            fileIn.Close();
            return arrInt32;
        }
        static void SaveBinaryReader(string filename, int[] arrInt32)
        {          
            FileStream fileOut = new FileStream(filename, FileMode.Create, FileAccess.Write);
            BinaryWriter fOut = new BinaryWriter(fileOut);
            for (int i = 0; i < arrInt32.Length; i++)
            {
                fOut.Write(arrInt32[i]);
            }
            fOut.Close();
            fileOut.Close();
        }


        static void Task04()
        {
            int nReadCnt = 0;
            Output.PrintXYColor("FileStream");
            byte[] arrByte = LoadFileStream("..//..//data.txt", out nReadCnt);
            SaveFileStream("..//..//newData.txt", arrByte);
            string textFromFile = Encoding.Default.GetString(arrByte);
            Output.PrintXYColor(textFromFile);

            Output.PrintXYColor("");
            Output.PrintXYColor("StreamWriter(StreamReader)");
            string text = LoadStreamReader("..//..//data.txt");
            SaveStreamReader("..//..//newData.txt", text);
            Output.PrintXYColor(text);

            Output.PrintXYColor("");
            Output.PrintXYColor("BinaryWriter(BinaryReader)");
            int[] arrInt32 = LoadBinaryReader("..//..//data.dat");
            SaveBinaryReader("..//..//newData.dat", arrInt32);
        }


        static void Main()
        {
            int nNumTask = 0;
            do
            {
                Console.Clear();
                Output.PrintXYColor("Введите номер домашнего задания от 1 - до 4 (0 - Выход): ", false, 0, 0, ConsoleColor.Red);
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
                    default:
                        Output.PrintXYColor("Вы ввели неверный номер!");
                        break;
                }
                Output.Pause();
            }
            while (nNumTask != 0);
        }
    }
}
