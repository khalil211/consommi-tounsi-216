using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsommiTounsi.Models.Forum
{
    public class PostLike
    {
        public long id { get; set; }
        public bool liked { get; set; }
        public User.User user { get; set; }
    }
}