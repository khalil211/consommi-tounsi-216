using ConsommiTounsi.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsommiTounsi.Models.Payment
{
    public enum PaymentType
    {
        ONLINE,
        ATDELIVERY
    }

    public class Payment
    {
        public PaymentType PaymentType { get; set; }
        public Address Address { get; set; }
    }
}