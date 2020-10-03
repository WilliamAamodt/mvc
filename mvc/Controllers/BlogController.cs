using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using mvc.Models.BlogRepo;
using mvc.Models.ViewModels;

namespace mvc.Controllers
{
    public class BlogController : Controller
    {

        private IBlogRepository blogRepository;
        private IPostRepository postRepository;

        public BlogController(IBlogRepository blogRepository, IPostRepository postRepository)
        {
            this.blogRepository = blogRepository;
            this.postRepository = postRepository;
        }

       
        public IActionResult Index()
        {
            return View(blogRepository.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            var blog = blogRepository.GetBlogs();
            return View(blog);

        }
        [HttpPost]
        public ActionResult Create([Bind("Name,ProductId")]
        BlogViewModel blog)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    blogRepository.Save(blog);
                    TempData["message"] = string.Format("{0} har blitt opprettet", blog.Name);
                    return RedirectToAction("Index");
                }
                {
                    return View();
                }
            }

            catch (Exception e)
            {
                return View();
            }
            
        }

        public ActionResult BlogView(int blogId)
        {
            var blog = blogRepository.GetBlog(blogId);

            var model = new BlogViewModel
            {
                BlogId = blog.BlogId
        };
            return View(model);
        }
    }
}
