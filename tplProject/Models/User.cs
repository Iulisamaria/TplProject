using System;
using System.Collections.Generic;

namespace tplProject.Models
{
    public partial class User
    {
        public decimal Cnp { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int? IdCard { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public virtual Card IdCardNavigation { get; set; }
    }
}
