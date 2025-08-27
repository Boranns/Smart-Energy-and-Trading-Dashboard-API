using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartEnergyAPI.Services;
using SmartEnergyAPI.DTOs;

namespace SmartEnergyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService service) => _service = service;

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto dto)
        {
            var user = await _service.RegisterAsync(dto.Name, dto.Email, dto.Password, dto.Role);
            if (user == null) return BadRequest("Email already exists.");
            return Ok(new { user.Id, user.Name, user.Email, user.Role });
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginDto dto)
        {
            var token = await _service.LoginAsync(dto.Email, dto.Password);
            if (token == null) return Unauthorized("Invalid credentials.");
            return Ok(new { token });
        }

        [HttpGet("profile")]
        [Authorize]
        public IActionResult Profile()
        {
            var name = User.Identity?.Name;
            var role = User.Claims.FirstOrDefault(c => c.Type == "role")?.Value;
            return Ok(new { Message = $"Welcome {name}, your role is {role}" });
        }
    }
}

