using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmSphere.Core.Entities.Movie;
using FilmSphere.DAL.Context;
using FilmSphere.DAL.Interfaces.Movie;

namespace FilmSphere.DAL.Repositories.Movie
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MovieEntity> AddMovieAsync(MovieEntity movie)
        {
            await _context.Movie.AddAsync(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<MovieEntity> GetMovieById(int id)
        {
            return await _context.Movie.FindAsync(id);
        }
    }
}
