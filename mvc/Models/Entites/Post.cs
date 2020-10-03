using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models.Entites
{
    public class Post
    {
        public int Postid { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public int CommentId { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
    }
}
