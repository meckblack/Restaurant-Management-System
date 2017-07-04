using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS_Objects.Enities
{
    class AppUser
    {
        public int AppUserId { get; set; }
        public string AppUserName { get; set; }
        public string AppUserPassword { get; set; }
        public string AppUserConfirmPassword { get; set; }
    }
}
