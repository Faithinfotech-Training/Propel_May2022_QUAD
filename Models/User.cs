using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuadClinicWebApplication2022.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public int? RoleId { get; set; }
        public int? StaffId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual Role Role { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
