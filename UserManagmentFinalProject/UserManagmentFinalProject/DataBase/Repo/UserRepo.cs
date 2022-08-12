using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagmentFinalProject.DataBase.Repo
{
    public class UserRepo
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
