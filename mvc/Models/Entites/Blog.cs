using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models.Entites
{
    public class Blog
    {
        public int BlogId { get; set; }

        public string Name { get; set; }

        public int PostId { get; set; }
        public virtual ICollection<Post> Post { get; set; }

        public virtual IdentityUser Owner { get; set; }
    }
}
