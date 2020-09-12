using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using mvc.Models.Entites;
using mvc.Data;
using mvc.Models.ViewModels;

//using mvc.Data;

namespace mvc.Models.Entites
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext db;
        public ProductRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Product> GetAll()
        {
            IEnumerable<Product> products = db.Products.Include("Category").Include("Manufacturer");
            return products;
        }

        public void Save(ProductsEditViewModel product)
        {
            var p = db.Products;
            p.AddRange(
                new Product
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    CategoryId = product.CategoryId,
                    ManufacturerId = product.ManufacturerId
                });
            db.SaveChanges();
        }

        public ProductsEditViewModel GetProductEditViewModel(int id)
        {
            var p = (from o in db.Products
                    .Include("Category")
                     where o.ProductId == id
                     select new ProductsEditViewModel()
                     {
                         ProductId = o.ProductId,
                         CategoryId = o.CategoryId,
                         ManufacturerId = o.ManufacturerId,
                         Name = o.Name,
                         Description = o.Description,
                         Price = o.Price,
                     }).FirstOrDefault();
            p.Categories = GetAllCategories().ToList();
            p.Manufacturers = GetAllManufacturers().ToList();
            return p;
        }

        public ProductsEditViewModel GetProductEditViewModel()
        {
            var p = (from o in db.Products
                    .Include("Category")
                select new ProductsEditViewModel()
                {
                    ProductId = o.ProductId,
                    CategoryId = o.CategoryId,
                    ManufacturerId = o.ManufacturerId,
                    Name = o.Name,
                    Description = o.Description,
                    Price = o.Price,
                }).FirstOrDefault();
            p.Categories = GetAllCategories().ToList();
            p.Manufacturers = GetAllManufacturers().ToList();
            return p;
        }

        private IEnumerable<Manufacturer> GetAllManufacturers()
        {
            IEnumerable<Manufacturer> manufacturers = db.Manufacturers;
            return db.Manufacturers;
        }

        private IEnumerable<Category> GetAllCategories()
        {
            IEnumerable<Category> categories = db.Categories;
            return db.Categories;
        }
    }
}
