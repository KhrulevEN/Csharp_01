using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_MyArray
{
    public class MyArray
    {
        int[] a;

        //  Создание массива и заполнение его одним значением el  
        public MyArray(int n, int el)
        {
            a = new int[n];
            for (int i = 0; i < n; i++)
                a[i] = el;
        }
        //  Создание массива и заполнение его случайными числами от min до max
        public MyArray(int n, int min, int max)
        {
            a = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                a[i] = rnd.Next(min, max);
        }


        public MyArray(int nCnt, int nBegin, int nStep, int Ficha)
        {
            a = new int[nCnt];
            for (int i = 0; i < nCnt; i++)
                a[i] = nBegin + i * nStep;
        }
        public int Max
        {
            get
            {
                int max = a[0];
                for (int i = 1; i < a.Length; i++)
                    if (a[i] > max) max = a[i];
                return max;
            }
        }
        public int Min
        {
            get
            {
                int min = a[0];
                for (int i = 1; i < a.Length; i++)
                    if (a[i] < min) min = a[i];
                return min;
            }
        }
        public int CountPositiv
        {
            get
            {
                int count = 0;
                for (int i = 0; i < a.Length; i++)
                    if (a[i] > 0) count++;
                return count;
            }
        }
        public override string ToString()
        {
            string s = "";
            foreach (int v in a)
                s = s + v + " ";
            return s;
        }

        public int Sum
        {
            get
            {
                int nSum = 0;
                for (int i = 0; i < a.Length; i++)
                    nSum += a[i];
                return nSum;
            }
        }

        public int[] Inverse()
        {
            int[] b = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                b[i] = -a[i];
            }
            return b;
        }

        public int MaxCount
        {
            get
            {
                int nMax = Max;
                int nMaxCount = 0;
                for (int i = 0; i < a.Length; i++)
                    if (a[i] == nMax) nMaxCount++;
                return nMaxCount;
            }
        }

        public void Multi()
        {
            int nMaxCount = MaxCount;
            for (int i = 0; i < a.Length; i++)
            {
                a[i] *= nMaxCount;
            }
        }
    }
}
