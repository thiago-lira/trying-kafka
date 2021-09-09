using System.ComponentModel.DataAnnotations;

namespace Movies.DTOs
{
    public class MovieDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Genre { get; set; }
    }
}
