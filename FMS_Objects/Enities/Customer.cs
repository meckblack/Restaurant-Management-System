using System;
using System.ComponentModel.DataAnnotations;
using FMS_Objects.Enums;

namespace FMS_Objects.Enities
{
    public class Customer
    {
        [Key]
        public int StaffId { get; set; }

        [Required(ErrorMessage = "First Name field is required")]
        [Display(Name = "First Name")]
        public string CustomerFirstName { get; set; }

        [Required(ErrorMessage = "Last Name field is required")]
        [Display(Name = "Last Name")]
        public string CustomerLastName { get; set; }

        [Required(ErrorMessage = "Middle Name field is required")]
        [Display(Name = "Middle Name")]
        public string CustomerMiddleName { get; set; }

        [Required(ErrorMessage = "Email Address field is required")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string CustomerEmail { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = " Gender field is required")]
        public Gender CustomerGender { get; set; }

        [Required(ErrorMessage = " Address field is required")]
        [Display(Name = "Address")]
        public string CustomerStreetAddress { get; set; }

        [Required(ErrorMessage = " City field is required")]
        [Display(Name = "City")]
        public string CustomerCity { get; set; }

        [Required(ErrorMessage = " State field is required")]
        [Display(Name = "State")]
        public State CustomerState { get; set; }

        [Required(ErrorMessage = " Zip/Postal Code field is required")]
        [Display(Name = "Zip/PostalCode")]
        public string CustomerZipCode { get; set; }

        [Required(ErrorMessage = "Phone Number field is required")]
        [Display(Name = "Phone Number")]
        public String CustomerPhoneNumber { get; set; }
    }
}