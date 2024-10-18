using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IAuthService authService, IMapper mapper)
        {
            _userService = userService;
            _authService = authService;
            _mapper = mapper;
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
                var userDto = _mapper.Map<UserDTO>(registerDto);
                var createdUser = await _userService.RegisterUserAsync(userDto);

                var userResponse = _mapper.Map<UserDTO>(createdUser);

                return CreatedAtAction(
                    nameof(GetUserByEmail),
                    new { email = createdUser.Email },
                    userResponse
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

            var dto = _mapper.Map<UserDTO>(loginDto);

            var userEntity = await _authService.ValidateUser(dto);

            if (userEntity == null)
            {
                return Unauthorized(new { Message = "Invalid credentials" });
            }

            var userDto = _mapper.Map<UserDTO>(userEntity);

            var token = await _authService.GenerateToken(userEntity);

            return Ok(new { User = userDto, Token = token });
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
