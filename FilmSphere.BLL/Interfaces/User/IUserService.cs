using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmSphere.BLL.DTOs.User;
using FilmSphere.Core.Entities.User;

namespace FilmSphere.BLL.Interfaces.User
{
    public interface IUserService
    {
        Task<UserDTO> RegisterUserAsync(UserDTO user);
        Task<UserDTO> GetUserByEmail(string email);
    }
}