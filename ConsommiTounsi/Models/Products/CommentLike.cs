using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsommiTounsi.Models.Products
{
    public class CommentLike
    {
        public long id { get; set; }
        public bool liked { get; set; }
        public User.User user { get; set; }
    }
}