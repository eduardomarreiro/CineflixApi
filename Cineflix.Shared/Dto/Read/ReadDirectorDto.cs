using CineflixApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineflixApi.Shared.Dto.Read
{
    public class ReadDirectorDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public List<ReadMovieDto> Movies { get; set; }
    }
}
