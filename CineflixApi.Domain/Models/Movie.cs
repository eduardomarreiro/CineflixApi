using System.ComponentModel.DataAnnotations;

namespace CineflixApi.Domain.Models
{
    public class Movie : Entity
    {
        [Required]
        public string Title { get; set; }
        
        [Required]
        public int Year { get; set; }
       
        [Required]
        public int Runtime { get; set; }
       
        [Required]
        
        public Director Director { get; set; }
        
        [Required]
        public int DirectorId { get; set; }
        
        [Required]
        public Genre Genre { get; set; }
        public int GenreId{ get; set; }
    }

}
