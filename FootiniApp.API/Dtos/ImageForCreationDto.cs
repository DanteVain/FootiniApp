using System;
using Microsoft.AspNetCore.Http;

namespace FootiniApp.API.Dtos
{
    public class ImageForCreationDto
    {
        public string Url { get; set; }
        public IFormFile File { get; set; }
        public string AssociatedText { get; set; }
        public DateTime DateAdded { get; set; }
        public string PublicId { get; set; }

        public ImageForCreationDto(){
            DateAdded = DateTime.Now;
        }

    }
}
