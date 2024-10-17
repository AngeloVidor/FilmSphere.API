using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmSphere.Core.Entities.User;

namespace FilmSphere.DAL.Interfaces.User
{
    public interface IUserRepository
    {
        Task<UserEntity>RegisterUserAsync(UserEntity user);
        Task<UserEntity> GetUserByEmail(string email);
    }
}