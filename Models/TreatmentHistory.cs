using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuadClinicWebApplication2022.Models
{
    public partial class TreatmentHistory
    {
        public int TreatmentHistoryId { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public int? LabTestPrescId { get; set; }
        public int? MedicinePrescId { get; set; }
        public int? AppointmentId { get; set; }
        public string Diagnosis { get; set; }
        public string Note { get; set; }
        public DateTime? TreatmentHistoryCreatedDate { get; set; }

        public virtual Appointment Appointment { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual LabTestPrescription LabTestPresc { get; set; }
        public virtual MedicinePrescription MedicinePresc { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
