/*using Microsoft.AspNetCore.Mvc;
using Sports_Stats_Back_End.Models;
using System;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sports_Stats_Back_End.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SignupController : ControllerBase
    {
        private readonly YourDbContext _context;

        public SignupController(YourDbContext context)
        {
            _context = context;
        }
        
        [HttpPost]
        public async Task<IActionResult> Signup(UserSignupModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if the username or email is already taken
            if (UsernameOrEmailExists(model.Username, model.Email))
            {
                return Conflict("Username or email already exists");
            }

            // Create a new user entity
            var newUser = new UserSignupModel
            {
                Username = model.Username,
                Email = model.Email,
                // Hash the password before storing it in the database
                // You should use a secure hashing algorithm like bcrypt
                // Do NOT store passwords in plaintext
                PasswordHash = HashPassword(model.Password)
                // You may also want to add other properties like FirstName, LastName, etc.
            };

            // Add the new user to the database
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            // Return a success response
            return Ok("Signup successful");
        }

        // Helper method to check if username or email already exists in the database
        private bool UsernameOrEmailExists(string username, string email)
        {
            return _context.Users.Any(u => u.Username == username || u.Email == email);
        }

        // Dummy method to hash the password (replace with your actual hashing implementation)
        private string HashPassword(string password)
        {
            // This is a dummy implementation, DO NOT use in production
            // You should use a secure hashing algorithm like bcrypt
            return password;
        }
    }
}
*/
