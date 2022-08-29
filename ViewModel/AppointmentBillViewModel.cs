using System;

namespace QuadClinicWebApplication2022.ViewModel
{
    public class AppointmentBillViewModel
    {
        public string PatientName { get; set; }
        public string PatientRegId { get; set; }
        public DateTime? PatientDob { get; set; }
        public DateTime? AppointmentBillDate { get; set; }
        public int AppointmentBillId { get; set; }
        public string StaffFullname { get; set; }
        public string ConsultationFees { get; set; }
    }
}
