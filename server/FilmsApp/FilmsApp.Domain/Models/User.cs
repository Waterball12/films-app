using System.ComponentModel.DataAnnotations;

namespace FilmsApp.Domain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
