using blog_management_v1._0.DataBase.Enums;
using blog_management_v1._0.DataBase.Models.Common;
using blog_management_v1._0.DataBase.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_management_v1._0.DataBase.Models
{
    public class Blog : Entity<string>
    {

        public User Owner { get; set; }

        public string Title { get; set; }

        public BlogStatus BlogStatus { get; set; }

        public static List<Comment> Comments { get; set; } = new List<Comment>();

        public string Content { get; set; }



        public Blog(User owner, string title, string content, BlogStatus blogStatus, string id = null)
        {
            Owner = owner;
            Title = title;
            Content = content;
            if (id != null && BlogRepository.IsIdExists(id))
            {
                Id = id;
            }
            else
            {

                Id = BlogRepository.RandomCode;
            }
            CreatedAt = DateTime.Now;
            BlogStatus = blogStatus;

        }

        public string GetBlogFullInfo()
        {
            return "Blog id : " + Id + " " + "Blog owner :" + Owner.Name + Owner.LastName + " " + "Blog title :" + Title + " " + "Blog content :" + Content + " " + "Blog creating time :" + CreatedAt + " " + "Blog status : " + BlogStatus;
        }

        public string GetBlogInfo()
        {
            return $"[{CreatedAt}][{Id}][{Owner.Name} {Owner.LastName}] \n ==={Title}=== \n {Content}";
        }
    }
}
