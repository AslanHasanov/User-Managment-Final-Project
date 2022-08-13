using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagmentFinalProject.ApplicationLogic.Validations;
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
    }
}
