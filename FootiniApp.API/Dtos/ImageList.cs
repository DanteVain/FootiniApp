using FootiniApp.API.Models;

namespace FootiniApp.API.Dtos
{
    public class ImageList
    {
        public int Id { get; set; }
        public string PublicId { get; set; } 
        public string Url { get; set; }
        public string AssociatedText { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}