using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsommiTounsi.Models.Payment
{
    public class Purchase
    {
        [JsonProperty("items")]
        public IEnumerable<Item> Items { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}