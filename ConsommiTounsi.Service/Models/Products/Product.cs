﻿using System;
using System.Collections.Generic;

namespace ConsommiTounsi.Service.Models.Products
{
    public class Product
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Picture { get; set; }
        public List<Tax> Taxes { get; set; }
        public Discount Discount { get; set; }
        public Category Category { get; set; }
        public List<AdvertisementProduct> AdvertisementProducts { get; set; }
    }
}