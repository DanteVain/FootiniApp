using System.ComponentModel.DataAnnotations;

namespace FootiniApp.API.Dtos
{
    public class UserForLoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; } 
    }
}