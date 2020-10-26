using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using mvc.Controllers;
using mvc.Data;
using mvc.Models;
using mvc.Models.Entites;
using mvc.Models.ViewModels;

namespace ProductUnitTest
{

    //[TestClass]
    //public class ProductControllerTest
    //{
    //    private Mock<IProductRepository> repository;

    //    [TestMethod]
    //    public void IndexReturnsAllProducts()
    //    {
    //        // Arrange
    //        repository = new Mock<IProductRepository>();
    //        List<Product> fakeproducts = new List<Product>
    //        {
    //            new Product {Name = "Hammer", Price = 121.50m, CategoryId = 13},
    //            new Product {Name = "Vinkelsliper", Price = 1520.00m, CategoryId = 13},
    //            new Product {Name = "Melk", Price = 14.50m, CategoryId = 12},
    //            new Product {Name = "Kjøttkaker", Price = 32.00m, CategoryId = 12},
    //            new Product {Name = "Brød", Price = 25.50m, CategoryId = 12}
    //        };
    //        repository.Setup(x => x.GetAll()).Returns(fakeproducts);
    //        var controller = new ProductController(repository.Object);
    //        // Act
    //        var result = (ViewResult) controller.Index();
    //        // Assert
    //        CollectionAssert.AllItemsAreInstancesOfType((ICollection) result.ViewData.Model,
    //            typeof(Product));
    //        Assert.IsNotNull(result, "View Result is null");
    //        var products = result.ViewData.Model as List<Product>;
    //        Assert.AreEqual(5, products.Count, "Got wrong number of products");
    //    }

    //    [TestMethod]
    //    public void SaveIsCalledWhenProductIsCreated()
    //    {
    //        // Arrange
    //        repository = new Mock<IProductRepository>();
    //        repository.Setup(x => x.Save(It.IsAny<ProductsEditViewModel>()));
    //        var controller = new ProductController(repository.Object);
    //        // Act
    //        var result = controller.Create(new ProductsEditViewModel());
    //        // Assert
    //        repository.VerifyAll();

    //        // test på at save er kalt et bestemt antall ganger
    //        repository.Verify(x => x.Save(It.IsAny<ProductsEditViewModel>()), Times.Exactly(1));
    //    }
    }

    //[TestClass]
    //public class ProductControllerTest2
    //{
    //    private Mock<IProductRepository> repository;

    //    [TestMethod]
    //    public void IndexReturnsNotNullResult()
    //    {
    //        // Arrange
    //        ApplicationDbContext db;
    //        repository = new Mock<IProductRepository>();
    //        List<Product> fakeproducts = new List<Product>
    //        {
    //            new Product {Name = "Hammer", Price = 121.50m, CategoryId = 13},
    //            new Product {Name = "Vinkelsliper", Price = 1520.00m, CategoryId = 13},
    //            new Product {Name = "Melk", Price = 14.50m, CategoryId = 12},
    //            new Product {Name = "Kjøttkaker", Price = 32.00m, CategoryId = 12},
    //            new Product {Name = "Brød", Price = 25.50m, CategoryId = 12}
    //        };
    //        var controller = new ProductController(repository.Object);
    //        //// Act
    //        var result = (ViewResult) controller.Index();
    //        // Assert
    //        Assert.IsNotNull(2, "View Result is null");
    //    }
    //}

    //[TestClass]
    //public class ProductControllerTestCreate
    //{
    //    private Mock<IProductRepository> repository;

    //    [TestMethod]
    //    public void CreateReturnNotNullResult()
    //    {
    //        ApplicationDbContext db;
    //        repository = new Mock<IProductRepository>();
    //        List<Product> fakeproducts = new List<Product>
    //        {
    //            new Product {Name = "Hammer", Price = 121.50m, CategoryId = 13},
    //            new Product {Name = "Vinkelsliper", Price = 1520.00m, CategoryId = 13},
    //            new Product {Name = "Melk", Price = 14.50m, CategoryId = 12},
    //            new Product {Name = "Kjøttkaker", Price = 32.00m, CategoryId = 12},
    //            new Product {Name = "Brød", Price = 25.50m, CategoryId = 12}
    //        };
    //        var controller = new ProductController(repository.Object);

    //        var result = (ViewResult) controller.Create();
    //        Assert.IsNotNull(result, "View Resualt is null");

    //    }

        //[TestClass]
        //public class ReturnToIndexWhenNull
        //{
        //    Mock<IProductRepository> _repository; 
        //    List<Product> fakeproducts; 
        //    List<Category> fakecategories;
        //    private Mock<IProductRepository> repoMock;

            //[TestMethod]
            //public void CreateNullIndex()
            //{
            //    var expectedViewName = "Create";
            //    repoMock = new Mock<IProductRepository>();
            //    List<Product> fakeproducts = new List<Product>
            //    {
            //        new Product {Name = "", Price = 121.50m, CategoryId = 13},
            //        new Product {Name = "", Price = 1520.00m, CategoryId = 13},
            //        new Product {Name = "", Price = 14.50m, CategoryId = 12},
            //        new Product {Name = "", Price = 32.00m, CategoryId = 12},
            //        new Product {Name = "", Price = 25.50m, CategoryId = 12}
            //    };
            //    var controller = new ProductController(repoMock.Object);
            //    var badModel = new ProductsEditViewModel() {Name = "", Description = ""};
            //    var validationContext = new ValidationContext(badModel, null, null);
            //    var validationResults = new List<ValidationResult>();
            //    Validator.TryValidateObject(badModel, validationContext, validationResults, true);
            //    foreach (var validationResult in validationResults)
            //    {
            //        controller.ModelState.AddModelError(validationResult.MemberNames.First(),
            //            validationResult.ErrorMessage);
            //    }


            //    var result = controller.Create(badModel) as ViewResult;

            //    Assert.IsNotNull(result);
            //    //Fikk den ikke til å returnere noe annet en Null, usikker på hvorfor.
            //    Assert.AreEqual(null, result.ViewName);

            //}

        //}


        //[TestMethod]
        //public void CreateRedirectActionRedirectsToIndexAction()
        //{
        //    //Kode KC - Tatt fra canvas, Testing ved bruk av Temp data.
        //    //Arrange            
        //    var mockRepo = new Mock<IProductRepository>();
        //    var controller = new ProductController(mockRepo.Object);
        //    controller.ControllerContext = MockHelpers.FakeControllerContext(false);

        //    var tempData = new
        //        TempDataDictionary(controller.ControllerContext.HttpContext, Mock.Of<ITempDataProvider>());

        //    controller.TempData = tempData;
        //    var model = new ProductsEditViewModel();
        //    model.Price = 100;
        //    model.Description = "Description of product";

        //    //Act            
        //    var result = controller.Create(model) as RedirectToActionResult;

        //    //Assert            
        //    Assert.IsNotNull(result,
        //        "RedirectToIndex needs to redirect to the Index action");

        //    Assert.AreEqual("Index", result.ActionName as String);



//        //}
//    }
//}