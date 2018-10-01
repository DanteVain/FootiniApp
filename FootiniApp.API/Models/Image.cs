using System;

namespace FootiniApp.API.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string PublicId { get; set; } 
        public string Url { get; set; }
        public DateTime Created { get; set; }
        public string AssociatedText { get; set; }
        public User User { get; set; }
        
    }
}