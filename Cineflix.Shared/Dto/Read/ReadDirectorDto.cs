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
        public string Name { get; set; }
        public List<ReadMovieDto> Movies { get; set; }
    }
}
