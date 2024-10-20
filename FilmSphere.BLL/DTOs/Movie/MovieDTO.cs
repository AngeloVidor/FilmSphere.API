using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmSphere.BLL.DTOs.Movie.Cast;

namespace FilmSphere.BLL.DTOs.Movie
{
    public class MovieDTO
    {
        public int MovieId { get; set; }
        public string OriginalTitle { get; set; }
        public string Description { get; set; }
        public string ReleaseDate { get; set; }
        public int RunTime { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string TrailerUrl { get; set; }
        
        //public ICollection<CastDTO> Cast { get; set; }

        public int UserId { get; set; }
    }
}
