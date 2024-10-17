using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmSphere.BLL.DTOs.User;
using FilmSphere.BLL.Interfaces.User;
using FilmSphere.Core.Entities.User;
using FilmSphere.DAL.Interfaces.User;

namespace FilmSphere.BLL.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDTO> GetUserByEmail(string email)
        {
            var userEntity = await _userRepository.GetUserByEmail(email);

            if (userEntity == null)
            {
                throw new Exception($"No user found with email: {email}");
            }
            return new UserDTO
            {
                UserId = userEntity.UserId,
                Username = userEntity.Username,
                Email = userEntity.Email,
                Password = userEntity.Password
            };
        }

        public async Task<UserDTO> RegisterUserAsync(UserDTO userDto)
        {
            if (string.IsNullOrEmpty(userDto.Username) || string.IsNullOrEmpty(userDto.Email))
            {
                throw new ArgumentException("Username and Email cannot be null or empty.");
            }

            var userEntity = new UserEntity
            {
                Username = userDto.Username,
                Email = userDto.Email,
                Password = userDto.Password
            };

            try
            {
                var createdUser = await _userRepository.RegisterUserAsync(userEntity);

                return new UserDTO
                {
                    UserId = createdUser.UserId,
                    Username = createdUser.Username,
                    Email = createdUser.Email,
                    Password = createdUser.Password
                };
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while registering the user.", ex);
            }
        }
    }
}
