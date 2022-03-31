using System;
using System.Collections.Generic;

namespace tplProject.Models
{
    public partial class Card
    {
        public Card()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public int? Routes { get; set; }
        public int? PassId { get; set; }

        public virtual Pass Pass { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
