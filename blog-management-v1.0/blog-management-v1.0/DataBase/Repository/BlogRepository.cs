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
            Entries.Add(new Blog(UserRepository.GetByEmail("ceyhun@gmail.com"), "How to learn programming", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", BlogStatus.Created, "BL10545"));
        }       

        static Random randomID = new Random();

        private static string _code;


        public static string RandomCode
        {
            get
            {
                _code = "BL" + randomID.Next(10000,100000);
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
