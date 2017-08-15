using System.ComponentModel.DataAnnotations;

namespace TheWall.Models
{
    public class RegisterViewModel : BaseEntity
    {
        [Required]
        [MinLength(2)]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }
    
        [Required]
        [MinLength(2)]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password {get; set;}

        [Compare("Password", ErrorMessage = "Pass and Confrim must match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string Confirm {get; set; }
    }
}

