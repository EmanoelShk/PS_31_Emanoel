using System;
using System.Collections.Generic;
using System.Text;

namespace UserLoginFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            LoginValidation loginValidation = new LoginValidation(Console.ReadLine(), Console.ReadLine(), OnError);

            if (loginValidation.ValidateUserInput(out User user))
            {
                Console.WriteLine(user);
                switch (LoginValidation.CurrentUserRole)
                {
                    case UserRoles.ANONYMOUS:
                        Console.WriteLine("Ролята на потребителя е Анонимна");
                        break;
                    case UserRoles.ADMIN:
                        Console.WriteLine("Ролята на потребителя е Админ");
                        AdminActivity();
                        break;
                    case UserRoles.INSPECTOR:
                        Console.WriteLine("Ролята на потребителя е Инспектор");
                        break;
                    case UserRoles.PROFESSOR:
                        Console.WriteLine("Ролята на потребителя е Професор");
                        break;
                    case UserRoles.STUDENT:
                        Console.WriteLine("Ролята на потребителя е Студент");
                        break;
                    default:
                        Console.WriteLine("Ролята на потребителя не е разпозната");
                        break;
                }
            }
        }

        public static void OnError(string errorMsg)
        {
            Console.WriteLine("!!! " + errorMsg + " !!!");
        }

        private static void AdminActivity()
        {
            while (true)
            {
                Console.WriteLine("Изберете опция:");
                Console.WriteLine("0: Изход");
                Console.WriteLine("1: Промяна на роля на потребител");
                Console.WriteLine("2: Промяна на активност на потребителя");
                Console.WriteLine("3: Списък на потребителите");
                Console.WriteLine("4: Преглед на лог на активност");
                Console.WriteLine("5: Преглед на текуща активност");
                int value = Convert.ToInt16(Console.ReadLine());
                StringBuilder sb = new StringBuilder();
                switch (value)
                {
                    case 0:
                        return;
                    case 1:
                        ChangeRole();
                        break;
                    case 2:
                        ChangeActiveDate();
                        break;
                    case 3:
                        UserData.PrintUsers();
                        break;
                    case 4:
                        IEnumerable<string> allActs = Logger.GetAllActivities();
                        foreach (string line in allActs)
                        {
                            sb.Append(line);
                        }
                        Console.WriteLine(sb);
                        break;
                    case 5:
                        string filter = Console.ReadLine();
                        IEnumerable<string> currentActs = Logger.GetCurrentSessionActivities(filter);
                        foreach (string line in currentActs)
                        {
                            sb.Append(line);
                        }
                        Console.WriteLine(sb);
                        break;
                }
            }
        }

        private static void ChangeRole()
        {
            Console.WriteLine("Изберете потребител: ");
            string username = Console.ReadLine();
            foreach (UserRoles userRoles in (UserRoles[])Enum.GetValues(typeof(UserRoles)))
            {
                Console.WriteLine(((int)userRoles) + ": " + userRoles.ToString());
            }
            Console.WriteLine("Изберете нова роля: ");
            int role = Convert.ToInt32(Console.ReadLine());
            UserData.AssingUserRole(username, role);
        }

        private static void ChangeActiveDate()
        {
            Console.WriteLine("Изберете потребител: ");
            string username = Console.ReadLine();
            Console.WriteLine("Изберете дата: ");
            UserData.SetUserActiveTo(username, DateTime.Parse(Console.ReadLine()));
        }

    }
}
