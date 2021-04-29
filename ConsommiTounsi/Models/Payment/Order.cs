using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsommiTounsi.Models.Payment
{
    public enum OrderStatus
    {
        PENDING,
        CANCELLED,
        CONFIRMED,
        INDELIVERY,
        DELIVERED
    }

    public class Order
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public OrderStatus Status { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}