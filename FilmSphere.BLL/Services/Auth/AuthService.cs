using AutoMapper;
using FilmSphere.BLL.DTOs.User;
using FilmSphere.BLL.Interfaces;
using FilmSphere.BLL.Interfaces.User.Auth;
using FilmSphere.DAL.Interfaces.User;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FilmSphere.BLL.Services.User.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AuthService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> ValidateUser(UserDTO userDto)
        {
            var userEntity = await _userRepository.GetUserByEmail(userDto.Email);
            if (userEntity == null || userEntity.Password != userDto.Password) 
            {
                return null;
            }
            return _mapper.Map<UserDTO>(userEntity);
        }

        public async Task<string> GenerateToken(UserDTO user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("G8p$7mZ4vQ9@hN1fTqK$3gR9fM#8xA6s"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "http://localhost:5266",
                audience: "http://localhost:5266",
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
