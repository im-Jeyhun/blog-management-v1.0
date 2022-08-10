using blog_management_v1._0.DataBase.Models;
using blog_management_v1._0.DataBase.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_management_v1._0.DataBase.Repository
{
    public class InboxRepository : Repository<Inbox, int>
    {
        static InboxRepository()
        {
            UserRepository userRepo = new UserRepository();
            Entries.Add(new Inbox("Default message", userRepo.Get(u => u.Email == "ceyhun@gmail.com")));
        }
    }
}
