using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsommiTounsi.Data.Models.Products
{
    public class AdvertisementProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public long TargetViewCount { get; set; }
        public long FinalViewsCount { get; set; }
        public double Cost { get; set; }
        public string Type { get; set; }
    }
}
