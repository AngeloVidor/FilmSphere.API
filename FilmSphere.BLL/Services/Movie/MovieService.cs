using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmSphere.BLL.DTOs.Movie;
using FilmSphere.BLL.DTOs.Movie.Cast;
using FilmSphere.BLL.Interfaces.Movie;
using FilmSphere.Core.Entities.Movie;
using FilmSphere.DAL.Interfaces.Movie;
using FluentValidation;

namespace FilmSphere.BLL.Services.Movie
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<MovieDTO> _movieValidator;
        private readonly IValidator<CastDTO> _castValidator;

        public MovieService(
            IMovieRepository movieRepository,
            IMapper mapper,
            IValidator<MovieDTO> movieValidator,
            IValidator<CastDTO> castValidator
        )
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
            _movieValidator = movieValidator;
            _castValidator = castValidator;
        }

        public async Task<CastDTO> AddCastToMovieAsync(CastDTO cast)
        {
            var validationResult = await _castValidator.ValidateAsync(cast);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(failure =>
                    $"Property {failure.PropertyName} failed validation. Error was: {failure.ErrorMessage}"
                );
                throw new ValidationException(string.Join("; ", errors));
            }

            var movie = await _movieRepository.GetMovieById(cast.MovieId);
            if (movie == null)
            {
                throw new ArgumentException($"Movie with ID: {cast.MovieId} not found");
            }
            if (cast == null)
            {
                throw new ArgumentException("Cast cannot be null");
            }
            var castEntity = _mapper.Map<CastEntity>(cast);

            var addedCast = await _movieRepository.AddCastToMovieAsync(castEntity);

            var castDtoResponse = _mapper.Map<CastDTO>(addedCast);
            return castDtoResponse;
        }

        public async Task<MovieDTO> AddMovieAsync(MovieDTO movie)
        {
            var validationResult = await _movieValidator.ValidateAsync(movie);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(failure =>
                    $"Property {failure.PropertyName} failed validation. Error was: {failure.ErrorMessage}"
                );
                throw new ValidationException(string.Join("; ", errors));
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
