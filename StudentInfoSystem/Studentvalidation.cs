using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem
{
    class Studentvalidation
    {
        public Student GetStudentDataByUser(User user)
        {
            return StudentData.TestStudents.FirstOrDefault(s => s.FacultyNumber.Equals(user.FacultyNumber));
        }
    }
}
