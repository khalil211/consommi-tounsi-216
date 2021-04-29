using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsommiTounsi.Models.Evenement
{
    public class Participation
    {
        public int id { get; set; }
        public DateTime participDate { get; set; }
        public Evenement ev { get; set; }
        public User.User user { get; set; }


    }
}