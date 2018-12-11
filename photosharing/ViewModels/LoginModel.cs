using System.ComponentModel.DataAnnotations;

namespace photosharing.ViewModels
{
    public class LoginModel
    {
        [EmailAddress(ErrorMessage = "Uncorrect email")]
        [Required(ErrorMessage = "Email required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
