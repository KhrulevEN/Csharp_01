
//1. С помощью рефлексии выведите все свойства структуры DateTime

using System;
using System.Reflection;

namespace App01
{
    class Program
    {

        static int GetValuePropInfo(object obj, string str)
        {
            PropertyInfo propinfo = obj.GetType().GetProperty(str);
            if (propinfo.CanRead)
                return (int)propinfo.GetValue(obj);
            else
                return -1;
        }

        static void Main(string[] args)
        {
            Type type1 = typeof(DateTime);
            Console.WriteLine(type1);
            var date1 = new DateTime(2021, 5, 25, 10, 0, 0);
            Type type2 = date1.GetType();
            Console.WriteLine(type2);
            Console.WriteLine(date1.ToString());
            int Year = GetValuePropInfo(date1, "Year");
            Console.WriteLine($"date1.GetType() -> Year = {Year}");
            int Month = GetValuePropInfo(date1, "Month");
            Console.WriteLine($"date1.GetType() -> Month = {Month}");
            int Day = GetValuePropInfo(date1, "Day");
            Console.WriteLine($"date1.GetType() -> Day = {Day}");
            int Hour = GetValuePropInfo(date1, "Hour");
            Console.WriteLine($"date1.GetType() -> Hour = {Hour}");
            int Minute = GetValuePropInfo(date1, "Minute");
            Console.WriteLine($"date1.GetType() -> Minute = {Minute}");
            int Second = GetValuePropInfo(date1, "Second");
            Console.WriteLine($"date1.GetType() -> Second = {Second}");
            Console.ReadKey();
        }
    }
}
