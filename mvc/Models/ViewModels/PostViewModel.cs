using mvc.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models.ViewModels
{
    public class PostViewModel
    {

    public int PostId { get; set; }

    public int BlogId { get; set; }

    public int CommentsId { get; set; }

    public string Name { get; set; }

    public string Content { get; set; }

    public List<Comments> Comments { get; set; }
    }
}
