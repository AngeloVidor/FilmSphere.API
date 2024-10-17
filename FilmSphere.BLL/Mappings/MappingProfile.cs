using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmSphere.BLL.DTOs.User;
using FilmSphere.Core.Entities.User;

namespace FilmSphere.BLL.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserEntity, UserDTO>().ForMember(dest => dest.Password, opt => opt.Ignore());

            CreateMap<UserDTO, UserEntity>();
        }
    }
}
