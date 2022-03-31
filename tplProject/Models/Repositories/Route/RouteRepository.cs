using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tplProject.Models;

namespace tplProject.Models.Repositories.Route
{
    public class RouteRepository
    {
        private readonly tpl_databaseContext _DatabaseContext;
        public RouteRepository(tpl_databaseContext DatabaseContext)
        {
            _DatabaseContext = DatabaseContext;
        }
    }
}
