using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmSphere.Core.Entities.Movie;

namespace FilmSphere.BLL.DTOs.Movie.Cast
{
    public class CastDTO
    {
        public int CastId { get; set; }
        public string ActorName { get; set; }
        public string CharacterName { get; set; }

        public int MovieId { get; set; }
    }
}
