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
            Entries.Add(new Comment(blogRepository.Get(b => b.Id == "BL10545"), UserRepository.GetByEmail("ceyhun@gmail.com"), "Salam"));
        }
    


    }
}
