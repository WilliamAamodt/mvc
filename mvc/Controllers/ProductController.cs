using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using mvc.Models;
using mvc.Models.Entites;
using mvc.Models.ViewModels;

namespace mvc.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;

        

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            var product = repository.GetProductEditViewModel();
            return View(product);
        }
        // Post: Product/Create
        [HttpPost]
        public ActionResult Create([Bind("ProductId,Name,Description,Price,ManufacturerId,CategoryId")]
            ProductsEditViewModel product)
        {
            
            try
            {
                if(ModelState.IsValid)
                {
                    repository.Save(product);
                    TempData["message"] = string.Format("{0} har blitt opprettet", product.Name);
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
    }
}
