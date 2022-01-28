using System.ComponentModel.DataAnnotations;

namespace CineflixApi.Shared.Dto.Create
{
    public class CreateGenreDto
    {
        [Required]
        public string Name { get; set; }
    }
}
