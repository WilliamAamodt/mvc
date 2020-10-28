using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mvc.Data;
using mvc.Models.BlogRepo;
using mvc.Models.Entites;

namespace mvc.Controllers
{
    public class CommentController : Controller
    {
        private ICommentsRepository commentsRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _db;
        private readonly IAuthorizationService _authorizationService;

        public CommentController(ICommentsRepository commentsRepository,
            ApplicationDbContext db = null, UserManager<IdentityUser> userManager = null, IAuthorizationService authorizationService = null)
        {
            this.commentsRepository = commentsRepository;
            _db = db;
            _userManager = userManager;
            _authorizationService = authorizationService;
        }

        public ActionResult Comments(int id)
        {
            return View(commentsRepository.GetCommentsByPost(id));

        }
        // GET: CommentController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CommentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateComment(int postId)
        {
            //var post = postRepository.Get(postId);

            var model = new Comments
            {
                PostId = postId
            };
            return PartialView("testCommentCreate", model);
        }

        // POST: CommentController/Create
        [HttpPost]
        public void CreateComment([Bind("Content,PostId")] Comments comment)
        {
            if (ModelState.IsValid)
            {
                var p = new Comments();
                p.PostId = comment.PostId;
                p.CommentId = comment.CommentId;
                p.Content = comment.Content;
                commentsRepository.SaveComment(p);
                //return RedirectToAction("Post", "Post", new { id = p.PostId });
            }

            //return View(comment);
        }

        // GET: CommentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CommentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CommentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CommentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
