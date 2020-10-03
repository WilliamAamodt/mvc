using mvc.Models.Entites;
using mvc.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models
{
    public interface IBlogRepository
    {
        IEnumerable<Blog> GetAll();

        void Save(BlogViewModel blog);

        BlogViewModel GetBlog(int id);

        BlogViewModel GetBlogs();

        void Delete(BlogViewModel blog);
    }
}
