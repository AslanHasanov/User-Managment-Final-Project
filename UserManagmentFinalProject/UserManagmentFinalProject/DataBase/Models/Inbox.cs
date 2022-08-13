using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagmentFinalProject.DataBase.Models.Common;
using UserManagmentFinalProject.DataBase.Repo;

namespace UserManagmentFinalProject.DataBase.Models
{
    public class Inbox : Entity<int>
    {
        public string Notification { get; set; }

        public User User { get; set; }

        public Inbox(string notification, User user, int? id = null)
        {
            Notification = notification;
            User = user;
            if (id != null)
            {
                Id = id.Value;
            }
            else
            {
                Id = UserRepo.IdCounter;
            }
        }
        public override string ToString()
        {
            return $"{Notification}";
        }
    }
}
