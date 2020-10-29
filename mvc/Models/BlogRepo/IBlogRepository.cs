using mvc.Models.Entites;
using mvc.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace mvc.Models
{
    public interface IBlogRepository
    {
        IEnumerable<Blog> GetAll();

        Task Save(BlogViewModel blog, IPrincipal principal);

        BlogViewModel GetBlog(int id);

        BlogViewModel GetBlogs();

        void Delete(BlogViewModel blog);
        void DeleteBlog(int id);
        Blog Get(int id);

        public void Edit(Blog blog);

        Task subscribe(int blogId, IPrincipal principal);
    }
}
