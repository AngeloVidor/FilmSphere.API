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
        public string MovieName { get; set; }
        public string MovieDescription { get; set; }

        public int UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
