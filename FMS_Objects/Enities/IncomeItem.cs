using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FMS_Objects.Enities
{
    public class IncomeItem
    {
        [Key]
        public int IncomeItemId { get; set; }

        [Required (ErrorMessage = "Title field required")]
        [Display(Name = "Title")]
        public string IncomeItemTitle { get; set; }
        
        [Required (ErrorMessage = "Price field requried")]
        [Display(Name = "Price(N)")]
        public decimal IncomeItemPrice { get; set; }

        [Required(ErrorMessage = "Quantity field required")]
        [Display(Name = "Quantity")]
        public string IncomeItemQuantity { get; set; }
        public int IncomeCategoryId { get; set; }
        public virtual IncomeCategory IncomeCategoryVirtual { get; set; }
    }
}