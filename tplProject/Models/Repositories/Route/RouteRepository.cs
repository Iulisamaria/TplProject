using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tplProject.Models;
using tplProject.ViewModels;

namespace tplProject.Models.Repositories
{
    public class RouteRepository : IRoute
    {
        private readonly tpl_databaseContext _DatabaseContext;
        public RouteRepository(tpl_databaseContext DatabaseContext)
        {
            _DatabaseContext = DatabaseContext;
        }

        public async Task AddRoute(AddRouteViewModel route)
        {

            Route addRoute = new Route()
            {
                Name = route.Name,
                Path = string.Join(",", route.Path.ToArray())
            };
            _DatabaseContext.Route.Add(addRoute);
            _DatabaseContext.SaveChanges();
        }
        public async Task Update(UpdateRouteViewModel route)
        {
            var oldRoute = await _DatabaseContext.Route.FindAsync(route.Id);
            if(oldRoute == null)
            {
                throw new Exception();
            }
            oldRoute.Name = route.Name;
            oldRoute.Path = string.Join(",", route.Path.ToArray());
            _DatabaseContext.Route.Update(oldRoute);
            _DatabaseContext.SaveChanges();
        }
        public async Task<List<Route>> GetAll()
        {
            var route =  _DatabaseContext.Route.ToList();
            if (route == null)
            {
                throw new Exception();
            }
            foreach()
           
            return route;
        }
        public async Task<RouteDetailsViewModel> Get(int id)
        {
            var route = await _DatabaseContext.Route.FindAsync(id);
            if (route == null)
            {
                throw new Exception();
            }
            var list = route.Path.Split(",");
            List<int> path = new List<int>();
            foreach (var item in list)
            {
                path.Add(Convert.ToInt32(item));
            }
            List<Stations> stations = new List<Stations>();
            foreach (var item in path)
            {
                var station = await _DatabaseContext.Stations.FindAsync(item);
                stations.Add(station);
            }
            RouteDetailsViewModel routeDetails = new RouteDetailsViewModel()
            {
                Name = route.Name,
                Path = stations
            };
            return routeDetails;
        }
        public async Task Delete(int id)
        {
            var route = await _DatabaseContext.Route.FindAsync(id);   
             _DatabaseContext.Route.Remove(route);
        }
    }
}
