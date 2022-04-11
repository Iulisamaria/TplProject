using System.ComponentModel.DataAnnotations;

namespace tplProject.Models.Users
{
    public class RegisterModel
    {
        [Required]
        public long  Cnp { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
}