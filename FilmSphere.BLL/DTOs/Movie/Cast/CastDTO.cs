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
        public int MovieId { get; set; }
        
        public string ActorName1 { get; set; }
        public string CharacterName1 { get; set; }
        public string ActorName2 { get; set; }
        public string CharacterName2 { get; set; }
        public string ActorName3 { get; set; }
        public string CharacterName3 { get; set; }
        public string ActorName4 { get; set; }
        public string CharacterName4 { get; set; }
        public string ActorName5 { get; set; }
        public string CharacterName5 { get; set; }
    }
}
