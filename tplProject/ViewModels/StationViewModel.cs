using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tplProject.ViewModels
{
    public class BaseStationViewModel
    {
        public int Id { get; set; }
        public string Nume { get; set; }
    }
    public class AddStationViewModel
    {
        public string Nume { get; set; }
    }
    public class DetailsStationViewModel : BaseStationViewModel
    {

    }
}
