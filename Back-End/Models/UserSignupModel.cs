using System.ComponentModel.DataAnnotations;

namespace Sports_Stats_Back_End.Models
{
    public class UserSignupModel
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, ErrorMessage = "Username must be between 3 and 50 characters", MinimumLength = 3)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "Password must be at least 6 characters", MinimumLength = 6)]
        public string Password { get; set; }

        // You can add additional properties here as needed, such as FirstName, LastName, etc.
    }
}
