using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagmentFinalProject.DataBase.Models;
using UserManagmentFinalProject.DataBase.Models.Enums;
using UserManagmentFinalProject.DataBase.Repo.Common;

namespace UserManagmentFinalProject.DataBase.Repo
{
    public class BlogRepo : Repository<Blog, string>
    {
        static Random random = new Random();
        private static string _idCounter;
        public static string IdBlog
        {
            get
            {
                _idCounter = "BL" + random.Next();
                return _idCounter;
            }
        }
        public static Blog Add(User fromUser, string title, string content)
        {
            Blog blog = new Blog(fromUser, title, content, BlogStatus.Sended);
            DbContext.Add(blog);
            return blog;
        }
        static BlogRepo()
        {
            DbContext.Add(new Blog(UserRepo.GetUserByEmail("yehya@gmail.com"), "Informasiya Texnologiyalari1", "Proqramlashdirma dilleri", BlogStatus.Approved, "yehya"));
            DbContext.Add(new Blog(UserRepo.GetUserByEmail("eshqin@gmail.com"), "Informasiya Texnologiyalari2", "Sistem adminstratorlugu", BlogStatus.Sended, "eshqin"));
            DbContext.Add(new Blog(UserRepo.GetUserByEmail("eshqin@gmail.com"), "Informasiya Texnologiyalari3", "Sistem adminstratorlugu 3", BlogStatus.Sended, "eshqin2"));
        }
    }
}
