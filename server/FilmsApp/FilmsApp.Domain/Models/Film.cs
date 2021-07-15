using System;
using System.ComponentModel.DataAnnotations;

namespace FilmsApp.Domain.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public float Rating { get; set; }
        
        public DateTime Release { get; set; }
    }
}
