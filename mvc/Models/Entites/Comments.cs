using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace mvc.Models.Entites
{
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }

        public string Content { get; set; }

        public int PostId { get; set; }

        public virtual IdentityUser Owner { get; set; }
    }
}
