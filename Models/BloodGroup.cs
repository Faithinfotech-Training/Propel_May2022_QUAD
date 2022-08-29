using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuadClinicWebApplication2022.Models
{
    public partial class BloodGroup
    {
        public BloodGroup()
        {
            //Patient = new HashSet<Patient>();
        }

        public int BloodGroupId { get; set; }
        public string BloodGroup1 { get; set; }

        //public virtual ICollection<Patient> Patient { get; set; }
    }
}
