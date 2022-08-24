using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuadClinicWebApplication2022.Models
{
    public partial class MedicinePrescription
    {
        public MedicinePrescription()
        {
            MedicineBill = new HashSet<MedicineBill>();
            TreatmentHistory = new HashSet<TreatmentHistory>();
        }

        public int MedicinePrescId { get; set; }
        public int? MedicineId { get; set; }
        public int? PatientId { get; set; }
        public int? AppointmentId { get; set; }
        public int? DoctorId { get; set; }
        public string Dosage { get; set; }
        public string NumberOfDays { get; set; }

        public virtual Appointment Appointment { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Medicine Medicine { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual ICollection<MedicineBill> MedicineBill { get; set; }
        public virtual ICollection<TreatmentHistory> TreatmentHistory { get; set; }
    }
}
