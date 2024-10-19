using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmSphere.BLL.DTOs.Movie;
using FilmSphere.BLL.DTOs.User;
using FilmSphere.Core.Entities.Movie;
using FilmSphere.Core.Entities.User;

namespace FilmSphere.BLL.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserEntity, UserDTO>().ForMember(dest => dest.Password, opt => opt.Ignore());
            CreateMap<RegisterDTO, UserDTO>();
            CreateMap<UserDTO, UserEntity>();

            CreateMap<UserDTO, LoginDTO>();
            CreateMap<LoginDTO, UserDTO>();

            CreateMap<MovieEntity, MovieDTO>();
            CreateMap<MovieDTO, MovieEntity>();
        }
    }
}
