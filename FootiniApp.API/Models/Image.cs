using System;

namespace FootiniApp.API.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }   
        public string link { get; set; }
        public DateTime Created { get; set; }
        public string AssociatedText { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}