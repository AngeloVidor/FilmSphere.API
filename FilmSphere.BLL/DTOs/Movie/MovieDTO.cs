using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmSphere.BLL.DTOs.Movie
{
    public class MovieDTO
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string MovieDescription { get; set; }
        public int UserId { get; set; }

        /*
        public int UserId { get; set; }
        public UserEntity User { get; set; }*/
    }
}
