using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mvc.Models.Entites;

namespace mvc.Models.ViewModels
{
    public class ProductsEditViewModel
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int ManufacturerId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<Category> Categories { get; set; }
        public List<Manufacturer> Manufacturers { get; set; }
        
    }
}
