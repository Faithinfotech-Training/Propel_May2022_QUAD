using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuadClinicWebApplication2022.Models
{
    public partial class Staff
    {
        public Staff()
        {
            Doctor = new HashSet<Doctor>();
            User = new HashSet<User>();
        }

        public int StaffId { get; set; }
        public string StaffFullname { get; set; }
        public string StaffGender { get; set; }
        public DateTime? StaffDob { get; set; }
        public string StaffMobileNumber { get; set; }
        public string StaffDesignation { get; set; }
        public string StaffAddress { get; set; }
        public DateTime? StaffCreatedDate { get; set; }
        public bool? StaffIsActive { get; set; }

        public virtual ICollection<Doctor> Doctor { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
