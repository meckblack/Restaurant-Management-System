
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FMS_Objects.Enities
{
    public class ExpenseCategory
    {
        [Key]
        public int ExpenseCategoryId { get; set; }

        [Required(ErrorMessage = "Title field required")]
        [Display(Name = "Title")]
        public string ExpenseCategoryTitle { get; set; }

        [Required(ErrorMessage = "Description field required")]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string ExpenseCategoryDescription { get; set; }
        public int RestaurantId { get; set; }
        public virtual Restaurant RestaurantVirtual { get; set; }
    }
}