using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagmentFinalProject.DataBase.Models
{
    public class Admin:User
    {
        public Admin(string firstName, string lastName, string email, string password, int? id = null)
            : base(firstName, lastName, email, password, id) { }

        public override string GetInfo()
        {
            return $" {FirstName} {LastName} ";
        }
    }
}
