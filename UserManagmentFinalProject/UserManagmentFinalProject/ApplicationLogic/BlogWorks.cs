using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagmentFinalProject.ApplicationLogic.Validations;
using UserManagmentFinalProject.DataBase.Models;
using UserManagmentFinalProject.DataBase.Models.Enums;
using UserManagmentFinalProject.DataBase.Repo;

namespace UserManagmentFinalProject.ApplicationLogic
{
     class BlogWorks
    {
        static BlogRepo blogRepo = new BlogRepo();
        static CommentRepo commentRepo = new CommentRepo();

        public static string GetComment()
        {
            Console.Write("Enter comment: ");
            string comment = Console.ReadLine();
            while (!Validation.IsLengthBetween(comment, 10, 35))
            {
                Console.Write("Comment length is incorrect, try again :");
                comment = Console.ReadLine();
            }

            return comment;
        }

        public static string GetTitle()
        {
            Console.Write("Enter title: ");
            string title = Console.ReadLine();
            while (!Validation.IsLengthBetween(title, 10, 35))
            {
                Console.Write("Title length is incorrect, try again :");
                title = Console.ReadLine();
            }

            return title;
        }

        public static string GetContent()
        {
            Console.Write("Enter content: ");
            string content = Console.ReadLine();
            while (!Validation.IsLengthBetween(content, 20, 45))
            {
                Console.Write("Content length is incorrect, try again :");
                content = Console.ReadLine();
            }

            return content;
        }

        public static void ShowBlogsWithComments()
        {
            BlogRepo blogRepo = new BlogRepo();
            CommentRepo commentRepo = new CommentRepo();
            List<Blog> blogs = blogRepo.GetAll();
            List<Comment> comments = commentRepo.GetAll();
            int counter = 1;

            foreach (Blog blog in blogRepo.GetAll(b => b.Status == BlogStatus.Approved)) //bura
            {
                Console.WriteLine(blog.GetBlogInfo());

                foreach (Comment comment in commentRepo.GetAll(c => c.Blog == blog))
                {
                    Console.WriteLine(counter + " " + comment.GetInfo());
                    counter++;
                    Console.WriteLine();
                }
            }
        }

        public static void ShowFilteredBlogsWithComments()
        {
            Console.Write(" Commands :\n /title \n /first-name");
            Console.WriteLine();
            while (true)
            {
                Console.Write("Enter filter :");
                string command = Console.ReadLine();

                if (command == "/title")
                {
                    Console.Write("Enter title: ");
                    string targetTitle = Console.ReadLine();
                    int counter = 1;

                    foreach (Blog blog in blogRepo.GetAll(b => b.Title.Contains(targetTitle)))
                    {
                        Console.WriteLine(blog.GetBlogInfo());

                        foreach (Comment comment in commentRepo.GetAll(c => c.Blog == blog))
                        {
                            Console.WriteLine($"{counter} {comment.GetInfo()}");
                            counter++;
                            Console.WriteLine();
                        }
                    }
                }

                else if (command == "/first-name")
                {
                    Console.Write("Enter first name: ");
                    string targetName = Console.ReadLine();
                    int counter = 1;

                    foreach (Blog blog in blogRepo.GetAll(b => b.FromUser.FirstName == targetName))  //bura
                    {
                        Console.WriteLine(blog.GetBlogInfo());

                        foreach (Comment comment in commentRepo.GetAll(c => c.Blog == blog))
                        {
                            Console.WriteLine($"{counter} {comment.GetInfo()}");
                            counter++;
                            Console.WriteLine();
                        }
                    }
                }

                else { Console.WriteLine("Command not found"); }
            }
        }

        public static void FindBlogByCode()
        {
            BlogRepo blogRepo = new BlogRepo();
            CommentRepo commentRepo = new CommentRepo();
            List<Blog> blogs = blogRepo.GetAll();

            while (true)
            {
                Console.Write("Enter code :");
                string blogCode = Console.ReadLine();
                int counter = 1;

                foreach (Blog blog in blogs)
                {
                    if (blog.Id == blogCode && blog.Status == BlogStatus.Approved)
                    {
                        Console.WriteLine(blog.GetBlogInfo());
                        foreach (Comment comment in commentRepo.GetAll(c => c.Blog == blog))
                        {
                            Console.WriteLine(counter + " " + comment.GetInfo());
                            counter++;
                            Console.WriteLine();
                        }
                    }

                    else { Console.WriteLine("Code not found "); break; }
                }
            }
        }
    }
}
