using System.ComponentModel.DataAnnotations;

namespace FMS_Objects.Entities.Staff
{
    public class Bank
    {
        public int BankId { get; set; }
        [Required(ErrorMessage="Bank name is required")]
        public string BankName { get; set; }
    }
}
