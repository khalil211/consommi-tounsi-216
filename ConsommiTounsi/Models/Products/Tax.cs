using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsommiTounsi.Data.Models.Products
{
    public class Tax
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public double TaxValue { get; set; }
        public ValueNature TaxType { get; set; }
    }
}
