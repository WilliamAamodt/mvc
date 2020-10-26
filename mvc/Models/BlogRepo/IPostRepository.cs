using mvc.Models.Entites;
using mvc.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models.BlogRepo
{
    public interface IPostRepository
    {

        IEnumerable<Post> GetAll();

        void Save(PostViewModel post);

        PostViewModel getPostViewModel(int id);

        PostViewModel getPostViewModel(int id, int postId);

        BlogViewModel GetBlogVM(int id);

        IEnumerable<Post> GetBlogPost(int id);

        IEnumerable<Blog> GetBlogs(int id);

        Blog GetBlog(int id);

        void Delete(PostViewModel post);

        void Edit(PostViewModel post);

        void EditPost(Post post);

        Post Get(int id);

        void SaveComment(Comments comments);

        void DeleteComment(int idComment, int id);
        void DeletePost( int postId, int blogId);
    }
}
