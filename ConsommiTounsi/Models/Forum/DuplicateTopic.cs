using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsommiTounsi.Models.Forum
{
    public class DuplicateTopic
    {
        public long id { get; set; }
        public List<Topic> originals { get; set; }
        public Topic duplicate { get; set; }
    }
}