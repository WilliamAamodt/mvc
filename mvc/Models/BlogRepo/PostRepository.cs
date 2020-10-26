using mvc.Data;
using mvc.Models.Entites;
using mvc.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace mvc.Models.BlogRepo
{
    public class PostRepository : IPostRepository
    {
        private ApplicationDbContext db;
        private UserManager<IdentityUser> manager;
        public PostRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Blog> GetBlogs(int id)
        {
            throw new NotImplementedException();
        }


        public void Delete(PostViewModel post)
        {
            throw new NotImplementedException();
        }

        public void Edit(PostViewModel post)
        {
            throw new NotImplementedException();
        }

        public void EditPost(Post post)
        {
            db.Update(post);
            db.SaveChanges();
        }

        public IEnumerable<Post> GetAll()
        {
            IEnumerable<Post> posts = db.Post;
            return posts;
        }

        public Post Get(int id)
        {
            Post p = (from o in db.Post
                where o.PostId == id
                select o).FirstOrDefault();
            return p;
        }


        public IEnumerable<Post> GetBlogPost(int id)
        {
            IQueryable<Post> p = (from o in db.Post
                where o.BlogId == id
                select new Post()
                {
                    PostId = o.PostId,
                    BlogId = o.BlogId,

                    Name = o.Name,
                    Content = o.Content,
                });
            return p;
        }

        public PostViewModel getPostViewModel(int id)
        {
            var p = (from o in db.Post
                where o.BlogId == id
                select new PostViewModel()
                {
                    PostId = o.PostId,
                    BlogId = o.BlogId,
                    Name = o.Name,
                    Content = o.Content,
                }).FirstOrDefault();
            p.Comments = GetAllCommentsToPost(p.PostId).ToList();

            return p;
        }

        public PostViewModel getPostViewModel(int id, int postid)
        {
            var p = (from o in db.Post
                where o.PostId == postid
                select new PostViewModel()
                {
                    PostId = o.PostId,
                    BlogId = o.BlogId,
                    Name = o.Name,
                    Content = o.Content,
                }).FirstOrDefault();
            p.Comments = GetAllCommentsToPost(postid).ToList();

            return p;
        }

        private IEnumerable<Comments> GetAllCommentsToPost(int id)
        {
            IQueryable<Comments> p = (from o in db.Comments
                where o.PostId == id
                select new Comments()
                {
                    CommentId = o.CommentId,
                    Content = o.Content,
                    PostId = o.PostId,
                });
            return p;
        }

        public void Save(PostViewModel post)
        {
           // var currentUser = await manager.FindByNameAsync(principal.Identity.Name);

            var p = db.Post;

            p.AddRange(
                new Post
                {
                    Name = post.Name,
                    Content = post.Content,
                    BlogId = post.BlogId,

                });
            db.SaveChanges();
        }

        public void SaveComment(Comments comments)
        {
            var p = db.Comments;

            p.AddRange(
                new Comments
                {
                    CommentId = comments.CommentId,
                    Content = comments.Content,
                    PostId = comments.PostId,
                });
            db.SaveChanges();
        }

        public void DeleteComment(int idComment, int id)
        {
            Comments comment = db.Comments.Find(idComment);
            db.Comments.Remove(comment);
            db.SaveChanges();

        }

        public void DeletePost(int postId, int blogId)
        {
            Post post = db.Post.Find(postId);
            db.Remove(post);
            db.SaveChanges();
        }

        public Blog GetBlog(int id)
        {
            var p = (from o in db.Blog
                where o.BlogId == id
                select new Blog()
                {
                    BlogId = o.BlogId,
                    Name = o.Name,
                    Owner = o.Owner,
                    PostId = o.PostId,
                }).FirstOrDefault();
            return p;
        }
    }
}
