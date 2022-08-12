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
        
    }
}
