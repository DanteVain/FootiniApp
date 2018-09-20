using System.ComponentModel.DataAnnotations;

namespace FootiniApp.API.Dtos
{
    public class UserForLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; } 
    }
}