using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserLoginFramework.Activities;

namespace UserLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "My User Login App";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            string name;

            do
            {
                Console.WriteLine("Въведете име:");
                name = Console.ReadLine();
                Console.WriteLine("Въведете парола:");
                string password = Console.ReadLine();
                LoginValidation loginValidation = new LoginValidation(name, password, OnError);

                if (loginValidation.ValidateUserInput(out User user))
                {
                    Console.WriteLine(user);
                    switch (LoginValidation.CurrentUserRole)
                    {
                        case UserRoles.ANONYMOUS:
                            Console.WriteLine("Ролята на потребителя е Анонимна");
                            user.setActivity(new AnonymousActivity());
                            break;
                        case UserRoles.ADMIN:
                            Console.WriteLine("Ролята на потребителя е Админ");
                            Console.WriteLine("Натис");
                            Console.ReadKey();
                            user.setActivity(new AdminActivity());
                            //AdminActivity();
                            break;
                        case UserRoles.INSPECTOR:
                            Console.WriteLine("Ролята на потребителя е Инспектор");
                            user.setActivity(new InspectorActivity());
                            break;
                        case UserRoles.PROFESSOR:
                            Console.WriteLine("Ролята на потребителя е Професор");
                            user.setActivity(new ProfessorActivity());
                            break;
                        case UserRoles.STUDENT:
                            Console.WriteLine("Ролята на потребителя е Студент");
                            user.setActivity(new StudentActivity());
                            break;
                        default:
                            Console.WriteLine("Ролята на потребителя не е разпозната");
                            user.setActivity(null);
                            break;
                    }
                    user.executeActivity();
                }
            } while (!name.Equals("Exit"));


            Console.ReadKey();
        }

        public static void OnError(string errorMsg)
        {
            Console.WriteLine("!!! " + errorMsg + " !!!");
        }

    }
}
