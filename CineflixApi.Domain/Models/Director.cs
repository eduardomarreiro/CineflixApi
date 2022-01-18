using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineflixApi.Domain.Models
{
    public class Director : Entity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public List<Movie> Movies { get; set; }

    }
}
