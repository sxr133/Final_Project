using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Sports_Stats_Back_End.Data;
using Sports_Stats_Back_End.Models;

namespace Sports_Stats_Back_End.Controllers.User
{
    [ApiController]
    [Route("[controller]")]
    public class SignupController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SignupController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Signup([FromBody] UserSignup request)
        {
            try
            {
                Console.WriteLine("Hello1");
                // Validate request data
                if (string.IsNullOrEmpty(request.FirstName) || string.IsNullOrEmpty(request.LastName) || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
                {
                    return BadRequest(new { Message = "All fields are required" });
                }
                Console.WriteLine("Hello2");
                // Check if user with email already exists
                var existingUser = _context.Users.FirstOrDefault(u => u.Email == request.Email);
                if (existingUser != null)
                {
                    return Conflict(new { Message = "User with this email already exists" });
                }
                Console.WriteLine("Hello3");
                // Create new user
                var newUserSignup = new UserSignup
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    StreetAddress1 = request.StreetAddress1,
                    StreetAddress2 = request.StreetAddress2,
                    City = request.City,
                    State_Prov = request.State_Prov,
                    Zip_Post_Cd = request.Zip_Post_Cd,
                    Country = request.Country,
                    Email = request.Email,
                    Password = request.Password
                    // You might want to hash the password before storing it
                };

                _context.UserSignups.Add(newUserSignup);
                _context.SaveChanges();

                // Create a new user instance
                var newUser = new Sports_Stats_Back_End.Models.User
                {
                    Email = request.Email,
                    Password = request.Password,
                    // You can add other properties here
                };

                // Add the user to the Users table
                _context.Users.Add(newUser);

                // Save changes to the database
                _context.SaveChanges();

                Console.WriteLine("The Request contains:", request);
                return Ok(new { Message = "User registered successfully" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, new { Message = "An unexpected error occurred" });
            }
        }
    }
}