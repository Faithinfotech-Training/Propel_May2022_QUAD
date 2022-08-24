using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuadClinicWebApplication2022.Models
{
    public partial class Specialization
    {
        public Specialization()
        {
            Appointment = new HashSet<Appointment>();
            Doctor = new HashSet<Doctor>();
        }

        public int SpecializationId { get; set; }
        public string SpecializationName { get; set; }

        public virtual ICollection<Appointment> Appointment { get; set; }
        public virtual ICollection<Doctor> Doctor { get; set; }
    }
}
