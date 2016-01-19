using System;
using System.Collections.Generic;
using System.Text;

namespace fanTASticWindowsPhone.Models
{
    public class Post
    {
        public int id { get; set; }
        public int authorId { get; set; }
        public string title { get; set; }
        public int reblog { get; set; }
        public string text { get; set; }
        public int tags { get; set; }
        public string attachment { get; set; }
        public DateTime date { get; set; }

    }
}
