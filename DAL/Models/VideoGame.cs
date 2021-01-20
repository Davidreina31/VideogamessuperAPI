using System;
namespace DAL.Models
{
    public class VideoGame
    {
        public int VideoGameId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int DeveloperId { get; set; }

        public int PublisherId { get; set; }

        public string JacketUrl { get; set; }

    }
}
