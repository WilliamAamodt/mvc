using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using mvc.Controllers;
using mvc.Data;
using mvc.Models;
using mvc.Models.BlogRepo;
using mvc.Models.Entites;
using ProductUnitTest;

namespace UnitTest
{
    [TestClass]
    class PostControllerMethod
    {
        private Mock<IPostRepository> repoPmock;
        private ApplicationDbContext db;

        [TestMethod]
        public void IndexReturnsAllPosts()
        {
            var mng = MockHelpers.MockUserManager<IdentityUser>();
            repoPmock = new Mock<IPostRepository>();
            List<Post> fakeBlogs = new List<Post>
            {
                new Post
                {
                    BlogId = 1, Name = "Kul blogg"
                }
            };
            repoPmock.Setup(x => x.GetAll()).Returns(fakeBlogs);
            var controller = new PostController(repoPmock.Object,null,mng.Object,null);

            var result = controller.Posts(1);

            Assert.IsNotNull(result, "hmm");
        }

    }
}
