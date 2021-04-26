using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsommiTounsi.Models.Forum
{
    public class Topic
    {
        public long id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(100, ErrorMessage = "You cannot exceed 100 characters")]
        public string title { get; set; }
        [DataType(DataType.MultilineText)]
        [StringLength(200, ErrorMessage = "You cannot exceed 200 characters")]
        public string description { get; set; }
        public DateTime date { get; set; }
        public User.User user { get; set; }
        public List<Post> posts { get; set; }
        public List<Star> stars { get; set; }
    }
}