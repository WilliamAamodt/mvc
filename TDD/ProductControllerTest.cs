//using System.Collections;
//using System.Collections.Generic;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using mvc.Controllers;
//using mvc.Models;
//using mvc.Models.Entites;

//namespace ProductUnitTest
//{

//    [TestClass]
//        public class ProductControllerTest
//        {
//            private Mock<IProductRepository> repository;
//            [TestMethod]
//            public void IndexReturnsAllProducts()
//            {
//                // Arrange
//                repository = new Mock<IProductRepository>();
//            List<Product> fakeproducts = new List<Product>{
//                new Product {Name="Hammer", Price=121.50m, Category="Verkt�y"},
//                new Product {Name="Vinkelsliper", Price=1520.00m, Category ="Verkt�y"},
//                new Product {Name="Melk", Price=14.50m, Category ="Dagligvarer"},
//                new Product {Name="Kj�ttkaker", Price=32.00m, Category ="Dagligvarer"},
//                new Product {Name="Br�d", Price=25.50m, Category ="Dagligvarer"}
//            };
//            repository.Setup(x => x.GetAll()).Returns(fakeproducts);
//            var controller = new ProductController(repository.Object);
//                // Act
//                var result = (ViewResult)controller.Index();
//                // Assert
//                CollectionAssert.AllItemsAreInstancesOfType((ICollection)result.ViewData.Model,
//                    typeof(Product));
//                Assert.IsNotNull(result, "View Result is null");
//                var products = result.ViewData.Model as List<Product>;
//                Assert.AreEqual(5, products.Count, "Got wrong number of products");
//            }
//            [TestMethod]
//            public void SaveIsCalledWhenProductIsCreated()
//            {
//                // Arrange
//                repository = new Mock<IProductRepository>();
//                repository.Setup(x => x.Save(It.IsAny<Product>()));
//                var controller = new ProductController(repository.Object);
//                // Act
//                var result = controller.Create(new Product());
//                // Assert
//                repository.VerifyAll();
//                // test p� at save er kalt et bestemt antall ganger
//                 repository.Verify(x => x.Save(It.IsAny<Product>()), Times.Exactly(1));
//            }
//    }

//        [TestClass]
//        public class ProductControllerTest2
//        {
//            private IProductRepository repository;
//                [TestMethod]
//            public void IndexReturnsNotNullResult()
//            {
//                // Arrange
//                repository = new FakeProductRepository();
//                var controller = new ProductController(repository);
//                // Act
//                var result = (ViewResult)controller.Index();
//                // Assert
//                Assert.IsNotNull(result, "View Result is null");
//            }
//        }



//}