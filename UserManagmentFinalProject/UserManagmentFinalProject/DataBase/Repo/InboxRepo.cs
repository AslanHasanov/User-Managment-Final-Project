using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagmentFinalProject.DataBase.Models;
using UserManagmentFinalProject.DataBase.Repo.Common;

namespace UserManagmentFinalProject.DataBase.Repo
{
    public class InboxRepo : Repository<Inbox, int>
    {

        static InboxRepo()
        {
            DbContext.Add(new Inbox("Salam dunya", UserRepo.GetUserByEmail("eshqin@gmail.com")));
        }
    }
}
