using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
using mvc.Models.ViewModels;
using ProductUnitTest;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private Mock<IBlogRepository> repoMock;
        private Mock<IPostRepository> repoPMock;
        private Mock<ControllerContext> mock;


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
            var controller = new BlogController(repoMock.Object, repoPMock.Object, mng.Object, null);

            var result = (ViewResult) controller.Index();

            Assert.IsNotNull(result, "hmm");
        }

        [TestMethod]
        public void CreateShouldShowLoginViewFor_Non_AuthorizedUser()
        {
            // Arrange
            ApplicationDbContext db;
            IAuthorizationService test = null;
            repoPMock = new Mock<IPostRepository>();
            var mockUserManager = MockHelpers.MockUserManager<IdentityUser>();
            var mockRepo = new Mock<IBlogRepository>();
            var controller = new BlogController(mockRepo.Object, repoPMock.Object, mockUserManager.Object, null);
            controller.ControllerContext = MockHelpers.FakeControllerContext(false);

            //// Act
            var result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.ViewName);

        }

        [TestMethod]
        public void IndexReturnsNotNullResult()
        {
            //Arrange
            repoPMock = new Mock<IPostRepository>();
            var mockUserManager = MockHelpers.MockUserManager<IdentityUser>();
            var mockRepo = new Mock<IBlogRepository>();
            List<Blog> fakeBlogs = new List<Blog>
            {
                new Blog
                {
                    BlogId = 1, Name = "Kul blogg", Owner = mockUserManager.Object.Users.FirstOrDefault()
                }
            };
            var controller = new BlogController(mockRepo.Object, repoPMock.Object, mockUserManager.Object, null);

            //Act
            var result = (ViewResult) controller.Index();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateReturnNotNullResult()
        {
            repoPMock = new Mock<IPostRepository>();
            var mockUserManager = MockHelpers.MockUserManager<IdentityUser>();
            var mockRepo = new Mock<IBlogRepository>();
            BlogViewModel bvm = new BlogViewModel
            {
                BlogId = 1, Name = "hello"
            };

            var controller = new BlogController(mockRepo.Object, repoPMock.Object, mockUserManager.Object, null);

            var result = (ViewResult) controller.Create(bvm);
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void CreateNullModel()
        {
            repoPMock = new Mock<IPostRepository>();
            var mockUserManager = MockHelpers.MockUserManager<IdentityUser>();
            var mockRepo = new Mock<IBlogRepository>();
            BlogViewModel bvm = new BlogViewModel
            {
                BlogId = 1,
                Name = "hello"
            };

            var controller = new BlogController(mockRepo.Object, repoPMock.Object, mockUserManager.Object, null);
            var badmodel = new BlogViewModel() {Name = ""};
            var validcntx = new ValidationContext(badmodel, null);
            var validResults = new List<ValidationResult>();
            Validator.TryValidateObject(badmodel, validcntx, validResults, true);

            foreach (var v in validResults)
            {
                controller.ModelState.AddModelError(v.MemberNames.First(),
                    v.ErrorMessage);
            }

            var result = controller.Create(badmodel) as ViewResult;

            Assert.IsNotNull(result);

            Assert.AreEqual(null, result.ViewName);
        }

        [TestMethod]
        public void EditDontReturnNull()
        {
            repoPMock = new Mock<IPostRepository>();
            var mockUserManager = MockHelpers.MockUserManager<IdentityUser>();
            var mockRepo = new Mock<IBlogRepository>();
            BlogViewModel bvm = new BlogViewModel
            {
                BlogId = 1,
                Name = "hello"
            };

            var controller = new BlogController(mockRepo.Object, repoPMock.Object, mockUserManager.Object, null);

            var result = controller.EditBlog(bvm.BlogId);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditDontReturnNullPost()
        {
            Blog blog = new Blog() {Name = "name"};
            repoPMock = new Mock<IPostRepository>();
            IAuthorizationService test = null;
            var mockUserManager = MockHelpers.MockUserManager<IdentityUser>();
            var mockRepo = new Mock<IBlogRepository>();
            BlogViewModel bvm = new BlogViewModel
            {
                BlogId = 1,
                Name = "hello"
            };

            var controller = new BlogController(mockRepo.Object, repoPMock.Object, mockUserManager.Object, test);
            var result = (ViewResult) controller.EditBlog(blog);
            var resyk = (AuthorizationResult) AuthorizationResult.Failed();
            Assert.IsNotNull(result);
            AuthorizationResult.Success();
            Assert.IsNotNull(result);

            Assert.AreEqual(null, result.ViewName);
        }

        [TestMethod]
        public void BlogViewTest()
        {
            repoPMock = new Mock<IPostRepository>();
            var mockUserManager = MockHelpers.MockUserManager<IdentityUser>();
            var mockRepo = new Mock<IBlogRepository>();
            BlogViewModel bvm = new BlogViewModel
            {
                BlogId = 1,
                Name = "hello"
            };

            var controller = new BlogController(mockRepo.Object, repoPMock.Object, mockUserManager.Object, null);

            var result = (RedirectToActionResult) controller.BlogView(bvm.BlogId);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SubscribeToBlogNotNull()
        {
            repoPMock = new Mock<IPostRepository>();
            var mockUserManager = MockHelpers.MockUserManager<IdentityUser>();
            var mockRepo = new Mock<IBlogRepository>();
            BlogViewModel bvm = new BlogViewModel
            {
                BlogId = 1,
                Name = "hello",
                Owner = mockUserManager.Object.Users.FirstOrDefault()
            };

            var controller = new BlogController(mockRepo.Object, repoPMock.Object, mockUserManager.Object, null);

            var result = controller.SubscribeToBlog(bvm.BlogId);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void userPageReturnView()
        {
            repoPMock = new Mock<IPostRepository>();
            var mockUserManager = MockHelpers.MockUserManager<IdentityUser>();
            var mockRepo = new Mock<IBlogRepository>();

            var controller = new BlogController(mockRepo.Object, repoPMock.Object, mockUserManager.Object, null);
            var result = controller.UserPage();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task DeleteReturnNotNullResult()
        {
            mock = new Mock<ControllerContext>();
            repoPMock = new Mock<IPostRepository>();
            var mockUserManager = MockHelpers.MockUserManager<IdentityUser>();
            var mockRepo = new Mock<IBlogRepository>();
            BlogViewModel bvm = new BlogViewModel
            {
                BlogId = 1,
                Name = "hello"
            };
            BlogController controller = new BlogController(mockRepo.Object, repoPMock.Object, mockUserManager.Object, null);
            var result = (ActionResult) await controller.DeleteBlogAsync(bvm.BlogId);
            Assert.IsNotNull(result);
        }
    }
}
