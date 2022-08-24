using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuadClinicWebApplication2022.Models
{
    public partial class LabTest
    {
        public LabTest()
        {
            LabTestPrescription = new HashSet<LabTestPrescription>();
        }

        public int LabTestId { get; set; }
        public string LabTestCode { get; set; }
        public string LabTestName { get; set; }
        public string LabTestPrice { get; set; }
        public bool? LabTestIsActive { get; set; }

        public virtual ICollection<LabTestPrescription> LabTestPrescription { get; set; }
    }
}
