using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CsvXmlConverter
{
    public class Student
    {

        public Student(Student student)
        {
            this.FirstName = student.FirstName;
            this.LastName = student.LastName;
            this.University = student.University;
            this.Faculty = student.Faculty;
            this.Department = student.Department;
            this.Age = student.Age;
            this.Course = student.Course;
            this.Group = student.Group;
            this.City = student.City;
        }
        public Student() { }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string University { get; set; }
        public string Faculty { get; set; }
        public string Department { get; set; }
        public int Age { get; set; }
        public int Course { get; set; }
        public int Group { get; set; }
        public string City { get; set; }
    }

    public class Students
    {
        private string fileName;
        private List<Student> list;

        public Student this[int index]
        {
            get { return list[index]; }
        }

        public int Count
        {
            get { return list.Count; }
        }

        public Students()
        {
            list = new List<Student>();
        }

        public void Add(Student student)
        {
            list.Add(new Student(student));
        }

        public void Remove(int index)
        {
            if (index >= 0 && index < list.Count)
                list.RemoveAt(index);
        }

        public void Load(string fileName)
        {
            this.fileName = fileName;
            StreamReader sr = new StreamReader(fileName);
            while (!sr.EndOfStream)  // Пока не конец потока (файла)
            {
                string s = sr.ReadLine();
                string[] strs = s.Split(';');
                if (strs.Length < 9)
                {

                }
                else {
                    Student student = new Student();
                    student.FirstName = strs[0];
                    student.LastName = strs[1];
                    student.University = strs[2];
                    student.Faculty = strs[3];
                    student.Department = strs[4];
                    student.Age = int.Parse(strs[5]);
                    student.Course = int.Parse(strs[6]);
                    student.Group = int.Parse(strs[7]);
                    student.City = strs[8];
                    Add(student);
                }
            }
        }

        public void Save(string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
            using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(fileStream, list);
            }
        }
    }
}
