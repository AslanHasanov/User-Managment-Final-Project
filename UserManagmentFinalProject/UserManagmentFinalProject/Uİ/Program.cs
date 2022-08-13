using System;
using UserManagmentFinalProject.ApplicationLogic.Validations;

namespace UserManagmentFinalProject.Uİ
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Validation.Typewrite("\n Commands :" +
                "\n /register " +
                "\n /login " +
                "\n /show-blogs-with-comments" +
                "\n /show-filtered-blogs-with-comments " +
                "\n /find-blog-by-code ");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" /exit");
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}
