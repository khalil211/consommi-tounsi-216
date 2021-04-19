using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsommiTounsi.Models.User
{
    public class PasswordEdit
    {
        [Display(Name = "Old password")]
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "It must be between 5 and 50 characters", MinimumLength = 5)]
        public string oldPassword { get; set; }

        [Display(Name = "New password")]
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "It must be between 5 and 50 characters", MinimumLength = 5)]
        public string newPassword { get; set; }
    }
}