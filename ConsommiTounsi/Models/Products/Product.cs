using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsommiTounsi.Models.Products
{
    public class Product
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "creationDate")]
        public DateTime CreationDate { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "price")]
        public double Price { get; set; }
        [JsonProperty(PropertyName = "picture")]
        public string Picture { get; set; }
        public List<Tax> Taxes { get; set; }
        public Discount Discount { get; set; }
        [JsonProperty(PropertyName = "category")]
        public Category Category { get; set; }
        public List<AdvertisementProduct> AdvertisementProducts { get; set; }

        public User.User user { get; set; }
        public List<Comment> comments { get; set; }
        public List<ProductRating> ratings { get; set; }

    }
}
