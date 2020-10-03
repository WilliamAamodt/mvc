using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Models.Entites;
using mvc.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models.BlogRepo
{
    public class BlogRepository : IBlogRepository
    {
        private ApplicationDbContext db;
        public BlogRepository (ApplicationDbContext db)
        { this.db = db; }
        public void Delete(BlogViewModel blog)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Blog> GetAll()
        {
            IEnumerable<Blog> blogs = db.Blog;
            return blogs;
        }

        public BlogViewModel GetBlog(int id)
        {
            var b = (from o in db.Blog
                     where o.BlogId == id
                     select new BlogViewModel()
                     {
                         BlogId = o.BlogId,
                         Name = o.Name,
                         PostId = o.PostId,
                     }).FirstOrDefault();
            b.Post = getAllPosts().ToList();
            return b;
        }

        private IEnumerable<Post> getAllPosts()
        {
            IEnumerable<Post> posts = db.Post;
            return posts;
        }

        public BlogViewModel GetBlogs()
        {
            var b = (from o in db.Blog
                     select new BlogViewModel()
                     {
                         BlogId = o.BlogId,
                         Name = o.Name,
                         PostId = o.PostId,
                     }).FirstOrDefault();
            return b;
        }

        public void Save(BlogViewModel blog)
        {
            var b = db.Blog;
            b.AddRange(
                new Blog
                {
                    Name = blog.Name
                });
            db.SaveChanges();
        }
    }
}
