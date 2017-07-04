using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FMS_Objects.Enities
{
    public class Sales
    {
        [Key]
        public int SaleId { get; set; }

        [Required(ErrorMessage = "Enter Sale Title")]
        [Display(Name = "Title")]
        public string SaleTitle { get; set; }

        [Required(ErrorMessage = "Enter Sale Amount")]
        [Display(Name = "Amount(N)")]
        public decimal SaleAmount { get; set; }

        [Required(ErrorMessage = "Enter Sale Quantity")]
        [Display(Name = "Quantity")]
        public int SaleQuantity { get; set; }

        public int RestaurantId { get; set; }
        public virtual Restaurant RestaurantVirtual { get; set; }
        public int FoodId { get; set; }
        public virtual Food FoodVirtual { get; set; }

    }
}