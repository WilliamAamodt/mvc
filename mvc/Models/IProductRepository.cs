using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mvc.Models.Entites;

namespace mvc.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        void Save(Product product);
    }
}
