using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuadClinicWebApplication2022.Models
{
    public partial class AppointmentBill
    {
        public int AppointmentBillId { get; set; }
        public int? AppointmentId { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public int? ClinicId { get; set; }
        public string AppointmentBillAmount { get; set; }
        public DateTime? AppointmentBillDate { get; set; }

        public virtual Appointment Appointment { get; set; }
        public virtual ClinicInfo Clinic { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
