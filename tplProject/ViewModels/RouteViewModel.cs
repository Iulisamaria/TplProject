using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tplProject.Models;

namespace tplProject.ViewModels
{
    public class BaseRouteViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
    public class AddRouteViewModel
    {
        public string Name { get; set; }
        public List<int> Path { get; set; }
    }
    public class UpdateRouteViewModel
    {
        public List<int> Path { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
    }

    public  class RouteDetailsViewModel:BaseRouteViewModel
    {
        public List<Stations> Path { get; set; }
        public string Start { get; set; }
        public string Destination { get; set; }
    }

}
