using System;
using System.Collections.Generic;

namespace tplProject.Models
{
    public partial class Pass
    {
        public Pass()
        {
            Card = new HashSet<Card>();
        }

        public int Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? IdType { get; set; }

        public virtual PassType IdTypeNavigation { get; set; }
        public virtual ICollection<Card> Card { get; set; }
    }
}
