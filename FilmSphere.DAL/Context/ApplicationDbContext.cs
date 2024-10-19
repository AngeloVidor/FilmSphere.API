using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmSphere.Core.Entities.Movie;
using FilmSphere.Core.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace FilmSphere.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<MovieEntity> Movie { get; set; }
        public DbSet<CastEntity> Cast { get; set; }
    }
}
