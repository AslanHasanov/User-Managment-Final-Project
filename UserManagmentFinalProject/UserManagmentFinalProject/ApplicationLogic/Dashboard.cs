using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagmentFinalProject.DataBase.Models;
using UserManagmentFinalProject.DataBase.Repo;

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
        }
    }
}
