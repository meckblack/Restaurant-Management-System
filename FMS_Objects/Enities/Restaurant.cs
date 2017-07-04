using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FMS_Objects.Enities
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }

        [Display(Name = "Restaurant Name")]
        [Required(ErrorMessage = "Restaurant name required")]
        [StringLength(35, ErrorMessage = "Please enteer a valid Restaurant Name")]
        public string RestaurantName { get; set; }

        [Display(Name = "Acronym")]
        [Required(ErrorMessage = "Restaurant acronym required")]
        public string RestaurantAcronym { get; set; }

        
        [Required (ErrorMessage = "Address field is required")]
        [Display(Name = "Address")]
        public string RestaurantAddress { get; set; }
        
        [Required(ErrorMessage = "LGA field is required")]
        public string LGA { get; set; }

        [Required(ErrorMessage = "Country field is required")]
        public string Country { get; set; }

        [Display(Name="Postal Code")]
        [Required(ErrorMessage = "Postal Code field is required")]
        [StringLength (10, ErrorMessage = "Please enter a valid postal code")]
        public string PostalCode { get; set; }
        public virtual ICollection<Staff> StaffVirtual { get; set; }
        public virtual ICollection<User> UserVirtual { get; set; }
        public virtual ICollection<Food> FoodVirtual { get; set; }
        public virtual ICollection<IncomeCategory> IncomeCategoryVirtual { get; set; }
        public virtual ICollection<ExpenseCategory> ExpenseCategoryVirtual { get; set; }
        public virtual ICollection<Sales> SalesVirtual { get; set; }

    }

}