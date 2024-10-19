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
            await ValidateMovieAsync(movie);

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

        public async Task<MovieDTO> ValidateMovieAsync(MovieDTO movieDto)
        {
            if (movieDto.MovieId < 0)
            {
                throw new ArgumentException("Movie ID cannot be negative.");
            }
            if (string.IsNullOrWhiteSpace(movieDto.OriginalTitle))
            {
                throw new ArgumentException("Original Title cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(movieDto.Description))
            {
                throw new ArgumentException("Description cannot be null or empty.");
            }
            if (!DateTime.TryParse(movieDto.ReleaseDate, out DateTime releaseDate))
            {
                throw new ArgumentException("The release date is not in a valid format.");
            }

            if (releaseDate > DateTime.Now)
            {
                throw new ArgumentException("The release date cannot be in the future");
            }
            if (string.IsNullOrWhiteSpace(movieDto.Language))
            {
                throw new ArgumentException("Language cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(movieDto.TrailerUrl))
            {
                throw new ArgumentException("Trailer url cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(movieDto.Country))
            {
                throw new ArgumentException("Country cannot be empty");
            }
            if (movieDto.RunTime <= 0)
            {
                throw new ArgumentException("Runtine must be greater than 0");
            }
            if (movieDto.RunTime > 600)
            {
                throw new ArgumentException("RunTime cannot exceed 600 minutes (10 hours).");
            }
            return movieDto;
        }
    }
}
