﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsommiTounsi.Service.Models.Products;

namespace ConsommiTounsi.Service.Models.Payment
{
    public class Item
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
