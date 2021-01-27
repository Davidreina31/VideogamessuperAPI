using System;
using System.Collections.Generic;

namespace LOCAL.Models
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

        public Developer Developer { get; set; }

        public Publisher Publisher { get; set; }

        public IEnumerable<Plateform> plateforms { get; set; }

    }
}
