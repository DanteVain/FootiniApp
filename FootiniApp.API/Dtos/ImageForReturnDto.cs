using System;

namespace FootiniApp.API.Dtos
{
    public class ImageForReturnDto
    {
        public int id { get; set; }
        public string Url { get; set; }

        public string  Description { get; set; }

        public DateTime DateAdded { get; set; }

        public string PublicId { get; set; }

        public ImageForReturnDto(){
            DateAdded = DateTime.Now;
        }

    }
}