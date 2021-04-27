using ConsommiTounsi.Models.Products;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsommiTounsi.Models.Payment
{
    public class Item
    {
        public int Id { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
