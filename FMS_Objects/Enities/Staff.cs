using System;
using System.ComponentModel.DataAnnotations;
using FMS_Objects.Enums;

namespace FMS_Objects.Enities
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }

        [Required (ErrorMessage = "First Name field is required")]
        [Display (Name = "First Name")]
        public string StaffFirstName { get; set; }

        [Required(ErrorMessage = "Last Name field is required")]
        [Display(Name = "Last Name")]
        public string StaffLastName { get; set; }

        [Required(ErrorMessage = "Middle Name field is required")]
        [Display(Name = "Middle Name")]
        public string StaffMiddleName { get; set; }

        [Required(ErrorMessage = "Email Address field is required")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string StaffEmail { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = " Gender field is required")]
        public Gender StaffGender { get; set; }

        [Required(ErrorMessage = " Address field is required")]
        [Display(Name = "Address")]
        public string StaffAddress { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Of Employment")]
        [Required(ErrorMessage = "Date Of Employment field is required")]
        public DateTime StaffDateOfEmployment { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date Of Birth field is required")]
        public DateTime StaffDateOfBirth { get; set; }

        [Required(ErrorMessage = "Phone Number field is required")]
        [Display(Name = "Phone Number")]
        public  String StaffPhoneNumber { get; set; }

        [Display(Name = "Account Name")]
        [Required(ErrorMessage = "Account Name field is required")]
        public string StaffAccountName { get; set; }

        [Display(Name = "Account Number")]
        [Required (ErrorMessage = "Account Number field reuired")]
        [StringLength(10, ErrorMessage = "Please enter a valid Account number")]
        public string StaffAccountNumber { get; set; }

        [Display(Name = "Bank Name")]
        [Required(ErrorMessage = "Bank Name field reuired")]
        public Bank StaffBank { get; set; }

        [Display(Name = "Department")]
        [Required(ErrorMessage = "Department field reuired")]
        public Department StaffDepartment { get; set; }
        public int RestaurantId { get; set; }
        public virtual Restaurant RestaurantVirtual { get; set; }

        

    }
}