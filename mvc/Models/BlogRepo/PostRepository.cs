using mvc.Data;
using mvc.Models.Entites;
using mvc.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models.BlogRepo
{
    public class PostRepository : IPostRepository
    {
        private ApplicationDbContext db;
        public PostRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Delete(PostViewModel post)
        {
            throw new NotImplementedException();
        }

        public void Edit(PostViewModel post)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAll()
        {
            IEnumerable<Post> posts = db.Post;
            return posts;
        }

        public PostViewModel getPrstViewModel(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(PostViewModel post)
        {
            throw new NotImplementedException();
        }
    }
}
