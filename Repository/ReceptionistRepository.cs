using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuadClinicWebApplication2022.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuadClinicWebApplication2022.ViewModel;

namespace QuadClinicWebApplication2022.Repository
{
    public class ReceptionistRepository : IReceptionistRepository
    {
        private readonly QuadClinicContext _context;

        public ReceptionistRepository(QuadClinicContext context)
        {
            _context = context;
        }

        #region Get all the patients
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatient()
        {
            if (_context != null)
            {
                return await _context.Patient.Include(e => e.BloodGroup).ToListAsync();
            }
            return null;
        }
        #endregion

        #region Insert a patient and Return that patient record
        public async Task<ActionResult<Patient>> PostPatientRecord(Patient patient)
        {
            if (_context != null)
            {
                await _context.Patient.AddAsync(patient);
                await _context.SaveChangesAsync();

                return patient;
            }
            return null;
        }
        #endregion

        #region Edit/Update
        public async Task<ActionResult<Patient>> PutPatient(Patient patient)
        {
            _context.Entry(patient).State = EntityState.Modified;
            //Exception handling
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
            return patient;
        }
        #endregion

        #region Get Active Patients
        public async Task<ActionResult<IEnumerable<Patient>>> GetActivePatients()
        {
            if (_context != null)
            {
                var patient = await _context.Patient.Where(x => x.PatientIsActive == true).ToListAsync();
                return patient;
            }
            return null;
        }
        #endregion

        #region Get InActive Patients
        public async Task<ActionResult<IEnumerable<Patient>>> GetInActivePatients()
        {
            if (_context != null)
            {
                var patient = await _context.Patient.Where(x => x.PatientIsActive == false).ToListAsync();
                return patient;
            }
            return null;
        }
        #endregion

        #region Search Patient by RegId
        public async Task<ActionResult<Patient>> GetPatientByRegId(string regId)
        {
            if (_context != null)
            {
                var patient = await _context.Patient.FirstOrDefaultAsync(e => e.PatientRegId == regId);
                return patient;
            }
            return null;
        }
        #endregion

        #region Search Patient by Name
        public async Task<ActionResult<Patient>> GetPatientByName(string name)
        {
            if (_context != null)
            {
                var patient = await _context.Patient.FirstOrDefaultAsync(e => e.PatientName == name);
                return patient;
            }
            return null;
        }
        #endregion

        #region Search Patient by Contact
        public async Task<ActionResult<Patient>> GetPatientByContact(string contact)
        {
            if (_context != null)
            {
                var patient = await _context.Patient.FirstOrDefaultAsync(e => e.PatientMobileNumber == contact);
                return patient;
            }
            return null;
        }
        #endregion

        //--------------------------Appointment---------------------------------
        #region Get All Appoinment
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAllAppointment()
        {
            if (_context != null)
            {
                return await _context.Appointment.ToListAsync();
            }
            return null;
        }
        #endregion

        #region Insert an appointment and Return a record
        public async Task<ActionResult<Appointment>> PostAppointmentRecord(Appointment appointment)
        {
            if (_context != null)
            {
                await _context.Appointment.AddAsync(appointment);
                await _context.SaveChangesAsync();

                return appointment;
            }
            return null;
        }
        #endregion

        #region Edit/Update
        public async Task<ActionResult<Appointment>> PutAppointment(Appointment appointment)
        {
            _context.Entry(appointment).State = EntityState.Modified;
            //Exception handling
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
            return appointment;
        }
        #endregion

        //-------------------------AppointmentBill-------------------------------
        #region Get All AppoinmentBill
        public async Task<ActionResult<IEnumerable<AppointmentBill>>> GetAllAppointmentBill()
        {
            if (_context != null)
            {
                return await _context.AppointmentBill.ToListAsync();
            }
            return null;
        }
        #endregion

        #region Insert an appointmentBill and Return a record
        public async Task<ActionResult<AppointmentBill>> PostAppointmentBillRecord(AppointmentBill appointmentBill)
        {
            if (_context != null)
            {
                await _context.AppointmentBill.AddAsync(appointmentBill);
                await _context.SaveChangesAsync();

                return appointmentBill;
            }
            return null;
        }
        #endregion

        #region Edit/Update
        public async Task<ActionResult<AppointmentBill>> PutAppointmentBill(AppointmentBill appointmentBill)
        {
            _context.Entry(appointmentBill).State = EntityState.Modified;
            //Exception handling
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
            return appointmentBill;
        }
        #endregion

        //-----------------------View Model---------------------------------------
        #region Generate Appointment Bill
        public async Task<ActionResult<IEnumerable<AppointmentBillViewModel>>> AppointmentBillGenerate()
        {
            if (_context != null)
            {
                //LINQ
                return await (from p in _context.Patient
                              from a in _context.AppointmentBill
                              from s in _context.Staff
                              from d in _context.Doctor
                              where p.PatientId == a.PatientId && s.StaffId == d.StaffId && d.DoctorId == a.DoctorId
                              select new AppointmentBillViewModel
                              {
                                  PatientName = p.PatientName,
                                  PatientRegId = p.PatientRegId,
                                  PatientDob = p.PatientDob,
                                  AppointmentBillDate = a.AppointmentBillDate,
                                  AppointmentBillId = a.AppointmentBillId,
                                  StaffFullname = s.StaffFullname,
                                  ConsultationFees = d.ConsultationFees
                              }).ToListAsync();
            }
            return null;
        }
        #endregion
        //-----------------------------User----------------------------

        #region Get Username Password
        public async Task<ActionResult<User>> GetUserbyPassword(string un, string pwd)
        {
            if (_context != null)
            {
                if (CaseUsernameAndPassword(un, pwd))
                {
                    //cHECKING uSERNAME AND Password
                    User user = await _context.User.FirstOrDefaultAsync(up => up.UserName.Contains(un) && up.Password.Contains(pwd));
                    return user;
                }
            }
            return null;
        }
        #endregion

        #region Check Case-sensitive

        private bool CaseUsernameAndPassword(string un, string pwd)
        {
            //Load into memory --array
            var users = _context.User.Where(u => u.UserName == un).ToArray();

            //Compare IN 
            if (users.Any(u => u.UserName == un && u.Password == pwd))
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
