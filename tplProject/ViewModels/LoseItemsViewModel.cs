using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tplProject.ViewModels
{
    public class LoseItemsViewModel
    {
        
    }
    public class AddLostItemsViewModel
    {
        public int? NrCrt { get; set; }
        public string Info { get; set; }
    }
    public class BaseLostItemsViewModel
    {
        public int Id { get; set; }
        public int? NrCrt { get; set; }
        public string Info { get; set; }
    }
   public class LostItemsDetailsViewModel : BaseLostItemsViewModel
    {

    }
}
