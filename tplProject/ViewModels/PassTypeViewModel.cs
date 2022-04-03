using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tplProject.ViewModels
{
    public class BasePassTypeViewModel
    {
        public int Id { get; set; }
        public string TypePass { get; set; }
        public int? Price { get; set; }

    }
    public class AddPassTypeViewModel
    {
     
        public string TypePass { get; set; }
        public int? Price { get; set; }

    }
    public class PassTypeDetailsViewModel:BasePassTypeViewModel
    {

    }
}
