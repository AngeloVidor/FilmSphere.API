using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FilmSphere.Core.Entities.User;

namespace FilmSphere.Core.Entities.Movie
{
    public class MovieEntity
    {
        [Key]
        public int MovieId { get; set; }
        public string OriginalTitle { get; set; }
        public string ReleaseDate { get; set; }
        public int RunTime { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string TrailerUrl { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
