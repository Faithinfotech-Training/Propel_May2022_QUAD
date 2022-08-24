using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuadClinicWebApplication2022.Models
{
    public partial class LabTestReport
    {
        public int LabTestReport1 { get; set; }
        public int? LabTestPrescId { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public string LowRange { get; set; }
        public string HighRange { get; set; }
        public string LabTestReportRemarks { get; set; }
        public string LabTestReportPrice { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual LabTestPrescription LabTestPresc { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
