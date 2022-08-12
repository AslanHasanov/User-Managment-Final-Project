using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagmentFinalProject.DataBase.Repo;

namespace UserManagmentFinalProject.DataBase.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public User(string firstName, string lastName, string email, string password, int? id = null)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            

        }
        public virtual string GetInfo()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
