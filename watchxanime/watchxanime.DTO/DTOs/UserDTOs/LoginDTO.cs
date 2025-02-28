using System.ComponentModel.DataAnnotations;

namespace watchxanime.DTO.DTOs.UserDTOs
{
    public class LoginDTO
    {

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
