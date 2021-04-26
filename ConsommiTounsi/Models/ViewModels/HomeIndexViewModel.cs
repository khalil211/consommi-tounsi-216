using ConsommiTounsi.Models.Payment;
using ConsommiTounsi.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsommiTounsi.Models.ViewModels
{
    public class HomeIndexViewModel
    {
        public Cart Cart { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}