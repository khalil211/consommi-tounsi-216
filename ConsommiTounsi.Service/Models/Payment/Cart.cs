using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsommiTounsi.Service.Models.Payment
{
    public class Cart
    {
        public int Id { get; set; }
        public int MyProperty { get; set; }
        public List<Item> Items { get; set; }
    }
}
