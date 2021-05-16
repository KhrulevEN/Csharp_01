using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // Обязательно еще одно пространство имен.

namespace Library_MyArray2
{
    public class MyArray2
    {
        int[,] a;

        public MyArray2(int n, int m, int min, int max)
        {
            a = new int[n, m];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    a[i,j] = rnd.Next(min, max);
        }
        public MyArray2(string filename)
        {
            // Создаем объект sr и связываем его с файлом array2.txt.
            try
            {
                StreamReader sr = new StreamReader(filename);// "..\\..\\data.txt");               
                int n = int.Parse(sr.ReadLine());
                int m = int.Parse(sr.ReadLine());
                a = new int[n,m];
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                    {
                        a[i,j] = int.Parse(sr.ReadLine());
                    }
                // Освобождаем файл data.txt для использования другими программами.
                sr.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        public bool SaveArrayToFile(string filename)
        {
            // Создаем объект sr и связываем его с файлом array2.txt.
            try
            {
                StreamWriter sr = new StreamWriter(filename);// "..\\..\\data.txt");               
                sr.WriteLine(a.GetLength(0));
                sr.WriteLine(a.GetLength(1));
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)                    
                        sr.WriteLine(a[i, j]);
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
        public int Sum()
        {
            int nSum = 0;
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    nSum += a[i, j];
            return nSum;
        }
        public int SumAbove(int nNumber)
        {
            int nSum = 0;
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    if (a[i, j] > nNumber)
                        nSum += a[i, j];
            return nSum;
        }
        public int Min
        {
            get
            {
                int min = a[0,0];
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)
                        if (a[i,j] < min) min = a[i,j];
                return min;
            }
        }
        public int Max
        {
            get
            {
                int max = a[0, 0];
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)
                        if (a[i, j] > max) max = a[i, j];
                return max;
            }
        }
        public void IndMax(ref int nIndMaxX, ref int nIndMaxY)
        {
            int max = a[0, 0];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    if (a[i, j] > max)
                    {
                        max = a[i, j];
                        nIndMaxX = i;
                        nIndMaxY = j;
                    }
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    s += a[i, j].ToString() + " ";
                s+="\n";
            }
            return s;
        }
    }
}
