using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmSphere.Core.Entities.Movie
{
    public class CastEntity
    {
        [Key]
        public int CastId { get; set; }
        public string ActorName { get; set; }
        public string CharacterName { get; set; }

        public int MovieId { get; set; }
        public MovieEntity Movie { get; set; }
    }
}
