using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsommiTounsi.Models.User
{
    public enum UserType
    {
        CUSTOMER,
        ADMIN,
        DELIVERER
    }

    public enum Gender
    {
        MALE,
        FEMALE,
        OTHER
    }

    public enum CivilState
    {
        MARRIED,
        DIVORCED,
        SINGLE
    }

    public enum Occupation
    {
        [Display(Name = "Artist")]
        ARTIST,
        [Display(Name = "Government job")]
        GOVERNMENT_JOBS,
        [Display(Name = "Business man")]
        BUSINESS_MAN,
        [Display(Name = "Social worker")]
        SOCIAL_WORKER,
        [Display(Name = "Student")]
        STUDENT,
        [Display(Name = "Retired")]
        RETIRED
    }

    public class User
    {
        public int id { get; set; }
        [Display(Name ="First Name")]
        [Required(ErrorMessage = "This field is required")]
        [StringLength(21, ErrorMessage = "It must be between 2 and 21 characters", MinimumLength = 2)]
        public string firstName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Last Name")]
        [StringLength(21, ErrorMessage = "It must be between 2 and 21 characters", MinimumLength = 2)]
        public string lastName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(21, ErrorMessage = "It must be between 2 and 21 characters", MinimumLength = 2)]
        public string username { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address")]
        [Required(ErrorMessage = "This field is required")]
        public string email { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "It must be between 5 and 50 characters", MinimumLength = 5)]
        public string password { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("[0-9]{8}", ErrorMessage = "It must contain 8 numbers")]
        [Display(Name = "Phone Number")]
        public string phoneNumber { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Birth Date")]
        public DateTime birthDate { get; set; }
        [Required(ErrorMessage = "Please select an option")]
        public Gender gender { get; set; }
        [Display(Name = "Civil State")]
        [Required(ErrorMessage = "Please select an option")]
        public CivilState civilState { get; set; }
        [Required(ErrorMessage = "Please select an option")]
        public Occupation occupation { get; set; }
        public UserType type { get; set; }
    }
}