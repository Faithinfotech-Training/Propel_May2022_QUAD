using Microsoft.AspNetCore.Mvc;
using QuadClinicWebApplication2022.Models;
using QuadClinicWebApplication2022.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuadClinicWebApplication2022.Repository
{
    public interface IReceptionistRepository
    {
        // Get all patients
        public Task<ActionResult<IEnumerable<Patient>>> GetPatient();

        //Insert a patient and Return that patient record
        public Task<ActionResult<Patient>> PostPatientRecord(Patient patient);

        //Edit/Update
        public Task<ActionResult<Patient>> PutPatient(Patient patient);

        //Get Active
        public Task<ActionResult<IEnumerable<Patient>>> GetActivePatients();

        //Get InActive
        public Task<ActionResult<IEnumerable<Patient>>> GetInActivePatients();

        //Search Patient by RegId
        public Task<ActionResult<Patient>> GetPatientByRegId(string regId);

        //Search Patient by Name
        public Task<ActionResult<Patient>> GetPatientByName(string name);

        //Search Patient by Contact
        public Task<ActionResult<Patient>> GetPatientByContact(string contact);

        //---------------------------------------Appointment Table-------------------------------------------
        //Get All Appointment
        public Task<ActionResult<IEnumerable<Appointment>>> GetAllAppointment();

        //Insert an appointment and Return a record
        public Task<ActionResult<Appointment>> PostAppointmentRecord(Appointment appointment);

        //Edit/Update
        public Task<ActionResult<Appointment>> PutAppointment(Appointment appointment);

        //--------------------------------------------Appoinments Bills------------------------------
        //Get All AppointmentBill
        public Task<ActionResult<IEnumerable<AppointmentBill>>> GetAllAppointmentBill();

        //Insert an appointmentBill and Return a record
        public Task<ActionResult<AppointmentBill>> PostAppointmentBillRecord(AppointmentBill appointmentBill);

        //Edit/Update
        public Task<ActionResult<AppointmentBill>> PutAppointmentBill(AppointmentBill appointmentBill);

        //----------------view model-------------------------
        public Task<ActionResult<IEnumerable<AppointmentBillViewModel>>> AppointmentBillGenerate();
        //--------------------User---------------
        //Get User by Password
        public Task<ActionResult<User>> GetUserbyPassword(string un, string pwd);
    }
}
