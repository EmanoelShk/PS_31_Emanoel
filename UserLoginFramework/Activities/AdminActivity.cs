using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace UserLoginFramework.Activities
{
    public class AdminActivity : IActivity
    {
        public void executeActivity()
        {
            while (true)
            {
                ConsoleKeyInfo value;
                ConsoleKey[] allowedKeys = new[] { ConsoleKey.D0, ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3, ConsoleKey.D4, ConsoleKey.D5 };
                do
                {
                    Console.Clear();
                    var left = Console.WindowWidth / 2 - 19;
                    var top = Console.WindowHeight / 2 - 4;
                    Console.SetCursorPosition(left, top);
                    Console.WriteLine("Изберете опция:");
                    Console.SetCursorPosition(left, top + 1);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("0: Изход");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.SetCursorPosition(left, top + 2);
                    Console.WriteLine("1: Промяна на роля на потребител");
                    Console.SetCursorPosition(left, top + 3);
                    Console.WriteLine("2: Промяна на активност на потребителя");
                    Console.SetCursorPosition(left, top + 4);
                    Console.WriteLine("3: Списък на потребителите");
                    Console.SetCursorPosition(left, top + 5);
                    Console.WriteLine("4: Преглед на лог на активност");
                    Console.SetCursorPosition(left, top + 6);
                    Console.WriteLine("5: Преглед на текуща активност");
                    Console.SetCursorPosition(left, top + 8);
                    value = Console.ReadKey();
                    var keyInfo = value.Key;

                    StringBuilder sb = new StringBuilder();
                    switch (keyInfo)
                    {
                        case ConsoleKey.D0:
                            return;
                        case ConsoleKey.D1:
                            ChangeRole();
                            break;
                        case ConsoleKey.D2:
                            ChangeActiveDate();
                            break;
                        case ConsoleKey.D3:
                            UserData.PrintUsers();
                            break;
                        case ConsoleKey.D4:
                            IEnumerable<string> allActs = Logger.GetAllActivities();
                            foreach (string line in allActs)
                            {
                                sb.AppendLine(line);
                            }
                            Console.WriteLine(sb);
                            break;
                        case ConsoleKey.D5:
                            string filter = Console.ReadLine();
                            IEnumerable<string> currentActs = Logger.GetCurrentSessionActivities(filter);
                            foreach (string line in currentActs)
                            {
                                sb.Append(line);
                            }
                            Console.WriteLine(sb);
                            break;
                    }
                } while (!allowedKeys.Contains(value.Key));
                Console.ReadKey();
            }
        }

        private void ChangeRole()
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

        private void ChangeActiveDate()
        {
            Console.WriteLine("Изберете потребител: ");
            string username = Console.ReadLine();
            Console.WriteLine("Изберете дата: ");
            UserData.SetUserActiveTo(username, DateTime.Parse(Console.ReadLine()));
        }
    }
}
