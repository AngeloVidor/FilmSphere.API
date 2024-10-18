using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmSphere.BLL.DTOs.User;

namespace FilmSphere.BLL.Interfaces.User.Auth
{
    public interface IAuthService
    {
        Task<string> GenerateToken(UserDTO user);
        Task<UserDTO> ValidateUser(UserDTO user);
    }
}
