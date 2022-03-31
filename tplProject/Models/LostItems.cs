using System;
using System.Collections.Generic;

namespace tplProject.Models
{
    public partial class LostItems
    {
        public int Id { get; set; }
        public int? NrCrt { get; set; }
        public string Info { get; set; }
    }
}
