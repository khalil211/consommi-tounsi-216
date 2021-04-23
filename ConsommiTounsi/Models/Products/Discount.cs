using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsommiTounsi.Models.Products
{
    public class Discount
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Discount StartsAt { get; set; }
        public Discount EndsAt { get; set; }
        public double DiscountValue { get; set; }
        public ValueNature DiscountType { get; set; }
    }
}
