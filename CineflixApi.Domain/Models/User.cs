using System.ComponentModel.DataAnnotations;

namespace CineflixApi.Domain.Models
{
    public class User : Entity
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
