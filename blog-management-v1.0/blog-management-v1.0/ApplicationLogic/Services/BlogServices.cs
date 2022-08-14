using blog_management_v1._0.ApplicationLogic.Validation;
using blog_management_v1._0.DataBase.Enums;
using blog_management_v1._0.DataBase.Models;
using blog_management_v1._0.DataBase.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_management_v1._0.ApplicationLogic.Services
{
    public class BlogServices
    {
        public static Repository<Blog, string> blogRepo = new Repository<Blog, string>();

        public static Repository<Comment, int> commentRepo = new Repository<Comment, int>();



        public static void ShowBlogs()
        {
            List<Blog> blogss = blogRepo.GetAll();
            int counter = 1;

            foreach (Blog blog in blogss)
            {
                if (blog.BlogStatus == BlogStatus.Approved)
                {
                    Console.WriteLine(counter + "." + blog.GetBlogInfo());
                    List<Comment> commentss = commentRepo.GetAll(c => c.Blog == blog);

                    for (int i = 0; i < commentss.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} {commentss[i].GetCommentInfo()}");
                    }
                    Console.WriteLine("______________________________________________________________________________");
                    Console.WriteLine();

                }
                else
                {
                    Console.WriteLine("Aprroved blogs couldnt finded");
                }
                counter++;

            }
        }


        public static string GetBlogTitle()
        {
            bool isEceptionValid;
            string title = null;
            do
            {

                try
                {
                    Console.Write("Insert title : ");
                    title = Console.ReadLine();
                    if (title == "null")
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

            } while (isEceptionValid || !Validations.IsLengthCorrect(title, 10, 35));


            return title;
        }
        public static string GetBlogContent()
        {
            bool isEceptionValid;
            string content = null;
            do
            {

                try
                {
                    Console.Write("Insert content : ");
                    content = Console.ReadLine();
                    if (content == "null")
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

            } while (isEceptionValid || !Validations.IsLengthCorrect(content, 20, 45));


            return content;
        }

        public static void FindBlogByCode()
        {

            Console.WriteLine("Eneter code : ");
            string blogCode = Console.ReadLine();

            Blog findedBlog = blogRepo.GetById(blogCode);
            int counter = 1;
            if (findedBlog != null)
            {
                if (findedBlog.BlogStatus == BlogStatus.Approved)
                {

                    Console.WriteLine(findedBlog.GetBlogInfo());
                    foreach (Comment comment in commentRepo.GetAll(c => c.Blog == findedBlog))
                    {
                        Console.WriteLine(counter + "." + comment.GetCommentInfo());
                        counter++;
                    }
                }
                else
                {
                    Console.WriteLine($"{findedBlog.Title} is not approved or {findedBlog.Title} is rejected..");
                }

            }
            else
            {
                Console.WriteLine("Blog couldn finded...");
            }

        }

        public static void ShowFilteredBlogsWithComments()
        {
            Console.WriteLine("Which type in u want search blogs ? (/title , /firstname");
            string type = Console.ReadLine();
            if (type == "/title")
            {
                Console.Write("Pls enter suitable title : ");
                string title = Console.ReadLine();
                int counter = 1;
                foreach (Blog blog in blogRepo.GetAll())
                {
                    if (blog.Title.Contains(title))
                    {
                        Console.WriteLine(counter + "." + blog.GetBlogInfo());
                        List<Comment> commentss = commentRepo.GetAll(c => c.Blog == blog);

                        for (int i = 0; i < commentss.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} {commentss[i].GetCommentInfo()}");
                        }
                        Console.WriteLine("______________________________________________________________________________");
                        Console.WriteLine();

                    }
                    else
                    {
                        Console.WriteLine($"Whit this {title} couldnt finded blog ");
                    }
                    counter++;
                }

            }
            else if (type == "/firstname")
            {
                Console.Write("Pls enter blog owner name : ");
                string blogOwner = Console.ReadLine();
                int counter = 1;
                foreach (Blog blog in blogRepo.GetAll())
                {
                    if (blog.Owner.Name.Contains(blogOwner))
                    {
                        Console.WriteLine(counter + "." + blog.GetBlogInfo());
                        List<Comment> commentss = commentRepo.GetAll(c => c.Blog == blog);

                        for (int i = 0; i < commentss.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} {commentss[i].GetCommentInfo()}");
                        }
                        Console.WriteLine("______________________________________________________________________________");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine($"This {blogOwner}'s blogs couldnt finded ");
                    }
                    counter++;
                }

            }
            else
            {
                Console.WriteLine("Command not found...");
            }
        }
    }
}
