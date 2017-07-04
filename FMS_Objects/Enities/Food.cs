using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FMS_Objects.Enums;

namespace FMS_Objects.Enities
{
    public class Food
    {

        [Key]
        public int FoodId { get; set; }

        [DataType(DataType.ImageUrl)]
        //[Required (ErrorMessage = "Image path required")]
        [Display (Name ="Image")]
        public string FoodImage { get; set; }

        [Required (ErrorMessage = "Food Name required")]
        [Display (Name = "Name")]
        public string FoodName { get; set; }
        

        [Required (ErrorMessage = "Food type required")]
        [Display (Name = "Type")]
        public FoodType FoodType { get; set; }

        [Required (ErrorMessage = "Food price required")]
        [Display(Name = "Price")]
        public decimal FoodPrice { get; set; }

        [Required (ErrorMessage = "Food description required")]
        [DataType (DataType.MultilineText)]
        [Display(Name = "Description")]
        public string  FoodDescription { get; set; }
        public int RestaurantId { get; set; }
        public virtual Restaurant RestaurantVirtual { get; set; }
        public virtual ICollection<Sales> SalesVirtual { get; set; }
    }

  
}