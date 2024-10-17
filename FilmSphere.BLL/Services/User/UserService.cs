using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmSphere.BLL.DTOs.User;
using FilmSphere.BLL.Interfaces.User;
using FilmSphere.Core.Entities.User;
using FilmSphere.DAL.Interfaces.User;

namespace FilmSphere.BLL.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetUserByEmail(string email)
        {
            var userEntity = await _userRepository.GetUserByEmail(email);

            if (userEntity == null)
            {
                throw new Exception($"No user found with email: {email}");
            }

            return _mapper.Map<UserDTO>(userEntity);
        }

        public async Task<UserDTO> RegisterUserAsync(UserDTO userDto)
        {
            if (string.IsNullOrEmpty(userDto.Username) || string.IsNullOrEmpty(userDto.Email))
            {
                throw new ArgumentException("Username and Email cannot be null or empty.");
            }

            var userEntity = _mapper.Map<UserEntity>(userDto);

            try
            {
                var createdUser = await _userRepository.RegisterUserAsync(userEntity);

                return _mapper.Map<UserDTO>(createdUser);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while registering the user.", ex);
            }
        }
    }
}
