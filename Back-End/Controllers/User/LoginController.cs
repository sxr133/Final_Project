using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Sports_Stats_Back_End.Data;

namespace Sports_Stats_Back_End.Controllers.User
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
           try
            {
                var user = _context.Users.FirstOrDefault(u => u.Email == request.Email);
                
                if (user != null)
                {
                    // User exists, but check if the password matches
                    if (user.Password == request.Password)
                    {
                        // Password matches, so user is authenticated
                        return Ok(new { Message = "Login successful" });
                    }
                    else
                    {
                        // Password does not match
                        return Unauthorized(new { Message = "Incorrect password" });
                    }
                }
                else
                {
                    // User does not exist
                    return Unauthorized(new { Message = "User does not exist" });
                }
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine($"Error: {ex.Message}");

                // Return a 500 Internal Server Error with an error message
                return StatusCode(500, new { Message = "An unexpected error occurred" });
            }
        }
    }
}