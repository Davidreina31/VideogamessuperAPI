using System;
using System.Collections.Generic;

namespace LOCAL.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public bool Admin { get; set; }

        public DateTime? DeletedDate { get; set; }

        //public List<int>? VideoGame { get; set; } = new List<int>();

        public IEnumerable<VideoGame> videoGamesList { get; set; }

    }
}
