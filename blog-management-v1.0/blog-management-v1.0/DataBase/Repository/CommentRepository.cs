using blog_management_v1._0.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_management_v1._0.DataBase.Repository
{
    public class CommentRepository : Common.Repository<Comment, int>
    {
        static CommentRepository()
        {
            BlogRepository blogRepository = new BlogRepository();
            Entries.Add(new Comment(blogRepository.Get(a => a.Id == "BLCode"), UserRepository.GetByEmail("ceyhun@gmail.com"), "Salam"));
        }
        //static CommentRepository()
        //{
        //    SeedUsers();
        //}

        //public static void SeedUsers()
        //{
        //    User user = new User("ceyhun", "haczada");
        //    Blog blog = new Blog(user, "Blog", "Test blog" , BlogStatus.Sended);
        //    Comment comment = new Comment(blog, user, "Test eladir");
        //    Entries.Add(comment);

        //}


    }
}
