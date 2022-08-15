using blog_management_v1._0.ApplicationLogic.Services;
using blog_management_v1._0.DataBase.Enums;
using blog_management_v1._0.DataBase.Models;
using blog_management_v1._0.DataBase.Repository;
using blog_management_v1._0.DataBase.Repository.Common;
using blog_management_v1._0.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog_management_v1._0.ApplicationLogic
{
    public partial class Dashboard
    {
        public static User CurrentUser { get; set; }
        public static void AdminPanel(string email)
        {
            Repository<User, int> userrepository = new Repository<User, int>();
            Repository<Admin, int> adminrepository = new Repository<Admin, int>();
            Repository<Blog, string> blogrepo = new Repository<Blog, string>();
            CommentRepository commentRepo = new CommentRepository();
            InboxRepository inboxRepo = new InboxRepository();

            User user = UserRepository.GetByEmail(email);
            Console.WriteLine($"Welcome admin : {user.GetUserInfo()}");
            while (true)
            {


                Console.WriteLine("Admin commands are :" +
                    " /add-user , /update-user ," +
                    " /remove-user , /add-admin," +
                    "/show-admins,/update-admin, " +
                    "/make-admin , /remove-admin, " +
                    "/show-users, /show-auditing-blogs , /approve-blog , /reject-blog , /logout");

                Console.Write("Enter suitable command : ");
                string command = Console.ReadLine();

                if (command == "/add-user")
                {
                    Authentication.Register();
                }
                else if (command == "/update-user")
                {
                    while (true)
                    {
                        Console.WriteLine("Enter email who u want to update");
                        string updatedUserEmail = Console.ReadLine();
                        User updatedUser = UserRepository.GetByEmail(updatedUserEmail);

                        if (updatedUser.Email == email)
                        {
                            Console.WriteLine("Deyismek isediyiniz admin ile daxil olmusunuz");
                        }
                        else if (updatedUser == null)
                        {
                            Console.WriteLine("Admin tapilmadi");
                        }
                        else
                        {

                            if (updatedUser is User)
                            {
                                User uppUser = new User(UserService.GetName(), UserService.GetLastName());
                                UserRepository.UpdateForUser(updatedUserEmail, uppUser);
                                Console.WriteLine("User update olundu");
                                break;
                            }
                            else if (updatedUser is Admin)
                            {
                                Console.WriteLine("Bu emaile mexsus istifadeci Admindir...");
                            }

                        }
                    }
                }
                else if (command == "/remove-user")
                {
                    while (true)
                    {
                        Console.Write("Enter email who u want to delete : ");
                        string deletedEmail = Console.ReadLine();
                        User deletedUser = UserRepository.GetByEmail(deletedEmail);
                        if (deletedUser == null)
                        {
                            Console.WriteLine("Emaile gore istifadeci tapilmadi");
                        }
                        else if (deletedUser is Admin)
                        {
                            Console.WriteLine("Emaile gore tapilan istifadeci admindir ...");
                        }
                        else
                        {
                            userrepository.Delete(deletedUser);
                            Console.WriteLine("User deleted succesfully");
                            break;
                        }
                    }
                }
                else if (command == "/add-admin")
                {
                    Admin newAdmin = new Admin(UserService.GetName(), UserService.GetLastName(), UserService.GetEmail(), UserService.GetPassword());
                    adminrepository.Add(newAdmin);
                    Console.WriteLine($"New admin added succesfully {newAdmin.GetUserInfo()} ");
                }
                else if (command == "/show-admins")
                {
                    List<User> admins = userrepository.GetAll();


                    foreach (User admin in admins)
                    {
                        if (admin is Admin)
                        {
                            Console.WriteLine(admin.GetUserInfo());
                        }
                    }
                }
                else if (command == "/update-admin")
                {
                    while (true)
                    {
                        Console.WriteLine("Enter admin email which u want to update admin's details");
                        string updatedAdmin = Console.ReadLine();
                        User admin = UserRepository.GetByEmail(updatedAdmin);
                        if (admin.Email == CurrentUser.Email)
                        {
                            Console.WriteLine("Deyismek isediyiniz admin ile daxil olmusunuz");
                        }
                        else if (admin == null)
                        {
                            Console.WriteLine("Admin tapilmadi");
                        }
                        else
                        {

                            if (admin is Admin)
                            {
                                Admin uppAdmin = new Admin(UserService.GetName(), UserService.GetLastName());
                                UserRepository.UpdateForAdmin(updatedAdmin, uppAdmin);
                                Console.WriteLine("Admin update olundu");
                                break;
                            }
                            else if (admin is User)
                            {
                                Console.WriteLine("Bu emaile mexsus istifadeci Userdir...");
                            }

                        }
                    }
                }
                else if (command == "/remove-admin")
                {
                    while (true)
                    {
                        Console.WriteLine("Enter Admin email for remove Admin : ");
                        string removedAdminEmail = Console.ReadLine();

                        Admin findedAdmin = UserRepository.GetByEmailForAdmin(removedAdminEmail);
                        //User findedAdmin = UserRepository.GetByEmail(removedAdminEmail);

                        if (findedAdmin.Email == removedAdminEmail)
                        {
                            Console.WriteLine("Silmek istediyiniz admin istifadecisindesiz");
                        }
                        else if (findedAdmin == null)
                        {

                            Console.WriteLine("Admin tapilmadi bu emaile");
                        }
                        else
                        {

                            if (findedAdmin is User)
                            {
                                Console.WriteLine("Istifadeci Adi userdi");
                            }
                            else if (findedAdmin is Admin)
                            {
                                adminrepository.Delete(findedAdmin);
                                Console.WriteLine("Admin silindi");
                                break;
                            }
                        }
                    }
                }
                else if (command == "/make-admin")
                {
                    Console.WriteLine("Insert emial who u want do make admin");
                    string userEmail = Console.ReadLine();
                    User user1 = UserRepository.GetByEmail(userEmail);
                    if (user1 == null)
                    {
                        Console.WriteLine("Email ile istifadeci tapilmadi");
                    }
                    else
                    {

                        userrepository.Delete(user1);

                        Admin admin1 = new Admin(user1.Name, user1.LastName, user1.Email, user1.Password, user1.Id);

                        adminrepository.Add(admin1);
                    }
                }
                else if (command == "/show-users")
                {
                    List<User> users = userrepository.GetAll();
                    foreach (User userr in users)
                    {
                        if (userr == null)
                        {
                            Console.WriteLine("Istifadeci tapilmadi");
                        }
                        else if (userr is not Admin)
                        {
                            Console.WriteLine(userr.GetUserInfo());
                        }

                    }
                }
                else if (command == "/show-auditing-blogs")
                {

                    List<Blog> blogs = blogrepo.GetAll();
                    CommentRepository commentRepository = new CommentRepository();

                    foreach (Blog blog in blogs)
                    {

                        if (blog.BlogStatus == BlogStatus.Created)
                        {
                            Console.WriteLine(blog.GetBlogInfo());
                            Console.WriteLine("______________________________________________________________________________");
                            Console.WriteLine();
                            //foreach (Comment comment in commentRepo.GetAll(c => c.Blog == blog))
                            //{
                            //    Console.WriteLine(comment.GetCommentInfo());
                            //}
                        }
                        else
                        {
                            Console.WriteLine("In system couldnt found Auditing blog..");
                        }


                    }

                }
                else if (command == "/approve-blog")
                {
                    Console.Write("Insert Blog Code for approve it : ");
                    string blogCode = Console.ReadLine();
                    Blog chosedblog = blogrepo.GetById(blogCode);

                    if (chosedblog != null && chosedblog.BlogStatus == BlogStatus.Created)
                    {
                        chosedblog.BlogStatus = BlogStatus.Approved;
                        Inbox message = new Inbox($"This blog {chosedblog.Id} Approved by Admin", chosedblog.Owner);
                        inboxRepo.Add(message);
                        Console.WriteLine("Blog Approved...");
                    }
                    else
                    {
                        Console.WriteLine("Blog not found or Blog already Approved or Rejected");
                    }
                }
                else if (command == "/reject-blog")
                {
                    Console.Write("Insert Blog Code for Reject it : ");
                    string blogCode = Console.ReadLine();
                    Blog chosedblog = blogrepo.GetById(blogCode);

                    if (chosedblog != null && chosedblog.BlogStatus == BlogStatus.Created)
                    {
                        chosedblog.BlogStatus = BlogStatus.Rejected;
                        Inbox message = new Inbox($"This blog {chosedblog.Id} Rejected by Admin", chosedblog.Owner);
                        inboxRepo.Add(message);
                        Console.WriteLine("Blog rejected...");
                    }
                    else
                    {
                        Console.WriteLine("Blog not found or Blog already Approved or Rejected");
                    }
                }
                else if (command == "/logout")
                {
                    Program.Main(new string[] { });
                    break;
                }
                else
                {
                    Console.WriteLine("Command not found ....");
                }
            }
        }
    }
    public partial class Dashboard
    {
        public static void UserPanel(string email)
        {
            Repository<User, int> userrepository = new Repository<User, int>();
            Repository<Blog, string> blogrepeo = new Repository<Blog, string>();
            Repository<Comment, int> commentRepo = new Repository<Comment, int>();
            Repository<Inbox, int> inboxRepo = new Repository<Inbox, int>();


            User user = UserRepository.GetByEmail(email);
            Console.WriteLine($"User succesfully joined : {user.GetUserInfo()}");
            while (true)
            {
                Console.WriteLine("User commands are : /update-info , /report-user ,/delete ,/inbox, /add-blog , /add-comment , /my-blogs , /logout ");
                Console.Write("Insert suitable command : ");
                string command = Console.ReadLine();

                if (command == "/update-info")
                {
                    if (user.Email == email)
                    {
                        User updateUser = new User(UserService.GetName(), UserService.GetLastName());
                        UserRepository.UpdateForUser(email, updateUser);
                    }
                }
                else if (command == "/add-blog")
                {
                    Console.WriteLine($"Dear {user.Name} Add your blog's title");
                    //string blogTitle = BlogServices.GetBlogTitle();
                    Console.WriteLine(" Add your blog  ");
                    //string blogContent = BlogServices.GetBlogContent();

                    Blog blog = new Blog(CurrentUser, BlogServices.GetBlogTitle(), BlogServices.GetBlogContent(), BlogStatus.Created);
                    blogrepeo.Add(blog);
                    Console.WriteLine("Blog successfully added.");



                }
                else if (command == "/add-comment")
                {
                    Console.WriteLine("Pls choose blog with it's id for add comment");
                    string blogId = Console.ReadLine();
                    Blog findedBlog = blogrepeo.GetById(blogId);
                    InboxRepository ınboxRepository = new InboxRepository();
                    if (findedBlog != null)
                    {
                        Console.WriteLine($"Pls enter comment to this blog {findedBlog.Title}");
                        string comment = CommentServices.GetCommentContent();
                        Comment newComment = new Comment(findedBlog, CurrentUser, comment);
                        //CommentRepository.AddComment(findedBlog, user, comment);
                        commentRepo.Add(newComment);
                        ınboxRepository.Add(new Inbox($" Your [{findedBlog.Id}] comment added by [{CurrentUser.Name} {CurrentUser.LastName}]", findedBlog.Owner));

                        Console.WriteLine("Comment added...");
                    }
                    else
                    {
                        Console.WriteLine("Blog not finded..");
                    }
                }
                else if (command == "/my-blogs")
                {
                    BlogRepository blogRepository = new BlogRepository();
                    List<Blog> blogs = blogRepository.GetAll();
                    int counter = 1;

                    foreach (Blog blog in blogs)
                    {

                        if (blog.Owner == CurrentUser)
                        {
                            Console.WriteLine(counter + "." + blog.GetBlogInfo());
                            counter++;
                            Console.WriteLine("______________________________________________________________________________");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("You dont have blog..");
                        }
                    }

                }
                else if (command == "/delete")
                {
                    Console.Write("Insert Blog code for delete : ");
                    string blogId = Console.ReadLine();
                    Blog findedBlog = blogrepeo.GetById(blogId);
                    List<Comment> findedComments = commentRepo.GetAll(c => c.Blog == findedBlog);
                    List<Inbox> findedMessages = inboxRepo.GetAll(m => m.Notfication.Contains(findedBlog.Id));
                    if (findedBlog.Owner == CurrentUser)
                    {

                        blogrepeo.Delete(findedBlog);
                        foreach (Comment comment in findedComments)
                        {

                            commentRepo.Delete(comment);
                        }
                        foreach (Inbox message in findedMessages)
                        {

                            inboxRepo.Delete(message);
                        }
                        Console.WriteLine($"Your {findedBlog.Title} is deleted.. ");
                    }
                    else
                    {
                        Console.WriteLine("U can only delete your blog");
                    }

                }
                else if (command == "/inbox")
                {
                    InboxRepository inboxRepository = new InboxRepository();
                    int counter = 1;
                    List<Inbox> inboxs = inboxRepository.GetAll();

                    foreach (Inbox inbox in inboxs)
                    {
                        if (inbox.User == CurrentUser)
                        {
                            Console.WriteLine(counter + "." + inbox.Notfication);
                            counter++;
                        }
                    }
                }
                else if (command == "/logout")
                {
                    Program.Main(new string[] { });
                    break;
                }
                else
                {
                    Console.WriteLine("Command not found...");
                }
            }


        }
    }
}
