using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS_Objects.Entities.SystemManagement
{
    public class Gender
    {
        [Key]
        public int GenderId { get; set; }

        [Required(ErrorMessage="Gender name is required")]
        public string GenderName { get; set; }
    }
}
