using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmSphere.BLL.DTOs.Movie;

namespace FilmSphere.BLL.Interfaces.Movie
{
    public interface IMovieService
    {
        Task<MovieDTO> AddMovieAsync(MovieDTO movie);
        Task<MovieDTO> GetMovieById(int id);
        Task<MovieDTO> ValidateMovieAsync(MovieDTO movie);
    }
}
