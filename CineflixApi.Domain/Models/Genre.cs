using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CineflixApi.Domain.Models
{
    public class Genre : Entity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public List<Movie> Movies { get; set; }
    }
}
