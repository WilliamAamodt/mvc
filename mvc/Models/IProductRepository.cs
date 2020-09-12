using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mvc.Models.Entites;
using mvc.Models.ViewModels;

namespace mvc.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        void Save(ProductsEditViewModel product);
        ProductsEditViewModel GetProductEditViewModel(int id);

        ProductsEditViewModel GetProductEditViewModel();
    }
}
