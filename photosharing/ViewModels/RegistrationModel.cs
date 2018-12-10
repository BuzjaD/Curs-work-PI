using System.ComponentModel.DataAnnotations;

namespace photosharing.ViewModels
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Email required")]
        public string Email { get; set; }

        public string Username { get; set; }

        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Uncorrect password")]
        public string ConfirmPassword { get; set; }
    }
}
