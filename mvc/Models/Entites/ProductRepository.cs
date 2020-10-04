using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using mvc.Models.Entites;
using mvc.Data;
using mvc.Models.ViewModels;

//using mvc.Data;

namespace mvc.Models.Entites
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext db;
        private UserManager<IdentityUser> manager;
        public ProductRepository(UserManager<IdentityUser> userManager , ApplicationDbContext db)
        {
            this.db = db;
            this.manager = userManager;
        }
        public IEnumerable<Product> GetAll()
        {
            IEnumerable<Product> products = db.Products.Include("Category").Include("Manufacturer");
            return products;
        }

        public void Save(ProductsEditViewModel product)
        {
            throw new NotImplementedException();
        }
        public Product Get(int? id)
        {
            Product p = (from o in db.Products
                //                            .Include("Category")
                //                            .Include("Manufacturer")
                where o.ProductId == id
                select o).FirstOrDefault();
            return p;
        }

        [Authorize]
        public async Task Save(ProductsEditViewModel product, IPrincipal principal)
        {
            var currentUser = await manager.FindByNameAsync(principal.Identity.Name);

            var p = db.Products;
            
            p.AddRange(
                new Product
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    CategoryId = product.CategoryId,
                    ManufacturerId = product.ManufacturerId,
                    Owner =  currentUser

                });
            db.SaveChanges();
        }

        public void Save(Product product)
        {
            throw new NotImplementedException();
        }

        public ProductsEditViewModel GetProductEditViewModel(int? id)
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

        public async Task Remove(Product p)
        {
            db.Products.Remove(p);
            await db.SaveChangesAsync();
        }

        public void Update(Product product)
        {
            db.Products.Update(product);
            db.SaveChanges();
        }
    }
}
