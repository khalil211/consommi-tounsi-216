using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsommiTounsi.Models.Evenement
{
    public enum EventType
    {
        [Display(Name = "sport")]
        SPORT,
        [Display(Name = "culture")]
        CULTURE,
        [Display(Name = "meetings")]
        MEETINGS,
        [Display(Name = "buissnes")]
        BUSINESS,
        [Display(Name = "cooking")]
        COOKING,
        [Display(Name = "charity")]
        CHARITY
    }
    public class Evenement
    {

        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string location { get; set; }
        public int number { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Event Date")]
        public DateTime eventDate { get; set; }

        public double sumCollect { get; set; }
        public double maxCollect { get; set; }
        public string picture { get; set; }

        [Display(Name = "Event Type")]
        [Required(ErrorMessage = "Please select an option")]
        public string eventType { get; set; }
        public List<Participation> participation { get; set; }
        public int maxnumber { get; set; }
        public List<Donation> events_donation { get; set; }
    }
}