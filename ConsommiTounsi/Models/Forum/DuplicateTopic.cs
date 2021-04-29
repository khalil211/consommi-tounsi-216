using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsommiTounsi.Models.Forum
{
    public class DuplicateTopic
    {
        public long id { get; set; }
        public List<Post> originals { get; set; }
        public Post duplicate { get; set; }
    }
}