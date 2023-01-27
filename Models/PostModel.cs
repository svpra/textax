using System;

namespace Tectex.Models {
    public class Post {
        public string Content { get; set; }
        public string AuthorId { get; set; }
        public User Author { get; set; }
    }
}
