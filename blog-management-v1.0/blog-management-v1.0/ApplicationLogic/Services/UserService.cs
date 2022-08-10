using blog_management_v1._0.ApplicationLogic.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_management_v1._0.ApplicationLogic.Services
{
    public class UserService
    {
        public static string GetName()
        {
            bool isEceptionValid;
            string name = null;
            do
            {

                try
                {
                    Console.Write("Insert Name : ");
                    name = Console.ReadLine();
                    if (name == "null")
                    {
                        throw new Exception();
                    }
                    isEceptionValid = false;
                }
                catch (Exception)
                {

                    isEceptionValid = true;
                    Console.WriteLine("Seflik var");
                }

            } while (isEceptionValid || !UserValidation.IsNameValid(name));


            return name;
        }
        public static string GetLastName()
        {
            bool isEceptionValid;
            string surname = null;
            do
            {

                try
                {
                    Console.Write("Insert Surname : ");
                    surname = Console.ReadLine();
                    if (surname == "null")
                    {
                        throw new Exception();
                    }
                    isEceptionValid = false;
                }
                catch (Exception)
                {

                    isEceptionValid = true;
                    Console.WriteLine("Seflik var");
                }

            } while (isEceptionValid || !UserValidation.IsNameValid(surname));


            return surname;
        }
        public static string GetEmail()
        {
            Console.Write("Insert email : ");
            string email = Console.ReadLine();
            while (!UserValidation.IsValidEmail(email) || !UserValidation.IsUserExistsByEmail(email))
            {
                Console.Write("Pls enter email again : ");
                email = Console.ReadLine();
            }
            return email;
        }
        public static string GetPassword()
        {
            string password = null;
            bool isExceptionValid;
            do
            {
                try
                {

                    Console.Write("Insert password : ");
                    password = Console.ReadLine();

                    if (password == "null")
                    {
                        throw new Exception();
                    }
                    isExceptionValid = false;
                }
                catch (Exception)
                {
                    isExceptionValid = true;
                    Console.WriteLine("Xeta var"); ;
                }

            } while (isExceptionValid || !UserValidation.IsPasswordValid(password));

            string conPass = null;
            do
            {
                try
                {

                    Console.Write("Insert password again : ");
                    conPass = Console.ReadLine();
                    if (conPass == "null")
                    {
                        throw new Exception();
                    }
                    isExceptionValid = false;
                }
                catch
                {
                    isExceptionValid = true;
                    Console.WriteLine("Conifrm pass null exception");
                }

            } while (isExceptionValid || !UserValidation.IsPasswordSame(password, conPass));


            return password;
        }
    }
}
