using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuadClinicWebApplication2022.Models;
using QuadClinicWebApplication2022.Repository;

namespace QuadClinicWebApplication2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IReceptionistRepository _repository;

        public AppointmentsController(IReceptionistRepository context)
        {
            _repository = context;
        }

        #region Get all Appointment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAllAppointment()
        {
            return await _repository.GetAllAppointment();
        }
        #endregion

        #region Create new Appointment
        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointmentRecord([FromBody] Appointment appointment)
        {
            //insert a record and return as an object named employee
            if (ModelState.IsValid)
            {
                var newAppointment = await _repository.PostAppointmentRecord(appointment);

                if (newAppointment != null)
                {
                    return newAppointment;
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest();

        }
        #endregion

        #region Edit/Update
        [HttpPut]
        public async Task<ActionResult<Appointment>> PutAppointment(Appointment appointment)
        {
            //update a record and return
            if (ModelState.IsValid)
            {
                var newAppointmentId = await _repository.PutAppointment(appointment);

                if (newAppointmentId != null)
                {
                    return newAppointmentId;
                }
                else
                {
                    return NotFound();
                }
            }
            return appointment;
        }
        #endregion

        //// GET: api/Appointments
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointment()
        //{
        //    return await _context.Appointment.ToListAsync();
        //}

        //// GET: api/Appointments/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Appointment>> GetAppointment(int id)
        //{
        //    var appointment = await _context.Appointment.FindAsync(id);

        //    if (appointment == null)
        //    {
        //        return NotFound();
        //    }

        //    return appointment;
        //}

        //// PUT: api/Appointments/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAppointment(int id, Appointment appointment)
        //{
        //    if (id != appointment.AppointmentId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(appointment).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AppointmentExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Appointments
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        //{
        //    _context.Appointment.Add(appointment);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAppointment", new { id = appointment.AppointmentId }, appointment);
        //}

        //// DELETE: api/Appointments/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Appointment>> DeleteAppointment(int id)
        //{
        //    var appointment = await _context.Appointment.FindAsync(id);
        //    if (appointment == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Appointment.Remove(appointment);
        //    await _context.SaveChangesAsync();

        //    return appointment;
        //}

        //private bool AppointmentExists(int id)
        //{
        //    return _context.Appointment.Any(e => e.AppointmentId == id);
        //}
    }
}
