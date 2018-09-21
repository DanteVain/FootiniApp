using System;
using System.Collections.Generic;

namespace FootiniApp.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime Created { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<Board> Boards { get; set; }

    }
}