using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmSphere.BLL.DTOs.Movie;
using FilmSphere.BLL.DTOs.Movie.Cast;
using FilmSphere.BLL.Interfaces.Movie;
using Microsoft.AspNetCore.Mvc;

namespace FilmSphere.API.Controllers.Movie
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movie;
        private readonly IMapper _map;

        public MovieController(IMapper map, IMovieService movie)
        {
            _map = map;
            _movie = movie;
        }

        [HttpPost("add-movie")]
        public async Task<IActionResult> AddMovie([FromBody] MovieDTO movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var addedMovie = await _movie.AddMovieAsync(movie);
                return CreatedAtAction(
                    nameof(GetMovieById),
                    new { addedMovie.MovieId },
                    addedMovie
                );
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error adding the movie: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMovieById(int id)
        {
            try
            {
                var movie = await _movie.GetMovieById(id);
                if (movie == null)
                {
                    return NotFound($"No movie found with ID {id}.");
                }
                return Ok(movie);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error fetching the movie: {ex.Message}");
            }
        }

        [HttpPost("add-cast")]
        public async Task<IActionResult> AddCastToMovie(CastDTO cast)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var addedCast = await _movie.AddCastToMovieAsync(cast);
                return CreatedAtAction(
                    nameof(AddCastToMovie),
                    new { castId = addedCast.CastId },
                    addedCast
                );
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    500,
                    new
                    {
                        message = "An error occurred while processing your request",
                        error = ex.Message
                    }
                );
            }
        }
    }
}
