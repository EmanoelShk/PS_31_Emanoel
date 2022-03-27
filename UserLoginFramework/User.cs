using System;
using System.Collections.Generic;
using System.Text;

namespace UserLoginFramework
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FacultyNumber { get; set; }
        public int Role { get; set; }
        public DateTime Created { get; set; }
        public DateTime Valid { get; set; }

        public override string ToString()
        {
            return Username + "|" + Password + "|" + FacultyNumber + "|" + Role;
        }
    }
}
