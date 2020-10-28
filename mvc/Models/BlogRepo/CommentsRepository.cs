using mvc.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using mvc.Data;

namespace mvc.Models.BlogRepo
{
    public class CommentsRepository : ICommentsRepository
    {

        private ApplicationDbContext db;
        private UserManager<IdentityUser> manager;

        public CommentsRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Comments> GetCommentsByPost(int id)
        {
            IQueryable<Comments> p = (from o in db.Comments
                where o.PostId == id
                select new Comments()
                {
                    CommentId =  o.CommentId,
                    Content = o.Content,
                    PostId = o.PostId,
                });
            return p;
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

        public void Delete(Comments comment)
        {
            throw new NotImplementedException();
        }

        public void Edit(Comments comment)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comments> getAll()
        {
            throw new NotImplementedException();
        }

        public Comments GetComment(int id)
        {
            throw new NotImplementedException();
        }

        public Comments GetComments()
        {
            throw new NotImplementedException();
        }

        public void Save(Comments comment)
        {
            throw new NotImplementedException();
        }
    }
}
