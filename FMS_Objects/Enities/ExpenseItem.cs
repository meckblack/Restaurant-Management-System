using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FMS_Objects.Enities
{
    public class ExpenseItem
    {
        [Key]
        public int ExpenseItemId { get; set; }

        [Required(ErrorMessage = "Title field required")]
        [Display(Name = "Title")]
        public string ExpenseItemTitle { get; set; }

        [Required(ErrorMessage = "Price field requried")]
        [Display(Name = "Price(N)")]
        public decimal ExpenseItemPrice { get; set; }

        [Required(ErrorMessage = "Quantity field required")]
        [Display(Name = "Quantity")]
        public string ExpenseItemQuantity { get; set; }
        public int ExpenseCategoryId { get; set; }
        public virtual ExpenseCategory ExpenseCategoryVirtual { get; set; }
    }
}