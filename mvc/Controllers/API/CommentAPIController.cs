using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Models.BlogRepo;
using mvc.Models.Entites;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mvc.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentAPIController : ControllerBase
    {

        private ICommentsRepository commentsRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _db;
        private readonly IAuthorizationService _authorizationService;

        public CommentAPIController(ICommentsRepository repository, UserManager<IdentityUser> userManager,
        ApplicationDbContext db = null, IAuthorizationService authorizationService = null)
        {
            this._db = db;
            this._userManager = userManager;
            _authorizationService = authorizationService;
            this.commentsRepository = repository;
        }
        // GET: api/<CommentAPIController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comments = commentsRepository.GetCommentsByPost(id);
            if (comments == null)
            {
                return NotFound();
            }

            return Ok(comments);
        }

        [HttpGet("Create/{id}")]
        
        public IActionResult Create( int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = new Comments
            {
                PostId = id
            };
            
            return Ok(model);
        }

        // GET api/<CommentAPIController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<CommentAPIController>
        [HttpPost]
        public IActionResult Post([FromForm] Comments comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var p = new Comments();
            p.PostId = comment.PostId;
            p.CommentId = comment.CommentId;
            p.Content = comment.Content;

            commentsRepository.SaveComment(p);

            return CreatedAtAction("Post","CommmentApi",new {id = comment.PostId, comment});
        }

        // PUT api/<CommentAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CommentAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
