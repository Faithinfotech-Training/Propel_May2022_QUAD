using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuadClinicWebApplication2022.Models
{
    public partial class Appointment
    {
        public Appointment()
        {
            AppointmentBill = new HashSet<AppointmentBill>();
            LabTestBill = new HashSet<LabTestBill>();
            LabTestPrescription = new HashSet<LabTestPrescription>();
            MedicineBill = new HashSet<MedicineBill>();
            MedicinePrescription = new HashSet<MedicinePrescription>();
            TreatmentHistory = new HashSet<TreatmentHistory>();
        }

        public int AppointmentId { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public int? TokenNumber { get; set; }
        public int? SpecializationId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Specialization Specialization { get; set; }
        public virtual ICollection<AppointmentBill> AppointmentBill { get; set; }
        public virtual ICollection<LabTestBill> LabTestBill { get; set; }
        public virtual ICollection<LabTestPrescription> LabTestPrescription { get; set; }
        public virtual ICollection<MedicineBill> MedicineBill { get; set; }
        public virtual ICollection<MedicinePrescription> MedicinePrescription { get; set; }
        public virtual ICollection<TreatmentHistory> TreatmentHistory { get; set; }
    }
}
