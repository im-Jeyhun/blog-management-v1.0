using blog_management_v1._0.DataBase.Enums;
using blog_management_v1._0.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_management_v1._0.DataBase.Repository
{
    public class BlogRepository : Common.Repository<Blog, string>
    {
        static BlogRepository()
        {
            Entries.Add(new Blog(UserRepository.GetByEmail("ceyhun@gmail.com"), "Revan", "Salam", BlogStatus.Sended, "BLCode"));
        }
        //static BlogRepository()
        //{
        //    SeedBlog();
        //}

        //public static void SeedBlog()
        //{
        //    User user = new User("Ceyhun", "Hacizada");

        //    Entries.Add(new Blog(user, "ela", "cox ela", BlogStatus.Sended,"BL34"));


        //}

        static Random randomID = new Random();

        private static string _code;


        public static string RandomCode
        {
            get
            {
                _code = "BL" + randomID.Next();
                return _code;
            }

        }



        public static Blog UpdateBlog(string id, Blog blog)
        {
            BlogRepository blogRepository = new BlogRepository();
            Blog findedblog = blogRepository.GetById(id);
         
            findedblog.Title = blog.Title;
            findedblog.Content = blog.Content;
         
            return findedblog;

        }


    }
}
