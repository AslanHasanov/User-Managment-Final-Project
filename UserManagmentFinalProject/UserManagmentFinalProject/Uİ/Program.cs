using System;
using UserManagmentFinalProject.ApplicationLogic;
using UserManagmentFinalProject.ApplicationLogic.Validations;

namespace UserManagmentFinalProject.Uİ
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Validation.Typewrite("\n Commands :" +
                "\n/register " +
                "\n/login " +
                "\n/show-blogs-with-comments" +
                "\n/show-filtered-blogs-with-comments " +
                "\n/find-blog-by-code ");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("/exit");
            Console.ForegroundColor = ConsoleColor.Green;

            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter command : ");
                string command = Console.ReadLine();

                if (command == "/register")
                {
                    Authentication.Register();
                }
                else if (command == "/login")
                {
                    Authentication.Login();
                }
                else if (command == "/show-blogs-with-comments")
                {
                    BlogWorks.ShowBlogsWithComments();
                }
                else if (command == "/show-filtered-blogs-with-comments")
                {
                    BlogWorks.ShowFilteredBlogsWithComments();
                }
                else if (command == "/find-blog-by-code")
                {
                    BlogWorks.FindBlogByCode();
                }
                else if (command == "/exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("command not found " + command);
                }
            }
        }
    }
}
