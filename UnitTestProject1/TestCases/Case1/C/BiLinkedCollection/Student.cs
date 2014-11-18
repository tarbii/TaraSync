using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiLinkedCollection
{
    [Serializable]
    public class Student
    {
        public string  Name { get;  set; }
        public DateTime BirthDate { get;  set; }
        public int Course { get;  set; }
        public string Faculty { get;  private set; }
        public bool IsLivingInHostel { get;  set; }
        public double AverageGrade { get;  set; }

        public Student(string name, DateTime birthDate, int course, string faculty, 
            bool isLivingInHostel, double averageGrade)
        {
            AverageGrade = averageGrade;
            IsLivingInHostel = isLivingInHostel;
            Faculty = faculty;
            Course = course;
            BirthDate = birthDate;
            Name = name;
        }
    }
}
