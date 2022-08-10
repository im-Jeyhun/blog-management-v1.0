using blog_management_v1._0.ApplicationLogic.Services;
using blog_management_v1._0.ApplicationLogic.Validation;
using blog_management_v1._0.DataBase.Models;
using blog_management_v1._0.DataBase.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_management_v1._0.ApplicationLogic
{
    public class Authentication
    {

        public static void Register()
        {
            string name = UserService.GetName();
            string lastName = UserService.GetLastName();
            string email = UserService.GetEmail();
            string password = UserService.GetPassword();

            User user = UserRepository.Add(name, lastName, email, password);
            Console.WriteLine($"User added to sytstem {user.GetUserInfo()}");

        }

        public static void Login()
        {
            while (true)
            {
                Console.Write("Pls enter email : ");
                string email = Console.ReadLine();
                Console.Write("Pls enter password : ");
                string password = Console.ReadLine();
                if (UserRepository.IsUserExistsByEmailAndPassword(email, password))
                {

                    User user = UserRepository.GetByEmail(email);

                    if (user != null)
                    {
                        Dashboard.CurrentUser = user;
                        if (user is Admin)
                        {
                            Dashboard.AdminPanel(email);
                        }
                        else if (user is User)
                        {
                            Dashboard.UserPanel(email);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Istifadeci tapilmadi");
                    }


                    if (user is Admin)
                    {
                        Dashboard.AdminPanel(email);
                    }
                    else if (user is User)
                    {
                        Dashboard.UserPanel(email);
                    }
                    else
                    {
                        Console.WriteLine("User");
                    }
                }
                else
                {
                    Console.WriteLine("Email or password not correct.");
                }

            }
        }
    }
}
