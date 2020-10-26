using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using mvc.Models.Entites;

namespace mvc.Models.ViewModels
{
    public class PostViewModel
    {
        [Key]
        public int PostId { get; set; }

        public int BlogId { get; set; }


        public string Name { get; set; }

        public string Content { get; set; }

        public List<Comments> Comments { get; set; }
    }
}