using System.ComponentModel.DataAnnotations;

namespace Sports_Stats_Back_End.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
