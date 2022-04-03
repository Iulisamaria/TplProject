using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tplProject.Models;
using tplProject.ViewModels;

namespace tplProject.Models.Repositories
{
    public class BusRepository:IBus
    {
        public readonly tpl_databaseContext _databaseContext;
        public BusRepository(tpl_databaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
    }
    //public async Task<BaseBusViewModel> Add(Bus bus)
    //{

    //}
}
