using CineflixApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineflixApi.Shared.Dto.Create
{
    public class CreateDirectorDto
    {
        [Required]
        public string Name { get; set; }
    }
}
