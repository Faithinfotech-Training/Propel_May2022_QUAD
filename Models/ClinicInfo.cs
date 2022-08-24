using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuadClinicWebApplication2022.Models
{
    public partial class ClinicInfo
    {
        public ClinicInfo()
        {
            AppointmentBill = new HashSet<AppointmentBill>();
            LabTestBill = new HashSet<LabTestBill>();
        }

        public int ClinicId { get; set; }
        public string RegId { get; set; }
        public string ClinicName { get; set; }

        public virtual ICollection<AppointmentBill> AppointmentBill { get; set; }
        public virtual ICollection<LabTestBill> LabTestBill { get; set; }
    }
}
