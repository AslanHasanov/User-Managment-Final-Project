using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagmentFinalProject.DataBase.Models.Common;
using UserManagmentFinalProject.DataBase.Models.Enums;
using UserManagmentFinalProject.DataBase.Repo;

namespace UserManagmentFinalProject.DataBase.Models
{
    public class Blog : Entity<string>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public BlogStatus Status { get; set; }
        public User FromUser { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public Blog(User fromUser, string title, string content, BlogStatus status, string id = null)
        {
            Title = title;
            Content = content;
            Status = status;
            FromUser = fromUser;
            if (id != null)
            {
                Id = id;
            }
            else
            {
                Id = BlogRepo.IdBlog;
            }
        }
        public string GetBlogInfo()
        {
            return $" {CreatedOn.ToString("dd/MM/yyyy")}  {Id} \n {Title} \n {Content} \n {Status}";
        }
    }
}
