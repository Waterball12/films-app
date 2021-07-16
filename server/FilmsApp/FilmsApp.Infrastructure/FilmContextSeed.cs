using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmsApp.Domain.Models;

namespace FilmsApp.Infrastructure
{
    public class FilmContextSeed
    {

        public async Task SeedAsync(FilmContext context)
        {
            if (!context.User.Any())
            {
                await context.User.AddRangeAsync(GetUsers());

                await context.SaveChangesAsync();
            }
            if (!context.Film.Any())
            {
                await context.Film.AddRangeAsync(GetFilms());
                await context.SaveChangesAsync();
            }
        }


        private IEnumerable<User> GetUsers()
        {
            return new List<User>()
            {
                new User() {Username = "example", Password = BCrypt.Net.BCrypt.HashPassword("pass")},
                new User() {Username = "example1", Password = BCrypt.Net.BCrypt.HashPassword("pass1")}
            };
        }

        private IEnumerable<Film> GetFilms()
        {
            return new List<Film>()
            {
                new Film(){Name = "Hitman's Wife's Bodyguard", Rating = 8.1f, Release = DateTime.UtcNow},
                new Film(){Name = "The Tomorrow War", Rating = 8.1f, Release = DateTime.UtcNow},
                new Film(){Name = "Peter Rabbit 2: The Runaway", Rating = 8.1f, Release = DateTime.UtcNow},
                new Film(){Name = "The Angry Birds Movie 2", Rating = 8.1f, Release = DateTime.UtcNow},
                new Film(){Name = "Alita: Battle Angel", Rating = 8.1f, Release = DateTime.UtcNow},
                new Film(){Name = "Sonic the Hedgehog", Rating = 8.1f, Release = DateTime.UtcNow}
            };
        }
    }
}
