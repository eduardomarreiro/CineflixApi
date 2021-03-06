using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineflixApi.Shared.Dto.Read
{
    public class ReadMovieDto
    {
        public string Title { get; set; }
       
        public int Year { get; set; }
       
        public string Genre { get; set; }
       
        public string Director { get; set; }
      
        public int Runtime { get; set; }
    }
}
