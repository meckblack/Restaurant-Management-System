using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FMS_Objects.Enities
{
    public class Role
    {
        public string RoleName { get; set; }
        public bool MangeStaff { get; set; }
        public bool MangeFood { get; set; }
        public bool MangeRestaurant { get; set; }
    }
}