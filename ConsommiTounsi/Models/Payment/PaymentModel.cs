using ConsommiTounsi.Models.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsommiTounsi.Models.Payment
{
    public class PaymentModel
    {

        [JsonProperty("userId")]
        public int UserId { get; set; }
        [JsonProperty("shippingAddress")]
        public Address ShippingAddress { get; set; }
        [JsonProperty("paymentType")]
        public PaymentType PaymentType { get; set; }
    }
}