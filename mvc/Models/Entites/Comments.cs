using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models.Entites
{
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }

        public string Content { get; set; }
    }
}
