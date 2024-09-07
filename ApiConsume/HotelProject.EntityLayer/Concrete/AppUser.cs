using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string AppUserName { get; set; }
        public string AppUserSurname { get; set; }
        public string? AppUserCity { get; set; }
        public string AppUserImageUrl { get; set; }
        public string? AppUserWorkDepartment { get; set; }
        public int WorkLocationID { get; set; }
        public virtual WorkLocation WorkLocation { get; set; }
    }
}
