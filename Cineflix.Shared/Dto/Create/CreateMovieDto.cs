
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineflixApi.Shared.Dto.Create
{
    public class CreateMovieDto
    {
        [Required]
        public string Title { get; set; }
       
        [Required]
        public int Year { get; set; }
       
        [Required]
        public int GenreId { get; set; }
       
        [Required]
        public int DirectorId { get; set; }
      
        [Required]
        public int Runtime { get; set; }
    }
}
