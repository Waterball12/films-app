using System.ComponentModel.DataAnnotations;

namespace FilmsApp.Domain.Models
{
    public class FilmWatched
    {
        [Key]
        public int Id { get; set; }

        public int FilmId { get; set; }

        public int UserId { get; set; }
    }
}
