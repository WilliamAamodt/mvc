using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Models.Entites;
using mvc.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace mvc.Models.BlogRepo
{
    public class BlogRepository : IBlogRepository
    {
        private ApplicationDbContext db;
        private UserManager<IdentityUser> manager;

        public BlogRepository(UserManager<IdentityUser> userManager, ApplicationDbContext db)
        {
            this.db = db;
            this.manager = userManager;
        }
        public void Delete(BlogViewModel blog)
        {
            throw new NotImplementedException();
        }

        public void DeleteBlog(int id)
        {
            Blog blog = db.Blog.Find(id);
            db.Remove(blog);
            db.SaveChanges();
        }

        public Blog Get(int id)
        {
            Blog blog = db.Blog.Find(id);
            return blog;
        }


        public void Edit(Blog blog)
        {
            db.Update(blog);
            db.SaveChanges();
        }

        public IEnumerable<Blog> GetAll()
        {
            IEnumerable<Blog> blogs = db.Blog.Include(o => o.Owner);
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
                         Owner = o.Owner,
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
        [Authorize]
        public async Task Save(BlogViewModel blog, IPrincipal principal)
        {
            var currentUser = await manager.FindByNameAsync(principal.Identity.Name);
            var b = db.Blog;
            b.AddRange(
                new Blog
                {
                    Name = blog.Name,
                    Owner = currentUser,
                    
                });
            db.SaveChanges();
        }

        public async Task<bool> Access(int blogId, IPrincipal principal)
        {
            var userBlog = db.Blog.Find(blogId);
            var currentUser = await manager.FindByNameAsync(principal.Identity.Name);

            if (userBlog.Owner == currentUser)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [Authorize]
        public async Task subscribe(int blogId, IPrincipal principal)
        {
            var currentUser = await manager.FindByNameAsync(principal.Identity.Name);
            var currentUserName = currentUser.Id;

            var p = new SubscribedBlogs
            {
                blogId = blogId,
                userId = currentUserName,
            };

            await db.SubscribedBlogses.AddAsync(p);
            await db.SaveChangesAsync();

        }
    }
}
