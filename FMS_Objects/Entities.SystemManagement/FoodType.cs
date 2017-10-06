using System.ComponentModel.DataAnnotations;

namespace FMS_Objects.Entities.SystemManagement
{
    public class FoodType
    {
        public int FoodTypeId { get; set; }

        [Required(ErrorMessage="Name is required")]
        public string FoodTypeName { get; set; }
    }
}
