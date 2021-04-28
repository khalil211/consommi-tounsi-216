using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsommiTounsi.Models.Products
{
    public class Comment
    {
        public long id { get; set; }
        public string content { get; set; }
        public DateTime date { get; set; }
       
        public User.User user { get; set; }
        public List<CommentLike> likes { get; set; }
    }
}