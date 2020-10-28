using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace mvc.Models.ViewModels
{
    public class CommentViewModel
    {
        public string Content { get; set; }

        public int PostId { get; set; }

        public virtual IdentityUser Owner { get; set; }
    }
}
