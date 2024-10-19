using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmSphere.BLL.DTOs.Movie;
using FilmSphere.BLL.Interfaces.Movie;
using FilmSphere.Core.Entities.Movie;
using FilmSphere.DAL.Interfaces.Movie;

namespace FilmSphere.BLL.Services.Movie
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<MovieDTO> AddMovieAsync(MovieDTO movie)
        {
            if (
                string.IsNullOrWhiteSpace(movie.MovieName)
                || string.IsNullOrWhiteSpace(movie.MovieDescription)
            )
            {
                throw new ArgumentException("Name and Description cannot be empty.");
            }

            if (movie.UserId <= 0)
            {
                throw new ArgumentException("User cannot be null");
            }

            var movieEntity = _mapper.Map<MovieEntity>(movie);

            var addedMovie = await _movieRepository.AddMovieAsync(movieEntity);
            return _mapper.Map<MovieDTO>(addedMovie);
        }

        public async Task<MovieDTO> GetMovieById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid movie ID.");
            }

            var movieEntity = await _movieRepository.GetMovieById(id);
            if (movieEntity == null)
            {
                return null;
            }
            return _mapper.Map<MovieDTO>(movieEntity);
        }
    }
}
