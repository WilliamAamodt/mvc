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

        public IActionResult Privacy()
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            var product = repository.GetProductEditViewModel();
            return View(product);
        }
        // Post: Product/Create
        [HttpPost]
        public ActionResult Create(ProductsEditViewModel product)
        {
            try
            {
                repository.Save(product);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}
