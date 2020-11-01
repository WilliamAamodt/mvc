
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
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


namespace TDD
{
    [TestClass]
    class BlogControllerTest
    {
        private Mock<IBlogRepository> repoMock;
        private Mock<IPostRepository> repoPMock;
        

        [TestMethod]
        public void IndexReturnsAllBlogs()
        {
            var mng = MockHelpers.MockUserManager<IdentityUser>();
            repoMock = new Mock<IBlogRepository>();
            repoPMock = new Mock<IPostRepository>();
            List<Blog> fakeBlogs = new List<Blog>
            {
                new Blog
                {
                    BlogId = 1, Name = "Kul blogg", Owner = mng.Object.Users.FirstOrDefault()
                }
            };
            repoMock.Setup(x => x.GetAll()).Returns(fakeBlogs);
            var controller = new BlogController(repoMock.Object, repoPMock.Object,mng.Object,null);

            var result = (ViewResult) controller.Index();

            Assert.IsNotNull(result,"hmm");
        }

        [TestMethod]
        public void CreateShouldShowLoginViewFor_Non_AuthorizedUser()
        {
            // Arrange
            var mng = MockHelpers.MockUserManager<IdentityUser>();
            repoPMock = new Mock<IPostRepository>();
            var mockUserManager = MockHelpers.MockUserManager<IdentityUser>();
            var mockRepo = new Mock<IBlogRepository>();
            var controller = new BlogController(repoMock.Object, repoPMock.Object, mng.Object, null);
            controller.ControllerContext = MockHelpers.FakeControllerContext(false);

            // Act
            var result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.ViewName);

        }
    }

    
}
