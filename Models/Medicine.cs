using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuadClinicWebApplication2022.Models
{
    public partial class Medicine
    {
        public Medicine()
        {
            MedicinePrescription = new HashSet<MedicinePrescription>();
        }

        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public string GenericName { get; set; }
        public string CompanyName { get; set; }
        public string MedicinePrice { get; set; }
        public bool? MedicineIsActive { get; set; }

        public virtual ICollection<MedicinePrescription> MedicinePrescription { get; set; }
    }
}
