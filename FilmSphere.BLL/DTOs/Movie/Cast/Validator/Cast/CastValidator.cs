using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace FilmSphere.BLL.DTOs.Movie.Cast.Validator
{
    public class CastValidator : AbstractValidator<CastDTO>
    {
        public CastValidator()
        {
            RuleFor(cast => cast.ActorName1)
                .NotNull()
                .NotEmpty()
                .WithMessage("Actor Name 1 must not be null or empty");

            RuleFor(cast => cast.CharacterName1)
                .NotNull()
                .NotEmpty()
                .WithMessage("Character Name 1 must not be null or empty");

            RuleFor(cast => cast.ActorName2)
                .NotNull()
                .NotEmpty()
                .WithMessage("Actor Name 2 must not be null or empty");

            RuleFor(cast => cast.CharacterName2)
                .NotNull()
                .NotEmpty()
                .WithMessage("Character Name 2 must not be null or empty");

            RuleFor(cast => cast.ActorName3)
                .NotNull()
                .NotEmpty()
                .WithMessage("Actor Name 3 must not be null or empty");

            RuleFor(cast => cast.CharacterName3)
                .NotNull()
                .NotEmpty()
                .WithMessage("Character Name 3 must not be null or empty");

            RuleFor(cast => cast.ActorName4)
                .NotNull()
                .NotEmpty()
                .WithMessage("Actor Name 4 must not be null or empty");

            RuleFor(cast => cast.CharacterName4)
                .NotNull()
                .NotEmpty()
                .WithMessage("Character Name 4 must not be null or empty");

            RuleFor(cast => cast.ActorName5)
                .NotNull()
                .NotEmpty()
                .WithMessage("Actor Name 5 must not be null or empty");

            RuleFor(cast => cast.CharacterName5)
                .NotNull()
                .NotEmpty()
                .WithMessage("Character Name 5 must not be null or empty");
        }
    }
}
