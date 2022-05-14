using System;
using System.Collections.Generic;
using System.Text;
using UserLoginFramework.Activities;

namespace UserLogin
{
    public class User
    {
        private IActivity _activity;

        public Int32 UserId { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String FacultyNumber { get; set; }
        public Int32 Role { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Valid { get; set; }

        public User()
        {

        }

        public User(String username, String password, String facultyNumber, Int32 role)
        {
            Username = username;
            Password = password;
            FacultyNumber = facultyNumber;
            Role = role;
        }

        public User(String username, String password, String facultyNumber, Int32 role, DateTime created) : this(username, password, facultyNumber, role)
        {
            Created = created;
        }

        public override string ToString()
        {
            return Username + "|" + Password + "|" + FacultyNumber + "|" + Role;
        }

        public void setActivity(IActivity activity)
        {
            _activity = activity;
        }

        public void executeActivity()
        {
            _activity.executeActivity();
        }
    }
}