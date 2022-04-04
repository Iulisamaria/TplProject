using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public string Path { get; set; }
    }

}
