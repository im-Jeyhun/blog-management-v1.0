using blog_management_v1._0.ApplicationLogic;
using blog_management_v1._0.ApplicationLogic.Services;
using blog_management_v1._0.DataBase.Models;
using blog_management_v1._0.DataBase.Repository;
using System;

namespace blog_management_v1._0.UI
{
    internal class Program
    {
        public static void Main(string[] args)
        {
           
            Console.WriteLine("___________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine(" Welcome our application pls enter suitable command for contuniue : ");
            Console.WriteLine("___________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("/register");
            Console.WriteLine("/login");
            Console.WriteLine("/show-blogs-with-comments");
            Console.WriteLine("/show-filtered-blogs-with-comments");
            Console.WriteLine("//find-blog-by-code");
            Console.WriteLine("/exit");

            while (true)
            {
                Console.Write("Enter suitable command :");
                string command = Console.ReadLine();
                if (command == "/register")
                {
                    Authentication.Register();

                }
                else if (command == "/login")
                {

                    Authentication.Login();

                }
                else if (command == "/show-blogs-with-comments")
                {
                    BlogServices.ShowBlogs();
                    
                }
                else if (command == "/show-filtered-blogs-with-comments")
                {
                    BlogServices.ShowFilteredBlogsWithComments();
                }
                else if (command == "/find-blog-by-code")
                {
                    BlogServices.FindBlogByCode();
                }
                else if (command == "/exit")
                {
                    Console.WriteLine("Thanks for using our application");
                    break;
                }
                else
                {
                    Console.WriteLine("Command not found ...");
                }
            }
        }
    }
}
