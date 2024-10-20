using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace FilmSphere.BLL.DTOs.Movie.Cast.Validator.Movie
{
    public class MovieValidator : AbstractValidator<MovieDTO>
    {
        public MovieValidator()
        {
            RuleFor(movie => movie.MovieId)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Movie ID cannot be negative.");

            RuleFor(movie => movie.OriginalTitle)
                .NotEmpty()
                .WithMessage("Original Title cannot be null or empty");

            RuleFor(movie => movie.Description)
                .NotEmpty()
                .WithMessage("Description cannot be null or empty.");

            RuleFor(movie => movie.ReleaseDate)
                .Must(BeAValidDate)
                .WithMessage("The release date is not in a valid format.")
                .Must(NotBeInFuture)
                .WithMessage("The release date cannot be in the future");

            RuleFor(movie => movie.Language).NotEmpty().WithMessage("Language cannot be empty.");

            RuleFor(movie => movie.TrailerUrl)
                .NotEmpty()
                .WithMessage("Trailer URL cannot be empty.");

            RuleFor(movie => movie.Country).NotEmpty().WithMessage("Country cannot be empty.");

            RuleFor(movie => movie.RunTime)
                .GreaterThan(0)
                .WithMessage("Runtime must be greater than 0.")
                .LessThanOrEqualTo(600)
                .WithMessage("Runtime cannot exceed 600 minutes (10 hours).");
        }

        private bool BeAValidDate(string releaseDate)
        {
            return DateTime.TryParse(releaseDate, out _);
        }

        private bool NotBeInFuture(string releaseDate)
        {
            if (DateTime.TryParse(releaseDate, out DateTime parsedDate))
            {
                return parsedDate <= DateTime.Now;
            }
            return true;
        }
    }
}
