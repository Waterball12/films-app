using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmsApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmsApp.Infrastructure
{
    public class FilmContext : DbContext
    {
        public FilmContext(DbContextOptions<FilmContext> options) : base(options)
        {
        }


        public DbSet<Film> Film { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<FilmWatched> FilmWatched { get; set; }
    }
}
