using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tplProject.Models;

namespace tplProject.Models.Repositories.User
{
    public class UserRepository:IUser
    {
        private readonly tpl_databaseContext _DatabaseContext;
        public UserRepository(tpl_databaseContext DatabaseContext)
        {
            _DatabaseContext = DatabaseContext;
        }
    }
}
