using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsommiTounsi.Models.Forum
{
    public class Post
    {
        public long id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.MultilineText)]
        [StringLength(255, ErrorMessage = "You cannot exceed 255 characters")]
        public string content { get; set; }
        public string medias { get; set; }
        public DateTime date { get; set; }
        public User.User user { get; set; }
        public List<PostLike> likes { get; set; }
    }
}