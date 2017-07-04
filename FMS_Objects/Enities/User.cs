using System;
using System.ComponentModel.DataAnnotations;
using FMS_Objects.Enums;


namespace FMS_Objects.Enities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "First Name field is required")]
        [Display(Name = "First Name")]
        public string UserFirstName { get; set; }

        [Required(ErrorMessage = "Last Name field is required")]
        [Display(Name = "Last Name")]
        public string UserLastName { get; set; }

        [Required(ErrorMessage = "Middle Name field is required")]
        [Display(Name = "Middle Name")]
        public string UserMiddleName { get; set; }

        [Required(ErrorMessage = "Email Address field is required")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = " Address field is required")]
        [Display(Name = "Address")]
        public string UserAddress { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = " Gender field is required")]
        public Gender UserGender { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime UserDateOfBirth { get; set; }
        public int RestaurantId { get; set; }
        public virtual Restaurant RestaurantVirtual { get; set; }

    }

 
}