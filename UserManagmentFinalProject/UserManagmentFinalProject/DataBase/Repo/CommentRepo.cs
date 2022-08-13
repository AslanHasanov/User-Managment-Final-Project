using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagmentFinalProject.DataBase.Models;
using UserManagmentFinalProject.DataBase.Repo.Common;

namespace UserManagmentFinalProject.DataBase.Repo
{
    public class CommentRepo : Repository<Comment, int>
    {

        private static int _idCounter;
        public static int IdComment
        {
            get
            {
                _idCounter++;
                return _idCounter;
            }
        }

        public static Comment AddComment(User fromUser, Blog blog, string content)
        {
            Comment comment = new Comment(blog, fromUser, content);
            DbContext.Add(comment);
            return comment;
        }
        public static BlogRepo BlogRepo = new BlogRepo();

        static CommentRepo()
        {
            DbContext.Add(new Comment(BlogRepo.GetById("yehya"), UserRepo.GetUserByEmail("yehya@gmail.com"), "tebrikler"));

        }
    }
}
