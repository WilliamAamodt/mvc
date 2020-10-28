using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.SignalR;
using mvc.Authorization;
using mvc.Data;
using mvc.Models;
using mvc.Models.BlogRepo;
using mvc.Models.Entites;
using mvc.Models.ViewModels;

namespace mvc.Controllers
{
    public class PostController : Controller
    {
        
        private IPostRepository postRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _db;
        private readonly IAuthorizationService _authorizationService;


        public PostController(IPostRepository postRepository,
            ApplicationDbContext db = null, UserManager<IdentityUser> userManager = null, IAuthorizationService authorizationService = null)
        {
            this.postRepository = postRepository;
            _db = db;
            _userManager = userManager;
            _authorizationService = authorizationService;
        }
        // GET: PostController
        //public ActionResult Post()
        //{
        //    return View(postRepository.GetAll());
        //}
        [Route("Post/Posts/{id}")]
        [HttpGet]
        public async Task<ActionResult> Posts(int id)
        {
            ViewBag.ID = id;
            BlogViewModel userBlog = postRepository.GetBlogVM(id);
            string blogOwner = userBlog.Owner.Id;
           // var currentUser = await _userManager.FindByNameAsync(iPrincipal.Identity.Name);
           var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            TempData["CurrentUser"] = userId;
            TempData["BlogOwner"] = blogOwner;
            return View(postRepository.GetBlogPost(id));
        }

        [Route("Post/Post/{PostId}")]
        [HttpGet]
        public ActionResult Post(int id,int postId)
        {
            
            PostViewModel p = postRepository.getPostViewModel(id, postId);

            return View(p);

        }

        //[Route("Post/Post/{PostId}")]
        [HttpGet]
        public ActionResult Post(int id)
        {
            
            PostViewModel p = postRepository.getPostViewModel(id);

            return View(p);

        }

        //// GET: PostController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: PostController/Create

        [HttpGet]
        public async Task<ActionResult> Create(int id)
        {
            var blog = postRepository.GetBlog(id);
            BlogViewModel userBlog = postRepository.GetBlogVM(id);
            var isAuthorized = await _authorizationService.AuthorizeAsync(User, userBlog, UserOperations.Create);

            if (!isAuthorized.Succeeded)
            {
                return RedirectToAction("Posts", "Post", new { id = blog.BlogId});
            }
            var model = new PostViewModel
            {
                BlogId = blog.BlogId
            };

            return View(model);
        }

        //// POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name,Content,BlogId")] PostViewModel post)
        {
            if (ModelState.IsValid)
            {
                var p = new PostViewModel();
                p.Name = post.Name;
                p.Content = post.Content;
                p.BlogId = post.BlogId;
                postRepository.Save(p);
                return RedirectToAction("Posts","Post",new{id = p.BlogId});
            }

            return View(post);
        }

        [HttpGet]
        public ActionResult CreateComment(int postId)
        {
            var post = postRepository.Get(postId);

            var model = new Comments
            {
                PostId = post.PostId
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateComment([Bind("Content,PostId")] Comments comment)
        {
            if (ModelState.IsValid)
            {
                var p = new Comments();
                p.PostId = comment.PostId;
                p.CommentId = comment.CommentId;
                p.Content = comment.Content;
                postRepository.SaveComment(p);
                return RedirectToAction("Post", "Post", new {id = p.PostId});
            }

            return View(comment);
        }

        [HttpGet]
        public ActionResult DeleteComment([Bind("CommentId,Content,PostId")] int idComment, int id)
        {
            postRepository.DeleteComment(idComment,id);


            return RedirectToAction("Post", "Post", new{id});
        }
        
        [HttpGet]
        public ActionResult DeletePost([Bind("Name, Content, BlogId")] int postId, int blogId)
        {
            postRepository.DeletePost(postId, blogId);

            int redirectId = blogId;

            return RedirectToAction("Posts", "Post", new {id = redirectId});
        }

        [HttpGet]
        public ActionResult EditPost(int id)
        {
            var post = postRepository.Get(id);

            return View(post);
        }

        [HttpPost]
        public ActionResult EditPost([Bind("PostId,Name,Content,BlogId")] Post post, int blogId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    postRepository.EditPost(post);
                    TempData["message"] = string.Format("{0} har blitt endret", post.Name);
                    return RedirectToAction("Posts", "Post", new { id = blogId });
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

        //// GET: PostController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: PostController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: PostController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: PostController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
