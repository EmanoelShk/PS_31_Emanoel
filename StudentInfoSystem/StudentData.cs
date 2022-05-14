using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    static class StudentData
    {
        public static List<Student> testStudents;

        public static List<Student> TestStudents
        {
            get
            {
                ResetTestStudentData();
                return testStudents;
            }
            private set
            {
                
            }
        }

        public static void ResetTestStudentData()
        {
            if (testStudents == null)
            {
                testStudents = new List<Student>();
                testStudents.Add(new Student
                {
                    Name = "Emanoel",
                    Surname = "Tsvetanov",
                    LastName = "Shkodrov",
                    Faculty = "FCST",
                    Major = "CSE",
                    Degree = "Bachlore's degree",
                    Status = "Ongoing",
                    FacultyNumber = "121219122",
                    Course = 3,
                    Flow = 9,
                    Group = 29
                });
            }
        }

        public static bool IsStudentDataFilled(Student student)
        {
            return !string.IsNullOrEmpty(student.Name) && !string.IsNullOrEmpty(student.Surname) && !string.IsNullOrEmpty(student.LastName) 
                && !string.IsNullOrEmpty(student.Faculty) && !string.IsNullOrEmpty(student.Major) && !string.IsNullOrEmpty(student.Degree)
                && !string.IsNullOrEmpty(student.Status) && !string.IsNullOrEmpty(student.FacultyNumber)
                && student.Course != 0 && student.Flow != 0 && student.Group != 0;
        }
    }
}
