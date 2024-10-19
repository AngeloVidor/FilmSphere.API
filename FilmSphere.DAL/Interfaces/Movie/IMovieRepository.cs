using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmSphere.Core.Entities.Movie;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace FilmSphere.DAL.Interfaces.Movie
{
    public interface IMovieRepository
    {
        Task<MovieEntity> AddMovieAsync(MovieEntity movie);
        Task<MovieEntity> GetMovieById(int id);
        Task<CastEntity> AddCastToMovieAsync(CastEntity cast);
    }
}
