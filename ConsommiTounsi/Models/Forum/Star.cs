using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsommiTounsi.Models.Forum
{
    public class Star
    {
        public long id { get; set; }
        public int value { get; set; }
        public User.User user { get; set; }
    }
}