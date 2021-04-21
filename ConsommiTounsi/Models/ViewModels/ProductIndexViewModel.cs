using ConsommiTounsi.Models.Payment;
using ConsommiTounsi.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsommiTounsi.Models.ViewModels
{
    public class ProductIndexViewModel
    {

        public Cart Cart { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}