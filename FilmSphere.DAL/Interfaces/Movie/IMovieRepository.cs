using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmSphere.Core.Entities.Movie;

namespace FilmSphere.DAL.Interfaces.Movie
{
    public interface IMovieRepository
    {
        Task<MovieEntity> AddMovieAsync(MovieEntity movie);
        Task<MovieEntity> GetMovieById(int id);
    }
}
