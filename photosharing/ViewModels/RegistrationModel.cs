using System.ComponentModel.DataAnnotations;

namespace photosharing.ViewModels
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Email required")]
        [EmailAddress(ErrorMessage = "Uncorrect email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Confirm required")]
        [Compare("Password", ErrorMessage = "Uncorrect password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
