using System;

namespace ConsommiTounsi.Service.Models.Products
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