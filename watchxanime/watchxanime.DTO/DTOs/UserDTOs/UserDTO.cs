using System.ComponentModel.DataAnnotations;

namespace watchxanime.DTO.DTOs.UserDTOs
{
    public class UserDTO
    {
        public string? FullName { get; set; }
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public DateTime Registration { get; set; }
    }
}
