using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineflixApi.Shared.Dto.Update
{
    public class UpdateGenreDto
    {
        [Required]
        public string Name { get; set; }
    }
}
