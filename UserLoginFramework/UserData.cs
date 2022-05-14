using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserLogin
{
    public static class UserData
    {
        private static List<User> _testUsers;

        public static List<User> TestUsers
        {
            get
            {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
        }

        public static void ResetTestUserData()
        {
            if (_testUsers == null)
            {
                _testUsers = new List<User>();
                _testUsers.Add(new User
                {
                    Username = "Emanoel",
                    Password = "12345",
                    FacultyNumber = "121219001",
                    Role = 1,
                    Created = DateTime.Now
                });
                _testUsers.Add(new User
                {
                    Username = "Tihomir",
                    Password = "13579",
                    FacultyNumber = "121219002",
                    Role = 4,
                    Created = DateTime.Now
                });
                _testUsers.Add(new User
                {
                    Username = "Pesho",
                    Password = "02468",
                    FacultyNumber = "121219003",
                    Role = 4,
                    Created = DateTime.Now
                });
            }
        }

        public static User IsUserPassCorrect(string username, string password)
        {
            return (from user in TestUsers
                    where user.Username.Equals(username) && user.Password.Equals(password)
                    select user).FirstOrDefault();
        }

        public static void SetUserActiveTo(string username, DateTime dateTime)
        {
            foreach (User user in TestUsers)
            {
                if (user.Username.Equals(username))
                {
                    user.Valid = dateTime;
                    Logger.LogActivity("Промяна на активност на " + username);
                    return;
                }
            }
        }

        public static void AssingUserRole(string username, int userRole)
        {
            foreach (User user in TestUsers)
            {
                if (user.Username.Equals(username))
                {
                    user.Role = userRole;
                    Logger.LogActivity("Промяна на роля на " + username);
                    return;
                }
            }
        }

        public static void PrintUsers()
        {
            foreach (User user in _testUsers)
            {
                Console.WriteLine(user);
            }
        }
    }
}
