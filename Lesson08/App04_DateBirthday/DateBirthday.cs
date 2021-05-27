using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace App04_DateBirthday
{
    public class DateBirthday
    {
        public DateBirthday()
        { }
        public DateBirthday(string fio, DateTime date)
        {
            FIO = fio;
            Date = date;
        }

        public string FIO { get; set; }
        public DateTime Date { get; set; }
    }

    public class DateBirthdays
    {
        private string fileName;
        private List<DateBirthday> list;


        public DateBirthday this[int index]
        {
            get { return list[index]; }
        }

        public int Count
        {
            get { return list.Count; }
        }

        public DateBirthdays(string fileName)
        {
            this.fileName = fileName;
            list = new List<DateBirthday>();
        }

        public void Add(string fio, DateTime date)
        {
            list.Add(new DateBirthday(fio, date));
        }

        public void Remove(int index)
        {
            if (index >= 0 && index < list.Count)
                list.RemoveAt(index);
        }

        public void Load()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<DateBirthday>));
            using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                list = (List<DateBirthday>)xmlSerializer.Deserialize(fileStream);
            }
        }

        public void Save()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<DateBirthday>));
            using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(fileStream, list);
            }
        }

        public void SaveAs(string fileName)
        {
            this.fileName = fileName;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<DateBirthday>));
            using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(fileStream, list);
            }
        }
    }
}
