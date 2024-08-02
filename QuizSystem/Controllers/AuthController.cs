using Microsoft.AspNetCore.Mvc;
using QuizSystem.Services.UserManagement;
using QuizSystem.ViewModels.User;

namespace QuizSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IUserService _service) : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterViewModel user)
        {
            if (_service.Register(user))
                return Ok(new { message = "Registration successful" });

            return BadRequest(new { message = "Username already exists" });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginViewModel user)
        {
            var authenticatedUser = _service.Authenticate(user.Username, user.Password);
            if (authenticatedUser is null)
                return Unauthorized(new { message = "Invalid credentials" });

            return Ok(new { message = "Login successful" });
        }
    }
}
