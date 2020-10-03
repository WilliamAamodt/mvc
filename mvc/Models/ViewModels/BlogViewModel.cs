using mvc.Models.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models.ViewModels
{
    public class BlogViewModel
    {
        [Key]
        public int BlogId { get; set; }

        public int PostId { get; set; }

        public string Name { get; set; }

        public List<Post> Post { get; set; }
    }
}
