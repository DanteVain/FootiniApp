using System.ComponentModel.DataAnnotations;

namespace FootiniApp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Forename { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 4, ErrorMessage = "you must specify a password between 4 and 16 characters")]
        public string Password { get; set; }

    }
}