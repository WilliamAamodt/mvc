using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mvc.Models.Entites;
using mvc.Data;

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
            IEnumerable<Product> products = db.Products;
            return db.Products;
        }

        public void Save(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
