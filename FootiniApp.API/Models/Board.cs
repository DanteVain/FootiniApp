using System.Collections.Generic;
using System;

namespace FootiniApp.API.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Image> Images { get; set; }
        public DateTime Created { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        // specify Board type, 2 cell, 4 cell or 6 cell
        public int BoardType {get; set; }
    }
}