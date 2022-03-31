using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tplProject.Models;

namespace tplProject.Models.Repositories
{
    public class PassRepository:IPass
    {
        public readonly tpl_databaseContext _databaseContext;
        public PassRepository(tpl_databaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
    }
}
