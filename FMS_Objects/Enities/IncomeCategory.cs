using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FMS_Objects.Enities
{
    public class IncomeCategory
    {
        [Key]
        public int IncomeCategoryId { get; set; }

        [Required (ErrorMessage = "Category Title field is required")]
        [Display (Name = "Category Title")]
        public string IncomeCategoryTitle { get; set; }

        [Required(ErrorMessage = "Category Description field is required")]
        [Display(Name = "Category Description")]
        [DataType(DataType.MultilineText)]
        public string IncomeCategoryDescription { get; set; }

        public int RestaurantId { get; set; }
        public virtual Restaurant RestaurantVirtual { get; set; }

        
    }
}