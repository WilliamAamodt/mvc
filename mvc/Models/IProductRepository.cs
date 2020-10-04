using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using mvc.Models.Entites;
using mvc.Models.ViewModels;

namespace mvc.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        void Save(ProductsEditViewModel product);
        Task Save(ProductsEditViewModel product, IPrincipal principal);
        void Save(Product product);
        void Update(Product product);
        ProductsEditViewModel GetProductEditViewModel(int? id);

        ProductsEditViewModel GetProductEditViewModel();
        Task Remove(Product p);

        Product Get(int? id);

    }
}
