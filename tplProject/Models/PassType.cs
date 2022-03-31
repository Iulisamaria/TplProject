using System;
using System.Collections.Generic;

namespace tplProject.Models
{
    public partial class PassType
    {
        public PassType()
        {
            Pass = new HashSet<Pass>();
        }

        public int Id { get; set; }
        public string TypePass { get; set; }
        public int? Price { get; set; }

        public virtual ICollection<Pass> Pass { get; set; }
    }
}
