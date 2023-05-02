using System.ComponentModel.DataAnnotations;

namespace UnitofworkandRepo.Models
{
    public class SignUp
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("confirmPassword")]
        public string confirmPassword { get; set; }
    }
}
