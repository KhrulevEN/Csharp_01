using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CsvXmlConverter
{
    class Program
    {

        static void Main(string[] args)
        {
            Students students = new Students();
            students.Load(AppDomain.CurrentDomain.BaseDirectory+"students.csv");
            students.Save(AppDomain.CurrentDomain.BaseDirectory + "students.xml");
            Console.Write("Файл students.csv коверитрован в файл students.xml!");
            Console.ReadKey();
        }
    }
}
