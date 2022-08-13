using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagmentFinalProject.DataBase.Models;
using UserManagmentFinalProject.DataBase.Models.Enums;
using UserManagmentFinalProject.DataBase.Repo;
using UserManagmentFinalProject.DataBase.Repo.Common;
using UserManagmentFinalProject.Uİ;

namespace UserManagmentFinalProject.ApplicationLogic
{
    public partial class Dashboard
    {
        public static User CurrentUser { get; set; }
        public static void AdminPanel()
        {
            BlogRepo blogRepo = new BlogRepo();
            InboxRepo inboxRepo = new InboxRepo();
            UserRepo userRepo = new UserRepo();
            Admin admin = (Admin)UserRepo.GetUserByEmail(CurrentUser.Email);

            Console.WriteLine($"Welcome dear admin, {admin.GetInfo()}");

            Console.Write("Admin's commands :" +
                "\n /show-users " +
                "\n /show-admins " +
                "\n /show-auditing-blogs " +
                "\n /approve-blog " +
                "\n /reject-blog " +
                "\n /log-out");

            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter command :");
                string command = Console.ReadLine();

                if (command == "/show-users")
                {
                    List<User> users = userRepo.GetAll();
                    int userCounter = 1;
                    foreach (User user in users)
                    {
                        if (user is not Admin)
                        {
                            Console.WriteLine($"{userCounter} {user.GetInfo()}");
                            userCounter++;
                        }
                    }
                }


                else if (command == "/show-admins")
                {
                    List<User> users = userRepo.GetAll();
                    int userCounter = 1;

                    foreach (User user in users)
                    {
                        if (user is Admin)
                        {
                            Console.WriteLine($"{userCounter} {user.GetInfo()}");
                            userCounter++;
                        }
                    }
                }

                else if (command == "/show-auditing-blogs")
                {
                    List<Blog> blogs = blogRepo.GetAll(b => b.Status == BlogStatus.Sended);
                    foreach (Blog blog in blogs)
                    {
                        Console.WriteLine(blog.GetBlogInfo());
                        Console.WriteLine();
                    }
                }

                else if (command == "/approve-blog")
                {
                    Console.Write("Enter blog code: ");
                    string blogCode = Console.ReadLine();

                    Blog blog = blogRepo.GetById(blogCode);

                    if (blog != null && blog.Status == BlogStatus.Sended)
                    {
                        blog.Status = BlogStatus.Approved;
                        Inbox inbox = new Inbox($"This blog cod's {blog.Id} approved", blog.FromUser);
                        inboxRepo.Add(inbox);

                        Console.WriteLine("Blog succesfully approved");
                    }

                }

                else if (command == "/reject-blog")
                {
                    Console.Write("Enter blog code: ");
                    string blogCode = Console.ReadLine();

                    Blog blog = blogRepo.GetById(blogCode);

                    if (blog != null && blog.Status == BlogStatus.Sended)
                    {
                        blog.Status = BlogStatus.Rejected;
                        Inbox inbox = new Inbox($"This blog cod's {blog.Id} rejected", blog.FromUser);
                        inboxRepo.Add(inbox);

                        Console.WriteLine("Blog succesfully rejected");
                    }
                }

                else if (command == "/log-out")
                {
                    Program.Main(new string[] { });
                    break;
                }
                else { Console.WriteLine("Command not found"); }
            }
        }
    }
    public partial class Dashboard
    {
        public static void UserPanel()
        {
            Repository<Blog, string> blogRepo = new Repository<Blog, string>();
            BlogRepo blogrepo = new BlogRepo();
            CommentRepo commentrepo = new CommentRepo();
            InboxRepo inboxRepo = new InboxRepo();
            User user = UserRepo.GetUserByEmail(CurrentUser.Email);

            Console.WriteLine($"Welcome to your accaunt {user.GetInfo()}");
            Console.Write("Your commands :" +
                "\n /inbox " +
                "\n /add-comment " +
                "\n /blogs " +
                "\n /add-blog " +
                "\n /delete-blog " +
                "\n /log-out");

            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter command: ");
                string command = Console.ReadLine();

                if (command == "/inbox")
                {
                    foreach (Inbox inbox in inboxRepo.GetAll(i => i.User == CurrentUser))
                    {
                        Console.WriteLine(inbox.ToString());
                    }
                }

                else if (command == "/add-comment")
                {
                    Console.Write("Enter Blog code: ");
                    string blogCode = Console.ReadLine();

                    Blog blog = blogrepo.GetById(blogCode);
                    if (blog != null)
                    {
                        Comment comments = new Comment(blog, CurrentUser, BlogWorks.GetComment());
                        blogrepo.Add(blog);

                        Inbox inbox = new Inbox($"This blog cod's {blog.Id} {blog.FromUser.FirstName}, {blog.FromUser.LastName} added comment", blog.FromUser);
                        inboxRepo.Add(inbox);

                        Console.WriteLine("Comment added to blog");
                    }
                    else { Console.WriteLine("Blog not found"); }

                }

                else if (command == "/blogs")
                {
                    List<Blog> blogs = blogRepo.GetAll(b => b.FromUser == CurrentUser);

                    foreach (Blog blog in blogs)
                    {
                        if (blog != null)
                        {
                            Console.WriteLine(blog.GetBlogInfo());
                            Console.WriteLine();
                        }
                        else { Console.WriteLine("Not found blog"); }

                    }
                }

                else if (command == "/add-blog")
                {
                    string title = BlogWorks.GetTitle();
                    string content = BlogWorks.GetContent();

                    BlogRepo.Add(CurrentUser, title, content);
                    Console.WriteLine("Blog added to system");
                }

                else if (command == "/delete-blog")
                {
                    Console.Write("Enter blog code: ");
                    string blogCode = Console.ReadLine();
                    Blog blog = blogRepo.GetById(blogCode);
                    List<Comment> comments = commentrepo.GetAll(c => c.Blog == blog);
                    List<Inbox> inboxes = inboxRepo.GetAll(i => i.Notification.Contains(blog.Id));

                    if (blog != null)
                    {
                        if (blog.FromUser == CurrentUser)
                        {
                            blogRepo.Delete(blog);
                            foreach (Comment comment in comments)
                            {
                                commentrepo.Delete(comment);
                            }
                            foreach (Inbox inbox in inboxes)
                            {
                                inboxRepo.Delete(inbox);
                            }

                            Console.WriteLine("Blog deleted");
                        }
                        else { Console.WriteLine("Blog code is incorrect"); }

                    }
                }
            }
        }
    }

}
