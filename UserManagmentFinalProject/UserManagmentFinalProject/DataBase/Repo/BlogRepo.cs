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
    }
}
