using System;
using System.Collections.Generic;
using System.Text;

namespace fanTASticWindowsPhone.Models
{
    public class Post
    {
        public string id { get; set; }
        public string authorId { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public DateTime date { get; set; }

    }
}
