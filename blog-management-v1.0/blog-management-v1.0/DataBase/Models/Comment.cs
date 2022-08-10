using blog_management_v1._0.DataBase.Models.Common;
using blog_management_v1._0.DataBase.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_management_v1._0.DataBase.Models
{
    public class Comment : Entity<int>
    {
        public Blog Blog { get; set; }

        public User Owner { get; set; }

        public string Content { get; set; }

        public Comment(Blog blog, User owner, string content, int? id = null)
        {
            Blog = blog;
            Owner = owner;
            Content = content;
            if (id != null)
            {
                Id = id.Value;
            }
            else
            {

                Id = UserRepository.IdCounter;
            }

            CreatedAt = DateTime.Now;
        }

        public string GetCommentInfo()
        {
            return $"[{CreatedAt}][{Owner.Name} {Owner.LastName}] - {Content}";
        }
    }
}
