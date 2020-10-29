using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;
using mvc.Authorization;
using mvc.Models;
using mvc.Models.BlogRepo;
using mvc.Models.ViewModels;
using mvc.Controllers;
using mvc.Data;
using mvc.Models.Entites;

namespace mvc.Controllers
{
    public class BlogController : Controller
    {

        private IBlogRepository blogRepository;
        private IPostRepository postRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _db;
        private readonly IAuthorizationService _authorizationService;

        public BlogController(IBlogRepository blogRepository, IPostRepository postRepository,
            ApplicationDbContext db = null, UserManager<IdentityUser> userManager = null, IAuthorizationService authorizationService = null)
        {
            this.blogRepository = blogRepository;
            this.postRepository = postRepository;
            _db = db;
            _userManager = userManager;
            _authorizationService = authorizationService;

        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(blogRepository.GetAll());
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            var blog = blogRepository.GetBlogs();
            return View(blog);

        }

        [HttpPost]
        [Authorize]
        public ActionResult Create([Bind("Name,ProductId")] BlogViewModel blog)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    blogRepository.Save(blog, User).Wait();
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
        [AllowAnonymous]
        [HttpGet]
        public ActionResult BlogView(int id)
        {
            return RedirectToAction("Posts", "Post", new {id});
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> DeleteBlogAsync(int id)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            BlogViewModel blog = blogRepository.GetBlog(id);
            var isAuthorized = await _authorizationService.AuthorizeAsync(User, blog, UserOperations.Delete);

            if (!isAuthorized.Succeeded)
            {
                TempData["message"] = "Ingen adgang!";
                return RedirectToAction("Index");
            }

            blogRepository.DeleteBlog(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> EditBlog(int id)
        {
            var blog = blogRepository.Get(id);

            BlogViewModel userBlog = blogRepository.GetBlog(id);
            var isAuthorized = await _authorizationService.AuthorizeAsync(User, userBlog, UserOperations.Update);

            if (!isAuthorized.Succeeded)
            {
                TempData["message"] = "Ingen adgang!";
                return RedirectToAction("Index");
            }

            return await Task.Run(() => View(blog));
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditBlog([Bind("Name,BlogId")] Blog blog)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    blogRepository.Edit(blog);
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

        [Authorize]
        public async Task<ActionResult> SubscribeToBlog(int id)
        {

           await blogRepository.subscribe(id, User);

            return RedirectToAction("Index");
        }
    }
}
