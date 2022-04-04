using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tplProject.Models;
using tplProject.ViewModels;

namespace tplProject.Models.Repositories
{
    public class RouteRepository:IRoute
    {
        private readonly tpl_databaseContext _DatabaseContext;
        public RouteRepository(tpl_databaseContext DatabaseContext)
        {
            _DatabaseContext = DatabaseContext;
        }

        public void AddPassType(AddRouteViewModel pass)
        {

            Route passType = new Route()
            {
                
            };
            _DatabaseContext.Route.Add(passType);
            _DatabaseContext.SaveChanges();

        }
    }
}
