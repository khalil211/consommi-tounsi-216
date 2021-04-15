using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsommiTounsi.Models.User
{
    public class Address
    {
        public long id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Recipient name")]
        public string recipientName { get; set; }


        [Required(ErrorMessage = "This field is required")]
        public string street { get; set; }


        [Required(ErrorMessage = "This field is required")]
        public string city { get; set; }


        [Required(ErrorMessage = "This field is required")]
        public string governorate { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [RegularExpression("[0-9]+", ErrorMessage = "Pleade enter a valid postcode")]
        [Display(Name = "Postcode")]
        public string postCode { get; set; }
    }
}