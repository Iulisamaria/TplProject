﻿
using System.Threading.Tasks;
using tplProject.ViewModels;

namespace tplProject.Models.Repositories
{
    public interface IRoute
    {
        Task AddRoute(AddRouteViewModel pass);
        Task<RouteDetailsViewModel> Get(int id);
        Task Delete(int id);
        Task Update(UpdateRouteViewModel route);
    }
}
