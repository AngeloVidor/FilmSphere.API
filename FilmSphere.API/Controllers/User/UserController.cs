using System.Threading.Tasks;
using FilmSphere.BLL.DTOs.User;
using FilmSphere.BLL.Interfaces;
using FilmSphere.BLL.Interfaces.User;
using FilmSphere.BLL.Interfaces.User.Auth;
using Microsoft.AspNetCore.Mvc;

namespace FilmSphere.API.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public UserController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterDTO registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdUser = await _userService.RegisterUserAsync(
                    new UserDTO
                    {
                        Username = registerDto.Username,
                        Email = registerDto.Email,
                        Password = registerDto.Password
                    }
                );
                return CreatedAtAction(
                    nameof(GetUserByEmail),
                    new { email = createdUser.Email },
                    createdUser
                );
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _authService.ValidateUser(
                new UserDTO
                {
                    Email = loginDto.Email,
                    Password = loginDto.Password 
                }
            );

            if (user == null)
            {
                return Unauthorized(new { Message = "Invalid credentials" });
            }

            var token = await _authService.GenerateToken(user);
            return Ok(new { Token = token });
        }

        [HttpGet("getByEmail/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmail(email);
            if (user == null)
            {
                return NotFound(new { Message = "User not found" });
            }
            return Ok(user);
        }
    }
}
