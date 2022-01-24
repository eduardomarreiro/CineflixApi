using System.ComponentModel.DataAnnotations;

namespace CineflixApi.Shared.Dto.Create
{
    public class CreateDirectorDto
    {
        [Required]
        public string Name { get; set; }
    }
}
