using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        // GET: Details
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound("Bad parameter");
            }
            var product = repository.GetProductEditViewModel(id);

            if (product == null)
            {
                return NotFound("Product not found.");
            }
            return View(product);
        }
        // GET: Product/Create
        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            var product = repository.GetProductEditViewModel();
            return View(product);
        }
        // Post: Product/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create([Bind("ProductId,Name,Description,Price,ManufacturerId,CategoryId")]
            ProductsEditViewModel product)
        {
            
            try
            {
                if(ModelState.IsValid)
                {
                    repository.Save(product, User).Wait();
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

        // GET: Product/Edit
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound("Bad parameter");
            }
            var productEditViewModel = repository.GetProductEditViewModel(id);
            if (productEditViewModel == null)
            {
                return NotFound();
            }
            return View(productEditViewModel);
        }

        // POST: Product/Edit
        [HttpPost]
        [Authorize]
        public ActionResult Edit(int id, [Bind("ProductId,Name,Description,Price,CategoryId,ManufacturerId")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }
            try
            {
                if (ModelState.IsValid)
                {
                    repository.Update(product);
                    TempData["message"] = $"{product.Name} has been updated";
                    return RedirectToAction("Index");
                }
                else return new ChallengeResult();
            }
            catch
            {
                return View(product);
            }
        }
        // GET: Product1/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = repository.GetProductEditViewModel(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = repository.Get(id);
            repository.Remove(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
