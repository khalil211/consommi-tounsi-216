using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsommiTounsi.Models.Evenement
{
    public class Donation
    {
        public int id { get; set; }
        public int amount { get; set; }
        public Evenement evenement { get; set; }
        public User.User user { get; set; }


    }
}