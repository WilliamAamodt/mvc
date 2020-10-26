using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models.Entites
{
    public class Post
    {
        public int PostId { get; set; }

        public int BlogId { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }
    }
}
