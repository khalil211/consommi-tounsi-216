using ConsommiTounsi.Models.Payment;
using ConsommiTounsi.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsommiTounsi.Models.ViewModels
{
    public class CheckoutViewModel
    {
        public Cart Cart { get; set; }
        public Payment.Payment Payment { get; set; }
    }
}