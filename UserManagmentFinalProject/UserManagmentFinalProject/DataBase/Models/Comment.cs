using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagmentFinalProject.DataBase.Models.Common;
using UserManagmentFinalProject.DataBase.Repo;

namespace UserManagmentFinalProject.DataBase.Models
{
    public class Comment : Entity<int>
    {
        public Blog Blog { get; set; }
        public User FromUser { get; set; }
        public string ContentComment { get; set; }

        public Comment(Blog blog, User fromUser, string contentComment, int? id = null)
        {
            Blog = blog;
            FromUser = fromUser;
            ContentComment = contentComment;

            if (id != null)
            {
                Id = id.Value;
            }
            else
            {
                Id = CommentRepo.IdComment;
            }

        }
        public string GetInfo()
        {
            return $" {CreatedAt} {FromUser.FirstName} {FromUser.LastName} {ContentComment}";
        }
    }
}
