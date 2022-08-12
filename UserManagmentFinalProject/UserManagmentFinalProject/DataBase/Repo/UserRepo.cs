using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagmentFinalProject.DataBase.Models;
using UserManagmentFinalProject.DataBase.Repo.Common;

namespace UserManagmentFinalProject.DataBase.Repo
{
    public class UserRepo: Repository<User, int>
    {
        private static int _idCounter;
        public static int IdCounter
        {
            get
            {
                return _idCounter++;
            }
        }
        static UserRepo()
        {
            SeedUsers();
        }

        private static void SeedUsers()
        {
            DbContext.Add(new Admin("Mahmood", "Garibov", "qaribov@gmail.com", "123"));
            DbContext.Add(new User("Eshqin", "Mahmudov", "eshqin@gmail.com", "123"));
            DbContext.Add(new User("Yehya", "Mahmudov", "yehya@gmail.com", "123"));
            DbContext.Add(new User("Aslan", "Hasan", "aslan@gmail.com", "123"));
        }
        public static User AddUser(string firstName, string lastName, string email, string password)
        {
            User user = new User(firstName, lastName, email, password, IdCounter);
            DbContext.Add(user);
            return user;
        }
    }
}
