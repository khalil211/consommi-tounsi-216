using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsommiTounsi.Models.Payment
{
    public class CreatePaymentResponse
    {
        public string PublishableKey { get; set; }
        public string ClientSecret { get; set; }
    }
}