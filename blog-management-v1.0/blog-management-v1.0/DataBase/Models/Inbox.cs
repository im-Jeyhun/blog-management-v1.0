using blog_management_v1._0.DataBase.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_management_v1._0.DataBase.Models
{
    public class Inbox : Entity<int>
    {
        public string Notfication { get; set; }

        public User User { get; set; }

        public Inbox(string notfication, User user)
        {
            Notfication = notfication;
            User = user;
        }
    }
}
