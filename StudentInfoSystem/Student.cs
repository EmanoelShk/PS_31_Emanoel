using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class Student
    {
        public Student()
        {

        }

        public Student(string name, string surname, string lastName, string faculty, string major, string degree, string status, string facultyNumber, int course, int flow, int group)
        {
            Name = name;
            Surname = surname;
            LastName = lastName;
            Faculty = faculty;
            Major = major;
            Degree = degree;
            Status = status;
            FacultyNumber = facultyNumber;
            Course = course;
            Flow = flow;
            Group = group;
        }

        public int StudentId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string LastName { get; set; }

        public string Faculty { get; set; }

        public string Major { get; set; }

        public string Degree { get; set; }

        public string Status { get; set; }

        public string FacultyNumber { get; set; }

        public int Course { get; set; }

        public int Flow { get; set; }

        public int Group { get; set; }

        public override string ToString() { return this.Name; }
    }
}
