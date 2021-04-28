using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsommiTounsi.Models.Products
{
    public class ProductRating
    {
        public long id { get; set; }
        public double starRate { get; set; }
        public long visitCount { get; set; }
        public double personalRating { get; set; }
        public double globalRating { get; set; }
        public User.User user { get; set; }



    }
}