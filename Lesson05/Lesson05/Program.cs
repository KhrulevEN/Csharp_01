using System;
using Library_Output;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Collections;

namespace Lesson05
{
    class Program
    {

        /*
        1. Создать программу, которая будет проверять корректность ввода логина. 
        Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита
        или цифры, при этом цифра не может быть первой:
        а) без использования регулярных выражений;
        б) **с использованием регулярных выражений. 
        */
        static int IsCorrectLoginWithoutReg(string strLogin)
        {
            char[] chLogin = strLogin.ToCharArray();
            int nSizeLogin = chLogin.Length;
            if (nSizeLogin < 2 || nSizeLogin > 10)
            {
                Output.PrintXYColor("Неверный логин - строка не от 2 до 10 символов!");
                return -1;
            }

            if (!char.IsLetter(chLogin[0]) || chLogin[0] > 255)
            {
                Output.PrintXYColor("Неверный логин - 1-й символ не буква латинского алфавита!");
                return -2;
            }
            for (int i = 1; i < chLogin.Length; i++)
            {
                if (!char.IsLetterOrDigit(chLogin[i]) || chLogin[i] > 255)
                {
                    Output.PrintXYColor("");
                    Output.PrintXYColor("Неверный логин - содержит не только буквы латинского алфавита и цифры!");
                    return -3;
                }
            }


            return 0;
        }
        static bool IsCorrectLoginWithReg(string strLogin)
        {
            Regex myReg = new Regex(@"^[A-Za-z][A-Za-z0-9]{1,9}$");
            return myReg.IsMatch(strLogin);
        }
        static void Task01()
        {
            Output.PrintXYColor("Введите логин:", false);
            string strLogin = Console.ReadLine();
            if (IsCorrectLoginWithoutReg(strLogin) == 0)
            {
                Output.PrintXYColor("Верный логин!");
            }
            Output.PrintXYColor("");
            if (IsCorrectLoginWithReg(strLogin))
                Output.PrintXYColor("Верный логин!");
            else
                Output.PrintXYColor("Неверный логин!");
        }

        /*
        2. Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
        а) Вывести только те слова сообщения, которые содержат не более n букв.
        б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
        в) Найти самое длинное слово сообщения.
        г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.

        д)- ***Создать метод, который производит частотный анализ текста. В качестве параметра 
        в него передается массив слов и текст, в качестве результата метод возвращает 
        сколько раз каждое из слов массива входит в этот текст. Здесь требуется использовать класс Dictionary.
        */
        static class Message
        {
            static public string strMessage;
            static string strDelimiter = " ";
            static char chDelimiter = ' ';

            static public string WordsOfMessageMoreN(int nLetters)
            {
                string[] strArr = strMessage.Split(chDelimiter);
                string strRes = "";
                for (int i = 0; i < strArr.Length; i++)
                {
                    if (strArr[i].Length > nLetters)
                        strRes = string.Concat(strRes, strArr[i], strDelimiter);
                }
                return strRes;
            }
            static public string DelWordsFinishLetter(char chLetter)
            {
                string strRes = "";
                string[] strArr = strMessage.Split(chDelimiter);
                for (int i = 0; i < strArr.Length; i++)
                {
                    int nLength = strArr[i].Length - 1;
                    if (strArr[i][nLength] != chLetter)
                    {
                        strRes = string.Concat(strRes, strArr[i], strDelimiter);
                    }
                }
                return strRes;
            }
            static public string MaxWord()
            {
                string strMax = "";
                string[] strArr = strMessage.Split(chDelimiter);
                if (strArr.Length == 0)
                    return strMax;
                strMax = strArr[0];
                for (int i = 1; i < strArr.Length; i++)
                {
                    if (strArr[i].Length > strMax.Length)
                        strMax = strArr[i];
                }
                return strMax;
            }
            static public StringBuilder GetStringOfMaxWords()
            {
                StringBuilder strB = new StringBuilder("");
                string strMax = MaxWord();
                string[] strArr = strMessage.Split(chDelimiter);
                for (int i = 0; i < strArr.Length; i++)
                {
                    if (strArr[i].Length == strMax.Length)
                        strB.Append(strArr[i] + strDelimiter);
                }
                return strB;
            }
            static public Dictionary<string, int> FreqAnalyzeText()
            {
                Dictionary<string, int> FreqDict = new Dictionary<string, int>();
                string[] strArr = strMessage.Split(chDelimiter);
                for (int i = 0; i < strArr.Length; i++)
                {
                    if (FreqDict.ContainsKey(strArr[i]))
                    {
                        FreqDict[strArr[i]] = ++FreqDict[strArr[i]];
                    }
                    else
                    {
                        FreqDict.Add(strArr[i], 1);
                    }
                }
                return FreqDict;
            }
        }
        static void Task02()
        {
            Output.PrintXYColor("Введите сообщение:", false);
            Message.strMessage = Console.ReadLine();
            string strRes1 = Message.WordsOfMessageMoreN(4);
            //Output.PrintXYColor(strRes);
            string[] strArr = strRes1.Split(' ');
            Output.PrintXYColor("Вывести только те слова сообщения, которые содержат не более n(4) букв:");
            for (int i = 0; i < strArr.Length; i++)
            {
                Output.PrintXYColor(strArr[i]);
            }
            Output.PrintXYColor("Удалить из сообщения все слова, которые заканчиваются на заданный символ(a):");
            string strRes2 = Message.DelWordsFinishLetter('a');
            Output.PrintXYColor(strRes2);

            Output.PrintXYColor("Найти самое длинное слово сообщения:");
            string strMax = Message.MaxWord();
            Output.PrintXYColor(strMax);

            Output.PrintXYColor("StringBuilder из самых длинных слов сообщения:");
            StringBuilder strB = Message.GetStringOfMaxWords();
            Console.WriteLine(strB);
            Output.PrintXYColor("Частотный анализ текста (с помощью Dictionary)):");
            Dictionary<string, int> FreqDict = Message.FreqAnalyzeText();
            foreach (KeyValuePair<string, int> keyValue in FreqDict)
            {
                Output.PrintXYColor($"{keyValue.Key} - {keyValue.Value}");                
            }
        }

        /*
        3. *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
        Например:
        badc являются перестановкой abcd.
        */
        static bool IsTransposition(string str1, string str2)
        {
            for (int i=0; i<str1.Length; i++)
            {
                int nPos = str2.IndexOf(str1[i]);
                if (nPos == -1)
                {
                    return false;
                }
                else
                {
                    str2 = str2.Remove(nPos,1);
                }
            }
            return (str2.Length == 0);
        }
        static void Task03()
        {
            Output.PrintXYColor("Введите 1-ю строку: ", false);
            string str1 = Console.ReadLine();
            Output.PrintXYColor("Введите 2-ю строку: ", false);
            string str2 = Console.ReadLine();
            if (IsTransposition(str1, str2))
            {
                Output.PrintXYColor($"Строка {str1} является перестановкой строки {str2}");
            }
            else
            {
                Output.PrintXYColor($"Строка {str1} не является перестановкой строки {str2}");
            }

        }

        /*
        4. *Задача ЕГЭ.
        На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы. 
        В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100, 
        каждая из следующих N строк имеет следующий формат:
        <Фамилия> <Имя> <оценки>,
        где <Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не более чем из 15 символов, 
        <оценки> — через пробел три целых числа, соответствующие оценкам по пятибалльной системе. <Фамилия> и <Имя>, 
        а также <Имя> и <оценки> разделены одним пробелом. Пример входной строки:
        Иванов Петр 4 5 3
        Требуется написать как можно более эффективную программу, которая будет выводить на экран фамилии и 
        имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики, набравшие тот же средний балл, 
        что и один из трёх худших, следует вывести и их фамилии и имена.
        */

        class Student
        {
            public Student() { }
            public Student(string surname, string firstname, byte mark1, byte mark2, byte mark3)
            {                
                Surname = surname;
                FirstName = firstname;
                Mark1 = mark1;
                Mark2 = mark2;
                Mark3 = mark3;
                AvrMark = (float)(mark1 + mark2 + mark3) / 3;
            }
            public string FirstName { get; set; }
            public string Surname { get; set; }
            public byte Mark1 { get; set; }
            public byte Mark2 { get; set; }
            public byte Mark3 { get; set; }
            public float AvrMark { get; set; }
        }

        static bool InputStudentsFromFile(string filename, List<Student> students)
        {
            try
            {
                StreamReader sr = new StreamReader(filename);
                int nCnt = 0;
                bool bRes = int.TryParse(sr.ReadLine(), out nCnt);
                if (!bRes)
                {
                    sr.Close();
                    return false;
                }
                for (int i = 0; i < nCnt; i++)
                {
                    string str = sr.ReadLine();
                    string[] str_arr = str.Split(' ');
                    Student student = new Student(str_arr[0], str_arr[1], byte.Parse(str_arr[2]),
                        byte.Parse(str_arr[3]), byte.Parse(str_arr[4]));
                    students.Add(student);
                }
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
            List<Student> students = new List<Student>();
            bool bRes = InputStudentsFromFile(AppDomain.CurrentDomain.BaseDirectory + "Students.txt", students);
            if (bRes)
            {
                SortedDictionary<float, List<Student>> statistics = new SortedDictionary<float, List<Student>>();
                foreach (var student in students)
                {
                    if (statistics.ContainsKey(student.AvrMark))
                    {
                        statistics[student.AvrMark].Add(student);
                    }
                    else
                    {
                        statistics.Add(student.AvrMark, new List<Student>() { student });
                    }
                }

                int counter = 0;
                foreach (var studentKeyValue in statistics)
                {
                    Output.PrintXYColor($"Средний балл: {studentKeyValue.Key}\nСтуденты:");
                    foreach (var student in studentKeyValue.Value)
                    {
                        Output.PrintXYColor($"\t{student.Surname} {student.FirstName}");
                        counter++;
                    }
                    if (counter >= 3)
                        break;
                }

            }

        }
        

        static void Main(string[] args)
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

