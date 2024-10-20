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

        public int MovieId { get; set; }
        public MovieEntity Movie { get; set; }
    }
}
